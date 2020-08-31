using System;
using System.Collections.Generic;
using System.Text;

namespace NewsReader.Persistance.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
        public Guid SourceGuid { get; set; }
        //public virtual Source Source { get; set; }
    }
}
