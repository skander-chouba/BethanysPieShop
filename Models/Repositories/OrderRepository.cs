using BethanysPieShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _cart;

        public OrderRepository(AppDbContext context, ShoppingCart cart)
        {
            _context = context;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.UtcNow;
            var shoppingCartItems = _cart.ShoppingCartItems;
            order.OrderTotal = _cart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
