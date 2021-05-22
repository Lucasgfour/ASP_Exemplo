using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ASP_Exemplo.Recursos {
    public class Conexao {
        private MySqlConnection conexao { get; set; }

        public Conexao() {
            openConexao();
        }

        public Conexao(String servidor, String usuario, String senha, String banco) {
            openConexao(servidor, usuario, senha, banco);
        }

        public Resultado openConexao() {
            return openConexao("localhost", "root", "lucasg4", "libertas2021");
        }

        public MySqlConnection getConexao() {
            try {
                return this.conexao;
            } catch (Exception eGet) {
                Console.WriteLine(eGet.ToString());
                return null;
            }
        }

        public void fecharConexao() {
            try {
                this.conexao.Close();
            } catch (Exception eClose) {
                Console.WriteLine(eClose.ToString());
            }
        }

        public Resultado openConexao(String servidor, String usuario, String senha, String banco) {
            try {
                MySqlConnectionStringBuilder StrConexao = new MySqlConnectionStringBuilder
                {
                    Server = servidor,
                    Database = banco,
                    UserID = usuario,
                    Password = senha
                };
                conexao = new MySqlConnection(StrConexao.ConnectionString);
                conexao.Open();
                return new Resultado(true, "Conectado com sucesso.");
            } catch (Exception eConexao) {
                Console.WriteLine(eConexao.ToString());
                return new Resultado(false, eConexao.Message);
            }
        }

    }
}
