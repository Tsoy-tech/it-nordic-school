using System;
using System.Collections.Generic;
using System.Text;

namespace L30_ClassWork.Orders
{
    public interface IOrderRepository
    {
        int GetOrderCount();
        List<OrderDiscount> GetOrderDiscountList();
        int AddOrder(int customerId, DateTimeOffset orderDate, float? discount, List<Tuple<int, int>> productIdCountList);
    }
}
