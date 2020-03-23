using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Minecraft_Server_Manager
{
    /// <summary>
    /// This class acts as a "wrapper" for every other settings class. It manages saving and generating config files.
    /// </summary>
    public class Settings
    {
        public ServerSettings ServerSettings { get; set; }
        public RemoteConfig RemoteConfig { get; set; }
        public GeneralSettings GeneralSettings { get; set; }

        public Settings()
        {
            ServerSettings = new ServerSettings();
            RemoteConfig = new RemoteConfig();
            GeneralSettings = new GeneralSettings();
        }

        public void Save()
        {
            GenMinecraftProperties();
        }

        private void GenMinecraftProperties()
        {
            MineServerConfig t = new MineServerConfig();
            t.Session = new Dictionary<string, object>(); //Create The Dictionary for the "parameters" to use in the T4 template
            t.Session.Add("Settings", this); // "Pass" the settings
            t.Initialize();
            string resultText = t.TransformText();
            System.IO.File.WriteAllText("server.properties", resultText); //overrides if exists
        }
    }

    public class ServerSettings
    {
        public string Version { get; set; }
        public string MOTD { get; set; }
        public bool AllowOnlyPremium { get; set; }
        public bool ModsEnabled { get; set; }
        public bool PvPAllowed { get; set; }
        public int ServerPort { get; set; }
    }

    public class RemoteConfig
    {
        public bool Enabled { get; set; }
        public int Port { get; set; }
    }

    public class GeneralSettings
    {
        public bool EnableMods { get; set; }
    }
}