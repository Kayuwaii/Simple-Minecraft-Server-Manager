using Ionic.Zip;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;

namespace Simple_Minecraft_Server_Manager
{
    public partial class MainForm : MetroForm
    {
        public Settings _settings;

        public MainForm()
        {
            InitializeComponent();
            LoadJson();
            metroLabel1.Text = _settings.ServerSettings.MOTD;
            UnpackServer();
        }

        public void LoadJson()
        {
            string settingsPath = @"./Settings.json";
            if (File.Exists(settingsPath))
            {
                using (StreamReader r = new StreamReader(settingsPath))
                {
                    try
                    {
                        string json = r.ReadToEnd();
                        _settings = JsonConvert.DeserializeObject<Settings>(json);
                    }
                    catch (Exception ex) //Any Exception, we don't wanna risk any error in this stage.
                    {
                        Engine.Base.General.ErrorMessageBox("Error while loading Your settings. \n" +
                            "If you made changes to the settings file, undo them. \n" +
                            "If that doesn't fix the issue, delete the file and restart this program to generate a new one.",
                            "ERROR READING SETTINGS");
                        _settings = new Settings();
                    }
                }
            }
            else _settings = new Settings();
        }

        public void UnpackServer()
        {
            ExtractCompressedServerFromAssembly();
            UnzipAndDelete();
        }

        public void ExtractCompressedServerFromAssembly()
        {
            var temp = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Stream stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(@"Simple_Minecraft_Server_Manager.Resources.server.zip");
            FileStream fileStream = new FileStream("server.zip", FileMode.Create);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }

        private void UnzipAndDelete()
        {
            string zipToUnpack = "server.zip";
            string unpackDirectory = "Minecraft";
            using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.
                foreach (ZipEntry e in zip1)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            File.Delete("server.zip");
            MessageBox.Show("Everything Ready");
        }
    }
}