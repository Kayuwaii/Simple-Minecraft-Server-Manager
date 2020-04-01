using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            SaveJson();
        }

        private void SaveJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this);
                File.WriteAllText("settings.json", json);
            }
            catch (Exception ex) //Any Exception, we don't wanna risk any error in this stage.
            {
                Engine.Base.General.ErrorMessageBox("Error while saving your settings. \n" +
                    "Minecraft Settings should be properly generated. \n" +
                    "Try saving again or restart the program.",
                    "ERROR WRITING SETTINGS");
            }
        }

        private void GenMinecraftProperties()
        {
            MineServerConfig t = new MineServerConfig();
            t.Session = new Dictionary<string, object>(); //Create The Dictionary for the "parameters" to use in the T4 template
            t.Session.Add("Settings", this); // "Pass" the settings
            t.Initialize();
            string resultText = t.TransformText();
            File.WriteAllText("Minecraft/server.properties", resultText); //overrides if exists
        }
    }

    public class ServerSettings
    {
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