using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pc3_teoria.Interfaces;
using pc3_teoria.Models;

namespace pc3_teoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService) {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Feedback feedback) {
            var added = await _feedbackService.AddFeedbackAsync(feedback);
            if (!added) return BadRequest("Ya existe feedback para ese post.");
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> Get() {
            return await _feedbackService.GetFeedbacksAsync();
        }
    }
}