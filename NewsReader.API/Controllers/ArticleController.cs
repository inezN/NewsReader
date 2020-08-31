using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsReader.Application.Interfaces;
using NewsReader.Persistance.Entities;

namespace NewsReader.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly INewsInitializeService _newsInitializeService;

        public ArticleController(INewsInitializeService newsInitializeService)
        {
            _newsInitializeService = newsInitializeService;
        }

        [Route("/api/LoadNews")]
        [HttpGet]
        public async Task<List<Application.DTOs.Article>> LoadNews()
        {
           return await _newsInitializeService.LoadingSourcesAndArticles();
        }

        //[Route("/api/ShowArticles")]
        //[HttpGet]
        //public async Task <List<Application.DTOs.Article>> GetArticles()
        //{
        //    return await _newsInitializeService.ArticlesForShowing();
        //}

    }
}