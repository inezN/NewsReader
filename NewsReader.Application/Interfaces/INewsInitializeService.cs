using NewsReader.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader.Application.Interfaces
{
    public interface INewsInitializeService
    {
        Task<List<Article>> LoadingSourcesAndArticles();
        //Task<List<Article>> ArticlesForShowing();
    }
}
