using System.ComponentModel.DataAnnotations;

namespace Labb3_RestApi.Models.PersonDTO
{
    public class PersonUpdateDto
    {
        public int PersonId { get; set; }
        [Required]
        [StringLength(maximumLength: 45)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 45)]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Phone { get; set; }
    }
}
