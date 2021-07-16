using System;
using System.Drawing;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmLivrosAtrasados : Form
    {
        VetorDados<Livro> osLivros;
        VetorDados<Leitor> osLeitores;
        VetorDados<TipoLivro> osTipos;


        int linhaLeitor = -1;
        int linhaLivro = -1;

        public FrmLivrosAtrasados()
        {
            InitializeComponent();
        }

        private void FrmLivrosAtrasados_Load(object sender, EventArgs e)
        {
            // Exibi os dados atualizados dos arquivos textos
            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osLeitores = new VetorDados<Leitor>(50);
            osLeitores.LerDados("C:\\Users\\aluno\\Music\\leitores.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");

            AtualizarTela(); // Apresenta os dados atualizados do leitor e do livro após o empréstimo concluido
        }

        private void AtualizarTela()
        {
            // Preenche os campos do dgvLivro com os respectivos campos de cada arquivo
            if (!osLeitores.EstaVazio && !osTipos.EstaVazio && !osLivros.EstaVazio)
            {
                dgvLivro.RowCount = osLivros.Tamanho; // é passado quantas linhas o dgvLivro terá

                // Percorre o arquivo de livros e verifica quais estão emprestados
                for (int indice = 0; indice < osLivros.Tamanho; indice++)
                {

                    // Preenche os campos do dgvLeitor com os atributos de livro 
                    dgvLivro[0, indice].Value = osLivros[indice].CodigoLivro;
                    dgvLivro[1, indice].Value = osLivros[indice].TituloLivro;

                    // livro tem empréstimo?
                    if (osLivros[indice].DataDevolucao > dtpSemEmprestimo.Value)
                    {
                        dgvLivro[3, indice].Value = osLivros[indice].DataDevolucao; // data marcada para devolver
                        dgvLivro.Rows[indice].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    else // livro não tem empréstimos
                    {
                        dgvLivro[3, indice].Value = "------------------"; // Logo, não tem data de devolução
                        dgvLivro.Rows[indice].DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                    // Preenche o campo descrição e data devolução do dgvLivro 
                    // através da busca e comparação das chaves 
                    for (int indice2 = 0; indice2 < osTipos.Tamanho; indice2++)
                    {
                        //        Foreing Key            ==            Prime Key
                        if (osLivros[indice].TipoDoLivro == osTipos[indice2].CodigoTipoLivro)
                        {
                            // a variavel indice2 está na posição da descrição do tipo de livro atual
                            dgvLivro[2, indice].Value = osTipos[indice2].DescricaoDoLivro;
                            break;
                        }
                    }

                    // livro está com a entrega atrasada?
                    if (osLivros[indice].DataDevolucao < dtpDataAtual.Value && osLivros[indice].DataDevolucao > dtpSemEmprestimo.Value )
                    {
                        dgvLivro.Rows[indice].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
        }
    }
}
