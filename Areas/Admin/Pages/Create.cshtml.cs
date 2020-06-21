using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLabsV05.DAL.Data;
using WebLabsV05.DAL.Entities;

namespace Lab1.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private IHostingEnvironment _environment;

        private readonly WebLabsV05.DAL.Data.ApplicationDbContext _context;

        public CreateModel(WebLabsV05.DAL.Data.ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["DishGroupId"] = new SelectList(_context.DishGroups, "DishGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        [BindProperty]
        public IFormFile image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            if (image != null)
            {
                Dish.Image = Dish.DishId +
                Path.GetExtension(image.FileName);
                var path = Path.Combine(_environment.WebRootPath, "images",
                Dish.Image);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                };
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
