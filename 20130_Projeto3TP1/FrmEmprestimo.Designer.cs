namespace apBiblioteca
{
    partial class FrmEmprestimo
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
            this.dgvLeitor = new System.Windows.Forms.DataGridView();
            this.colunaCodLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNomeLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQtdLivros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLivro1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLivro2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLivro3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLivro4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLivro5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLivro = new System.Windows.Forms.DataGridView();
            this.colunaCodLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEmprestar = new System.Windows.Forms.Button();
            this.ssMensagem = new System.Windows.Forms.StatusStrip();
            this.stlbMensagem = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).BeginInit();
            this.ssMensagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLeitor
            // 
            this.dgvLeitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodLeitor,
            this.colunaNomeLeitor,
            this.colunaQtdLivros,
            this.colunaLivro1,
            this.colunaLivro2,
            this.colunaLivro3,
            this.colunaLivro4,
            this.colunaLivro5});
            this.dgvLeitor.GridColor = System.Drawing.Color.Gray;
            this.dgvLeitor.Location = new System.Drawing.Point(13, 13);
            this.dgvLeitor.Name = "dgvLeitor";
            this.dgvLeitor.ReadOnly = true;
            this.dgvLeitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeitor.Size = new System.Drawing.Size(972, 222);
            this.dgvLeitor.TabIndex = 0;
            this.dgvLeitor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeitor_CellClick);
            // 
            // colunaCodLeitor
            // 
            this.colunaCodLeitor.HeaderText = "CodLeitor";
            this.colunaCodLeitor.Name = "colunaCodLeitor";
            this.colunaCodLeitor.ReadOnly = true;
            // 
            // colunaNomeLeitor
            // 
            this.colunaNomeLeitor.HeaderText = "Nome do Leitor";
            this.colunaNomeLeitor.Name = "colunaNomeLeitor";
            this.colunaNomeLeitor.ReadOnly = true;
            this.colunaNomeLeitor.Width = 300;
            // 
            // colunaQtdLivros
            // 
            this.colunaQtdLivros.HeaderText = "# Livros";
            this.colunaQtdLivros.Name = "colunaQtdLivros";
            this.colunaQtdLivros.ReadOnly = true;
            // 
            // colunaLivro1
            // 
            this.colunaLivro1.HeaderText = "Livro 1";
            this.colunaLivro1.Name = "colunaLivro1";
            this.colunaLivro1.ReadOnly = true;
            this.colunaLivro1.Width = 85;
            // 
            // colunaLivro2
            // 
            this.colunaLivro2.HeaderText = "Livro 2";
            this.colunaLivro2.Name = "colunaLivro2";
            this.colunaLivro2.ReadOnly = true;
            this.colunaLivro2.Width = 85;
            // 
            // colunaLivro3
            // 
            this.colunaLivro3.HeaderText = "Livro 3";
            this.colunaLivro3.Name = "colunaLivro3";
            this.colunaLivro3.ReadOnly = true;
            this.colunaLivro3.Width = 85;
            // 
            // colunaLivro4
            // 
            this.colunaLivro4.HeaderText = "Livro 4";
            this.colunaLivro4.Name = "colunaLivro4";
            this.colunaLivro4.ReadOnly = true;
            this.colunaLivro4.Width = 85;
            // 
            // colunaLivro5
            // 
            this.colunaLivro5.HeaderText = "Livro 5";
            this.colunaLivro5.Name = "colunaLivro5";
            this.colunaLivro5.ReadOnly = true;
            this.colunaLivro5.Width = 85;
            // 
            // dgvLivro
            // 
            this.dgvLivro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodLivro,
            this.colunaTitulo,
            this.colunaDescricao});
            this.dgvLivro.Enabled = false;
            this.dgvLivro.Location = new System.Drawing.Point(13, 262);
            this.dgvLivro.Name = "dgvLivro";
            this.dgvLivro.ReadOnly = true;
            this.dgvLivro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLivro.Size = new System.Drawing.Size(595, 209);
            this.dgvLivro.TabIndex = 1;
            this.dgvLivro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivro_CellClick);
            // 
            // colunaCodLivro
            // 
            this.colunaCodLivro.HeaderText = "CodLivro";
            this.colunaCodLivro.Name = "colunaCodLivro";
            this.colunaCodLivro.ReadOnly = true;
            // 
            // colunaTitulo
            // 
            this.colunaTitulo.HeaderText = "Título do Livro";
            this.colunaTitulo.Name = "colunaTitulo";
            this.colunaTitulo.ReadOnly = true;
            this.colunaTitulo.Width = 300;
            // 
            // colunaDescricao
            // 
            this.colunaDescricao.HeaderText = "Descrição do Tipo";
            this.colunaDescricao.Name = "colunaDescricao";
            this.colunaDescricao.ReadOnly = true;
            this.colunaDescricao.Width = 130;
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Enabled = false;
            this.dtpDevolucao.Location = new System.Drawing.Point(673, 293);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(234, 20);
            this.dtpDevolucao.TabIndex = 2;
            this.dtpDevolucao.ValueChanged += new System.EventHandler(this.dtpDevolucao_ValueChanged);
            this.dtpDevolucao.Enter += new System.EventHandler(this.dtpDevolucao_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(749, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Devolver em:";
            // 
            // btnEmprestar
            // 
            this.btnEmprestar.Enabled = false;
            this.btnEmprestar.Location = new System.Drawing.Point(752, 328);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(75, 23);
            this.btnEmprestar.TabIndex = 4;
            this.btnEmprestar.Text = "Emprestar";
            this.btnEmprestar.UseVisualStyleBackColor = true;
            this.btnEmprestar.Click += new System.EventHandler(this.btnEmprestar_Click);
            // 
            // ssMensagem
            // 
            this.ssMensagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ssMensagem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlbMensagem});
            this.ssMensagem.Location = new System.Drawing.Point(0, 485);
            this.ssMensagem.Name = "ssMensagem";
            this.ssMensagem.Size = new System.Drawing.Size(991, 22);
            this.ssMensagem.TabIndex = 6;
            this.ssMensagem.Text = "statusStrip1";
            // 
            // stlbMensagem
            // 
            this.stlbMensagem.Name = "stlbMensagem";
            this.stlbMensagem.Size = new System.Drawing.Size(340, 17);
            this.stlbMensagem.Text = "Mensagem: Selecione o Leitor que deseja fazer um empréstimo";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightCoral;
            this.textBox1.Location = new System.Drawing.Point(673, 404);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(23, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(702, 404);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(205, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Leitor/Livro Indisponível para empréstimo";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(702, 430);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(205, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "Leitor/Livro Disponível para empréstimo";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightBlue;
            this.textBox4.Location = new System.Drawing.Point(673, 430);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(23, 20);
            this.textBox4.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(757, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Orientação:";
            // 
            // FrmEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 507);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ssMensagem);
            this.Controls.Add(this.btnEmprestar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDevolucao);
            this.Controls.Add(this.dgvLivro);
            this.Controls.Add(this.dgvLeitor);
            this.Name = "FrmEmprestimo";
            this.Text = "Manutenção de Empréstimos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEmprestimo_FormClosing);
            this.Load += new System.EventHandler(this.FrmEmprestimo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).EndInit();
            this.ssMensagem.ResumeLayout(false);
            this.ssMensagem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLeitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodLeitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNomeLeitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQtdLivros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaLivro1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaLivro2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaLivro3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaLivro4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaLivro5;
        private System.Windows.Forms.DataGridView dgvLivro;
        private System.Windows.Forms.DateTimePicker dtpDevolucao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmprestar;
        private System.Windows.Forms.StatusStrip ssMensagem;
        private System.Windows.Forms.ToolStripStatusLabel stlbMensagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
    }
}