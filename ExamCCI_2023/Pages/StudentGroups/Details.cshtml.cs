using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;

namespace ExamCCI_2023.Pages.StudentGroups
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentGroup StudentGroup { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.StudentGroups == null)
            {
                return NotFound();
            }

            var studentgroup = await _context.StudentGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (studentgroup == null)
            {
                return NotFound();
            }
            else
            {
                StudentGroup = studentgroup;
            }
            return Page();
        }
    }
}
