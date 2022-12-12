using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Repositories.Interfaces;

namespace MinhaPrimeiraAPI.V1.Controllers
{
    // O que é "API" interface de programação de aplicações, conjunto de rotinas, protocolos e ferramentas para construir aplicações.
    // Processa as solicitações do usuário.

    // "Controllers" Responsável por controllar a maneira como um usuário interage.
    // "Controller" entre colchetes, significa que tem que informar o nome do controlador.

    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/participantes")] // Atributo "Route" define uma rota padrão para poder acessar essa API via url.
    [ApiController] // "ApiController" decora o controlador, ele define recursos e comportamentos com o objetivo de melhorar a experiência do desenvolvedor para criar as API's.
    public class ParticipanteController : ControllerBase // "ControllerBase ou ControllerBase" fornece muitas propriedades e métodos úteis para lidar com requisições HTTP.
    {
        // Injeção de dependêcia - injeta o repositório na controller
        private readonly IParticipanteRepository participanteRepository;

        // Construtor
        public ParticipanteController(IParticipanteRepository participanteRepository)
        {
            this.participanteRepository = participanteRepository;
        }

        // Métodos usados para processar as requisições recebidas via http.

        // "ActionResult" concreto, um tipo específico de retorno.
        // "IActionResult" abstração, vários tipos de retorno.
        // "FromBody" atributo para vincular dados a partir do Body do request.
        // "Endpoint" endereço onde será acessado.
        // "HttpGet" Verbo.

        [HttpGet]  // GetAll listar tudo
        public IActionResult GetAll()
        {
            var participantes = participanteRepository.GetAll();
            return Ok(participantes);
        }

        // TODO Tarefa a fazer

        // PostAsync - inserir

        // PutAsync - atualizar

        // DeleteAsync - remover

        // GetByIdAsync - obter por id
    }
}