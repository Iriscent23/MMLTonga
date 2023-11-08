using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMLTonga.Data;
using MMLTonga.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMLTonga.Controllers
{
    public class CartController : Controller
    {
        private readonly DbProductContext _context;

        public CartController(DbProductContext context)
        {
            _context = context;
        }

        // This action is called when the user navigates to the Checkout page.
        [HttpGet]
       public async Task<IActionResult> Checkout()
        {
            var viewModel = new ShoppingCartViewModel
            {
                // Assuming you've added an ExchangeRates property to your ShoppingCartViewModel
                ExchangeRates = await _context.ExchangeRates.ToListAsync()
            };

            return View(viewModel);
        }
        //public IActionResult Checkout()
        //{
        //    // You don't need to pass productIds here because you're handling it client-side.
        //    // Just return the view which will then use the localStorage data.
        //    return View();
        //}
    }
}
