namespace RazorPagesTour.Data.Models
{
    public class HelpTicket
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
