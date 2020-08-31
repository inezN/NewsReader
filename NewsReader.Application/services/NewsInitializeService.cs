using AutoMapper;
using NewsReader.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsReader.Application.DTOs;
using NewsReader.Persistance.Repository.Interfaces;
using Article = NewsReader.Application.DTOs.Article;
using Source = NewsReader.Application.DTOs.Source;
using NewsReader.Persistance;
using Microsoft.EntityFrameworkCore;

namespace NewsReader.Application.services
{
    public class NewsInitializeService : INewsInitializeService
    {
        private readonly INewsApiService _newsApiService;
        private readonly IArticleEntitiesRepository _articleEntitiesRepository;
        private readonly ISourceEntitiesRepository _sourceEntitiesRepository;
        private readonly IMapper _mapper;
        private readonly NewsReaderContext _context; 

        public NewsInitializeService(NewsReaderContext context, INewsApiService newsapiservice, IArticleEntitiesRepository articleEntitiesRepository, ISourceEntitiesRepository sourceEntitiesRepository, IMapper mapper)
        {
            _newsApiService = newsapiservice;
            _articleEntitiesRepository = articleEntitiesRepository;
            _sourceEntitiesRepository = sourceEntitiesRepository;
            _mapper = mapper;
            _context = context; 
        }

        public async Task<List<Application.DTOs.Article>> LoadingSourcesAndArticles()  
        {
            CleanDataBase();
           
            var newsCollection = await _newsApiService.LoadNews();
           
            var allTheSources = GetAllTheDifferentSources(newsCollection);
            var allTheArticles = GetTheArticles(newsCollection, allTheSources); 

            var articles = _mapper.Map<List<Article>, List<Persistance.Entities.Article>>(allTheArticles);
            var sources = _mapper.Map<List<Source>, List<Persistance.Entities.Source>>(allTheSources);

            _sourceEntitiesRepository.SaveSourceEntitiesInDb(sources);
            _articleEntitiesRepository.SaveArticleEntitiesInDb(articles);

            return await ArticlesForShowing();
        }

        private List<Article> GetTheArticles(NewsCollection allArticles, List<Source> sources) 
        {
            var dtoArticles = new List<Article>();

            foreach (var article in allArticles.Articles)
            {
                foreach (var source in sources)
                {
                    if (source.Name == article.Source.Name)
                    {
                        article.SourceGuid = source.SourceGuid;
                        dtoArticles.Add(article);
                    }
                }
            }
            return dtoArticles;
        }

        private List<Source> GetAllTheDifferentSources(NewsCollection allArticles)
        {
            var sources = new List<Source>();
            foreach (var article in allArticles.Articles)
            {
                var containingSource = sources.Any(x => x.Name == article.Source.Name);

                if (!containingSource)
                {
                    article.Source.SourceGuid = Guid.NewGuid();
                    sources.Add(article.Source);
                }
            }
            return sources;
        }

        private void CleanDataBase()
        {
            _context.Database.EnsureDeleted(); 
            _context.Database.Migrate();  
        }

        public async Task<List<Article>> ArticlesForShowing() 
        {
            var sourceEntities = await _sourceEntitiesRepository.GetSourceEntitiesOfDB();
            var articleEntities = await _articleEntitiesRepository.GetArticleEntitiesOfDB();

            List<Article> articles = new List<Article>();

            foreach (var article in articleEntities)
            {
                var sourceOfArticle = sourceEntities.Where(e => e.SourceGuid == article.SourceGuid).FirstOrDefault();

                var articleDTO = _mapper.Map<Persistance.Entities.Article, Article>(article);
                var sourceDTO = _mapper.Map<Persistance.Entities.Source, Source>(sourceOfArticle);
                
                articleDTO.Source = sourceDTO;

                articles.Add(articleDTO);
            }

            return articles;
        }
    }
}
