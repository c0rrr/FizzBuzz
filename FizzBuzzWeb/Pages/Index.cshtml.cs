using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public FizzBuzzForm FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (FizzBuzz.Number % 3 == 0 & FizzBuzz.Number % 5 == 0)
                    TempData["AlertMessage"] = "FizzBuzz";
                else if (FizzBuzz.Number % 5 == 0)
                    TempData["AlertMessage"] = "Buzz";
                else if (FizzBuzz.Number % 3 == 0)
                    TempData["AlertMessage"] = "Fizz";
                else if (FizzBuzz.Number != null)
                    TempData["AlertMessage"] = "Liczba: "+ FizzBuzz.Number +" nie spełnia kryteriów FizzBuzz";

                return Page();
            }
            return RedirectToPage("./Privacy");
        }
    }
}