# Chapter.Net.Processes Library

## Overview
Chapter.Net.Processes brings access and handlers to local processes and assemblies.

## Features
- **IAssemblyReader:** Reads data from the current executable.
- **IProcessHandler:** Birngs features to work with processes.
- **Wrappers and Interfaces:** All methods are available static, but also with an interface and wrapper class for mocking.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.Processes library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.Processes
    ```

2. **IAssemblyReader**
    - Usage
    ```csharp
    public class ViewModel
    {
        public string GetVersion()
        {
            var version = AssemblyReader.GetExeVersion();
            return $"v{version.ToString(2)}";
        }
    }
    ```
    ```csharp
    public class ViewModel
    {
        private readonly IAssemblyReader _assemblyReader;

        public ViewModel(IAssemblyReader assemblyReader)
        {
            _assemblyReader = assemblyReader;
        }

        public string GetVersion()
        {
            var version = _assemblyReader.GetExeVersion();
            return $"v{version.ToString(2)}";
        }
    }
    ```

3. **IProcessHandler**
    - Usage
    ```csharp
    public class ViewModel : ObservableObject
    {
        public void ChangeSetting()
        {
            // Apply new setting

            // Restart application
            ProcessHandler.Restart(4);
        }
    }
    ```
    ```csharp
    public class Bootstrapper
    {
        public void CheckSingleInstance()
        {
            var other = ProcessHandler.GetSimilarProcess();
            if (other != null)
            {
                ProcessHandler.BringInFront(other);
                Application.Current.Shutdown();
            }
        }
    }
    ```
    ```csharp
    public class ViewModel : ObservableObject
    {
        private readonly IProcessHandler _processHandler;

        public ViewModel(IProcessHandler processHandler)
        {
            _processHandler = processHandler;
        }

        public void ChangeSetting()
        {
            // Apply new setting

            // Restart application
            _processHandler.Restart(4);
        }
    }
    ```
    ```csharp
    public class Bootstrapper
    {
        private readonly IProcessHandler _processHandler;

        public Bootstrapper(IProcessHandler processHandler)
        {
            _processHandler = processHandler;
        }

        public void CheckSingleInstance()
        {
            var other = _processHandler.GetSimilarProcess();
            if (other != null)
            {
                _processHandler.BringInFront(other);
                Application.Current.Shutdown();
            }
        }
    }
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.Processes)
* [GitHub](https://github.com/dwndland/Chapter.Net.Processes)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
