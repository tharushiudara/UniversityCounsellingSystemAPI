using Microsoft.AspNetCore.Mvc;
using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Services;

namespace UniversityCounsellingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Session_scheduleController : ControllerBase
    {
       
            private readonly ISession_scheduleService _session_scheduleService;

            public Session_scheduleController(ISession_scheduleService session_scheduleService)
            {
                this._session_scheduleService = session_scheduleService;
            }

            [HttpGet("all")]
            public async Task<IActionResult> getSession_schedule()
            {
                Console.WriteLine("Pass");

                var session_schedule = await this._session_scheduleService.getAllSession_schedule();
                return Ok(session_schedule);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateSession_schedule([FromBody] Session_schedule session_schedule)
            {

                if (session_schedule == null)
                {
                    return BadRequest("Session_schedule data is null.");
                }

                try
                {
                    Console.WriteLine(session_schedule);
                    await _session_scheduleService.createSession_schedule(session_schedule);
                    return Ok("Session_schedule created successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpDelete("delete/{session_NO}")]
            public async Task<IActionResult> DeleteSession_schedule(int session_NO)
            {

                if (session_NO == null)
                {
                    return BadRequest();
                }

                var session_scheduleDelete = await _session_scheduleService.findSession_scheduleBySession_NO(session_NO);
                if (session_scheduleDelete == null)
                {
                    return NotFound();
                }

                try
                {
                    await _session_scheduleService.deleteSession_schedule(session_scheduleDelete);
                    return Ok("Session_schedule deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("update/{session_NO}")]
            public async Task<IActionResult> UpdateSession_schedule(int session_NO, [FromBody] Session_schedule session_schedule)
            {

                if (session_NO != session_schedule.session_NO)
                {
                    return BadRequest();
                }

                var session_scheduleUpdate = await _session_scheduleService.findSession_scheduleBySession_NO(session_NO);
                if (session_schedule == null)
                {
                    return NotFound();
                }

                try
                {
                    await _session_scheduleService.updateSession_schedule(session_schedule);
                    return Ok("Session_schedule updated successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }



        }
    }

