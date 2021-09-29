using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabaxBlog.Application.DTOs
{
    public class ArticleResponseDto
    {
        public int TotalArticles { get; set; }
        public List<ArticleDto> Articles { get; set; }
    }
}
