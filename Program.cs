using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connString);
            
            var repo = new DapperProductRepository(connection);
            //repo.CreateProduct("Michelle", 9.99, 1, 1025);
            repo.DeleteProduct(869);
            repo.UpdateProduct("111111111111111111111", 880);
            var products = repo.GetAllProducts();


            foreach (var prod in products)
            {
                Console.WriteLine($" {prod.Name}");
            }

        }
    }
}
