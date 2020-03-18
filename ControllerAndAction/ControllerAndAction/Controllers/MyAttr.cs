using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerAndAction.Controllers
{
    [Controller]
    public class MyAttr
    {

        public string Index() => "Hello From MyAttr Controller";
    }
}
