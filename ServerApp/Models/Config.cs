namespace ServerWizard.Models
{
    internal class Config
    {
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ServerApp[] ServerApps { get; set; }

        public Config()
        {
            this.IpAddress = "";
            this.MacAddress = "";
            this.Username = "";
            this.Password = "";
            this.ServerApps = [];
        }
    }
}
