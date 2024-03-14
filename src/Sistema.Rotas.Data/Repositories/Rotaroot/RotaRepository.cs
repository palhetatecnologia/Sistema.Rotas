
using Sistema.Rotas.Data.Baseteste;
using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;
using Sistema.Rotas.Domain.RotasRoot.Interfaces;

namespace Sistema.Rotas.Data.Repositories.Rotaroot
{
    public class RotaRepository : IRotaRepository
    {

        private readonly BaseRotas _baseR;
        public RotaRepository()
        {
            _baseR = new BaseRotas();
        }

        public async Task<int> Adicionar(RotaAddCommand command)
        {
            return await _baseR.Adicionar(command);
        }

        public async Task<int> Deletar(RotaDeleteCommand command)
        {
            return await _baseR.Deletar(command);
        }

        public async Task<int> Atualizar(RotaUpdateCommand command)
        {
            return await _baseR.Atualizar(command);
        }
    }
}
