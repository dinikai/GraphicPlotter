using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class AboutModel : PageModel
    {
        private Random random = new();
        public int randomInt, forMax;

        public void OnGet(int max, int forMax)
        {
            randomInt = random.Next(max);
            this.forMax = forMax;
        }
    }
}
