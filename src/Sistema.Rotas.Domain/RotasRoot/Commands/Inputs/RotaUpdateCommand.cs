namespace Sistema.Rotas.Domain.RotasRoot.Commands.Inputs
{
    public class RotaUpdateCommand
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int Valor { get; set; }

        public Rota GetRota()
        {
            return new Rota
            {
                Origem = this.Origem,
                Destino = this.Destino,
                Valor = this.Valor
            };
        }
    }
}
