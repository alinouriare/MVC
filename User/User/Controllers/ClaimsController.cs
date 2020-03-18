using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    public class ClaimsController : Controller
    {
        [Authorize]
        public IActionResult Index() => View(User?.Claims);

        [Authorize(Policy = "Allstate")]
        public string Allstate() => "Location Allstate";

        [Authorize(Policy = "Allstate")]
        public string Tehran() => "Location Tehran";

        [Authorize(Policy = "DC")]
        public string DC() => "Location DC";

        [Authorize(Policy = "NotMahdi")]
        public string NotMahdi() => "NotMahdi";

        [Authorize(Policy = "Country")]
        public string Country() => "Country Db";
    }
}