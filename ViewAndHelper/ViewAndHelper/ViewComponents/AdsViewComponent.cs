using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewAndHelper.Models;

namespace ViewAndHelper.ViewComponents
{
    public class AdsViewComponent: ViewComponent
    {

        public IViewComponentResult Invoke(string prifixAdd)
        {
            List<Ads> a = new List<Ads> { new Ads { Id=1,Description="DDDD",Titr=$"{prifixAdd} --aa"}, new Ads { Id = 2, Description = "DDDD2", Titr =$"{prifixAdd}--aa2" } };
            return View(a);
        }
    }
}
