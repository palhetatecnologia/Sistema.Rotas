using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Rotas.Domain.RotasRoot.Commands.Inputs
{
    public class RotaVerifyNonStopCommand
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}
