using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.Mapper;

public interface IMapperPaciente : IMapperBase<Paciente, PacienteDto>
{
}