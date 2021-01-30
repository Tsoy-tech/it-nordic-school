using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using L30_ClassWork.Orders;

namespace L30_ClassWork
{
    public partial class OnlineStoreRepository : IOrderRepository
    {
        public int AddOrder(int customerId, DateTimeOffset orderDate, float? discount, List<Tuple<int, int>> productIdCountList)
        {
            using var connection = GetOpenedSqlConnection();

            using var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddOrder";
                command.Parameters.AddWithValue("@customerId", customerId);
                command.Parameters.AddWithValue("@orderDate", orderDate);
                if (discount.HasValue)
                    command.Parameters.AddWithValue("@discount", discount);

                int orderId = (int)(decimal)command.ExecuteScalar();

                foreach (var productIdCount in productIdCountList)
                {
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddOrderItem";
                    command.Parameters.AddWithValue("@orderId", orderId);
                    command.Parameters.AddWithValue("@productId", productIdCount.Item1);
                    command.Parameters.AddWithValue("@numberOfItems", productIdCount.Item2);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();

                return orderId;
            }
            catch (SqlException)
            {
                transaction.Rollback();
                throw;
            }
        }

        public int GetOrderCount()
        {
            using var connection = GetOpenedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) FROM dbo.[Order]";

            int result = (int)command.ExecuteScalar();
            return result;
        }

        public List<OrderDiscount> GetOrderDiscountList()
        {
            List<OrderDiscount> result = new List<OrderDiscount>();

            using var connection = GetOpenedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"
                SELECT 
                    Id, 
                    Discount 
                FROM dbo.[Order] 
                ORDER BY Id ASC";

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
                return result;

            int idColumnIndex = reader.GetOrdinal("Id");
            int discountColumnIndex = reader.GetOrdinal("Discount");

            while (reader.Read())
            {
                var id = reader.GetInt32(idColumnIndex);

                double discount = 0;
                if(!reader.IsDBNull(discountColumnIndex))
                    discount = reader.GetDouble(discountColumnIndex);
                
                var orderDiscount = new OrderDiscount(id, discount);
                result.Add(orderDiscount);
            }

            return result;
        }
    }
}
