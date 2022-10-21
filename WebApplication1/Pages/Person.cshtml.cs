using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class PersonModel : PageModel
    {
        public string[]? Persons { get; set; }
        public string? PersonName { get; set; }

        public void OnGet(int id)
        {
            Persons = new string[] { "Tom", "Hel", "Tim" };
            PersonName = Persons[id];
        }
    }
}
