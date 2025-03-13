using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFBlog.Models
{
    public class BlogInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int LikeCount { get; set; }
        public int FavoriteCount { get; set; }
        public int CommentCount { get; set; }
    }
}
