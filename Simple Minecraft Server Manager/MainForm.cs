using Ionic.Zip;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Engine.Base;
using System.Diagnostics;
using MetroFramework;
using Microsoft.Win32;

namespace Simple_Minecraft_Server_Manager
{
    public partial class MainForm : MetroForm, IDataForm
    {
        public Settings _settings;
        private bool isServerExtracted;
        private string tempZipPath;
        private Thread _thread;
        private LoadingForm _waitForm;
        private Process mcProcess;

        public MainForm()
        {
            InitializeComponent();
            ToolTip.SetToolTip(motdLabel, " The message displayed on the Minecraft server selection screen ");
            LoadData();
            if (!isServerExtracted) UnpackServer();
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
                    finally
                    {
                        r.Close(); ;
                    }
                }
            }
            else _settings = new Settings();
        }

        public void UnpackServer()
        {
            ShowWaitForm("Extracting Files");
            ExtractCompressedServerFromAssembly();
            UnzipAndDelete();
        }

        public void ExtractCompressedServerFromAssembly()
        {
            tempZipPath = Path.GetTempFileName();
            Stream stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(@"Simple_Minecraft_Server_Manager.Resources.server.zip");
            FileStream fileStream = new FileStream(tempZipPath, FileMode.Create);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }

        private void UnzipAndDelete()
        {
            string unpackDirectory = "Minecraft";
            using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(tempZipPath))
            {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.
                foreach (ZipEntry e in zip1)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            File.Delete(tempZipPath);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ShowWaitForm("Saving Your Settings. Wait");
            if (ValidateFields())
            {
                UpdateSettings();
                _settings.Save();
                MetroFramework.MetroMessageBox.Show(this, "You're settings have been saved and applied to the server. \n" +
                   "They will take effect the next time the server starts", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information, 150);
            }
            else MetroFramework.MetroMessageBox.Show(this, "Something is wrong... \n" +
                   "It seems you have incorrect values in your configuration! \n" +
                   "Check your configuration for any empty option or wrong value", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
        }

        private void UpdateSettings()
        {
            _settings.GeneralSettings.EnableMods = modsCheckBox.Checked;
            _settings.ServerSettings.AllowOnlyPremium = premiumCheckBox.Checked;
            _settings.ServerSettings.PvPAllowed = premiumCheckBox.Checked;
            _settings.ServerSettings.MOTD = motdTextBox.Text;
            _settings.ServerSettings.ServerPort = Int32.Parse(portTxTBox.Text);
        }

        protected void ShowWaitForm(string message)
        {
            // don't display more than one wait form at a time
            if (_waitForm != null && !_waitForm.IsDisposed)
            {
                return;
            }
            _thread = new Thread(() =>
            {
                _waitForm = new LoadingForm(message);
                _waitForm.TopMost = true;
                _waitForm.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(_waitForm);
            });
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();

            Application.Idle += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            _waitForm.Invoke((MethodInvoker)delegate { _waitForm.Close(); });
            if (_thread.IsAlive) _thread.Abort();
        }

        public bool ValidateFields()
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(portTxTBox.Text, "[^0-9]") &&
                !String.IsNullOrWhiteSpace(motdTextBox.Text);
        }

        public void LoadData()
        {
            isServerExtracted = Directory.Exists("Minecraft");
            LoadJson();
            modsCheckBox.Checked = _settings.GeneralSettings.EnableMods;
            premiumCheckBox.Checked = _settings.ServerSettings.AllowOnlyPremium;
            PvPCheckBox.Checked = _settings.ServerSettings.PvPAllowed;
            motdTextBox.Text = _settings.ServerSettings.MOTD;
            portTxTBox.Text = _settings.ServerSettings.ServerPort.ToString();
        }

        private void portTxTBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(portTxTBox.Text, "[^0-9]"))
            {
                portTxTBox.WithError = true;
            }
            else
            {
                portTxTBox.WithError = false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            LaunchMinecraftServer();
        }

        private void LaunchMinecraftServer()
        {
            mcProcess = new Process();

            try
            {
                string currentDir = Directory.GetCurrentDirectory();
                mcProcess.StartInfo.WorkingDirectory = currentDir + "\\Minecraft";
                //mcProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mcProcess.StartInfo.UseShellExecute = false;
                mcProcess.StartInfo.FileName = GetJavaInstallationPath() + @"\bin\javaw.exe";
                mcProcess.StartInfo.Arguments = "-jar " + (_settings.GeneralSettings.EnableMods ? "forge.jar" : "minecraft_server.1.12.2.jar") + " -Xms2G -Xmx2G";
                //mcProcess.StartInfo.RedirectStandardOutput = true;
                mcProcess.Start();
                //MetroMessageBox.Show(this, mcProcess.StandardOutput.ReadToEnd());
                //mcProcess.WaitForExit();
            }
            catch (NewerJavaException ex)
            {
                MetroMessageBox.Show(this, "Your java version is " + ex.version + " you need to disable mods to be able to run the server", "JAVA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
            }
            Thread.Sleep(2500);
            //mcProcess.Kill();
        }

        private String GetJavaInstallationPath()
        {
            String javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
            {
                String currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                float ver = float.Parse(currentVersion.Replace('.', ','));
                if (ver >= 1.9f) throw new NewerJavaException(ver);
                using (var homeKey = baseKey.OpenSubKey(currentVersion))
                    return homeKey.GetValue("JavaHome").ToString();
            }
        }
    }
}