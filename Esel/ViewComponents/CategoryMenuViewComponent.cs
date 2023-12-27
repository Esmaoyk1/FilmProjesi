using Esel.Data;
using Microsoft.AspNetCore.Mvc;

namespace Esel.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["action"].ToString() == "Index")
            {
                ViewBag.SelectedCategory = RouteData?.Values["id"];
            }

            return View(CategoryRepository.Categories);
        }
    }
}
