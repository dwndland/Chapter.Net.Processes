// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessResult.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes;

/// <summary>
///     Contains the process execution result data used by
///     <see cref="ProcessHandler.ExecuteSilentlyAndWait(string, string)" />.
/// </summary>
public sealed class ProcessResult
{
    internal ProcessResult(int exitCode, string output)
    {
        ExitCode = exitCode;
        Output = output;
    }

    /// <summary>
    ///     Gets the process exit code.
    /// </summary>
    public int ExitCode { get; }

    /// <summary>
    ///     Gets the output the process created at execution time.
    /// </summary>
    public string Output { get; }
}