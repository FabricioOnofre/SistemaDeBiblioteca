using System;
using System.Drawing;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmLivrosEmprestados : Form
    {

        public FrmLivrosEmprestados()
        {
            InitializeComponent();
        }

        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        VetorDados<Livro> osLivros;
        VetorDados<Leitor> osLeitores;
        VetorDados<TipoLivro> osTipos;

        /*************************************************************************************************************/



        /**************************************    MÉTODOS DA CLASSE        *****************************************/

        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmLivrosEmprestados_Load(object sender, EventArgs e)
        {
            // Faz a leitura dos arquivos textos
            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osLeitores = new VetorDados<Leitor>(50);
            osLeitores.LerDados("C:\\Users\\aluno\\Music\\leitores.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");

            AtualizarTela(); // Exibi 
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        void AtualizarTela()
        {
            // Preenche os campos do dgvLivro com os respectivos campos de cada arquivo
            if (!osLeitores.EstaVazio && !osTipos.EstaVazio && !osLivros.EstaVazio)
            {
                dgvLivro.RowCount = osLivros.Tamanho; // é passado quantas linhas o dgvLivro deve conter

                // Percorre o arquivo de livros e verifica quais estão emprestados
                for (int indice = 0; indice < osLivros.Tamanho; indice++)
                {

                    // Preenche os campos do dgvLeitor com os atributos de livro 
                    dgvLivro[0, indice].Value = osLivros[indice].CodigoLivro;
                    dgvLivro[1, indice].Value = osLivros[indice].TituloLivro;

                    // livro tem empréstimo?
                    if (osLivros[indice].DataDevolucao > dateTimePicker2.Value)
                    {
                        dgvLivro.Rows[indice].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    else  // livro não tem empréstimos
                    {
                        dgvLivro.Rows[indice].DefaultCellStyle.BackColor = Color.LightGreen;
                        dgvLivro[3, indice].Value = "-----------------"; // Logo, não tem data de devolução
                    }

                    // Preenche o campo descrição do dgvLivro 
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

                    // Preenche o campo nome do leitor do dgvLivro 
                    // através da busca e comparação das chaves                     
                    for (int indiceLeitor = 0; indiceLeitor < osLeitores.Tamanho; indiceLeitor++)
                    {
                        for (int qualLivro = 0; qualLivro < osLeitores[indiceLeitor].QuantosLivrosComLeitor; qualLivro++)
                        {
                            //         Prime Key             ==                Foreing Key
                            if (osLivros[indice].CodigoLivro == osLeitores[indiceLeitor].CodigoLivroComLeitor[qualLivro])
                            {
                                // a variavel indiceLeitor está na posição do leitor atual
                                dgvLivro[3, indice].Value = osLeitores[indiceLeitor].NomeLeitor;
                                break;
                            }
                        }                        
                    }
                }
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/

        /*************************************************************************************************************/
    }
}

