using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICtest.Infrastructure
{
 public   interface ITransientService
    {
         Guid id { get; set; }

    }
    public interface IScopeService
    {
        Guid id { get; set; }

    }
    public interface ISingletoneService
    { 
        Guid id { get; set; }

    }


    public class TransientService : ITransientService
    {
        public Guid id { get  ; set; }
        public TransientService()
        {
            id = Guid.NewGuid();
        }
    }

    public class ScopeService : IScopeService
    {
        public Guid id { get; set; }
        public ScopeService()
        {
            id = Guid.NewGuid();
        }
    }

    public class SingletoneService : ISingletoneService
    {
        public Guid id { get; set; }
        public SingletoneService()
        {
            id = Guid.NewGuid();
        }
    }

}
