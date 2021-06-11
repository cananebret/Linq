using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId = 1, CategoryName="Bilgisayar"},
                new Category{CategoryId = 2, CategoryName="Telefon"},
                new Category{CategoryId = 3, CategoryName="Buzdolabı"},
                new Category{CategoryId = 4, CategoryName="Masa"}
            };

            List<Product> products = new List<Product>
            {
                new Product {ProductId = 1, CategoryId=1, ProductName= "Acer Laptop", QuantityPerUnit="32 GB Ram", UnitPrice= 10000,UnitsInStock= 5 },
                new Product {ProductId = 2, CategoryId=1, ProductName= "Asus Laptop", QuantityPerUnit="16 GB Ram", UnitPrice= 8000,UnitsInStock= 3 },
                new Product {ProductId = 3, CategoryId=1, ProductName= "HP Laptop", QuantityPerUnit="8 GB Ram", UnitPrice= 8000,UnitsInStock= 2 },
                new Product {ProductId = 4, CategoryId=2, ProductName= "Samsung Telefon", QuantityPerUnit="4 GB Ram", UnitPrice= 5000,UnitsInStock= 15 },
                new Product {ProductId = 5, CategoryId=2, ProductName= "Apple Telefon", QuantityPerUnit="4 GB Ram", UnitPrice= 8000,UnitsInStock= 0 }

            };

            //find(products);
            //AnyTest(products);
            //foreachtest(products);
            //ornek(products);
            //FindAll(products);
            //AscDescTest(products);
            //DTOTest(products);

            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         where p.UnitPrice> 5000 
                         orderby p.ProductName descending
                         select new ProductDTO { ProductId = p.ProductId, UnitPrice = p.UnitPrice, ProductName = p.ProductName, CategoryName = c.CategoryName };
            
            foreach (var productDTO in result)
            {
                //Console.WriteLine(productDTO.ProductName +" "+ productDTO.CategoryName);
               
                Console.WriteLine("{0}----{1}", productDTO.ProductName , productDTO.CategoryName); // diğer türlü kullanımı
            }
                        

        }

        private static void DTOTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice >= 5000 && p.UnitsInStock > 0
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDTO {ProductId = p.ProductId, ProductName=p.ProductName, UnitPrice=p.UnitPrice };

            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void FindAll(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void find(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 54);
            Console.WriteLine(result.ProductName);
        }

        private static void foreachtest(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }

        private static void ornek(List<Product> products)
        {
            var resultt = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);
            Console.WriteLine(resultt);

            foreach (var item in resultt)
            {
                //Console.WriteLine(item.ProductName);
            }
            GetProducts(products);
            GetProductsLinq(products);
        }

        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filteredProduct = new List<Product>();
            foreach (var product in products)
            {
                if(product.UnitPrice>5000 && product.UnitsInStock>3 )
                {
                    filteredProduct.Add(product);
                }
            }
            return filteredProduct;
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList(); ;

        }

    }

    class ProductDTO
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName   { get; set; }
    }
}
