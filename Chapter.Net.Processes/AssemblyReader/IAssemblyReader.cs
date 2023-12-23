// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IAssemblyReader.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes;

/// <summary>
///     Reads information about the executable.
/// </summary>
public interface IAssemblyReader
{
    /// <summary>
    ///     Reads the location of the executable.
    /// </summary>
    /// <returns>The location of the executable.</returns>
    string GetExeLocation();

    /// <summary>
    ///     Reads the version of the executable.
    /// </summary>
    /// <returns>The version of the executable.</returns>
    Version GetExeVersion();
}