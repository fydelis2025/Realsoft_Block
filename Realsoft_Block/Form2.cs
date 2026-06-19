using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Realsoft_Block
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtBloquear_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DgLista.Rows.Add();

                DgLista.Rows[i].Cells[0].Value = Realsoft_Parametros.IP;
                DgLista.Rows[i].Cells[1].Value = Txsite.Text;

                Form1.EnviaMensagem("BLOQUEARSITE" + Txsite.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
