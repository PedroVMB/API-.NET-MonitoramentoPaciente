using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Pessoa> Pessoas => Set<Pessoa>();
    public DbSet<ProfissionalSaude> Profissionais => Set<ProfissionalSaude>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
    public DbSet<DadoVital> DadosVitais => Set<DadoVital>();
    public DbSet<Dieta> Dietas => Set<Dieta>();
    public DbSet<Exercicio> Exercicios => Set<Exercicio>();
    public DbSet<Notificacao> Notificacoes => Set<Notificacao>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<ProfissionalSaude>()
            .HasOne(p => p.Usuario)
            .WithOne(u => u.ProfissionalDeSaude)
            .HasForeignKey<ProfissionalSaude>(p => p.UsuarioId);
        
        builder.Entity<Paciente>()
            .HasOne(p => p.Usuario)
            .WithOne(u => u.Paciente)
            .HasForeignKey<Paciente>(p => p.UsuarioId);
        
        builder.Entity<Paciente>()
            .HasMany(p => p.Consultas)
            .WithOne(c => c.Paciente)
            .HasForeignKey(c => c.PacienteId);

        builder.Entity<Paciente>()
            .HasMany(p => p.DadosVitais)
            .WithOne(dv => dv.Paciente)
            .HasForeignKey(dv => dv.PacienteId);

        builder.Entity<Paciente>()
            .HasMany(p => p.Dietas)
            .WithOne(d => d.Paciente)
            .HasForeignKey(d => d.PacienteId);

        builder.Entity<Paciente>()
            .HasMany(p => p.Exercicios)
            .WithOne(e => e.Paciente)
            .HasForeignKey(e => e.PacienteId);

        builder.Entity<Paciente>()
            .HasMany(p => p.Notificacoes)
            .WithOne(n => n.Paciente)
            .HasForeignKey(n => n.PacienteId);

    }
}
