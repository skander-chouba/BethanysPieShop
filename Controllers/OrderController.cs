using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly ShoppingCart _cart;

        public OrderController(IOrderRepository repository, ShoppingCart cart)
        {
            _repository = repository;
            _cart = cart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _cart.GetShoppingCartItems();
            _cart.ShoppingCartItems = items;

            if (!_cart.ShoppingCartItems.Any())
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }
            if (ModelState.IsValid)
            {
                _repository.CreateOrder(order);
                _cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewData["CheckoutCompleteMessage"] = "Thanks for your order, You'll soon enjoy your delicious pies!";
            return View();
        }
    }
}
