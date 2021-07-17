using System;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmBiblioteca : Form
    {

        // Todos formulários do sistema
        FrmLivros               frmLivros;
        FrmLeitores             frmLeitores;
        FrmTipoLivro            frmTipoLivro;
        FrmEmprestimo           frmEmprestimo;
        FrmDevolucoes           frmDevolucoes;
        FrmLivrosAtrasados      frmLivrosAtrasados;
        FrmLivrosEmprestados    frmLivrosEmprestados;


        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLivros == null || frmLivros.IsDisposed == true)
            {
                frmLivros = new FrmLivros();
                frmLivros.Show();
            }
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLeitores == null || frmLeitores.IsDisposed == true)
            {
                frmLeitores = new FrmLeitores();
                frmLeitores.Show();
            }
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmEmprestimo == null || frmEmprestimo.IsDisposed == true)
            {
                frmEmprestimo = new FrmEmprestimo();
                frmEmprestimo.Show();
            }
        }

        private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDevolucoes == null || frmDevolucoes.IsDisposed == true)
            {
                frmDevolucoes = new FrmDevolucoes();
                frmDevolucoes.Show();
            }
        }

        private void tipoLivroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTipoLivro == null || frmTipoLivro.IsDisposed == true)
            {
                frmTipoLivro = new FrmTipoLivro();
                frmTipoLivro.Show();
            }
        }


        private void livrosAtrasadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLivrosAtrasados == null || frmLivrosAtrasados.IsDisposed == true)
            {
                frmLivrosAtrasados = new FrmLivrosAtrasados();
                frmLivrosAtrasados.Show();
            }
        }

        private void livrosAtrasadpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLivrosEmprestados == null || frmLivrosEmprestados.IsDisposed == true)
            {
                frmLivrosEmprestados = new FrmLivrosEmprestados();
                frmLivrosEmprestados.Show();
            }
        }

        private void simToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
