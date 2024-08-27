using GerenciadorDeTarefas.Application.UseCases.Tarefas.Cadastrar;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.DeleteTarefaById;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.GetAllTarefas;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.GetTarefaById;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.UpdateTarefaById;
using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Response;

using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Tarefas : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTodasTarefas), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAllTarefas()
    {
        var useCase = new GetAllTarefasUseCase();

        var response = useCase.Execute();


        return Ok(response);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseTodasTarefas), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTarefaById([FromRoute] Guid id)
    {
        var useCase = new GetTarefaByIdUseCase();

        var response = useCase.Execute(id);


        return Ok(response);
    }


    [HttpPost]
    [ProducesResponseType(typeof(ResponseTarefaUnica), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult CriarTarefa([FromBody] RequestTarefa request)
    {
        var useCase = new CadastrarTarefaUseCase();

        var response = useCase.Execute(request);


        return Created(string.Empty, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseTarefaUnica), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateTarefa([FromRoute] Guid id, [FromBody] RequestTarefa request  )
    {
        var useCase = new UpdateTarefaByIdUseCase();

        var response = useCase.Execute(id, request);


        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseTarefaUnica), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteTarefa([FromRoute] Guid id)
    {
        var useCase = new DeleteTarefaByIdUseCase();

        useCase.Execute(id);

        return Ok();
    }
}
