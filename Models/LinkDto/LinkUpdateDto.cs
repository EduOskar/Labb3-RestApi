using Microsoft.Build.Framework;

namespace Labb3_RestApi.Models.LinkDto
{
    public class LinkUpdateDto
    {
        [Required]
        public int LinkId { get; set; }
        public int? FKPersonId { get; set; }
        public int? FKinterestId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
