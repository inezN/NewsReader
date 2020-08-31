using NewsReader.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using NewsReader.Persistance.Entities;
using System.Threading.Tasks;

namespace NewsReader.Persistance.Repository.Interfaces
{
    public interface IArticleEntitiesRepository
    {
        void SaveArticleEntitiesInDb(List<Article> list);
        Task<List<Article>> GetArticleEntitiesOfDB();
    }
}
