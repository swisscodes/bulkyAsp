using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Display Order"), Range(1, 1000, ErrorMessage = "Display Order must be between 1-1000")] //this is for ui part what what want to display
        public int DisplayOrder { get; set; }
    }
}
