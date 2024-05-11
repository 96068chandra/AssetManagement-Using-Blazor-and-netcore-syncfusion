using System.Runtime.CompilerServices;

// The InternalsVisibleTo attribute makes the internal members of the current assembly visible to the specified assembly.
// This is useful when you want to allow unit tests to access internal members of your application code.
// In this example, the "AssetManagement.Application.Tests" assembly will be able to access the internal members of the current assembly.
[assembly: InternalsVisibleTo("AssetManagement.Application.Tests")]

// You can also specify multiple assemblies to grant access to, by separating them with a semicolon.
// [assembly: InternalsVisibleTo("Assembly1;Assembly2;Assembly3")]
