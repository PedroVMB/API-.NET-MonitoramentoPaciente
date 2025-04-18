﻿using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.Mapper;

public class MapperPaciente : IMapperPaciente
{
    IEnumerable<PacienteDto> _pacienteDtos = new List<PacienteDto>();    
    
    
    public Paciente MapperDtoToEntity(PacienteDto dto)
    {
        return new Paciente
        {
            Id = dto.Id ?? Guid.NewGuid(),
            Nome = dto.Nome,
            Email = dto.Email,
            Genero = dto.Genero,
            DataNascimento = dto.DataNascimento,
            Idade = dto.Idade,
            Altura = dto.Altura,
            Usuario = dto.Usuario,
            Consultas = dto.Consultas ?? new List<Consulta>(),
            DadosVitais = dto.DadosVitais ?? new List<DadoVital>(),
            Dietas = dto.Dietas ?? new List<Dieta>(),
            Exercicios = dto.Exercicios ?? new List<Exercicio>(),
            Notificacoes = dto.Notificacoes ?? new List<Notificacao>(),
        };
    }

    public IEnumerable<PacienteDto> MapperListTEntityDto(IEnumerable<Paciente> listTEntities)
    {
        var dto = listTEntities.Select(c => new PacienteDto
        {
            Id = c.Id,
            Nome = c.Nome,
            Email = c.Email,
            Genero = c.Genero,
            DataNascimento = c.DataNascimento,
            Idade = c.Idade,
            Altura = c.Altura,
            Usuario = c.Usuario,
            Consultas = c.Consultas,
            DadosVitais = c.DadosVitais,
            Dietas = c.Dietas,
            Exercicios = c.Exercicios,
            Notificacoes = c.Notificacoes,
        });
        
        return dto;
    }

    public PacienteDto MapperEntityToDto(Paciente tEntity)
    {
        return new PacienteDto
        {
            Id = tEntity.Id,
            Nome = tEntity.Nome,
            Email = tEntity.Email,
            Genero = tEntity.Genero,
            DataNascimento = tEntity.DataNascimento,
            Idade = tEntity.Idade,
            Altura = tEntity.Altura,
            Usuario = tEntity.Usuario,
            Consultas = tEntity.Consultas ?? new List<Consulta>(),
            DadosVitais = tEntity.DadosVitais ?? new List<DadoVital>(),
            Dietas = tEntity.Dietas ?? new List<Dieta>(),
            Exercicios = tEntity.Exercicios ?? new List<Exercicio>(),
            Notificacoes = tEntity.Notificacoes ?? new List<Notificacao>(),
        };
    }
}