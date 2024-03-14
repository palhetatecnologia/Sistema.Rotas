using Sistema.Rotas.Domain.RotasRoot;
using Sistema.Rotas.Domain.RotasRoot.Interfaces;

namespace Sistema.Rotas.Data.Repositories.Rotaroot
{
    public class RotaReadRepository : IRotaReadRepository
    {
        public RotaReadRepository()
        {

        }

        public List<Rota> GetRotas()
        {
            return Baseteste.BaseRotas.GetRotas();
        }
    }
}
