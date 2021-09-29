using CrabaxBlog.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrabaxBlog.Application.Services
{
    public class PostService
    {
        public async Task<JsonResponse<ArticleResponseDto>> GetAllAsync(string query)
        {
            var posts = await GetGNewsPostsAsync(query);
            return posts;
        }

        private async Task<JsonResponse<ArticleResponseDto>> GetGNewsPostsAsync(string query)
        {
            using (var http = new HttpClient())
            {
                try
                {
                    var apiQuery = $"https://gnews.io/api/v4/search?q={query}&token=1293fc5ae3c20a0f5774ff2729914e8f";
                    var jsonRes = await http.GetStringAsync(apiQuery);
                    var response = JsonConvert.DeserializeObject<ArticleResponseDto>(jsonRes);
                    return JsonResponse.Success().ToResultObject(response);
                }
                catch (Exception ex)
                {
                    return JsonResponse.Failed("Cannot query data at this time.").ToResultObject<ArticleResponseDto>();
                }
            }

        }
    }
}
