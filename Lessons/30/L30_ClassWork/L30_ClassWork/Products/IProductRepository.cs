using System;
using System.Collections.Generic;
using System.Text;

namespace L30_ClassWork.Products
{
    public interface IProductRepository
    {
        int GetProductCount();
        List<Product> GetProductList();
        int AddProduct(ProductRestricted product);
    }
}
