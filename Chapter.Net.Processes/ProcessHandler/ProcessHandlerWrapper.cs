// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessHandlerWrapper.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes;

/// <summary>
///     Brings the possibility to work with processes.
/// </summary>
public class ProcessHandlerWrapper : IProcessHandler
{
    /// <inheritdoc />
    public void Restart(int delay = 2)
    {
        ProcessHandler.Restart(delay);
    }

    /// <inheritdoc />
    public void Restart(int processId, int delay)
    {
        ProcessHandler.Restart(processId, delay);
    }

    /// <inheritdoc />
    public void Restart(string processName, int delay = 2)
    {
        ProcessHandler.Restart(processName, delay);
    }

    /// <inheritdoc />
    public void Restart(Process process, int delay = 2)
    {
        ProcessHandler.Restart(process, delay);
    }

    /// <inheritdoc />
    public IEnumerable<Process> GetSimilarProcesses()
    {
        return ProcessHandler.GetSimilarProcesses();
    }

    /// <inheritdoc />
    public Process GetSimilarProcess()
    {
        return ProcessHandler.GetSimilarProcess();
    }

    /// <inheritdoc />
    public void BringInFront(Process process)
    {
        ProcessHandler.BringInFront(process);
    }

    /// <inheritdoc />
    public ProcessResult ExecuteSilentlyAndWait(string executable, string parameters)
    {
        return ProcessHandler.ExecuteSilentlyAndWait(executable, parameters);
    }

    /// <inheritdoc />
    public void OpenFileInLocalApp(string file)
    {
        ProcessHandler.OpenFileInLocalApp(file);
    }
}