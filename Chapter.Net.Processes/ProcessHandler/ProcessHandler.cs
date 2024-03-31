// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessHandler.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Chapter.Net.WinAPI;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes
{
    /// <summary>
    ///     Brings the possibility to work with processes.
    /// </summary>
    public static class ProcessHandler
    {
        /// <summary>
        ///     Restarts the current process with a delay.
        /// </summary>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        public static void Restart(int delay = 2)
        {
            var process = Process.GetCurrentProcess();
            Restart(process, delay);
        }

        /// <summary>
        ///     Restarts the process by its process ID with a delay.
        /// </summary>
        /// <param name="processId">The ID of the process to restart.</param>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        /// <exception cref="ArgumentException">
        ///     The process specified by the processId parameter is not running. The identifier
        ///     might be expired.
        /// </exception>
        public static void Restart(int processId, int delay)
        {
            var process = Process.GetProcessById(processId);
            Restart(process, delay);
        }

        /// <summary>
        ///     Restarts all processes with a specific name.
        /// </summary>
        /// <param name="processName">The name of the processes to restart.</param>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        /// <exception cref="ArgumentNullException">processName is null or whitespace.</exception>
        public static void Restart(string processName, int delay = 2)
        {
            if (string.IsNullOrWhiteSpace(processName))
                throw new ArgumentNullException(nameof(processName));

            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
                Restart(process, delay);
        }

        /// <summary>
        ///     Restarts the given process with a delay.
        /// </summary>
        /// <param name="process">The process to restart.</param>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        /// <exception cref="ArgumentNullException">process is null.</exception>
        public static void Restart(Process process, int delay = 2)
        {
            if (process == null)
                throw new ArgumentNullException(nameof(process));

            var module = process.MainModule;
            if (module == null)
                return;

            var info = new ProcessStartInfo
            {
                Arguments = $"/C ping 127.0.0.1 -n {delay} && \"{module.FileName}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(info);
            process.Kill();
        }

        /// <summary>
        ///     Gets all similar processes except the current.
        /// </summary>
        /// <returns>The list of similar processes.</returns>
        public static IEnumerable<Process> GetSimilarProcesses()
        {
            var current = Process.GetCurrentProcess();
            return Process.GetProcessesByName(current.ProcessName).Where(x => x.Id != current.Id);
        }

        /// <summary>
        ///     Gets the next possible similar process except the current.
        /// </summary>
        /// <returns>The next similar processes if found; otherwise null.</returns>
        public static Process GetSimilarProcess()
        {
            return GetSimilarProcesses().FirstOrDefault();
        }

        /// <summary>
        ///     Brings the given process on front. Normalizes it if minimized.
        /// </summary>
        /// <param name="process">The process to bring on front.</param>
        /// <exception cref="NotSupportedException">The given process has no main window.</exception>
        public static void BringInFront(Process process)
        {
            if (process.MainWindowHandle == IntPtr.Zero)
                throw new NotSupportedException("The given process must have a main window.");

            User32.SetForegroundWindow(process.MainWindowHandle);
            User32.ShowWindow(process.MainWindowHandle, WindowShowStyle.Restore);
        }

        /// <summary>
        ///     Executes a given process without display it with parameters; waits for the process to end and returns it result
        ///     code and console output.
        /// </summary>
        /// <param name="executable">The process to execute.</param>
        /// <param name="parameters">The process parameters.</param>
        /// <returns>The result and output the process gave at runtime.</returns>
        /// <exception cref="InvalidOperationException">The process cannot be started.</exception>
        public static ProcessResult ExecuteSilentlyAndWait(string executable, string parameters)
        {
            var startInfo = new ProcessStartInfo(executable)
            {
                Arguments = parameters,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            var process = Process.Start(startInfo);
            if (process == null)
                throw new InvalidOperationException($"The process ('{executable}') cannot be started.");
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return new ProcessResult(process.ExitCode, output);
        }

        /// <summary>
        ///     Opens the given in the default application configured in the local system.
        /// </summary>
        /// <param name="file">The file to open.</param>
        public static void OpenFileInLocalApp(string file)
        {
            Process.Start(new ProcessStartInfo(file) { UseShellExecute = true });
        }
    }
}