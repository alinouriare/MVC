using DICtest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICtest.Models
{
    public class MemoryRepository : IRepository
    {

        public MemoryRepository(IScopeService scopeService,ITransientService transientService
            ,ISingletoneService singletoneService)
        {
            this.scopeService = scopeService;
            this.transientService = transientService;
            this.singletoneService = singletoneService;
        }

        private Dictionary<string, Product> products;
        private readonly IScopeService scopeService;
        private readonly ITransientService transientService;
        private readonly ISingletoneService singletoneService;

        public MemoryRepository()
        {
            products = new Dictionary<string, Product>();
            new List<Product> { 
            
            new Product{ Name="Kayak" , Price=275M},
            new Product { Name="LifeJecket", Price=48.95M},
            new Product{Name="Soccer Ball",Price=19.50M }
            }.ForEach(p=>AddProduct(p));
        }



        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product product)
        {
            products[product.Name] = product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product.Name);
        }

        public Product GetByName(string name)
        {
            return products[name];
        }
    }
}
