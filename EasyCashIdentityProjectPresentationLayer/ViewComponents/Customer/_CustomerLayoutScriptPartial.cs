using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutScriptPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
