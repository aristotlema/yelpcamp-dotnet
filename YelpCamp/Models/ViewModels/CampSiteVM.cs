using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YelpCamp.Models.ViewModels
{
    public class CampSiteVM
    {
        public CampSite CampSite { get; set; }
        public IEnumerable<Comment> CommentList { get; set; }
    }
}
