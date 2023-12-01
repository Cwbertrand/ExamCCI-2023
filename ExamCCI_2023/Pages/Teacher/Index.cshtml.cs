using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        public IList<Model.Teacher> Teacher { get;set; } = default!;

    }
}
