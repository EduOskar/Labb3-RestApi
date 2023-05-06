using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_RestApi.Models.InterestDTO
{
    public class InterestDto
    {
        public int InterestId { get; set; }
        public int? FKPerson { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
