using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ProductShop
{
    class ProgramProductShop
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Products>> foodStore = new Dictionary<string, List<Products>>();

            string[] info = ReadArrayConsole();

            while (info[0] != "Revision")
            {
                string shopName = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);
                Products productInfo = new Products()
                {
                    Product = product,
                    Price = price
                };

                if (foodStore.ContainsKey(shopName))
                {
                    foodStore[shopName].Add(productInfo);
                }
                else
                {
                    foodStore.Add(shopName, new List<Products>() { productInfo });
                }

                info = ReadArrayConsole();
            }
            foreach (var shop in foodStore.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var prod in shop.Value)
                {
                    Console.WriteLine($"Product: {prod.Product}, Price: {prod.Price}");
                }
            }

        }
        public static string[] ReadArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public class Products
        {
            public string Product { get; set; }
            public double Price { get; set; }
            public Products()
            {

            }
        }
    }
}
