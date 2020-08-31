using NewsReader.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NewsReader.Application.DTOs;

namespace NewsReader.Application.services
{
    public class NewsApiService : INewsApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly MySettings _settings;

        public NewsApiService(IHttpClientFactory clientFactory, IOptionsMonitor<MySettings> settings)
        {
            _clientFactory = clientFactory;
            _settings = settings.CurrentValue;
        }

        public async Task<NewsCollection> LoadNews()
        {
            var url = _settings.Url;
            var apiKey = _settings.Key;
          
            var createdClient = _clientFactory.CreateClient();

            var response = await createdClient.GetAsync($"{url}{apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("News articles not found.");
            }

            var newsCollection = await response.Content.ReadAsAsync<NewsCollection>();

            return newsCollection;
        }
    } 
}
