using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        } 
    }
}
