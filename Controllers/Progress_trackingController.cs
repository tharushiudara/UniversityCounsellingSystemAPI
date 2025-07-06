using Microsoft.AspNetCore.Mvc;
using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Services;

namespace UniversityCounsellingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Progress_trackingController : ControllerBase
    {

        
            private readonly IProgress_trackingService _progress_trackingService;

            public Progress_trackingController(IProgress_trackingService progress_trackingService)
            {
                this._progress_trackingService = progress_trackingService;
            }

            [HttpGet("all")]
            public async Task<IActionResult> getProgress_tracking()
            {
                Console.WriteLine("Pass");

                var progress_tracking = await this._progress_trackingService.getAllProgress_tracking();
                return Ok(progress_tracking);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateProgress_tracking([FromBody] Progress_tracking progress_tracking)
            {

                if (progress_tracking == null)
                {
                    return BadRequest("Progress_tracking data is null.");
                }

                try
                {
                    Console.WriteLine(progress_tracking);
                    await _progress_trackingService.createProgress_tracking(progress_tracking);
                    return Ok("Progress_tracking created successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpDelete("delete/{universityId}")]
            public async Task<IActionResult> DeleteProgress_tracking(int universityId)
            {

                if (universityId == null)
                {
                    return BadRequest();
                }

                var progress_trackingDelete = await _progress_trackingService.findProgress_trackingByuniversityId(universityId);
                if (progress_trackingDelete == null)
                {
                    return NotFound();
                }

                try
                {
                    await _progress_trackingService.deleteProgress_tracking(progress_trackingDelete);
                    return Ok("Progress_tracking deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("update/{universityId}")]
            public async Task<IActionResult> UpdateProgress_tracking(int universityId, [FromBody] Progress_tracking progress_tracking)
            {

                if (universityId != progress_tracking.universityId)
                {
                    return BadRequest();
                }

                var progress_trackingUpdate = await _progress_trackingService.findProgress_trackingByuniversityId(universityId);
                if (progress_tracking == null)
                {
                    return NotFound();
                }

                try
                {
                    await _progress_trackingService.updateProgress_tracking(progress_tracking);
                    return Ok(" Progress_tracking updated successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }



        }
    }

