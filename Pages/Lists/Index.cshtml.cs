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
    public class IndexModel : PageModel
    {
        private readonly LIST.Data.LISTContext _context;

        public IndexModel(LIST.Data.LISTContext context)
        {
            _context = context;
        }

        public IList<List> List { get;set; } = default!;

        public async Task OnGetAsync()
        {
            List = await _context.List.ToListAsync();
        }
    }
}
