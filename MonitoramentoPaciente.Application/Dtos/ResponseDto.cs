namespace MonitoramentoPaciente.Application.Dtos;

public class ResponseDto
{
    public ResponseDto(bool sucesso, string message)
    {
        Status = sucesso ? "Success" : "Error";
        Message = message;
    }

    public string? Status { get; set; }
    public string? Message { get; set; }
}