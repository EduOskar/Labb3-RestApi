using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_RestApi.Models.LinkDto
{
    public class LinksDto
    {
        public int LinkId { get; set; }
        [Required]
        public int? FKPersonId { get; set; }
        [Required]
        public int? FKinterestId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
