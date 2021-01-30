using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using L30_ClassWork.Products;
using System.Text;

namespace L30_ClassWork
{
    public partial class OnlineStoreRepository : IProductRepository
    {
        public int AddProduct(ProductRestricted product) //процедуры
        {
            using var connection = GetOpenedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.AddProduct";
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);

            int result = (int)(decimal)command.ExecuteScalar();
            return result;
        }

        public int GetProductCount()
        {
            using var connection = GetOpenedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) FROM dbo.[Product]";

            int result = (int)command.ExecuteScalar();
            return result;
        }
        public List<Product> GetProductList()
        {
            List<Product> result = new List<Product>();

            using var connection = GetOpenedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"
                SELECT 
                    Id, 
                    [Name], 
                    Price 
                FROM dbo.[Product] 
                ORDER BY Id ASC";

            using SqlDataReader reader = command.ExecuteReader();
            
            if(!reader.HasRows)
                return result;

            int idColumnIndex = reader.GetOrdinal("Id");
            int nameColumnIndex = reader.GetOrdinal("Name");
            int priceColumnIndex = reader.GetOrdinal("Price");

            while(reader.Read())
            {
                var id = reader.GetInt32(idColumnIndex);
                var name = reader.GetString(nameColumnIndex);
                var price = reader.GetDecimal(priceColumnIndex);

                var product = new Product(id, name, price);
                result.Add(product);
            }

            return result;
        }
    }
}
