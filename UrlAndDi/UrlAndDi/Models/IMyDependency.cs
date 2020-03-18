using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlAndDi.Models
{
    public interface IMyDependency
    {

        string GetText();
    }

    public class MyDependency : IMyDependency
    {
        public string GetText() => "Is Dependency Class";

    }


    public class MyDependencyModule : Module

    {
         
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyDependency>().As<IMyDependency>();
        }

    }

}
