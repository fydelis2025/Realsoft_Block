namespace Realsoft_Block
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DgLista = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtBloqueio = new System.Windows.Forms.ToolStripButton();
            this.BtMonitorar = new System.Windows.Forms.ToolStripButton();
            this.BtLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtListar = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.NOMEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPLOCAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPREMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONECTAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Desconectar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Porta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgLista)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgLista
            // 
            this.DgLista.AllowUserToAddRows = false;
            this.DgLista.AllowUserToDeleteRows = false;
            this.DgLista.AllowUserToResizeColumns = false;
            this.DgLista.AllowUserToResizeRows = false;
            this.DgLista.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMEPC,
            this.IPLOCAL,
            this.IPREMOTO,
            this.MAC,
            this.CONECTAR,
            this.Desconectar,
            this.Porta});
            this.DgLista.GridColor = System.Drawing.SystemColors.Desktop;
            this.DgLista.Location = new System.Drawing.Point(4, 42);
            this.DgLista.Name = "DgLista";
            this.DgLista.RowHeadersVisible = false;
            this.DgLista.Size = new System.Drawing.Size(813, 390);
            this.DgLista.TabIndex = 0;
            this.DgLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgLista_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtBloqueio,
            this.BtMonitorar,
            this.BtLog,
            this.toolStripSeparator1,
            this.BtListar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(820, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtBloqueio
            // 
            this.BtBloqueio.ForeColor = System.Drawing.Color.White;
            this.BtBloqueio.Image = global::Realsoft_Block.Properties.Resources._109;
            this.BtBloqueio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtBloqueio.Name = "BtBloqueio";
            this.BtBloqueio.Size = new System.Drawing.Size(106, 36);
            this.BtBloqueio.Text = "Bloquear Site";
            this.BtBloqueio.Click += new System.EventHandler(this.BtBloqueio_Click_1);
            // 
            // BtMonitorar
            // 
            this.BtMonitorar.ForeColor = System.Drawing.Color.White;
            this.BtMonitorar.Image = global::Realsoft_Block.Properties.Resources._22;
            this.BtMonitorar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtMonitorar.Name = "BtMonitorar";
            this.BtMonitorar.Size = new System.Drawing.Size(115, 36);
            this.BtMonitorar.Text = "Monitoramento";
            this.BtMonitorar.Click += new System.EventHandler(this.BtMonitorar_Click);
            // 
            // BtLog
            // 
            this.BtLog.ForeColor = System.Drawing.Color.White;
            this.BtLog.Image = global::Realsoft_Block.Properties.Resources._1;
            this.BtLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtLog.Name = "BtLog";
            this.BtLog.Size = new System.Drawing.Size(60, 36);
            this.BtLog.Text = "Log";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // BtListar
            // 
            this.BtListar.ForeColor = System.Drawing.Color.White;
            this.BtListar.Image = global::Realsoft_Block.Properties.Resources.images__2_;
            this.BtListar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtListar.Name = "BtListar";
            this.BtListar.Size = new System.Drawing.Size(102, 36);
            this.BtListar.Text = "Listar Redes";
            this.BtListar.Click += new System.EventHandler(this.BtListar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.White;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Description = "Conectar";
            this.dataGridViewImageColumn1.HeaderText = "Conectar";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Conectar";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Status";
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // NOMEPC
            // 
            this.NOMEPC.FillWeight = 150F;
            this.NOMEPC.HeaderText = "PC";
            this.NOMEPC.Name = "NOMEPC";
            this.NOMEPC.Width = 150;
            // 
            // IPLOCAL
            // 
            this.IPLOCAL.FillWeight = 150F;
            this.IPLOCAL.HeaderText = "IP LOCAL";
            this.IPLOCAL.Name = "IPLOCAL";
            this.IPLOCAL.Width = 150;
            // 
            // IPREMOTO
            // 
            this.IPREMOTO.FillWeight = 150F;
            this.IPREMOTO.HeaderText = "IP REMOTO";
            this.IPREMOTO.Name = "IPREMOTO";
            this.IPREMOTO.Width = 150;
            // 
            // MAC
            // 
            this.MAC.FillWeight = 150F;
            this.MAC.HeaderText = "MAC";
            this.MAC.Name = "MAC";
            this.MAC.Width = 150;
            // 
            // CONECTAR
            // 
            this.CONECTAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CONECTAR.HeaderText = "CONECTAR";
            this.CONECTAR.Name = "CONECTAR";
            this.CONECTAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CONECTAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CONECTAR.Text = "CONECTAR";
            this.CONECTAR.ToolTipText = "CONECTAR";
            this.CONECTAR.UseColumnTextForButtonValue = true;
            // 
            // Desconectar
            // 
            this.Desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Desconectar.HeaderText = "Desconectar";
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.ToolTipText = "Desconectar";
            this.Desconectar.UseColumnTextForButtonValue = true;
            // 
            // Porta
            // 
            this.Porta.HeaderText = "Porta";
            this.Porta.Name = "Porta";
            this.Porta.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 458);
            this.Controls.Add(this.DgLista);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rdes Locais";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgLista)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgLista;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ToolStripButton BtBloqueio;
        private System.Windows.Forms.ToolStripButton BtMonitorar;
        private System.Windows.Forms.ToolStripButton BtLog;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPLOCAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPREMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.DataGridViewButtonColumn CONECTAR;
        private System.Windows.Forms.DataGridViewButtonColumn Desconectar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porta;
    }
}

