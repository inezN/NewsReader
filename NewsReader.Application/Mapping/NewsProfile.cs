using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NewsReader.Application.DTOs;
using NewsReader.Persistance.Entities;
using Article = NewsReader.Persistance.Entities.Article;
using Source = NewsReader.Persistance.Entities.Source;

namespace NewsReader.Application.Mapping
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<DTOs.Article, Article>();
            CreateMap<DTOs.Source, Source>();

            CreateMap<Article, DTOs.Article>();
            CreateMap<Source, DTOs.Source>();
        }
    }
}
