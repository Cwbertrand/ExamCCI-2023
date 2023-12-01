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

        //Pagination
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;


        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public int PageCount { get; set; }

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

                // It holds the query for a while before it's executed
                IQueryable<Model.Teacher> query = _context.Teachers;

                var totalCount = query.Count();

                PageCount = (int)Math.Ceiling((double)totalCount / PageSize);

                PageIndex = Math.Max(1, Math.Min(PageIndex, PageCount));
                query = query.Skip((PageIndex - 1) * PageSize).Take(PageSize);
                Teacher = await query.ToListAsync();
            }
        }
    }
}
