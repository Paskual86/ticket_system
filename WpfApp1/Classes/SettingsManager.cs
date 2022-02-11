using System;
using System.Diagnostics;
using System.Reflection;
using TicketSystem.Properties;

namespace TicketSystem.Classes
{
    internal static class SettingsManager
    {
        internal static string AppVersion;
        internal static string RootDirectory;

        public static long TerminalID => Settings.Default.TerminalID;

        public static DbProviderEnum DbProvider => DbProviderEnum.MSSQL;
        public static string LastUserName { get; set; }

        static SettingsManager()
        {
            AppVersion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion;
            RootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }
    }

    internal enum DbProviderEnum
    {
        Sqlite,
        MSSQL
    }
}
