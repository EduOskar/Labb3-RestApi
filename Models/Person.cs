using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_RestApi.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        //Navigation
        Collection<Interest> interests { get; set; }
        Collection <Links> Links { get; set; }
    }
}
