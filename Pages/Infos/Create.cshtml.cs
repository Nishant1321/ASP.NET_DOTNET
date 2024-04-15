using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using info.Data;
using info.Model;

namespace info.Pages.Infos
{
    public class CreateModel : PageModel
    {
        private readonly info.Data.infoContext _context;

        public CreateModel(info.Data.infoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Info Info { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Info.Add(Info);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
