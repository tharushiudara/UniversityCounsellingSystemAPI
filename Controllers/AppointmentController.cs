using Microsoft.AspNetCore.Mvc;
using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Services;

namespace UniversityCounsellingSystemAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {


        private readonly IAppointment_Service _appointmentService;

            public AppointmentController(IAppointment_Service appointmentService)
            {
                this._appointmentService = appointmentService;
            }

            [HttpGet("all")]
            public async Task<IActionResult> getAppointment()
            {
                Console.WriteLine("Pass");

                var appointment = await this._appointmentService.getAllAppointment();
                return Ok(appointment);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
            {

                if (appointment == null)
                {
                    return BadRequest("Appointment data is null.");
                }

                try
                {
                    Console.WriteLine(appointment);
                    await _appointmentService.createAppointment(appointment);
                    return Ok("Appointment created successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpDelete("delete/{universityId}")]
            public async Task<IActionResult> DeleteAppointment(int universityId)
            {

                if (universityId == null)
                {
                    return BadRequest();
                }

                var appointmentDelete = await _appointmentService.findAppointmentByuniversityId(universityId);
                if (appointmentDelete == null)
                {
                    return NotFound();
                }

                try
                {
                    await _appointmentService.deleteAppointment(appointmentDelete);
                    return Ok("Appointment deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("update/{universityId}")]
            public async Task<IActionResult> UpdateAppointment(int universityId, [FromBody] Appointment appointment)
            {

                if (universityId != appointment.universityId)
                {
                    return BadRequest();
                }

                var appointmentUpdate = await _appointmentService.findAppointmentByuniversityId(universityId);
                if (appointment == null)
                {
                    return NotFound();
                }

                try
                {
                    await _appointmentService.updateAppointment(appointment);
                    return Ok(" Appointment updated successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging service here)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }



        }
    }

