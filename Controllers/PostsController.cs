using CrabaxBlog.Application.DTOs;
using CrabaxBlog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabaxBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "q")]string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest();
            }

            var posts = await _postService.GetAllAsync(query);
            if (!posts.Ok)
            {
                return UnprocessableEntity(posts);
            }

            //Response formatted as GNews.io
            return Ok(posts.ResultObject);
        }
    }
}
