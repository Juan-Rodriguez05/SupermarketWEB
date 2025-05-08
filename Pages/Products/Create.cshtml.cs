using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SupermarketWEB.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Categories { get; set; } 

        public void OnGet()
        {
            Categories = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
        }

        [BindProperty]

        public Product Product { get; set; } 

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
                return Page();
            }
            if (string.IsNullOrEmpty(Product.Name) || Product.Price <= 0 || Product.Stock < 0 || Product.CategoryId <= 0)
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
                ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
                return Page();
            }

            
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Product.CategoryId);

            if (category == null)
            {
                
                ModelState.AddModelError("", "Invalid category selected.");
                ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return RedirectToPage("./Index");
        }
    }
}