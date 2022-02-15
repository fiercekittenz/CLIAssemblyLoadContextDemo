# CLIAssemblyLoadContextDemo
Demonstrates the issues with C++/CLI in a /clr:netcore project that calls into another /clr:netcore project, but invokes C# code. The second project will load its referenced assemblies into an IsolatedComponentLoadContext, which is different from the Default ALC. This means if you rely on singletons, you're going to get multiple instances.

# C++/CLI with Microsoft.Data.SqlClient
I discovered this change in assembly loading thanks to the SqlClient library; however, it appears the real issue is if you set your C++/CLI project's character set to use Unicode. When you do that and it calls into the C# code to execute the SqlClient connection code, it will throw a "Platform not supported" exception.
