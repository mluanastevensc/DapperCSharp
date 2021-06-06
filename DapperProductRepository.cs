using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuy
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID, int StockLevel)
        {
            _connection.Execute("INSERT INTO products(Name, Price, CategoryID, StockLevel) values (@Name,@Price, @CategoryID, @StockLevel);",
                new { name = name, price = price, categoryID = categoryID, stocklevel=StockLevel });
        }

        
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products ;");
        }

        public void DeleteProduct(int ProductID)
        {
            _connection.Execute("Delete from products where productID =@productId;",
                new { productid = ProductID });
        }

        public void UpdateProduct(string updateName, int productID)
        {
            _connection.Execute("Update Products SET Name = @updateName where ProductID=@productID;",
                new { updateName=updateName, productID=productID });
        }
    }

}