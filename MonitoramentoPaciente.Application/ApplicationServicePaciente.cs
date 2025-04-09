using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Application.Mapper;
using MonitoramentoPaciente.Domain.Core.Interfaces.Services;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application;

public class ApplicationServicePaciente : IApplicationServicePaciente
{
    private readonly IServicePaciente _servicePaciente;
    private readonly IMapperPaciente _mapper;

    public ApplicationServicePaciente(IServicePaciente servicePaciente, IMapperPaciente mapper)
    {
        this._servicePaciente = servicePaciente;
        this._mapper = mapper;
    }
    
    public void Add(PacienteDto pacienteDto)
    {
        var paciente = _mapper.MapperDtoToEntity(pacienteDto);
        _servicePaciente.Add(paciente);
    }

    public void Update(PacienteDto pacienteDto)
    {
       var paciente = _mapper.MapperDtoToEntity(pacienteDto);
       _servicePaciente.Update(paciente);
    }

    public void Delete(PacienteDto pacienteDto)
    {
        var cliente = _mapper.MapperDtoToEntity(pacienteDto);
        _servicePaciente.Delete(cliente);
    }

    public IEnumerable<PacienteDto> GetAll()
    {
        var pacientes = _servicePaciente.GetAll();
        return _mapper.MapperListTEntityDto(pacientes);
    }

    public PacienteDto? GetById(Guid id)
    {
        var paciente = _servicePaciente.GetById(id);
        return _mapper.MapperEntityToDto(paciente);
    }
}