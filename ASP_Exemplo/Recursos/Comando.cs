using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace ASP_Exemplo.Recursos
{
    public class Comando {
        private Conexao con;
        private MySqlCommand comando;

        public Comando(String query) {
            comando = new MySqlCommand(query);
        }

        public void setComando(String comando) {
            this.comando.CommandText = comando;
        }

        public void addParametro(String parametro, Object valor) {
            try {
                comando.Parameters.AddWithValue(parametro, valor);
            } catch(Exception eAdd) {
                Console.WriteLine(eAdd.ToString());
            }
        }

        public Resultado executar() {
            con = new Conexao();
            Resultado saida = new Resultado(false, "Comando não executado.");
            try {
                comando.Connection = con.getConexao();
                saida = new Resultado(true, "Comando executado com sucesso.", comando.ExecuteNonQuery());
            } catch(Exception eExecutar) {
                Console.WriteLine(eExecutar.ToString());
                saida = new Resultado(false, "Comando não executado : " + eExecutar.Message);
            }
            con.fecharConexao();
            return saida;
        }

        public Resultado consultar<T>() {
            Resultado saida = new Resultado(false, "Comando não executado.");
            Conexao con = new Conexao();
            try {
                comando.Connection = con.getConexao();
                MySqlDataReader dados = comando.ExecuteReader();
                if(dados.HasRows) {
                    T obj = novaInstancia<T>();
                    dados.Read();
                    saida = new Resultado(true, "Consulta realizada com sucesso.", FillObject(obj, dados));
                } else {
                    saida = new Resultado(false, "Nenhum registro encontrado.");
                }
            } catch (Exception eConsultar) {
                Console.WriteLine(eConsultar.ToString());
                saida = new Resultado(false, "Comando não executado : " + eConsultar.Message);
            }
            con.fecharConexao();
            return saida;
        }

        public Resultado listar<T>() {
            Resultado saida = new Resultado(false, "Comando não executado.");
            Conexao con = new Conexao();
            try {
                comando.Connection = con.getConexao();
                MySqlDataReader dados = comando.ExecuteReader();
                if (dados.HasRows) {
                    LinkedList<T> lista = new LinkedList<T>();
                    while (dados.Read()) {
                        lista.AddLast((T) FillObject(novaInstancia<T>(), dados));
                    }
                    saida = new Resultado(true, "Comando executado com sucesso.", lista);
                } else {
                    saida = new Resultado(false, "Nenhum registro encontrado.");
                }
            } catch (Exception eConsultar) {
                Console.WriteLine(eConsultar.ToString());
                saida = new Resultado(false, "Comando não executado : " + eConsultar.Message);
            }
            con.fecharConexao();
            return saida;
        }

        private T novaInstancia<T>() {
            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }

        private Object FillObject(Object obj, MySqlDataReader dados) {
            PropertyInfo[] campos = obj.GetType().GetProperties();
            foreach(PropertyInfo campo in campos) {
                campo.SetValue(obj, dados.GetValue(dados.GetOrdinal(campo.Name.ToLower())));
            }
            return obj;
        }


    }
}
