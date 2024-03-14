using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;
using Sistema.Rotas.Domain.RotasRoot.Interfaces;

namespace Sistema.Rotas.Domain.RotasRoot.Commands.Handlers
{
    public class RotaHandler : IRotaHandler
    {
        private readonly IRotaService _rotaService;
        public RotaHandler(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        public List<Rota> GetAll()
        {
            return _rotaService.GetAll();
        }

        public async Task<int> Handler(RotaAddCommand command)
        {
            return await _rotaService.Adicionar(command);
        }

        public async Task<int> Handler(RotaUpdateCommand command)
        {
            return await _rotaService.Atualizar(command);
        }
        public async Task<int> Handler(RotaDeleteCommand command)
        {
            return await _rotaService.Deletar(command);
        }

        public Task<Dictionary<string, int>> Handler(RotaVerifyCommand command)
        {
            var result = _rotaService.VerificarRotaMaisRotaMaisBarata(command);
            return result;
        } 
        
        public Task<Dictionary<string, int>> Handler(RotaVerifyNonStopCommand command)
        {
            var result = _rotaService.VerificarRotaMaisrapida(command);
            return result;
        }
    }
}
