using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;
using System.Net.NetworkInformation;

namespace Realsoft_Block
{
    public class Realsoft_Parametros
    {
        public static String IP;
        public static string IPvalido;
        public static int Porta;

        public static string UsuarioLogado = null;

        public static string _descriptografado;
        public static string _textocriptografado;
        public static string passPhrase;
        public static string saltValue;
        public static string hashAlgorithm;
        public static int _interacao = 2;
        public static string _initvector;
        public static int keySize;
        public static string parametroconexao;
        public static string tipoconexao = "System.Data.SqlClient";
        public static Random _Codigo = new Random();
        public static string DataAutorizacao;
        public static string DataRegistro;
        public static bool LicencaLiberada;
        public static string Validade;
        public static string Valido;
        public static string SerialAtivo;
        public static string Filial;
        public static string CNPJ;

        

        public static XmlNode Elemento(XmlNode no, string elemento)
        {
        try
        {
            for (int n = 0; n < no.ChildNodes.Count; n++)
            {
                if (no.ChildNodes[n].Name.Equals(elemento))
                    return no.ChildNodes[n];
            }
        }
        catch (XmlException ex)
        {
            throw new Exception(ex.Message);
        }

        return Elemento(no.LastChild, elemento);
    }

    public static string ArquivoXml(string arquivo)
    {
        string _xml = "";

        StreamReader LerArquivo = new StreamReader(arquivo);
        string Linha = LerArquivo.ReadLine();
        while (Linha != null)
        {
            _xml += Linha;
            Linha = LerArquivo.ReadLine();
        }
        LerArquivo.Close();

        return _xml;
    }

        public static void RetornoCaminhoBanco()
        {
            try
            {                
                String[] Licenca = Directory.GetFiles(Environment.CurrentDirectory,"Licenca.xml");
                
                DataTable xml = new DataTable();
                for (int i = 0; i < Licenca.Length; i++)
                {
                    if (Licenca[i].LastIndexOf(".xml") > -1)
                    {
                        XmlNode xmlDados = null;
                        System.Xml.XmlDocument myXMLDoc = new System.Xml.XmlDocument();
                        myXMLDoc.PreserveWhitespace = true;

                        myXMLDoc.LoadXml(Realsoft_Parametros.ArquivoXml(Licenca[i]));
                        xmlDados = myXMLDoc.DocumentElement;
                        
                        XmlNode _passPhrase = Realsoft_Parametros.Elemento(xmlDados, "passPhrase");
                        Realsoft_Parametros.passPhrase = _passPhrase.LastChild.Value.ToString();

                        XmlNode _saltValue = Realsoft_Parametros.Elemento(xmlDados, "saltValue");
                        Realsoft_Parametros.saltValue = _saltValue.LastChild.Value.ToString();

                        XmlNode _hashAlgorithm = Realsoft_Parametros.Elemento(xmlDados, "hashAlgorithm");
                        Realsoft_Parametros.hashAlgorithm = _hashAlgorithm.LastChild.Value.ToString();

                        XmlNode _initvector = Realsoft_Parametros.Elemento(xmlDados, "initvector");
                        Realsoft_Parametros._initvector = _initvector.LastChild.Value.ToString();

                        XmlNode _keySize = Realsoft_Parametros.Elemento(xmlDados, "keySize");
                        Realsoft_Parametros.keySize = int.Parse(_keySize.LastChild.Value.ToString());
                                                
                        XmlNode _conexao = Realsoft_Parametros.Elemento(xmlDados, "conexao");
                        string retorno = _conexao.LastChild.Value.ToString();
                        Realsoft_Parametros.parametroconexao = Realsoft_Criptografia.Decrypt(retorno, Realsoft_Parametros.passPhrase, Realsoft_Parametros.saltValue, Realsoft_Parametros.hashAlgorithm, Realsoft_Parametros._interacao, Realsoft_Parametros._initvector, Realsoft_Parametros.keySize);

                    }
                }                
            }                
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
