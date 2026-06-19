using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Realsoft_Block
{
    public class Realsoft_Conexao
    {
        private static SqlConnection _connection;
        public static SqlConnection Conecta()
        {
            try
            {
                _connection = new SqlConnection();
                _connection.ConnectionString = Realsoft_Parametros.parametroconexao;
                _connection.Open();

                return _connection;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IDbDataParameter CreateParameter(IDbCommand Comando, string Nome, DbType Tipo, Object Valor)
        {
            IDbDataParameter P = Comando.CreateParameter();
            P.DbType = Tipo;
            P.ParameterName = Nome;
            P.Value = Valor;

            return P;
        }

        public static List<Realsoft_Redes> Listar_Redes()
        {
            try
            {

                SqlCommand _comando = Realsoft_Conexao.Conecta().CreateCommand();
                _comando.CommandText = "SELECT NOMEPC, IPLOCAL, IPVALIDO, MAC, PORTA FROM REALSOFT_REDES";

                SqlDataReader leitura = _comando.ExecuteReader(CommandBehavior.CloseConnection);

                Realsoft_Redes _rede = null;

                List<Realsoft_Redes> Lista = new List<Realsoft_Redes>();

                while (leitura.Read())
                {
                    _rede = new Realsoft_Redes();

                    if (!leitura.IsDBNull(0))
                    {
                        _rede._NomePC = leitura.GetString(0);
                    }
                    if (!leitura.IsDBNull(1))
                    {
                        _rede._IPLocal = leitura.GetString(1);
                    }
                    if (!leitura.IsDBNull(2))
                    {
                        _rede._IPValido = leitura.GetString(2);
                    }
                    if (!leitura.IsDBNull(3))
                    {
                        _rede._Mac = leitura.GetString(3);
                    }
                    if (!leitura.IsDBNull(4))
                    {
                        _rede._PortaComunicacao = leitura.GetInt32(4);
                    }

                    Lista.Add(_rede);
                }

                Realsoft_Conexao.Conecta().Close();
                return Lista;
            }
            catch (Exception ex)
            {
                Realsoft_Conexao.Conecta().Close();
                throw ex;
            }
        }

    }
}
