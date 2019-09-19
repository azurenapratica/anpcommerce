using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ANPCommerce.Web.Models;

namespace ANPCommerce.Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ANPCommerce.Web.Models.ANPCommerceWebContext _context;

        public ProductsModel(ANPCommerce.Web.Models.ANPCommerceWebContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
