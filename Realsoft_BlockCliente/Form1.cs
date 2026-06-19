using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace Realsoft_Block
{
    public partial class Form1 : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);
        private IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
        private NotifyIcon notificacao = new NotifyIcon();
        

        public Form1()
        {
            
            InitializeComponent();
        }

        public static String getMacAddress()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                          ).FirstOrDefault();
        }

        private string nomepc = System.Windows.Forms.SystemInformation.ComputerName;

        Realsoft_Redes _redes = new Realsoft_Redes();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                string processo = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                if (Process.GetProcessesByName(processo).Length > 1)
                {
                }
                else
                {
                    Realsoft_Parametros.RetornoCaminhoBanco();

                    int retorno = Realsoft_Conexao.VerificaDados(nomepc, localIPs[0].ToString());

                    int retornoporta = Realsoft_Conexao.VerificaPorta(nomepc, localIPs[0].ToString());

                    if (retornoporta == 0)
                    {
                        Random rd = new Random();
                        Realsoft_Parametros.Porta = rd.Next(9999);
                    }
                    else
                    {
                        Realsoft_Parametros.Porta = retornoporta;
                    }

                    if (retorno == 0)
                    {
                        _redes = null;

                        _redes = new Realsoft_Redes();
                        _redes._NomePC = nomepc;
                        _redes._IPLocal = localIPs[0].ToString();
                        _redes._IPValido = PegarIPValido();
                        _redes._Mac = getMacAddress();
                        _redes._PortaComunicacao = Realsoft_Parametros.Porta;

                        Realsoft_Conexao.Insere_RedesLocais(_redes);
                    }


                    IPAddress enderecoIP = IPAddress.Parse(localIPs[0].ToString());

                    ChatServidor mainServidor = new ChatServidor(enderecoIP);

                    ChatServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

                    mainServidor.IniciaAtendimento();

                    NotifyIcon mynotifyicon = new NotifyIcon();

                    mynotifyicon.Visible = true;
                    this.Hide();
                    this.ShowInTaskbar = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }

        private void AtualizaStatus(string strMensagem)
        {
            try
            {
                if (strMensagem.Length > 10)
                {
                    if (strMensagem.Remove(12) == "BLOQUEARSITE")
                    {
                        string site = strMensagem.Replace("BLOQUEARSITE", "");
                        Realsoft_Bloqueio.BloquearSite(site);
                    }
                }

                if (strMensagem == "BLOQUEARDESKTOP")
                {
                    Form2 frmbloc = new Form2();
                    frmbloc.ShowDialog();

                }
                else if (strMensagem == "BLOQUEARNAVEGADOR")
                {

                }

                else if (strMensagem == "BLOQUEARPAINELCONTROLE")
                {
                    Realsoft_Bloqueio.BloquearControlPanel();
                }

                else if (strMensagem == "VNC")
                {

                }
                else
                { 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string PegarIPValido()
        {
            System.Net.WebClient t = new System.Net.WebClient();
            string meuip = t.DownloadString("http://meuip.datahouse.com.br");
            return meuip
                .Substring(
                meuip.IndexOf("o Meu IP? ") + "o Meu IP? ".Length, meuip.IndexOf("</title>") - meuip.IndexOf("o Meu IP? ") - "o Meu IP? ".Length);
        }


    }
}
