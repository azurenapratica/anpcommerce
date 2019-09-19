using ANPCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANPCommerce.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ANPCommerce.Web.Models.ANPCommerceWebContext _context;
        public IList<Banner> Banners { get; set; }

        public IndexModel(ANPCommerce.Web.Models.ANPCommerceWebContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Banners = await _context.Banner.ToListAsync();
        }
    }
}
