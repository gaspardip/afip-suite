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
            PreferencesConfig = new PreferencesConfig();

            if (!Directory.Exists(PreferencesConfig.Directory))
                Directory.CreateDirectory(PreferencesConfig.Directory);

            IndexesConfig = new IndexesConfig();

            if (!Directory.Exists(IndexesConfig.Directory))
                Directory.CreateDirectory(IndexesConfig.Directory);

            OutputConfig = new OutputConfig();

            if (!Directory.Exists(OutputConfig.Directory))
                Directory.CreateDirectory(OutputConfig.Directory);

            CurrentSettings = new Settings();
        }

        public SettingsManager(bool autoLoad) : this()
        {
            if(autoLoad)
                Load();
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
            if (!File.Exists(PreferencesConfig.FilePath)) return;

            try
            {
                CurrentSettings = SerializationHelpers.Deserialize<Settings>(PreferencesConfig.FilePath);
            }
            catch (Exception)
            {
                // log
            }
        }

        public bool Save()
        {
            var previousHash = new byte[] { };

            if (File.Exists(PreferencesConfig.FilePath))
                previousHash = PreferencesConfig.FilePath.GetFileHash();

            var xml = CurrentSettings.SerializeToXML();

            try
            {
                File.WriteAllText(PreferencesConfig.FilePath, xml);
            }
            catch (Exception)
            {
                return false;
            }

            var newHash = PreferencesConfig.FilePath.GetFileHash();

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
                Settings oldSettings;

                try
                {
                    oldSettings = SerializationHelpers.Deserialize<Settings>(PreferencesConfig.FilePath);
                }
                catch (Exception)
                {
                    // log
                    return false;
                }

                return !CurrentSettings.Equals(oldSettings);
            }
        }
    }
}
