// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyReader.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes
{
    /// <summary>
    ///     Reads information about the executable.
    /// </summary>
    public static class AssemblyReader
    {
        /// <summary>
        ///     Reads the location of the executable.
        /// </summary>
        /// <returns>The location of the executable.</returns>
        public static string GetExeLocation()
        {
            var assembly = Assembly.GetEntryAssembly();
            return Path.GetDirectoryName(assembly.Location);
        }

        /// <summary>
        ///     Reads the version of the executable.
        /// </summary>
        /// <returns>The version of the executable.</returns>
        public static Version GetExeVersion()
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetName();
            return assemblyName.Version;
        }
    }
}