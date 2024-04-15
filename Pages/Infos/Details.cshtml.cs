using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using info.Data;
using info.Model;

namespace info.Pages.Infos
{
    public class DetailsModel : PageModel
    {
        private readonly info.Data.infoContext _context;

        public DetailsModel(info.Data.infoContext context)
        {
            _context = context;
        }

        public Info Info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info.FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            else
            {
                Info = info;
            }
            return Page();
        }
    }
}
