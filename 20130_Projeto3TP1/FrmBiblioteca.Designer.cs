namespace apBiblioteca
{
    partial class FrmBiblioteca
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.livrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leitoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tipoLivroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empréstimosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.livroEmprestadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.livrosAtrasadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nãoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.simToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.manutençãoToolStripMenuItem,
            this.operaçõesToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // manutençãoToolStripMenuItem
            // 
            this.manutençãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.livrosToolStripMenuItem,
            this.leitoresToolStripMenuItem,
            this.toolStripMenuItem2,
            this.tipoLivroToolStripMenuItem});
            this.manutençãoToolStripMenuItem.Name = "manutençãoToolStripMenuItem";
            this.manutençãoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.manutençãoToolStripMenuItem.Text = "Manutenção";
            // 
            // livrosToolStripMenuItem
            // 
            this.livrosToolStripMenuItem.Name = "livrosToolStripMenuItem";
            this.livrosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.livrosToolStripMenuItem.Text = "Livros";
            this.livrosToolStripMenuItem.Click += new System.EventHandler(this.livrosToolStripMenuItem_Click);
            // 
            // leitoresToolStripMenuItem
            // 
            this.leitoresToolStripMenuItem.Name = "leitoresToolStripMenuItem";
            this.leitoresToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.leitoresToolStripMenuItem.Text = "Leitores";
            this.leitoresToolStripMenuItem.Click += new System.EventHandler(this.leitoresToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // tipoLivroToolStripMenuItem
            // 
            this.tipoLivroToolStripMenuItem.Name = "tipoLivroToolStripMenuItem";
            this.tipoLivroToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tipoLivroToolStripMenuItem.Text = "Categoria de Livros";
            this.tipoLivroToolStripMenuItem.Click += new System.EventHandler(this.tipoLivroToolStripMenuItem_Click);
            // 
            // operaçõesToolStripMenuItem
            // 
            this.operaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empréstimosToolStripMenuItem,
            this.devoluçõesToolStripMenuItem});
            this.operaçõesToolStripMenuItem.Name = "operaçõesToolStripMenuItem";
            this.operaçõesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.operaçõesToolStripMenuItem.Text = "Operações";
            // 
            // empréstimosToolStripMenuItem
            // 
            this.empréstimosToolStripMenuItem.Name = "empréstimosToolStripMenuItem";
            this.empréstimosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.empréstimosToolStripMenuItem.Text = "Empréstimos";
            this.empréstimosToolStripMenuItem.Click += new System.EventHandler(this.emprestimosToolStripMenuItem_Click);
            // 
            // devoluçõesToolStripMenuItem
            // 
            this.devoluçõesToolStripMenuItem.Name = "devoluçõesToolStripMenuItem";
            this.devoluçõesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.devoluçõesToolStripMenuItem.Text = "Devoluções";
            this.devoluçõesToolStripMenuItem.Click += new System.EventHandler(this.devolucoesToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.livroEmprestadosToolStripMenuItem,
            this.livrosAtrasadosToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // livroEmprestadosToolStripMenuItem
            // 
            this.livroEmprestadosToolStripMenuItem.Name = "livroEmprestadosToolStripMenuItem";
            this.livroEmprestadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.livroEmprestadosToolStripMenuItem.Text = "Livros Emprestados";
            this.livroEmprestadosToolStripMenuItem.Click += new System.EventHandler(this.livrosEmprestadosToolStripMenuItem_Click);
            // 
            // livrosAtrasadosToolStripMenuItem
            // 
            this.livrosAtrasadosToolStripMenuItem.Name = "livrosAtrasadosToolStripMenuItem";
            this.livrosAtrasadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.livrosAtrasadosToolStripMenuItem.Text = "Livros Atrasados";
            this.livrosAtrasadosToolStripMenuItem.Click += new System.EventHandler(this.livrosAtrasadosToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nãoToolStripMenuItem1,
            this.simToolStripMenuItem1});
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // nãoToolStripMenuItem1
            // 
            this.nãoToolStripMenuItem1.Name = "nãoToolStripMenuItem1";
            this.nãoToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.nãoToolStripMenuItem1.Text = "Não";
            // 
            // simToolStripMenuItem1
            // 
            this.simToolStripMenuItem1.Name = "simToolStripMenuItem1";
            this.simToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.simToolStripMenuItem1.Text = "Sim";
            this.simToolStripMenuItem1.Click += new System.EventHandler(this.simToolStripMenuItem1_Click);
            // 
            // FrmBiblioteca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::apBiblioteca.Properties.Resources.alexandria_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(751, 513);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmBiblioteca";
            this.Text = "Biblioteca de Alexandria";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem livrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leitoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem operaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empréstimosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem livroEmprestadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem livrosAtrasadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nãoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem simToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tipoLivroToolStripMenuItem;
    }
}

