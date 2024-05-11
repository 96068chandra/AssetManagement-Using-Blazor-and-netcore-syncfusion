namespace AssetManagement;

public abstract class AssetManagementApplicationTestBase : AssetManagementTestBase
{
    protected AssetManagementApplicationTestBase() : base(new AssetManagementApplicationTestModule())
    {
    }
}
