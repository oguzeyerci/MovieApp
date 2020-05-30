using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace filmapp.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<string>(){
               "Romantik","Aksiyon","Dram","Bilimkurgu","Biografi","Aile","Komedi","Savaş","Belgesel"
            };
            ViewBag.SelectedCategory= RouteData?.Values["id"];
            return View(categories);
        }
    }
}