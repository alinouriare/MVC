using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewAndHelper.Infrastructures
{
    public class SimpleExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values.Add("Color", "Red");
        }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.Values.Any(c => c.Key == "Color"))
            {

            }
            foreach (string location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }
            yield return "/{1}/Views/{0}.cshtml";
        }
    }
}
