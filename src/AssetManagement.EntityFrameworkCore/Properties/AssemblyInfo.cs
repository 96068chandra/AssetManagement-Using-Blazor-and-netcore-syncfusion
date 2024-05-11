using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AssetManagement.EntityFrameworkCore.Tests")]

// Only make internal types and members visible to testing projects if they are needed.
// This reduces the risk of testing code inadvertently relying on implementation details.
internal class InternalType
{
    internal void InternalMethod()
    {
        // Method implementation here.
    }
}

// If internal types or members need to be accessed from external code, consider using the Internationalization Attribute.
[assembly: InternalsVisibleTo("OtherAssemblyName")]
internal class AnotherInternalType
{
    internal void AnotherInternalMethod()
    {
        // Method implementation here.
    }
}
