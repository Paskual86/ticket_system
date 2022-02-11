using System;
using System.IO;
using System.Threading.Tasks;

namespace TicketSystem.Classes
{
    internal static class LogHelper
    {
        private static string _logPath;

        internal static async Task LogWarning(string message, LogCat cat = LogCat.Default, bool logConsole = false, bool logFile = true)
        {
            await Log(message, LogSeverity.Warning, cat, logConsole, logFile).ConfigureAwait(false);
        }

        internal static async Task LogError(string message, LogCat cat = LogCat.Default, bool logConsole = false)
        {
            await Log(message, LogSeverity.Error, cat, logConsole).ConfigureAwait(false);
        }

        internal static async Task LogInfo(string message, LogCat cat = LogCat.Default, bool logConsole = false, bool logFile = true)
        {
            await Log(message, LogSeverity.Info, cat, logConsole, logFile).ConfigureAwait(false);
        }

        internal static async Task Log(string message, LogSeverity severity = LogSeverity.Info, LogCat cat = LogCat.Default, bool logConsole = false, bool logFile = true)
        {
            try
            {
                _logPath = _logPath ?? Path.Combine(SettingsManager.RootDirectory, "logs");

                var file = Path.Combine(_logPath, $"{cat}.log");

                if (!Directory.Exists(_logPath))
                    Directory.CreateDirectory(_logPath);

                // var cc = Console.ForegroundColor;

                if (logFile)
                    File.AppendAllText(file, $@"{DateTime.Now,-19} [{severity,8}]: {message}{Environment.NewLine}");

                switch (severity)
                {
                    case LogSeverity.Critical:
                    case LogSeverity.Error:
                        Console.ForegroundColor = ConsoleColor.Red;

                        break;
                    case LogSeverity.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogSeverity.Info:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case LogSeverity.Verbose:
                    case LogSeverity.Debug:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                }

                if (logConsole)
                    Console.WriteLine($@"{DateTime.Now,-19} [{severity,8}] [{cat}]: {message}");
            }
            catch
            {
                // ignored
            }
        }

        internal static async Task LogEx(string message, Exception exception, LogCat cat = LogCat.Default)
        {
            try
            {
                _logPath = _logPath ?? Path.Combine(SettingsManager.RootDirectory, "logs");
                var file = Path.Combine(_logPath, $"{cat}.log");

                if (!Directory.Exists(_logPath))
                    Directory.CreateDirectory(_logPath);

                File.AppendAllText(file,
                    $@"{DateTime.Now,-19} [{LogSeverity.Critical,8}]: {message} {Environment.NewLine}{exception}{exception.InnerException}{Environment.NewLine}");
            }
            catch
            {
                // ignored
            }
        }
    }

    internal enum LogCat
    {
        Default,
        Data
    }

    internal enum LogSeverity
    {
        Debug = 0,
        Verbose,
        Info,
        Warning,
        Error,
        Critical,
    }
}
