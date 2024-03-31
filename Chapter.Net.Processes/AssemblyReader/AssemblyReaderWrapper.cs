// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyReaderWrapper.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.Processes
{
    /// <summary>
    ///     Reads information about the executable.
    /// </summary>
    public class AssemblyReaderWrapper : IAssemblyReader
    {
        /// <inheritdoc />
        public string GetExeLocation()
        {
            return AssemblyReader.GetExeLocation();
        }

        /// <inheritdoc />
        public Version GetExeVersion()
        {
            return AssemblyReader.GetExeVersion();
        }
    }
}