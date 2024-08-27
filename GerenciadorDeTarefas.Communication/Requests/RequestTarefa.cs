using GerenciadorDeTarefas.Infrastructure.Enums;

namespace GerenciadorDeTarefas.Communication.Requests;

public class RequestTarefa
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataLimite { get; set; }
    public PrioridadeEnum Prioridade { get; set; }
    public StatusEnum Status { get; set; }
}
