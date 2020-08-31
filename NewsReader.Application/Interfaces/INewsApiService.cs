using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  NewsReader.Application.DTOs;

namespace NewsReader.Application.Interfaces
{
    public interface INewsApiService
    {
        Task<NewsCollection> LoadNews();
    }
}
