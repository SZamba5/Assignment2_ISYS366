using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty(SupportsGet = true)]
    public PersonModel? PersonModel { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        _logger.LogInformation("Index OnGet");
        LogPersonModel();

        if (PersonModel != null && !string.IsNullOrEmpty(PersonModel.Name) && PersonModel.Age > 0)
        {
            return RedirectToPage("Privacy", new { name = PersonModel.Name, age = PersonModel.Age });
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        _logger.LogInformation("Index OnPost");
        LogPersonModel();
        return RedirectToPage("Privacy", new { name = PersonModel?.Name, age = PersonModel?.Age });
    }

    // Handles cross-page post requests
    public IActionResult OnPostCrossPost(string name, int age)
    {
        _logger.LogInformation("Index OnPostCrossPost");

        return RedirectToPage("Privacy", new { name = PersonModel?.Name, age = PersonModel?.Age });
    }

    private void LogPersonModel()
    {
        if (PersonModel != null)
        {
            _logger.LogInformation($"Name={PersonModel.Name}");
            _logger.LogInformation($"Age={PersonModel.Age}");
        }
    }
}
