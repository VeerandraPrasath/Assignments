﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Task4
    {
        public List<Product> productList { get; set; }
        public Task4()
        {
            productList = new List<Product>() {
                 new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",20000,3),
                new Product("Shirt",3,"Clothing",1000,5),
                new Product("Trousers",4,"Clothing",1500,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",2500,9),
                new Product("Headphones",7,"Electronics",1500,10),
                new Product("Psychology of money",8,"Books",500,11),
                new Product("T-Shirt",9,"Clothing",500,12),
                new Product("Rich Dad ,Poor Dad",10,"Books",2000,13),
                new Product("Sandals",11,"Footwear",1000,14),
            };
        }
        public void Run()
        {
            GetProductByCategory("Books");

        }
        public void GetProductByCategory(string category)
        {
            List<Product> OrderBooksByPrice = productList.Where(p => p.Category == category).OrderByDescending(x=>x.Price).ToList();
            OrderBooksByPrice.ForEach(p => Console.WriteLine(p));

        }
    }
}
