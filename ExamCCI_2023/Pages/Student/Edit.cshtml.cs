using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;

namespace CciCour.Pages.ContactView
{
    public class EditModel : PageModel
    {
        private readonly Model.ApplicationDbContext _context;
        public List<Model.StudentGroup> Groups { get; set; }

        public SelectList AllGroups { get; set; }

        [BindProperty]
        public int[] SelectedGroups { get; set; }

        public EditModel(Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(c => c.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Student == null)
            {
                return NotFound();
            }
            AllGroups = new SelectList(await _context.Students.ToListAsync(), "Id", "Name");
            SelectedGroups = Student.Group.Select(cg => cg.GroupsId).ToArray();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                var groupIds = Request.Form["SelectedGroups"].Select(int.Parse).ToList();

                _context.StudentGroups.RemoveRange(_context.StudentGroups.Where(cg
                    => cg.Id == Student.Id));
                var studentGroup = SelectedGroups.Select(groupId => new Model.StudentGroup
                {
                    Id = Student.Id,
                    Label = Request.Form["WrittenLabel"]
                });

                _context.StudentGroups.AddRange(studentGroup);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ContactExists(Student.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
            return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
