using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;

namespace Sistema.Rotas.Domain.RotasRoot.Interfaces
{
    public interface IRotaHandler
    {
        List<Rota> GetAll();
        Task<int> Handler(RotaAddCommand command);
        Task<int> Handler(RotaUpdateCommand command);
        Task<int> Handler(RotaDeleteCommand command);
        Task<Dictionary<string, int>> Handler(RotaVerifyCommand command);
        Task<Dictionary<string, int>> Handler(RotaVerifyNonStopCommand command);
    }
}
