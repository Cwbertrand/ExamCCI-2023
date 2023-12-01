using ExamCCI_2023.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Data;
using System.Drawing.Printing;

namespace ExamCCI_2023.ApiController
{
    [Route("api/[Controller]")]
    public class CountryController : Controller
    {

        private readonly Model.ApplicationDbContext _context;

        public IList<Country> Country { get; set; }
        public CountryController(Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, int pageCount)
        {
            IQueryable<Country> query = _context.Countries;

            var totalCount = query.Count();

            pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

            pageIndex = Math.Max(1, Math.Min(pageIndex, pageCount));
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Ok(query.ToList());
        }

        [HttpPost("/add/country")]
        public IActionResult Post([FromBody] Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return Ok(country);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country updatedCountry)
        {
            updatedCountry.Id = id;

            _context.Attach(updatedCountry).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(updatedCountry);
        }
    }
}
