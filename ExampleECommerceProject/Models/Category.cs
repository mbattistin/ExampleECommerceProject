using System.ComponentModel.DataAnnotations;

namespace ExampleECommerceProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Range(1,100, ErrorMessage ="Display order must be between 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
