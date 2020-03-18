using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICtest.Models
{

    public interface IComplexClass
    {

    }


    public class ComplexCalss: IComplexClass
    {

        public ComplexCalss(string connectionstring)
        {
            Connectionstring = connectionstring;
        }

        public string Connectionstring { get; }
    }



    public interface IComplexClass2
    {

    }


    public class ComplexCalssORACLE : IComplexClass2
    {

       
        public string Connectionstring { get; }
    }


    public class ComplexCalssSQL : IComplexClass2
    {

    

        public string Connectionstring { get; }
    }


    public interface IRepository
    {

        IEnumerable<Product> Products { get; }

        Product GetByName(string name);

        void AddProduct(Product product);

        void DeleteProduct(Product product);
    }
}
