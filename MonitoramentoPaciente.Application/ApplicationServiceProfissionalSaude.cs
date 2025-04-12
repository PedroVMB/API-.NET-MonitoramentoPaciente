using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Application.Interfaces;
using MonitoramentoPaciente.Application.Mapper;
using MonitoramentoPaciente.Domain.Core.Interfaces.Services;

namespace MonitoramentoprofissionalSaude.Application;

public class ApplicationServiceProfissionalSaude : IApplicationServiceProfissionalSaude
{
    private readonly IServiceProfissionalSaude _serviceProfissionalSaude;
    private readonly IMapperProfissionalSaude _mapper;

    public ApplicationServiceProfissionalSaude(IServiceProfissionalSaude serviceProfissionalSaude, IMapperProfissionalSaude mapperProfissionalSaude)
    {
        this._serviceProfissionalSaude = serviceProfissionalSaude;
        this._mapper = mapperProfissionalSaude;
    }


    public void Add(ProfissionalSaudeDto profissionalSaudeDto)
    {
        var profissionalSaude = _mapper.MapperDtoToEntity(profissionalSaudeDto);
        _serviceProfissionalSaude.Add(profissionalSaude);
    }

    public void Update(ProfissionalSaudeDto profissionalSaudeDto)
    {
        var profissionalSaude = _mapper.MapperDtoToEntity(profissionalSaudeDto);
        _serviceProfissionalSaude.Update(profissionalSaude);
    }

    public void Delete(ProfissionalSaudeDto profissionalSaudeDto)
    {
        var cliente = _mapper.MapperDtoToEntity(profissionalSaudeDto);
        _serviceProfissionalSaude.Delete(cliente);
    }

    public IEnumerable<ProfissionalSaudeDto> GetAll()
    {
        var profissionalSaudes = _serviceProfissionalSaude.GetAll();
        return _mapper.MapperListTEntityDto(profissionalSaudes);
    }

    public ProfissionalSaudeDto? GetById(Guid id)
    {
        var profissionalSaude = _serviceProfissionalSaude.GetById(id);
        return _mapper.MapperEntityToDto(profissionalSaude);
    }
}