using GerenciadorDeTarefas.Infrastructure;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.DeleteTarefaById;

public class DeleteTarefaByIdUseCase
{
    public void Execute(Guid id)
    {

        var dbContext = new GerenciadorTarefasDbContext();

        var tarefa = dbContext.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

        if(tarefa is null)
        {
            throw new Exception("Não encontrado Id");
        }

        dbContext.Remove(tarefa);

        dbContext.SaveChanges();
    }
}
