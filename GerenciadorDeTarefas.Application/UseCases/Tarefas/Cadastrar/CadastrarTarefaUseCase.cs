using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Response;
using GerenciadorDeTarefas.Infrastructure;
using GerenciadorDeTarefas.Infrastructure.Entities;


namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.Cadastrar;

public class CadastrarTarefaUseCase
{

    public ResponseTarefaUnica Execute(RequestTarefa request)
    {

        var dbContext = new GerenciadorTarefasDbContext();

        var entity = new TarefasEntity
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataLimite = request.DataLimite,
            Prioridade = request.Prioridade,
            Status = request.Status,
        };

        dbContext.Tarefas.Add(entity);

        dbContext.SaveChanges();

        return new ResponseTarefaUnica
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Descricao = entity.Descricao,
            DataLimite = entity.DataLimite,
            Prioridade = entity.Prioridade,
            Status = entity.Status,
        };
    }
}
