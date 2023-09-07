using System.ComponentModel.DataAnnotations;

namespace ExampleECommerceProject.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(600, ErrorMessage = "Title must be between 1-600.")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Author must be between 1-300.")]
        public string Author { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price100 { get; set; }
    }
}
