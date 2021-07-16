namespace apBiblioteca
{
    partial class FrmLivrosAtrasados
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
            this.dgvLivro = new System.Windows.Forms.DataGridView();
            this.colunaCodLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDataAtual = new System.Windows.Forms.DateTimePicker();
            this.dtpSemEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivro
            // 
            this.dgvLivro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodLivro,
            this.colunaTitulo,
            this.colunaDescricao,
            this.colunaData});
            this.dgvLivro.Location = new System.Drawing.Point(40, 38);
            this.dgvLivro.Name = "dgvLivro";
            this.dgvLivro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLivro.Size = new System.Drawing.Size(730, 209);
            this.dgvLivro.TabIndex = 2;
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
            // colunaData
            // 
            this.colunaData.HeaderText = "Data da devolução";
            this.colunaData.Name = "colunaData";
            this.colunaData.ReadOnly = true;
            this.colunaData.Width = 130;
            // 
            // dtpDataAtual
            // 
            this.dtpDataAtual.Location = new System.Drawing.Point(588, 253);
            this.dtpDataAtual.Name = "dtpDataAtual";
            this.dtpDataAtual.Size = new System.Drawing.Size(200, 20);
            this.dtpDataAtual.TabIndex = 3;
            this.dtpDataAtual.Visible = false;
            // 
            // dtpSemEmprestimo
            // 
            this.dtpSemEmprestimo.Location = new System.Drawing.Point(588, 279);
            this.dtpSemEmprestimo.Name = "dtpSemEmprestimo";
            this.dtpSemEmprestimo.Size = new System.Drawing.Size(200, 20);
            this.dtpSemEmprestimo.TabIndex = 4;
            this.dtpSemEmprestimo.Value = new System.DateTime(1899, 1, 1, 0, 0, 0, 0);
            this.dtpSemEmprestimo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Orientação:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(71, 322);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(205, 20);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "Livro com a entrega em dia";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightBlue;
            this.textBox4.Location = new System.Drawing.Point(42, 322);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(23, 20);
            this.textBox4.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(71, 296);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(205, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "Livro com a entrega atrasada";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightCoral;
            this.textBox1.Location = new System.Drawing.Point(42, 296);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(23, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(71, 348);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(205, 20);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "Livro não emprestado";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.LightGreen;
            this.textBox6.Location = new System.Drawing.Point(42, 348);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(23, 20);
            this.textBox6.TabIndex = 21;
            // 
            // FrmLivrosAtrasados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 398);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtpSemEmprestimo);
            this.Controls.Add(this.dtpDataAtual);
            this.Controls.Add(this.dgvLivro);
            this.Name = "FrmLivrosAtrasados";
            this.Text = "Consulta de Livros Atrasados";
            this.Load += new System.EventHandler(this.FrmLivrosAtrasados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLivro;
        private System.Windows.Forms.DateTimePicker dtpDataAtual;
        private System.Windows.Forms.DateTimePicker dtpSemEmprestimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
    }
}