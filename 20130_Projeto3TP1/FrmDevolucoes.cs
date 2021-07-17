using System;
using System.Drawing;
using System.Windows.Forms;

namespace apBiblioteca
{
    // 20130 - Fabricio Onofre

    public partial class FrmDevolucoes : Form
    {
        public FrmDevolucoes()
        {
            InitializeComponent();
        }

        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        VetorDados<Livro> osLivros;
        VetorDados<Leitor> osLeitores;
        VetorDados<TipoLivro> osTipos;

        // variaves usadas para saber o indice dos registros no arquivo de texto
        int linhaLeitor = -1;
        int linhaLivro  = -1;

        /*************************************************************************************************************/



        /**************************************    MÉTODOS DA CLASSE        *****************************************/

        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmDevolucoes_Load(object sender, EventArgs e)
        {
            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osLeitores = new VetorDados<Leitor>(50);
            osLeitores.LerDados("C:\\Users\\aluno\\Music\\leitores.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");

            AtualizarTela(); // Atualiza a tela preenchendo o datagridview com os dados de livros e leitores
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a gravação dos dados de leitores e livros atualizados, após o formulário ser fechado
        private void FrmDevolucoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            osLeitores.GravacaoEmDisco("C:\\Users\\aluno\\Music\\leitores.txt");
            osLivros.GravacaoEmDisco("C:\\Users\\aluno\\Music\\livros.txt");
        }
        /*-----------------------------------------------------------------------------------------------------*/

        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a atualização do datagridview para que assim exiba a versão mais recente dos arquivos de livros e leitores
        private void AtualizarTela()
        {
            if (!osLeitores.EstaVazio && !osTipos.EstaVazio && !osLivros.EstaVazio)
            {
                dgvLeitor.RowCount = osLeitores.Tamanho; // É passado quantas linhas o dgvLeitor deve conter 
                for (int indice = 0; indice < osLeitores.Tamanho; indice++)
                {
                    // Preenche o dgvLeitor com os atributos do registro de Leitor
                    dgvLeitor.Rows[indice].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvLeitor[0, indice].Value = osLeitores[indice].CodigoLeitor;
                    dgvLeitor[1, indice].Value = osLeitores[indice].NomeLeitor;
                    dgvLeitor[2, indice].Value = osLeitores[indice].QuantosLivrosComLeitor;


                    byte qtdLivros = osLeitores[indice].QuantosLivrosComLeitor;
                    if (qtdLivros > 0) // leitor fez empréstimos?
                    {
                        // Exibi o código dos livros que estão emprestados
                        // através do vetor CodigoLivroComLeitor[]
                        switch (qtdLivros)
                        {
                            case 0:
                                {
                                    dgvLeitor.Rows[indice].DefaultCellStyle.BackColor = Color.LightCoral;
                                    dgvLeitor[3, indice].Value = "";
                                    dgvLeitor[4, indice].Value = "";
                                    dgvLeitor[5, indice].Value = "";
                                    dgvLeitor[6, indice].Value = "";    // Limpa a tela para os livros que foram entregues
                                    dgvLeitor[7, indice].Value = "";
                                }
                                break;
                            case 1:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                    dgvLeitor[4, indice].Value = "";
                                    dgvLeitor[5, indice].Value = "";
                                    dgvLeitor[6, indice].Value = "";   
                                    dgvLeitor[7, indice].Value = "";
                                }
                                break;
                            case 2:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                    dgvLeitor[5, indice].Value = "";
                                    dgvLeitor[6, indice].Value = "";
                                    dgvLeitor[7, indice].Value = ""; 
                                }
                                break;
                            case 3:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 3];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[5, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                    dgvLeitor[6, indice].Value = "";
                                    dgvLeitor[7, indice].Value = "";
                                }
                                break;
                            case 4:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 4];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 3];
                                    dgvLeitor[5, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[6, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                    dgvLeitor[7, indice].Value = "";
                                }
                                break;
                            case 5:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 5]; 
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 4];
                                    dgvLeitor[5, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 3];
                                    dgvLeitor[6, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[7, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                }
                                break;
                        }
                    }
                    else
                    {
                        dgvLeitor.Rows.Clear();
                    }
                }                
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para selecionar um leitor e verificar se há algum livro emprestado com o leitor selecionado
        private void dgvLeitor_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Leitor tem empréstimos?
            if (osLeitores[Convert.ToInt32(dgvLeitor.CurrentRow.Index)].QuantosLivrosComLeitor == 0) // leitor não fez empréstimos
            {
                MessageBox.Show("Não é possível escolher este leitor, pois ele não tem nenhum livro emprestado.");
                stlbMensagem.Text = "Mensagem: Selecione o Leitor que deseja fazer a devolução";
                dgvLivro.Enabled = false;
                btnDevolver.Enabled = false;
            }
            else  // leitor fez empréstimos
            {
                // Procura qual é o registro que o livro selecionado está
                // através da busca e comparação das chaves                 
                for (int indice = 0; indice < osLeitores.Tamanho; indice++)
                {
                    if (dgvLeitor.CurrentRow.Cells[0].Value.ToString() == osLeitores[indice].CodigoLeitor)
                    {
                        linhaLeitor = indice; // é passado onde está o registro do leitor selecionado
                        break;
                    }
                }
                dgvLivro.Enabled = true;
                stlbMensagem.Text = "Mensagem: Selecione o Livro que deseja fazer a devolução";
                ExibirLivroDevolucao(); // Exibi os livros que esse leitor pode devolver
            }             
        }


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a atualização do datagridview, para que assim exiba somente os livros que estão com o leitor selecionado
        void ExibirLivroDevolucao()
        {

            //É passado quantas linhas o dgvLivro deve conter
            byte linhaAtualLeitor = Convert.ToByte(dgvLeitor.CurrentRow.Index);
            dgvLivro.RowCount = osLeitores[linhaAtualLeitor].QuantosLivrosComLeitor; 


            for (int indice = 0; indice < dgvLivro.RowCount; indice++)
            {
                // Preenche os campos do dgvLeitor com os atributos do registro de leitor
                dgvLivro.Rows[indice].DefaultCellStyle.BackColor = Color.LightBlue;
                dgvLivro[0, indice].Value = osLeitores[linhaLeitor].CodigoLivroComLeitor[indice];

                // Procura quais são os livros que estão em posse do leitor
                //  E os Preenche no campos do dgvLivro 
                // através da busca e comparação das chaves 
                for (int indice2 = 0; indice2 < osLivros.Tamanho; indice2++)
                {
                    
                    // compara as chaves de pesquisa
                    if (osLivros[indice2].CodigoLivro == osLeitores[linhaLeitor].CodigoLivroComLeitor[indice]) 
                    {
                        // Atributo titulo do livro
                        dgvLivro[1, indice].Value = osLivros[indice2].TituloLivro;
                        for (int indice3 = 0; indice3 < osTipos.Tamanho; indice3++) // compara as chaves de pesquisa
                        {
                            if (osLivros[indice2].TipoDoLivro == osTipos[indice3].CodigoTipoLivro)
                            {
                                // Atributo descrição do livro
                                dgvLivro[2, indice].Value = osTipos[indice3].DescricaoDoLivro;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para selecionar um livro e verificar se há algum leitor com esse livro emprestado
        private void dgvLivro_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(osLivros[Convert.ToInt32(dgvLivro.CurrentRow.Index)].CodigoLeitorComLivro != "0000000") // livro está emprestado?
            {
                int qtdLivros = osLeitores[linhaLeitor].QuantosLivrosComLeitor;
                osLeitores[linhaLeitor].CodigoLivroComLeitor[qtdLivros] = dgvLivro.CurrentRow.Cells[0].Value.ToString();

                // Procura qual é o registro que o livro selecionado está
                // através da busca e comparação das chaves 
                for (int indice = 0; indice < osLivros.Tamanho; indice++)
                {
                    if (osLeitores[linhaLeitor].CodigoLivroComLeitor[osLeitores[linhaLeitor].QuantosLivrosComLeitor] == osLivros[indice].CodigoLivro) // chaves de pesquisa
                    {
                        linhaLivro = indice; // é passado qual o registro do livro selecionado
                        break;
                    }
                }

                stlbMensagem.Text = "Mensagem: Pressione [Devolver] para concluir a devolução.";
                btnDevolver.Enabled = true;
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                // Obriga o usuario a executar o fluxo de execução correto para o programa
                dgvLivro.Enabled = false;
                btnDevolver.Enabled = false;
                stlbMensagem.Text = "Mensagem: Selecione o Leitor que deseja fazer a devolução";

                // Procura qual é o livro que o leitor deseja devolver 
                // dentre todos os empréstimos que ele tem
                // atráves da comparação de chaves
                int qualLivro = 0;
                for (int indice = 0; indice < osLeitores[linhaLeitor].QuantosLivrosComLeitor; indice++)
                {
                    if (dgvLivro.CurrentRow.Cells[0].Value.ToString() == osLeitores[linhaLeitor].CodigoLivroComLeitor[indice])
                    {
                        qualLivro = indice; // é passado qual é a posição do indice do vetor  que está o livro selecionado
                    }
                }

                // Se o livro já passou da data de devolução
                if(dtpDevolucao.Value > osLivros[linhaLivro].DataDevolucao)
                {
                    MessageBox.Show("Livro entregue com atraso!");
                }

                // Instancia um objeto da classe Livro, com a data de devolução maxima e o código leitor vazio
                // para podermos depois fazer um empréstimo desse livro.
                var novoLivro = new Livro(osLivros[linhaLivro].CodigoLivro, osLivros[linhaLivro].TituloLivro, 
                osLivros[linhaLivro].TipoDoLivro, new DateTime(1899, 1, 1), "000000");


                osLivros.Excluir(linhaLivro);    // Exclui o registro antigo desse leitor no arquivo texto 
                osLivros.Incluir(novoLivro, linhaLivro);  // Inclui o novo  registro desse leitor no arquivo texto 


                // Exclui o livro selecionado dentro do vetor CodigoLivroComLeitor[]
                ExcluirLivroDoLeitor(qualLivro);

                // Instancia um objeto da classe Leitor, com os dados de QuantosLivrosComLeitor
                // e CodigoLivroComLeitor[] atualizados, após a devolução ter sido concluido
                var novoLeitor = new Leitor(Convert.ToString(osLeitores[linhaLeitor].CodigoLeitor), Convert.ToString(osLeitores[linhaLeitor].NomeLeitor),
                Convert.ToString(osLeitores[linhaLeitor].EnderecoLeitor), osLeitores[linhaLeitor].QuantosLivrosComLeitor, osLeitores[linhaLeitor].CodigoLivroComLeitor);


                osLeitores.Excluir(linhaLeitor);     // Exclui o registro antigo desse leitor gravado no arquivo texto 
                osLeitores.Incluir(novoLeitor, linhaLeitor);  // Inclui o novo  registro desse leitor no arquivo texto 

                AtualizarTela(); // Exibi os dados de livros e leitores após a devolução ter sido construida
                if(osLeitores[linhaLeitor].QuantosLivrosComLeitor > 0)
                    ExibirLivroDevolucao();
                else
                {
                    dgvLivro.Rows.Clear();
                    dgvLeitor.Rows.Clear();
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }

        }

        void ExcluirLivroDoLeitor(int livro)
        {
            // é possivel devolver esse livro?
            if (livro < 0 || livro > osLeitores[linhaLeitor].QuantosLivrosComLeitor - 1)
            {
                throw new Exception("Índice fora dos limites!");
            }

            // Quantidade de livros diminui a cada devolução
            osLeitores[linhaLeitor].QuantosLivrosComLeitor--;

            // Reorganiza o vetor CodigoLivroComLeitor[] após a devolução do livro selecionado
            for (int indice = livro; indice < osLeitores[linhaLeitor].QuantosLivrosComLeitor; indice++)
            {
                osLeitores[linhaLeitor].CodigoLivroComLeitor[indice] = osLeitores[linhaLeitor].CodigoLivroComLeitor[indice + 1];
            }

        }
    }
}

