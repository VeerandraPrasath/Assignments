using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Task5
    {
        QueryBuilder q;
        public Task5()
        {
            q= new QueryBuilder();
        }
        public void Run()
        {
            var result =q.Filter(p => p.Price > 10).SortBy(func => func.Price).Join(p=>p.SupplierId,s=>s.SupplierId).Execute();
        

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }


    }

    public class QueryBuilder
    {
        public List<Product> productList { get; set; }

        public List<Supplier> supplierList { get; set; }

        public  IEnumerable<object> result { get; set; }

        public int Count { get; set; }

        public QueryBuilder()
        {
            productList = new List<Product>() {
               new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",2000,3),
                new Product("Shirt",3,"Clothing",100,5),
                new Product("Trousers",4,"Clothing",10,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",25,9)
            };
            supplierList = new List<Supplier>()
            {
                new Supplier("Lenova",1,1),
                new Supplier("Samsung",3,2),
                new Supplier("Levis",5,3),
                new Supplier("Jockey",7,4),
                new Supplier("Bata",8,6),
                new Supplier("Puma",9,5)
            };

            result = null;
        }


        public QueryBuilder Filter(Func<Product, bool> func)
        {
            result = productList.Where(func);
           
            return this;
        }

        public QueryBuilder SortBy(Func<Product, decimal> func)
        {
            //result = from p in result as IEnumerable<Product> orderby func select p;
            var source = (IEnumerable<Product>)result;
            result = source.OrderBy(func);

            return this;
        }

        //public QueryBuilder Join(Func<Product, Supplier, bool> func)
        //{
        //    var source=result as IEnumerable<Product>;
            
        //    result = from p in source from s in supplierList where func(p, s) select new { p.ProductId, p.ProductName, s.SupplierName, p.Price };
        //    return this;
        //}

        public QueryBuilder Join(Func<Product,int> func1,Func<Supplier, int> func2)
        {
            var source = result as IEnumerable<Product>;
            //result = from p in source join s in supplierList on func1(p) equals func2(s) select new { p.ProductId, p.ProductName, s.SupplierName, p.Price };
            result = source.Join(supplierList, func1, func2, (p, s) =>new  { p.ProductName,p.ProductId,p.Price,s.SupplierName});
            return this;
        }

        public IEnumerable<object> Execute()
        {
            return result;
        }

    }

}
 