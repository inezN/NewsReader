using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsReader.Persistance.Entities;
using NewsReader.Persistance.Repository.Interfaces;


namespace NewsReader.Persistance.Repository
{
    public class ArticleEntitiesRepository : IArticleEntitiesRepository
    {
        private readonly NewsReaderContext _context;

        public ArticleEntitiesRepository(NewsReaderContext context)
        {
            _context = context;
        }

        public void SaveArticleEntitiesInDb(List<Article> list) 
        {
            _context.AddRange(list);
            _context.SaveChanges();
        }

        public async Task<List<Article>> GetArticleEntitiesOfDB()
        {
    
            return await _context.Article.ToListAsync();
        }
    }
}
