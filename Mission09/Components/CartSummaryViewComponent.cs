using Microsoft.AspNetCore.Mvc;
using Mission09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09.Components
{
    public class CartSummaryViewComponent : ViewComponent {
        private Basket basket;
        public CartSummaryViewComponent(Basket cartService)
        {
            basket = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
