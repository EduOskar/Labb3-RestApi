using System.ComponentModel.DataAnnotations;

namespace Labb3_RestApi.Models.LinkDto
{
    public class LinkCreateDto
    {
        public int? FKPersonId { get; set; }
        public int? FKinterestId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
