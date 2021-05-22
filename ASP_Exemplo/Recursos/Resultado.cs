using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Exemplo.Recursos {
    public class Resultado {

        public bool condicao { get; set; }
        public String mensagem { get; set; }
        public Object resultado { get; set; }

        public Resultado() {
            this.condicao = false;
            this.mensagem = "NÃO INFORMADO";
        }

        public Resultado(bool condicao, String mensagem) {
            this.condicao = condicao;
            this.mensagem = mensagem;
        }

        public Resultado(bool condicao, String mensagem, object resultado) {
            this.condicao = condicao;
            this.mensagem = mensagem;
            this.resultado = resultado;
        }
    }
}
