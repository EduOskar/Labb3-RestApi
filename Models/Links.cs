using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_RestApi.Models
{
    public class Links
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }
        //ForeignKey objects
        [ForeignKey("person")]
        public int? FKPersonId { get; set; }
        public Person? person { get; set; }
        //
        [ForeignKey("interest")]
        public int? FKinterestId { get; set; }
        public Interest? interest { get; set; }
        //End of foreginkeys
        public string Title { get; set; }
        public string URL { get; set; }


    }
}
