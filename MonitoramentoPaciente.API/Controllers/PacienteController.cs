using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonitoramentoPaciente.Application;
using MonitoramentoPaciente.Application.Dtos;

namespace MonitoramentoPaciente.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")] 
public class PacienteController : ControllerBase
{
    private readonly IApplicationServicePaciente _applicationService;

    public PacienteController(IApplicationServicePaciente applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var pacientes = _applicationService.GetAll();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var paciente = _applicationService.GetById(id);
        if (paciente == null)
            return NotFound();

        return Ok(paciente);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PacienteDto pacienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _applicationService.Add(pacienteDto);
        return CreatedAtAction(nameof(GetById), new { id = pacienteDto.Id }, pacienteDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] PacienteDto pacienteDto)
    {
        if (id != pacienteDto.Id)
            return BadRequest("ID da URL não bate com o corpo da requisição.");

        _applicationService.Update(pacienteDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var paciente = _applicationService.GetById(id);
        if (paciente == null)
            return NotFound();

        _applicationService.Delete(paciente);
        return NoContent();
    }
}