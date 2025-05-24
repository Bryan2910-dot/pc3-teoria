using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pc3_teoria.Controllers
{
    [Route("[controller]")]
    public class NewsController : Controller {
    private readonly ApiService _api;

    public NewsController(ApiService api) {
        _api = api;
    }

    public async Task<IActionResult> Index() {
        var posts = await _api.GetPostsAsync();
        return View(posts);
    }

    public async Task<IActionResult> Details(int id) {
        var post = (await _api.GetPostsAsync()).FirstOrDefault(p => p.Id == id);
        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> React(int id, string sentimiento) {
        await _api.SendFeedbackAsync(id, sentimiento);
        return RedirectToAction("Details", new { id });
    }
}
}