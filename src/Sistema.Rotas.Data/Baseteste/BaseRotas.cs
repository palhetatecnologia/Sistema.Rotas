using Sistema.Rotas.Domain.RotasRoot;
using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;

namespace Sistema.Rotas.Data.Baseteste
{
    public class BaseRotas
    {
        private static List<Rota> rotas = new List<Rota>
            {
                new Rota {Id = 1, Origem = "GRU", Destino = "BRC", Valor = 10 },
                new Rota {Id = 2, Origem = "BRC", Destino = "SCL", Valor = 5 },
                new Rota {Id = 3, Origem = "GRU", Destino = "CDG", Valor = 75 },
                new Rota {Id = 4, Origem = "GRU", Destino = "SCL", Valor = 20 },
                new Rota {Id = 5, Origem = "GRU", Destino = "ORL", Valor = 56 },
                new Rota {Id = 6, Origem = "ORL", Destino = "CDG", Valor = 5 },
                new Rota {Id = 7, Origem = "SCL", Destino = "ORL", Valor = 20 }
            };

        public static List<Rota> GetRotas()
        {
            return rotas;
        }

        public Task<int> Adicionar(RotaAddCommand command)
        {
            
            rotas.Add(new Rota
            {
                Id = (rotas.Count + 1),
                Origem = command.Origem,
                Destino = command.Destino,
                Valor = command.Valor,
            });

            return Task.FromResult(rotas.Count);
        }

        public Task<int> Atualizar(RotaUpdateCommand command)
        {
            rotas.Where(x => x.Id == command.Id).ToList().ForEach(s =>
             {
                 s.Origem = command.Origem;
                 s.Destino = command.Destino;
                 s.Valor = command.Valor;
             });

            return Task.FromResult(rotas.Count);
        }

        public Task<int> Deletar(RotaDeleteCommand command)
        {
            var rota = rotas.Where(x => x.Id == command.Id).FirstOrDefault();
            rotas.Remove(rota);
            return Task.FromResult(rotas.Count);
        }
    }
}
