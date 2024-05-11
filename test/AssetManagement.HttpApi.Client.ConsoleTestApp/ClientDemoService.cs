using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.UI;

namespace AssetManagement.HttpApi.Client.ConsoleTestApp;

public class ClientDemoService : ITransientDependency
{
    private readonly IProfileAppService _profileAppService;

    public ClientDemoService(IProfileAppService profileAppService)
    {
        _profileAppService = profileAppService;
    }

    public async Task RunAsync()
    {
        try
        {
            var userProfile = await _profileAppService.GetAsync();
            Console.WriteLine($"UserName : {userProfile.UserName}");
            Console.WriteLine($"Email    : {userProfile.Email}");
            Console.WriteLine($"Name     : {userProfile.Name}");
            Console.WriteLine($"Surname  : {userProfile.Surname}");
        }
        catch (UserFriendlyException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
