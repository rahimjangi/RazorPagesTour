namespace RazorPagesTour.Data.Models
{
    public class SurveyItem
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
