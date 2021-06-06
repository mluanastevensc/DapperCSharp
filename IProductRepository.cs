using System;
using System.Collections.Generic;

namespace BestBuy
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID, int stockLevel);
        void DeleteProduct(int productID);
        void UpdateProduct(string updateName, int productID);
    }


}
