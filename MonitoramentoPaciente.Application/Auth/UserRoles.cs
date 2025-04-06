namespace MonitoramentoPaciente.Application.Auth;

public enum RoleType
{
    Admin,
    Paciente,
    Profissional
}

public static class UserRoles
{
    public static string Admin => RoleType.Admin.ToString();
    public static string Paciente => RoleType.Paciente.ToString();
    public static string Profissional => RoleType.Profissional.ToString();

    public static bool IsValid(string role) =>
        Enum.TryParse<RoleType>(role, out _);
}
