using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;

namespace ExamCCI_2023.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        private readonly Model.ApplicationDbContext _context;

        public IndexModel(Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Model.Teacher> Teacher { get;set; } = default!;

        [Authorize]
        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Teacher = await _context.Teachers.ToListAsync();
            }
        }
    }
}
