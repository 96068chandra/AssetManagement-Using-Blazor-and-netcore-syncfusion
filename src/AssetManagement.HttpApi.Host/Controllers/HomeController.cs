using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("api/[controller]")]
public class HomeController : AbpController
{
    [HttpGet]
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}
