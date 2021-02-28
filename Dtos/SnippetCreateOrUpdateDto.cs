using System.ComponentModel.DataAnnotations;

namespace Snippy.Dtos
{
    public class SnippetCreateOrUpdateDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Expansion { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}