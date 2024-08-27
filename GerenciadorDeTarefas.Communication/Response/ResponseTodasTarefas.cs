namespace GerenciadorDeTarefas.Communication.Response;

public class ResponseTodasTarefas
{

    public IList<ResponseTarefaUnica> Tarefas { get; set; } = [];
}
