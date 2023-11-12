using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
