using Sistema.Rotas.Domain.RotasRoot.Commands.Inputs;
using Sistema.Rotas.Domain.RotasRoot.Interfaces;

namespace Sistema.Rotas.Domain.RotasRoot.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaReadRepository _rotaReadRepository;
        private readonly IRotaRepository _rotaRepository;

        public RotaService(IRotaReadRepository rotaReadRepository, IRotaRepository rotaRepository)
        {
            _rotaReadRepository = rotaReadRepository;
            _rotaRepository = rotaRepository;
        }

        public List<Rota> GetAll()
        {
            return _rotaReadRepository.GetRotas();
        }

        public async Task<int> Adicionar(RotaAddCommand command)
        {
            return await _rotaRepository.Adicionar(command);
        }

        public async Task<int> Deletar(RotaDeleteCommand command)
        {
            return await _rotaRepository.Deletar(command);
        }

        public async Task<int> Atualizar(RotaUpdateCommand command)
        {
            return await _rotaRepository.Atualizar(command);
        }

        public Task<Dictionary<string, int>> VerificarRotaMaisrapida(RotaVerifyNonStopCommand command)
        {
            Dictionary<string, int> rotaValor = new Dictionary<string, int>();

            var origem = command.Origem.ToUpper();
            var destino = command.Destino.ToLower();
            var rotas = _rotaReadRepository.GetRotas();

            string rotaDestino = $"{origem}";
            string novodestino = string.Empty;
            string novaOrigem = string.Empty;
            int valorFinal = 0;

            //validar Rotas Existentes
            var vRotas = rotas.Any(x => x.Origem.Equals(command.Origem) && x.Destino.Equals(command.Destino));
            if (!vRotas)
            {
                rotaDestino = $"Não há Origem ou Destino com esse nome";
                rotaValor.Add(rotaDestino, valorFinal);
                return Task.FromResult(rotaValor);
            }

            var rotaDireta = rotas.Where(x => x.Origem.Equals(origem) && x.Destino.Equals(destino))?.FirstOrDefault();
            if (rotaDireta != null)
            {
                rotaDestino = $"Origem: {rotaDireta.Origem} - Destino:{rotaDireta.Destino}";
                valorFinal = rotaDireta.Valor;
                rotaValor.Add(rotaDestino, valorFinal);                
            }
           
            return Task.FromResult(rotaValor);
        }


        public Task<Dictionary<string, int>> VerificarRotaMaisRotaMaisBarata(RotaVerifyCommand command)
        {
            Dictionary<string, int> rotaValor = new Dictionary<string, int>();           

            var origem = command.Origem.ToUpper();
            var destino = command.Destino.ToLower();
            var rotas = _rotaReadRepository.GetRotas();

            string rotaDestino = $"{origem}";
            string novodestino = string.Empty;
            string novaOrigem = string.Empty;
            int valorFinal = 0;

            //validar Rotas Existentes
            var vRotas = rotas.Any(x => x.Origem.Equals(command.Origem) && x.Destino.Equals(command.Destino));
            if (!vRotas)
            {
                rotaDestino = $"Não há Origem ou Destino com esse nome";
                rotaValor.Add(rotaDestino, valorFinal);
                return Task.FromResult(rotaValor);
            }

            for (int i = 0; i < rotas.Count; i++)
            {
                //proximo 
                if (!rotas[i].Destino.Equals(destino))
                {
                    if (novaOrigem.Equals(destino))
                    {
                        break;
                    }

                    if (string.IsNullOrEmpty(novaOrigem))
                    {
                        novaOrigem = origem;
                        var nRotas = rotas.Where(x => x.Origem.Equals(novaOrigem) && !x.Destino.Equals(destino))?.ToList();
                       
                        var nRota = nRotas.OrderBy(x => x.Valor)?.First();
                        if (nRota == null)
                        {
                            rotaValor.Add(rotaDestino, valorFinal);
                            return Task.FromResult(rotaValor);
                        }
                        novaOrigem = nRota.Destino;
                        rotaDestino += $" - {novaOrigem}";
                        valorFinal += nRota.Valor;
                    }
                    else
                    {
                        var nRota = rotas.Where(x => x.Origem.Equals(novaOrigem)).ToList().OrderBy(x => x.Valor).LastOrDefault();
                        if (nRota == null)
                        {
                            rotaValor.Add(rotaDestino, valorFinal);
                            return Task.FromResult(rotaValor);
                        }
                        novaOrigem = nRota.Destino;
                        rotaDestino += $" - {novaOrigem}";
                        valorFinal += nRota.Valor;
                    }
                }
                else
                {
                    var nRota = rotas.Where(x => x.Origem.Equals(novaOrigem)).ToList().OrderBy(x => x.Valor)?.LastOrDefault();
                    if (nRota == null)
                    {
                        rotaValor.Add(rotaDestino, valorFinal);
                        return Task.FromResult(rotaValor);
                    }
                    novaOrigem = nRota.Destino;
                    rotaDestino += $" - {novaOrigem}";
                    valorFinal += nRota.Valor;
                }
            }

            rotaValor.Add(rotaDestino, valorFinal);
            return Task.FromResult(rotaValor);
        }
    }


}

    

