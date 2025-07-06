using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Services;

namespace UniversityCounsellingSystemAPI.Controllers
{

        [ApiController]
        [Route("[controller]")]
        public class CounsellorController : ControllerBase
        {
            private readonly ICounsellorService _counsellorService;

            public CounsellorController(ICounsellorService counsellorService)
            {
                this._counsellorService = counsellorService;
            }

            [HttpGet("all")]
            public async Task<IActionResult> getCounsellors()
            {
                Console.WriteLine("Pass");

                var counsellor = await this._counsellorService.getAllCounsellor();
                return Ok(counsellor);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateCounsellors([FromBody] Counsellor counsellor)
            {

                if (counsellor == null)
                {
                    return BadRequest("Counsellor data is null.");
                }

                try
                {
                    Console.WriteLine(counsellor);
                    await _counsellorService.createCounsellor(counsellor);
                    return Ok("Counsellor created successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

        [HttpDelete("delete/{email}")]
        public async Task<IActionResult> DeleteCounsellors(string email)
        {

            if (email == null)
            {
                return BadRequest();
            }

            var counsellorDelete = await _counsellorService.findCounsellorByemail(email);
            if (counsellorDelete == null)
            {
                return NotFound();
            }

            try
            {
                await _counsellorService.deleteCounsellor(counsellorDelete);
                return Ok("Counsellor deleted successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging service here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{email}")]
        public async Task<IActionResult> UpdateCounsellors(string email, [FromBody] Counsellor counsellor)
        {

            if (email != counsellor.email)
            {
                return BadRequest();
            }

            var counsellorUpdate = await _counsellorService.findCounsellorByemail(email);
            if (counsellor == null)
            {
                return NotFound();
            }

            try
            {
                await _counsellorService.updateCounsellor(counsellor);
                return Ok(" Counsellor updated successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging service here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}



