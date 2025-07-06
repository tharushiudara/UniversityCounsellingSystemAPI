using Microsoft.AspNetCore.Mvc;
using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Services;

namespace UniversityCounsellingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    { 


            private readonly IFeedbackService _feedbackService;

            public FeedbackController(IFeedbackService feedbackService)
            {
                this._feedbackService = feedbackService;
            }

            [HttpGet("all")]
            public async Task<IActionResult> getFeedback()
            {
                Console.WriteLine("Pass");

                var feedback = await this._feedbackService.getAllFeedback();
                return Ok(feedback);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateFeedback([FromBody] Feedback feedback)
            {

                if (feedback == null)
                {
                    return BadRequest("Feedback data is null.");
                }

                try
                {
                    Console.WriteLine(feedback);
                    await _feedbackService.createFeedback(feedback);
                    return Ok("Feedback created successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpDelete("delete/{universityId}")]
            public async Task<IActionResult> DeleteFeedback(int universityId)
            {

                if (universityId == null)
                {
                    return BadRequest();
                }

                var feedbackDelete = await _feedbackService.findFeedbackByuniversityId(universityId);
                if (feedbackDelete == null)
                {
                    return NotFound();
                }

                try
                {
                    await _feedbackService.deleteFeedback(feedbackDelete);
                    return Ok("Feedback deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("update/{universityId}")]
            public async Task<IActionResult> UpdateFeedback(int universityId, [FromBody] Feedback feedback)
            {

                if (universityId != feedback.universityId)
                {
                    return BadRequest();
                }

                var feedbackUpdate = await _feedbackService.findFeedbackByuniversityId(universityId);
                if (feedback == null)
                {
                    return NotFound();
                }

                try
                {
                    await _feedbackService.updateFeedback(feedback);
                    return Ok(" Feedback updated successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }



        }
    }

