using System;
using System.Collections.Generic;
using System.Text;

namespace NewsReader.Application.DTOs
{
    public class NewsCollection
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}
