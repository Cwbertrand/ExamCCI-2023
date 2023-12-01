using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ExamCCI_2023.Pages.Teacher
{
    public class PaginationModel
    {
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;


        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;


        [BindProperty(SupportsGet = true)]
        public int PageCount { get; set; }
    }
}
