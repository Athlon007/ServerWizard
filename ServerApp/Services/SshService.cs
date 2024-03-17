using Renci.SshNet;
using ServerWizard.Models;
using System.Text.RegularExpressions;

namespace ServerWizard.Services
{
    internal class SshService: IDisposable
    {
        private Config config;
        private SshClient sshClient;

        private bool connected;

        public SshService(Config config)
        {
            this.config = config;
            this.sshClient = new SshClient(config.IpAddress, config.Username, config.Password);
        }

        private string ExecuteCommand(string command)
        {
            var cmd = sshClient.CreateCommand(command);
            var result = cmd.Execute();

            return result.Trim();
        }

        private string ExecuteCommandAsAdmin(string command)
        {
            var promptRegex = new Regex(@"\][#$>]"); // regular expression for matching terminal prompt
            var modes = new Dictionary<Renci.SshNet.Common.TerminalModes, uint>();
            var stream = sshClient.CreateShellStream("xterm", 255, 50, 800, 600, 1024, modes);
            
            stream.Write("sudo " + command + "\n");
            stream.Expect("password");
            stream.Write(config.Password + "\n");
            var output = stream.Expect(promptRegex);

            stream.Close();

            return output;
        }

        public bool IsAlive()
        {
            try
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                if (!sshClient.IsConnected)
                {
                    Console.WriteLine("Unable to connect.");
                    return false;
                }

                // Try doing 'echo ping' and see if it returns 'ping'.
                var result = this.ExecuteCommand("echo ping");
                if (result != "ping")
                {
                    Console.WriteLine("Server is not responding. Response: " + result);
                }

                connected = true;
                return true;
            } catch
            {
                // Was connected?
                if (connected)
                {
                    sshClient.Dispose();
                }

                return false;
            }
        }

        public void PowerOff()
        {
            ExecuteCommandAsAdmin("poweroff");
            sshClient.Dispose();
            connected = false;
        }

        public bool IsAppAlive(ServerApp app)
        {
            string output = ExecuteCommand("test -f " + app.Location + "/.lock && echo true");
            return output == "true";
        }

        public void RunApp(ServerApp app)
        {
            ExecuteCommand($"cd \"{app.Location}\" && {app.StartCommand}");
        }

        public void KillApp(ServerApp app)
        {
            string pid = ExecuteCommand($"cat \"{app.Location}/.lock\"");
            ExecuteCommand($"kill {pid}");
        }

        public ServerInfo GetServerInfo()
        {
            var output = new ServerInfo();

            string info = ExecuteCommand("top -bn 1 | egrep 'Cpu|Mem|Swap'");
            string[] infos = info.Split('\n');

            string cpuString = infos[0].Split(':')[1];
            cpuString = (cpuString.Split(',')[0] + ',' + cpuString.Split(',')[1].Replace("us", "")).Trim();
            output.CpuUsage = Convert.ToDouble(cpuString);

            string memString = infos[1].Split(':')[1];
            string memStringTotal = (memString.Split(',')[0] + ',' + memString.Split(',')[1].Replace("total", "")).Trim();
            string memStringUsed = (memString.Split(',')[4] + ',' + memString.Split(',')[5].Replace("used", "")).Trim();
            output.TotalMemory = Convert.ToDouble(memStringTotal);
            output.UsedMemory = Convert.ToDouble(memStringUsed);

            string swapString = infos[2].Split(':')[1];
            string swapStringTotal = (swapString.Split(',')[0] + ',' + swapString.Split(',')[1].Replace("total", "")).Trim();
            string swapStringUsed = (swapString.Split(',')[4] + ',' + swapString.Split(',')[5].Replace("used", "")).Split('.')[0].Trim();
            output.TotalSwap = Convert.ToDouble(swapStringTotal);
            output.UsedSwap = Convert.ToDouble(swapStringUsed);

            return output;
        }

        public void Dispose()
        {
            sshClient.Dispose();
        }
    }
}
