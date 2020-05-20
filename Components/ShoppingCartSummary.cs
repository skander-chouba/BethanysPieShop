using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly ShoppingCart _cart;

        public ShoppingCartSummary(ShoppingCart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cart.GetShoppingCartItems();
            _cart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _cart,
                ShoppingCartTotal = _cart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}
