using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Exemplo.Model {
    [Serializable]
    public class Veiculo {
        public int codigo { get; set; }
        public int ano { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String placa { get; set; }

        public Veiculo() {

        }
    }
}
