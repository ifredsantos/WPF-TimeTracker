﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using TimeTracker.UI.Models;

namespace TimeTracker.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AppConfig _config;
        public AppConfig Config
        {
            get
            {
                if (_config != null) return _config;
                _config = LoadAppInfo();
                return _config;
            }
        }

        private AppConfig LoadAppInfo()
        {
            return new AppConfig
            {
                database_type = AppConfig.enDataBaseType.JSON,
                json_database_config = new JSONDataBaseConfig
                {
                    directory = Debugger.IsAttached ? "./data" : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "iFredApps", "Database"),
                    filename = "dbTimeTracker.json"
                }
            };
        }
    }
}
