using System;
using System.IO;
using SiAp_Parser.Enums;
using SiAp_Parser.Helpers;
using SiAp_Parser.Extensions;

namespace SiAp_Parser.Settings
{
    public sealed class SettingsManager
    {
        #region Constructors

        public SettingsManager()
        {
            this.PreferencesConfig = new PreferencesConfig();

            if (!Directory.Exists(this.PreferencesConfig.Directory))
                Directory.CreateDirectory(this.PreferencesConfig.Directory);

            this.IndexesConfig = new IndexesConfig();

            if (!Directory.Exists(this.IndexesConfig.Directory))
                Directory.CreateDirectory(this.IndexesConfig.Directory);

            this.OutputConfig = new OutputConfig();

            if (!Directory.Exists(this.OutputConfig.Directory))
                Directory.CreateDirectory(this.OutputConfig.Directory);

            this.CurrentSettings = new Settings();
        }

        public SettingsManager(bool autoLoad) : this()
        {
            if(autoLoad)
                this.Load();
        }

        #endregion

        /// <summary>
        /// Loads an existing config file
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// </summary>
        public void Load()
        {
            if (File.Exists(this.PreferencesConfig.FilePath))
            {
                try
                {
                    this.CurrentSettings = SerializationHelpers.Deserialize<Settings>(this.PreferencesConfig.FilePath);
                }
                catch (Exception)
                {
                    // log
                }
            }
        }

        public bool Save()
        {
            byte[] previousHash = new byte[] { };

            if (File.Exists(this.PreferencesConfig.FilePath))
                previousHash = this.PreferencesConfig.FilePath.GetFileHash();

            var xml = this.CurrentSettings.SerializeToXML();

            try
            {
                File.WriteAllText(this.PreferencesConfig.FilePath, xml);
            }
            catch (Exception)
            {
                return false;
            }

            var newHash = this.PreferencesConfig.FilePath.GetFileHash();

            return previousHash != newHash;
        }

        public OutputConfig OutputConfig { get; set; }
        public PreferencesConfig PreferencesConfig { get; set; }
        public IndexesConfig IndexesConfig { get; set; }
        public Settings CurrentSettings { get; set; }
        public TiposLibro CurrentBookType { get; set; }
        public string CurrentIndexesPath { get; set; }

        public bool HasUnsavedChanges
        {
            get
            {
                Settings OldSettings = null;

                try
                {
                    OldSettings = SerializationHelpers.Deserialize<Settings>(PreferencesConfig.FilePath);
                }
                catch (Exception)
                {
                    // log
                    return false;
                }

                return !CurrentSettings.Equals(OldSettings);
            }
        }
    }
}
