using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_RestApi.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        //Foreginkey
        [ForeignKey("person")]
        public int? FKPerson { get; set; }
        public Person? person { get; set; }
        //End of foreginkeys
        public string Title { get; set; }
        public string Description { get; set; }
       
        //Navigering
        ICollection<Links> links { get; set; }
    }
}
