using System.ComponentModel.DataAnnotations;

namespace Snippy.Models
{
    public class Snippet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Expansion { get; set; }

        [Required]
        public string Code { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}