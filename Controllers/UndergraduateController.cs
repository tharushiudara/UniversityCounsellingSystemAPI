using Microsoft.AspNetCore.Mvc;
using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Services;

namespace UniversityCounsellingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UndergraduateController :ControllerBase
    {

        
            private readonly IUndergraduateService _undergraduateService;

            public UndergraduateController(IUndergraduateService undergraduateService)
            {
                this._undergraduateService = undergraduateService;
            }

            [HttpGet("all")]
            public async Task<IActionResult> getUndergraduate()
            {
                Console.WriteLine("Pass");

                var undergraduate = await this._undergraduateService.getAllUndergraduate();
                return Ok(undergraduate);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateUndergraduate([FromBody] Undergraduate undergraduate)
            {

                if(undergraduate == null)
                {
                    return BadRequest("Undergraduate data is null.");
                }

                try
                {
                    Console.WriteLine(undergraduate);
                    await _undergraduateService.createUndergraduate(undergraduate);
                    return Ok("Undergraduate created successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpDelete("delete/{universityId}")]
            public async Task<IActionResult> DeleteUndergraduate(int universityId)
            {

                if (universityId == null)
                {
                    return BadRequest();
                }

                var undergraduateDelete = await _undergraduateService.findUndergraduateByuniversityId(universityId);
                if (undergraduateDelete == null)
                {
                    return NotFound();
                }

                try
                {
                    await _undergraduateService.deleteUndergraduate(undergraduateDelete);
                    return Ok("Undergraduate deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("update/{universityId}")]
            public async Task<IActionResult> UpdateUndergraduate(int universityId, [FromBody] Undergraduate undergraduate)
            {

                if (universityId != undergraduate.universityId)
                {
                    return BadRequest();
                }

                var undergraduateUpdate = await _undergraduateService.findUndergraduateByuniversityId(universityId);
                if (undergraduate == null)
                {
                    return NotFound();
                }

                try
                {
                    await _undergraduateService.updateUndergraduate(undergraduate);
                    return Ok(" Undergraduate updated successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }



        }
    }

