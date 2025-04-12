using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Application.Interfaces;

namespace MonitoramentoprofissionalSaude.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")] 
public class ProfissionalSaudeController : ControllerBase
{
    private readonly IApplicationServiceProfissionalSaude _applicationService;

    public ProfissionalSaudeController(IApplicationServiceProfissionalSaude applicationService)
    {
        this._applicationService = applicationService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var profissionalSaudeList = _applicationService.GetAll();
        return Ok(profissionalSaudeList);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var profissionalSaude = _applicationService.GetById(id);
        if (profissionalSaude == null)
            return NotFound();

        return Ok(profissionalSaude);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProfissionalSaudeDto profissionalSaudeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _applicationService.Add(profissionalSaudeDto);
        return CreatedAtAction(nameof(GetById), new { id = profissionalSaudeDto.Id }, profissionalSaudeDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ProfissionalSaudeDto profissionalSaudeDto)
    {
        if (id != profissionalSaudeDto.Id)
            return BadRequest("ID da URL não bate com o corpo da requisição.");

        _applicationService.Update(profissionalSaudeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var profissionalSaude = _applicationService.GetById(id);
        if (profissionalSaude == null)
            return NotFound();

        _applicationService.Delete(profissionalSaude);
        return NoContent();
    }
}