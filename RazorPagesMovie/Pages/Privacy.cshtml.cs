using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;


namespace RazorPagesMovie.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty]
        public PersonModel? PersonModel { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Privacy OnGet");

            if (PersonModel is not null)
            {
                _logger.LogInformation("Name={Name}", PersonModel.Name);
                _logger.LogInformation("Age={Age}", PersonModel.Age);
            }
        }

        public void OnPost()
        {
            _logger.LogInformation("Privacy OnPost");

            if (PersonModel is not null)
            {
                _logger.LogInformation("Name={Name}", PersonModel.Name);
                _logger.LogInformation("Age={Age}", PersonModel.Age);
            }
        }
    }
}
