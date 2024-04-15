using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using info.Data;
using info.Model;

namespace info.Pages.Infos
{
    public class EditModel : PageModel
    {
        private readonly info.Data.infoContext _context;

        public EditModel(info.Data.infoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Info Info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info =  await _context.Info.FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            Info = info;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(Info.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InfoExists(int id)
        {
            return _context.Info.Any(e => e.Id == id);
        }
    }
}
