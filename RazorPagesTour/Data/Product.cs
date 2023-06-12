using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesTour.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public string ImageFile { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? Upload { get; set; }
    }
}
