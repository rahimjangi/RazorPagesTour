using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTour.Data.Models;
using System.Text.Json;

namespace RazorPagesTour.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<SurveyItem>? SurveyResults { get; set; } = new List<SurveyItem>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var rawJson = System.IO.File.ReadAllText("wwwroot/sampledata/survey.json");
            var resultJson = JsonSerializer.Deserialize<List<SurveyItem>>(rawJson);
            if (resultJson != null & SurveyResults != null)
            {
                SurveyResults!.AddRange(resultJson!);

            }
        }
    }
}
