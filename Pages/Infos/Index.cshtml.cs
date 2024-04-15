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
    public class IndexModel : PageModel
    {
        private readonly info.Data.infoContext _context;

        public IndexModel(info.Data.infoContext context)
        {
            _context = context;
        }

        public IList<Info> Info { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Info = await _context.Info.ToListAsync();
        }
    }
}
