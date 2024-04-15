using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIST.Data;
using LIST.Model;

namespace LIST.Pages.Lists
{
    public class DetailsModel : PageModel
    {
        private readonly LIST.Data.LISTContext _context;

        public DetailsModel(LIST.Data.LISTContext context)
        {
            _context = context;
        }

        public List List { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = await _context.List.FirstOrDefaultAsync(m => m.Id == id);
            if (list == null)
            {
                return NotFound();
            }
            else
            {
                List = list;
            }
            return Page();
        }
    }
}
