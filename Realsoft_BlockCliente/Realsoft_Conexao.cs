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


        public static void Insere_RedesLocais(Realsoft_Block.Realsoft_Redes _Redes)
        {
            try
            {
                SqlCommand _comando = Conecta().CreateCommand();
                _comando.CommandText = "INSERT INTO REALSOFT_REDES(NOMEPC, IPLOCAL, IPVALIDO, MAC, PORTA)VALUES(@NOMEPC, @IPLOCAL, @IPVALIDO, @MAC, @PORTA)";

                _comando.Parameters.Add(CreateParameter(_comando, "@NOMEPC", DbType.String, _Redes._NomePC));
                _comando.Parameters.Add(CreateParameter(_comando, "@IPLOCAL", DbType.String, _Redes._IPLocal));
                _comando.Parameters.Add(CreateParameter(_comando, "@IPVALIDO", DbType.String, _Redes._IPValido));
                _comando.Parameters.Add(CreateParameter(_comando, "@MAC", DbType.String, _Redes._Mac));
                _comando.Parameters.Add(CreateParameter(_comando, "@PORTA", DbType.Int32, _Redes._PortaComunicacao));


                try
                {
                    int execute = _comando.ExecuteNonQuery();
                    Conecta().Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static int VerificaDados(string NomePc, string IPLocal)
        {
            try
            {
                SqlCommand comando = Realsoft_Conexao.Conecta().CreateCommand();
                comando.CommandText = "SELECT ID FROM REALSOFT_REDES WHERE NOMEPC = @NOMEPC AND IPLOCAL = @IPLOCAL";

                comando.Parameters.Add(CreateParameter(comando, "@NOMEPC", DbType.String, NomePc));
                comando.Parameters.Add(CreateParameter(comando, "@IPLOCAL", DbType.String, IPLocal));

                SqlDataReader leitura = comando.ExecuteReader(CommandBehavior.CloseConnection);

                int id = 0;

                if (leitura.Read())
                {
                    if (!leitura.IsDBNull(0))
                    {
                        id = leitura.GetInt32(0);
                    }
                }

                leitura.Close();
                return id;
            }
            catch (Exception e)
            {
                try
                {
                    Realsoft_Conexao.Conecta().Close();
                }
                catch (Exception ex)
                { throw ex; }
                //transacao.Rollback();

                throw e;
            }
        }

        public static int VerificaPorta(string NomePc, string IPLocal)
        {
            try
            {
                SqlCommand comando = Realsoft_Conexao.Conecta().CreateCommand();
                comando.CommandText = "SELECT PORTA FROM REALSOFT_REDES WHERE NOMEPC = @NOMEPC AND IPLOCAL = @IPLOCAL";

                comando.Parameters.Add(CreateParameter(comando, "@NOMEPC", DbType.String, NomePc));
                comando.Parameters.Add(CreateParameter(comando, "@IPLOCAL", DbType.String, IPLocal));

                SqlDataReader leitura = comando.ExecuteReader(CommandBehavior.CloseConnection);

                int id = 0;

                if (leitura.Read())
                {
                    if (!leitura.IsDBNull(0))
                    {
                        id = leitura.GetInt32(0);
                    }
                }

                leitura.Close();
                return id;
            }
            catch (Exception e)
            {
                try
                {
                    Realsoft_Conexao.Conecta().Close();
                }
                catch (Exception ex)
                { throw ex; }
                //transacao.Rollback();

                throw e;
            }
        }
    }
}
