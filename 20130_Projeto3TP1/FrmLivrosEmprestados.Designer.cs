namespace apBiblioteca
{
    partial class FrmLivrosEmprestados
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvLivro = new System.Windows.Forms.DataGridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.colunaCodLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Orientação:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(57, 357);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(205, 20);
            this.textBox3.TabIndex = 27;
            this.textBox3.Text = "Livro emprestado";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(481, 380);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 25;
            this.dateTimePicker2.Value = new System.DateTime(1899, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(481, 354);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.Visible = false;
            // 
            // dgvLivro
            // 
            this.dgvLivro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodLivro,
            this.colunaTitulo,
            this.colunaDescricao,
            this.colunaLeitor});
            this.dgvLivro.Location = new System.Drawing.Point(28, 28);
            this.dgvLivro.Name = "dgvLivro";
            this.dgvLivro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLivro.Size = new System.Drawing.Size(741, 284);
            this.dgvLivro.TabIndex = 23;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightBlue;
            this.textBox4.Location = new System.Drawing.Point(28, 357);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(23, 20);
            this.textBox4.TabIndex = 31;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.LightGreen;
            this.textBox6.Location = new System.Drawing.Point(28, 383);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(23, 20);
            this.textBox6.TabIndex = 32;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(57, 383);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(205, 20);
            this.textBox5.TabIndex = 29;
            this.textBox5.Text = "Livro não emprestado";
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
            // colunaLeitor
            // 
            this.colunaLeitor.HeaderText = "Leitor com o livro";
            this.colunaLeitor.Name = "colunaLeitor";
            this.colunaLeitor.ReadOnly = true;
            this.colunaLeitor.Width = 150;
            // 
            // FrmLivrosEmprestados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 425);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dgvLivro);
            this.Name = "FrmLivrosEmprestados";
            this.Text = "Consulta de Livros Emprestados";
            this.Load += new System.EventHandler(this.FrmLivrosEmprestados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgvLivro;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaLeitor;
    }
}