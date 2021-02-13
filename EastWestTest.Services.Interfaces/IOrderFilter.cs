using EastWestTest.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EastWestTest.Services.Interfaces
{
    public interface IOrderFilter
    {
        List<Order> ByDateTime(List<Order> orders, DateTime dateTime);
        List<Order> ByCustomerName(List<Order> orders, string name);
    }
}
