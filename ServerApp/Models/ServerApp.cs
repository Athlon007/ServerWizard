namespace ServerWizard.Models
{
    internal class ServerApp
    {
        public string Name { get; set; }
        
        /// <summary>
        /// eg: /home/athlon/servers/minecraft
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// eg: start.sh
        /// </summary>
        public string StartCommand { get; set; }       
    }
}
