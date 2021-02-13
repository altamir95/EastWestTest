using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EastWestTest.Domain.Core;
using EastWestTest.Domain.Interfaces;
using EastWestTest.Services.Interfaces;

namespace EastWestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository repo;
        IOrderFilter order;
        public OrderController(IOrderRepository r, IOrderFilter o)
        {
            repo = r;
            order = o;
        }

        // GET api/order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return repo.GetOrderList();
        }

        // GET api/order/*
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return repo.GetOrder(id);
        }

        //GET api/order/?name=*&date=*
        //IF NAME IS "all" IN URL THEN RETURN WITHOUT FILTER NAMES
        //IF DATE IS "0001-01-01T00:00:00(DateTime.MinValue)" IN URL THEN RETURN WITHOUT FILTER DATE
        [HttpGet("name={name}&date={date}")]
        public ActionResult<IEnumerable<Order>> Get(string name, DateTime date)
        {
            List<Order> orders = repo.GetOrderList().ToList();

            orders = order.ByCustomerName(orders, name);
            orders = order.ByDateTime(orders, date);

            return orders;
        }
    }
}
