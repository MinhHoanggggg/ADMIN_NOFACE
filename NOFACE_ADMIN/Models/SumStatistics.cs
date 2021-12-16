using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOFACE_ADMIN.Models
{
    public class SumStatistics
    {
        public int SumPosts { get; set; }
        public int SumUsers { get; set; }
        public int UserMonth { get; set; }
        public int PostsMonth { get; set; }
    }
}