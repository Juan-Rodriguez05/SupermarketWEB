using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<PayMode> Pay_mode { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pay_mode != null)
            {
                Pay_mode = await _context.Pay_mode.ToListAsync();
            }
        }
    }
}