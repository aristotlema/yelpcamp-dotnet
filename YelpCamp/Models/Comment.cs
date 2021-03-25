using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YelpCamp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        public string AuthorAvatar { get; set; }
        [Required]
        public string CommentBody { get; set; }

        public int CampSiteId { get; set; }
        [ForeignKey("CampSiteId")]
        public virtual CampSite CampSite { get; set; }
    }
}
