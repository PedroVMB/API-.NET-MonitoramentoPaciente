using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.Mapper;

public class MapperProfissionalSaude : IMapperProfissionalSaude
{
    IEnumerable<ProfissionalSaude> _profissionalSaudeList = new List<ProfissionalSaude>();
    public ProfissionalSaude MapperDtoToEntity(ProfissionalSaudeDto dto)
    {
        return new ProfissionalSaude
        {
            Id = dto.Id ?? Guid.NewGuid(),
            Nome = dto.Nome,
            Email = dto.Email,
            Genero = dto.Genero,
            DataNascimento = dto.DataNascimento,
            Idade = dto.Idade,
            Altura = dto.Altura,
            Usuario = dto.Usuario,
            Especialidade = dto.Especialidade,
        };
    }

    public IEnumerable<ProfissionalSaudeDto> MapperListTEntityDto(IEnumerable<ProfissionalSaude> listTEntities)
    {
        return listTEntities.Select(p => new ProfissionalSaudeDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Email = p.Email,
            Genero = p.Genero,
            DataNascimento = p.DataNascimento,
            Idade = p.Idade,
            Altura = p.Altura,
            Usuario = p.Usuario,
            Especialidade = p.Especialidade,
        });
    }

    public ProfissionalSaudeDto MapperEntityToDto(ProfissionalSaude tEntity)
    {
        return new ProfissionalSaudeDto
        {
            Id = tEntity.Id,
            Nome = tEntity.Nome,
            Email = tEntity.Email,
            Genero = tEntity.Genero,
            DataNascimento = tEntity.DataNascimento,
            Idade = tEntity.Idade,
            Altura = tEntity.Altura,
            Usuario = tEntity.Usuario,
            Especialidade = tEntity.Especialidade,
        };
    }
}