// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IProcessHandler.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes
{
    /// <summary>
    ///     Brings the possibility to work with processes.
    /// </summary>
    public interface IProcessHandler
    {
        /// <summary>
        ///     Restarts the current process with a delay.
        /// </summary>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        void Restart(int delay = 2);

        /// <summary>
        ///     Restarts the process by its process ID with a delay.
        /// </summary>
        /// <param name="processId">The ID of the process to restart.</param>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        /// <exception cref="ArgumentException">
        ///     The process specified by the processId parameter is not running. The identifier
        ///     might be expired.
        /// </exception>
        void Restart(int processId, int delay);

        /// <summary>
        ///     Restarts all processes with a specific name.
        /// </summary>
        /// <param name="processName">The name of the processes to restart.</param>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        /// <exception cref="ArgumentNullException">processName is null or whitespace.</exception>
        void Restart(string processName, int delay = 2);

        /// <summary>
        ///     Restarts the given process with a delay.
        /// </summary>
        /// <param name="process">The process to restart.</param>
        /// <param name="delay">The delay in seconds when the process has to restart.</param>
        /// <exception cref="ArgumentNullException">process is null.</exception>
        void Restart(Process process, int delay = 2);

        /// <summary>
        ///     Gets all similar processes except the current.
        /// </summary>
        /// <returns>The list of similar processes.</returns>
        IEnumerable<Process> GetSimilarProcesses();

        /// <summary>
        ///     Gets the next possible similar process except the current.
        /// </summary>
        /// <returns>The next similar processes if found; otherwise null.</returns>
        Process GetSimilarProcess();

        /// <summary>
        ///     Brings the given process on front. Normalizes it if minimized.
        /// </summary>
        /// <param name="process">The process to bring on front.</param>
        /// <exception cref="NotSupportedException">The given process has no main window.</exception>
        void BringInFront(Process process);

        /// <summary>
        ///     Executes a given process without display it with parameters; waits for the process to end and returns it result
        ///     code and console output.
        /// </summary>
        /// <param name="executable">The process to execute.</param>
        /// <param name="parameters">The process parameters.</param>
        /// <returns>The result and output the process gave at runtime.</returns>
        /// <exception cref="InvalidOperationException">The process cannot be started.</exception>
        ProcessResult ExecuteSilentlyAndWait(string executable, string parameters);

        /// <summary>
        ///     Opens the given in the default application configured in the local system.
        /// </summary>
        /// <param name="file">The file to open.</param>
        void OpenFileInLocalApp(string file);
    }
}