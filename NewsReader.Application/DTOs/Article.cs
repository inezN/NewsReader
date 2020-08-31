using System;
using NewsReader.Application.DTOs;

namespace NewsReader.Application.DTOs
{
    public class Article
    {
        public int ArticleId { get; set; }
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
        public Guid SourceGuid { get; set; }
    }
}
