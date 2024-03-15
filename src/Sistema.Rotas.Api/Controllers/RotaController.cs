using Microsoft.AspNetCore.Mvc;
using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;
using Sistema.Rotas.Domain.RotasRoot.Commands.Results;
using Sistema.Rotas.Domain.RotasRoot.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Sistema.Rotas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RotaController : ControllerBase
    {
        private readonly IRotaHandler _rotaHandler;
        public RotaController(IRotaHandler rotaHandler)
        {
            _rotaHandler = rotaHandler;
        }

        /// <summary>
        /// Obtem todas as Rotas
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(422, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [HttpGet("obterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = _rotaHandler.GetAll();
            return await Task.FromResult(new ObjectResult(result));
        }

        /// <summary>
        /// Adiciona uma nova Rota
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(422, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [HttpPost("adicionar")]
        public async Task<IActionResult> ObterTodos([FromBody] RotaAddCommand command)
        {
            var result = _rotaHandler.Handler(command);
            return await Task.FromResult(new ObjectResult(result));
        }

        /// <summary>
        /// Deleta uma Rota
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(422, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [HttpDelete("deletar")]
        public async Task<IActionResult> Adicionar([FromQuery] RotaDeleteCommand command)
        {
            var result = _rotaHandler.Handler(command);
            return await Task.FromResult(new ObjectResult(result));
        }

        /// <summary>
        /// Atualiza uma Rota
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(422, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] RotaUpdateCommand command)
        {
            var result = _rotaHandler.Handler(command);
            return await Task.FromResult(new ObjectResult(result));
        }

        /// <summary>
        /// Verifica se há rota mais rápida
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(422, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [HttpPost("verificar-rota-acessivel")]
        public async Task<IActionResult> VeirificarRoraAssessivel([FromBody] RotaVerifyCommand command)
        {
            var result = _rotaHandler.Handler(command);
            return await Task.FromResult(new ObjectResult(result));
        }

        /// <summary>
        /// Verifica rota mais barata porem com paradas
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(422, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [SwaggerResponse(200, type: typeof(IEnumerable<RotaQueryResult>), description: "Codigo de retorno quando o método processou a solicitação so client")]
        [HttpPost("verificar-rota-rapida")]
        public async Task<IActionResult> VeirificarRotaRapida([FromBody] RotaVerifyNonStopCommand command)
        {
            var result = _rotaHandler.Handler(command);
            return await Task.FromResult(new ObjectResult(result));
        }
    }
}
