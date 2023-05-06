using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_RestApi.Models.InterestDTO
{
    public class InterestCreateDto
    {
        //Foreginkey
        public int? FKPerson { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
