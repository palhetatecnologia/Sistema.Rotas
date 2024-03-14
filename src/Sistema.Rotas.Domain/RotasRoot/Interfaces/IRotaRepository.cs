using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;

namespace Sistema.Rotas.Domain.RotasRoot.Interfaces
{
    public interface IRotaRepository
    {
        Task<int> Adicionar(RotaAddCommand command);
        Task<int> Deletar(RotaDeleteCommand command);
        Task<int> Atualizar(RotaUpdateCommand command);
    }
}
