using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutSidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
