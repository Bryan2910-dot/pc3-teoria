using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pc3_teoria.Dto;
using pc3_teoria.Interfaces;

namespace pc3_teoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsApiController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsApiController(INewsService newsService) {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostWithExtrasDto>>> Get() {
            var data = await _newsService.GetEnrichedPostsAsync();
            return Ok(data);
        }
    }
}