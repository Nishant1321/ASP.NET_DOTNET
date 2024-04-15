using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDEAPP_1.Data;
using CRUDEAPP_1.Model;

namespace CRUDEAPP_1.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly CRUDEAPP_1.Data.CRUDEAPP_1Context _context;

        public IndexModel(CRUDEAPP_1.Data.CRUDEAPP_1Context context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
