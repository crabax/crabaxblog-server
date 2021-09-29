using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabaxBlog.Application.DTOs
{
    public class ArticleDto
    {
        public string Url { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }
    }
}
