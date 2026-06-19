using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Realsoft_Block
{
    public partial class Form1 : Form
    {
        // Trata o nome do usuário
        private string Usuario = System.Windows.Forms.SystemInformation.ComputerName;
        private string NomeUsuario = "Desconhecido";
        private static StreamWriter stwEnviador;
        private static StreamReader strReceptor;
        private TcpClient tcpServidor;
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;

        public Form1()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                DgLista.Rows.Clear();

                Realsoft_Parametros.RetornoCaminhoBanco();

                List<Realsoft_Redes> _rede = Realsoft_Conexao.Listar_Redes();

                for (int i = 0; i <= _rede.Count - 1; i++)
                {
                    string[] param = new string[7];

                    param[0] = ((Realsoft_Redes)_rede[i])._NomePC;
                    param[1] = ((Realsoft_Redes)_rede[i])._IPLocal;
                    param[2] = ((Realsoft_Redes)_rede[i])._IPValido;
                    param[3] = ((Realsoft_Redes)_rede[i])._Mac;
                    param[6] = ((Realsoft_Redes)_rede[i])._PortaComunicacao.ToString();


                    DgLista.Rows.Add(param);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void InicializaConexao(string ip)
        {
            try
            {
                enderecoIP = IPAddress.Parse(ip);
                tcpServidor = new TcpClient();
                tcpServidor.Connect(enderecoIP, int.Parse(Realsoft_Parametros.Porta));

                Conectado = true;

                NomeUsuario = Usuario;


                stwEnviador = new StreamWriter(tcpServidor.GetStream());
                stwEnviador.WriteLine(Usuario);
                stwEnviador.Flush();

                mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
                mensagemThread.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro na conexão com servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RecebeMensagens()
        {
            // recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else // Se o primeiro caractere não for 1 a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                // exibe mensagems no Textbox
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            //txtLog.AppendText(strMensagem + "\r\n");
        }

        public static void EnviaMensagem(string mensagem)
        {

            stwEnviador.WriteLine(mensagem);
            stwEnviador.Flush();
            
        }

        // Fecha a conexão com o servidor
        private void FechaConexao(string Motivo)
        {
            // Mostra o motivo porque a conexão encerrou
            //txtLog.AppendText(Motivo + "\r\n");

            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }

        // O tratador de evento para a saida da aplicação
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado == true)
            {
                // Fecha as conexões, streams, etc...
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void DgLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 4)
                {
                    Realsoft_Parametros.IP = DgLista.CurrentRow.Cells[1].Value.ToString();

                    Realsoft_Parametros.IPvalido = DgLista.CurrentRow.Cells[2].Value.ToString();

                    Realsoft_Parametros.Porta = DgLista.CurrentRow.Cells[6].Value.ToString();

                    InicializaConexao(Realsoft_Parametros.IP);
                }
                else if (e.ColumnIndex == 5)
                {
                    FechaConexao("ACABOU");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void BtBloqueio_Click_1(object sender, EventArgs e)
        {
            Form2 bloc = new Form2();

            bloc.ShowDialog();
        }

        private void BtMonitorar_Click(object sender, EventArgs e)
        {
            Form3 frmmonitor = new Form3();
            frmmonitor.ShowDialog();
        }

        private void BtListar_Click(object sender, EventArgs e)
        {
            try
            {
                DgLista.Rows.Clear();

                Realsoft_Parametros.RetornoCaminhoBanco();

                List<Realsoft_Redes> _rede = Realsoft_Conexao.Listar_Redes();

                for (int i = 0; i <= _rede.Count - 1; i++)
                {
                    string[] param = new string[7];

                    param[0] = ((Realsoft_Redes)_rede[i])._NomePC;
                    param[1] = ((Realsoft_Redes)_rede[i])._IPLocal;
                    param[2] = ((Realsoft_Redes)_rede[i])._IPValido;
                    param[3] = ((Realsoft_Redes)_rede[i])._Mac;
                    param[6] = ((Realsoft_Redes)_rede[i])._PortaComunicacao.ToString();

                    DgLista.Rows.Add(param);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

    }
}
