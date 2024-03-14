using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;

namespace Sistema.Rotas.Domain.RotasRoot.Interfaces
{
    public interface IRotaService
    {
        List<Rota> GetAll();
        Task<int> Adicionar(RotaAddCommand command);
        Task<int> Deletar(RotaDeleteCommand command);
        Task<int> Atualizar(RotaUpdateCommand command);
        Task<Dictionary<string, int>> VerificarRotaMaisRotaMaisBarata(RotaVerifyCommand command);
        Task<Dictionary<string, int>> VerificarRotaMaisrapida(RotaVerifyNonStopCommand command);
    }
}
