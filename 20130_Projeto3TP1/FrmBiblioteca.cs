using System;
using System.Windows.Forms;

namespace apBiblioteca
{
    // Autor: Fabricio Onofre Rezende de Camargo

    public partial class FrmBiblioteca : Form
    {
        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        // Formulários do programa
        FrmLivros frmLivros;                            // Formulario CRUD de Livros
        FrmLeitores             frmLeitores;            // Formulario CRUD de Leitores
        FrmTipoLivro            frmTipoLivro;           // Formulario CRUD de Categorias de Livros
        FrmEmprestimo           frmEmprestimo;          // Formulario de Empréstimos de Livros
        FrmDevolucoes           frmDevolucoes;          // Formulario de Devoluções  de Livros
        FrmLivrosAtrasados      frmLivrosAtrasados;     // Formulario para consultar livros atrasados
        FrmLivrosEmprestados    frmLivrosEmprestados;   // Formulario para consultar livros emprestados

        /*************************************************************************************************************/



        /**************************************    MÉTODOS DA CLASSE        *****************************************/

        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Livros
        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLivros == null || frmLivros.IsDisposed == true)
            {
                frmLivros = new FrmLivros();
                frmLivros.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Leitores
        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLeitores == null || frmLeitores.IsDisposed == true)
            {
                frmLeitores = new FrmLeitores();
                frmLeitores.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Categorias de Livro
        private void tipoLivroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTipoLivro == null || frmTipoLivro.IsDisposed == true)
            {
                frmTipoLivro = new FrmTipoLivro();
                frmTipoLivro.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Consulta de Livros atrasados
        private void livrosAtrasadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLivrosAtrasados == null || frmLivrosAtrasados.IsDisposed == true)
            {
                frmLivrosAtrasados = new FrmLivrosAtrasados();
                frmLivrosAtrasados.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Devolução Livros
        private void devolucoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDevolucoes == null || frmDevolucoes.IsDisposed == true)
            {
                frmDevolucoes = new FrmDevolucoes();
                frmDevolucoes.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Empréstimos de Livros
        private void emprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmEmprestimo == null || frmEmprestimo.IsDisposed == true)
            {
                frmEmprestimo = new FrmEmprestimo();
                frmEmprestimo.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para abrir o formulário de Consulta de Livros Emprestados
        private void livrosEmprestadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLivrosEmprestados == null || frmLivrosEmprestados.IsDisposed == true)
            {
                frmLivrosEmprestados = new FrmLivrosEmprestados();
                frmLivrosEmprestados.Show();
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/



        /*----------------------------------------------------------------------------------------------------------*/
        // Método para fechar o programa, ou seja, o formulário principal da Biblioteca
        private void simToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
        /*----------------------------------------------------------------------------------------------------------*/

        /*************************************************************************************************************/

    }
}
