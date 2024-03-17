using ServerWizard.Models;
using ServerWizard.Services;
using System.ComponentModel;
using System.Data;

namespace ServerWizard
{
    public partial class Form1 : Form
    {
        private Config config;
        private ConfigService configService;
        private SshService sshService;
        private WolService wolService;

        private bool serverOn;

        private List<Thread> threads;

        public Form1()
        {
            InitializeComponent();

            this.configService = new ConfigService();
            this.config = configService.Load();

            this.sshService = new SshService(config);
            this.wolService = new WolService();
            this.threads = new List<Thread>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckServerStatus();
            InitializeAppServices();
            InitalizeSystemMonitor();
        }

        private void CheckServerStatus()
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (s, args) =>
            {
                // Ping server.
                bool alive = sshService.IsAlive();
                if (alive)
                {
                    serverOn = true;
                    SetLabelStatus("ALIVE", Color.Green);
                }
                else
                {
                    serverOn = false;
                    SetLabelStatus("NOT RESPONDING", Color.Red);
                }

                Thread.Sleep(5000);
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                worker.RunWorkerAsync();
            };

            worker.RunWorkerAsync();
        }

        private void InitializeAppServices()
        {
            // First, let's sort apps by name.
            var apps = config.ServerApps;
            apps = apps.OrderBy(x => x.Name).ToArray();

            foreach (var app in apps)
            {
                ListViewItem item = new ListViewItem();
                item.Text = app.Name;
                item.Tag = app;
                item.SubItems.Add("Checking...");

                lstServices.Items.Add(item);

                var worker = new BackgroundWorker();
                worker.DoWork += (s, args) =>
                {
                    if (!serverOn)
                    {
                        Thread.Sleep(2000);
                        return;
                    }

                    var alive = sshService.IsAppAlive(app);
                    lstServices.Invoke((MethodInvoker)(() =>
                    {
                        item.SubItems[1].Text = alive ? "On" : "Off";
                        item.ForeColor = alive ? Color.Green : Color.Red;
                    }));


                    Thread.Sleep(5000);
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    worker.RunWorkerAsync();
                };

                worker.RunWorkerAsync();
            }

            lstServices.Sort();
        }

        private void InitalizeSystemMonitor()
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (s, args) =>
            {
                if (!serverOn)
                {
                    Thread.Sleep(1000);
                    return;
                }

                var info = sshService.GetServerInfo();

                lblCPU.Invoke((MethodInvoker)(() =>
                {
                    lblCPU.Text = info.CpuUsage.ToString() + "%";
                    lblRam.Text = info.UsedMemory.ToString() + "/" + info.TotalMemory.ToString() + " MB";
                    lblSwap.Text = info.UsedSwap.ToString() + "/" + info.TotalSwap.ToString() + " MB";

                    prbCPU.Value = Convert.ToInt32(info.CpuUsage);
                    prbRam.Maximum = Convert.ToInt32(info.TotalMemory);
                    prbRam.Value = Convert.ToInt32(info.UsedMemory);
                    prbSwap.Maximum = Convert.ToInt32(info.TotalSwap);
                    prbSwap.Value = Convert.ToInt32(info.UsedSwap);                    
                }));
                

                Thread.Sleep(1000);
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                worker.RunWorkerAsync();
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Thread safe setting status label.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        private void SetLabelStatus(string text, Color color)
        {
            try
            {
                lblStatusText.Invoke((MethodInvoker)(() =>
                {
                    lblStatusText.Text = text;
                    lblStatusText.ForeColor = color;
                }));
            }
            catch { }
        }

        private void RunThread(Action action)
        {
            var thread = new Thread(delegate ()
            {
                action();
            });

            thread.Start();
            threads.Add(thread);
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            await wolService.WakeOnLan(config.MacAddress);
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            RunThread(sshService.PowerOff);
        }

        private void lstServices_DoubleClick(object sender, EventArgs e)
        {
            if (!serverOn || lstServices.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = lstServices.SelectedItems[0];
            var selected = selectedItem.Tag as ServerApp;
            var status = selectedItem.SubItems[1].Text;

            if (selected == null)
            {
                return;
            }

            if (status == "Off")
            {
                if (IsAnyOtherAppRunning())
                {
                    MessageBox.Show("Please stop any other server first.");
                    return;
                }

                selectedItem.SubItems[1].Text = "Loading...";

                // Turn the service on.
                RunThread(() =>
                {
                    sshService.RunApp(selected);
                });

                // Unselect
                lstServices.SelectedItems.Clear();
            }
            else if (status == "On")
            {
                selectedItem.SubItems[1].Text = "Shutting down...";

                // Turn the service off.
                lstServices.SelectedItems.Clear();

                RunThread(() =>
                {
                    sshService.KillApp(selected);
                });
            }
            // Else would mean it's still checking - don't care about that.
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sshService.Dispose();
            } catch { }

            // Kill all threads
            foreach (var thread in threads)
            {
                try
                {
                    thread.Abort();
                }
                catch
                {
                }
            }
        }

        public bool IsAnyOtherAppRunning()
        {
            foreach (ListViewItem item in lstServices.Items) 
            {
                if (item.SubItems[1].Text == "On")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
