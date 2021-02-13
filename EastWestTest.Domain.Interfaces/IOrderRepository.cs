using EastWestTest.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EastWestTest.Domain.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrderList();
        Order GetOrder(int id);
        void Save();
    }
}
