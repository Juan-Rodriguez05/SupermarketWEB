using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Validar si el correo ya existe
            var exists = _context.Users.Any(u => u.Email == User.Email);
            if (exists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe una cuenta con este correo.");
                return Page();
            }

            // Hashear la contraseña
            var hasher = new PasswordHasher<User>();
            User.Password = hasher.HashPassword(User, User.Password);

            // Agregar el usuario a la base de datos
            _context.Users.Add(User);

            // Guardar cambios
            await _context.SaveChangesAsync();

            return RedirectToPage("Login");
        }
    }
}
