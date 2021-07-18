using System;
using System.Drawing;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmEmprestimo : Form
    {        
        public FrmEmprestimo()
        {
            InitializeComponent();
        }

        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        VetorDados<Livro> osLivros;
        VetorDados<Leitor> osLeitores;
        VetorDados<TipoLivro> osTipos;

        int linhaLeitor = -1;
        int linhaLivro = -1;

        /*************************************************************************************************************/



        /**************************************    MÉTODOS DA CLASSE        *****************************************/

        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmEmprestimo_Load(object sender, EventArgs e)
        {
            // Leitura dos arquivos textos

            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osLeitores = new VetorDados<Leitor>(50);
            osLeitores.LerDados("C:\\Users\\aluno\\Music\\leitores.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");


            AtualizarTela();  // Exibi os dados iniciais dos arquivos textos 
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a atualização do datagridview para que assim exiba a versão mais recente dos arquivos txt
        private void AtualizarTela()
        {
            // Exibi os dados atualizados dos leitores e livros
            if (!osLeitores.EstaVazio && !osTipos.EstaVazio && !osLivros.EstaVazio)
            {
                dgvLeitor.RowCount = osLeitores.Tamanho; // É passado quantas linhas o dgvLeitor deve conter

                for (int indice = 0; indice < osLeitores.Tamanho; indice++)
                {
                    // Preenche os campos do dgvLeitor com os atributos do registro de leitor
                    dgvLeitor.Rows[indice].DefaultCellStyle.BackColor = Color.LightBlue; 
                    dgvLeitor[0, indice].Value = osLeitores[indice].CodigoLeitor;
                    dgvLeitor[1, indice].Value = osLeitores[indice].NomeLeitor;
                    dgvLeitor[2, indice].Value = osLeitores[indice].QuantosLivrosComLeitor;
                    byte qtdLivros = osLeitores[indice].QuantosLivrosComLeitor; 

                    if(qtdLivros > 0) // leitor fez empréstimos?
                    {
                        switch (qtdLivros)
                        {
                            // Exibi o código dos livros que estão emprestados
                            // através do vetor CodigoLivroComLeitor[]
                            case 1:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                }
                                break;
                            case 2:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                }
                                break;
                            case 3:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 3];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[5, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                }
                                break;
                            case 4:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 4];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 3];
                                    dgvLeitor[5, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[6, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                }
                                break;
                            case 5:
                                {
                                    dgvLeitor[3, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 5];
                                    dgvLeitor[4, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 4];
                                    dgvLeitor[5, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 3];
                                    dgvLeitor[6, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 2];
                                    dgvLeitor[7, indice].Value = osLeitores[indice].CodigoLivroComLeitor[qtdLivros - 1];
                                    dgvLeitor.Rows[indice].DefaultCellStyle.BackColor = Color.LightCoral;
                                }
                                break;
                        }
                    }
                }

                dgvLivro.RowCount = osLivros.Tamanho; // É passado quantas linhas o dgvLivro deve conter
                for (int indLivro = 0; indLivro < osLivros.Tamanho; indLivro++)
                {
                    // Preenche os campos do dgvLivro com os atributos do registro de livro
                    dgvLivro[0, indLivro].Value = osLivros[indLivro].CodigoLivro;
                    dgvLivro[1, indLivro].Value = osLivros[indLivro].TituloLivro;

                    // Preenche o campo descrição do dgvLivro 
                    // através da busca e comparação das chaves 
                    for (int indTipoLivro = 0; indTipoLivro < osTipos.Tamanho; indTipoLivro++)
                    {
                        //        Foreing Key              ==            Prime Key
                        if (osLivros[indLivro].TipoDoLivro == osTipos[indTipoLivro].CodigoTipoLivro)
                        {
                            // a variavel indTipoLivro está na posição da descrição do tipo de livro atual
                            dgvLivro[2, indLivro].Value = osTipos[indTipoLivro].DescricaoDoLivro; 
                            break;
                        }
                    }

                    // Os livros já emprestados ficam com a cor vermelha
                    if( osLivros[indLivro].CodigoLeitorComLivro != "000000")
                    {
                        dgvLivro.Rows[indLivro].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else  // Os livros não emprestados ficam com a cor azul
                    {
                        dgvLivro.Rows[indLivro].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void dgvLeitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(osLeitores[Convert.ToInt32(dgvLeitor.CurrentRow.Index)].QuantosLivrosComLeitor == 5) // leitor já tem 5 empréstimos? 
            {
                MessageBox.Show("Não é possível escolher este leitor, pois ele não pode fazer mais empréstimos.");
                dgvLivro.Enabled = false;
                dtpDevolucao.Enabled = false;
                btnEmprestar.Enabled = false;
            }
            else // leitor ainda pode fazer empréstimos
            { 
                // Procura o registro em que o leitor selecionado está no arquivo 
                for (int indice = 0; indice < osLeitores.Tamanho; indice++)
                {
                    if (dgvLeitor.CurrentRow.Cells[0].Value.ToString() == osLeitores[indice].CodigoLeitor)
                    {
                        // a variavel linhaLeitor recebe qual o registro do leitor selecionado 
                        linhaLeitor = indice;
                        break;
                    }
                }
                dgvLivro.Enabled = true; // após a escolha do leitor, é liberado para escolher o livro
                stlbMensagem.Text = "Mensagem: Selecione o Livro que deseja fazer o empréstimo";
            }            
        }

        private void dgvLivro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (osLivros[Convert.ToInt32(dgvLivro.CurrentRow.Index)].CodigoLeitorComLivro != "000000") // livro já está emprestado?
            {
                MessageBox.Show("Não é possível escolher este livro, pois ele já está emprestado.");    
                dtpDevolucao.Enabled = false;
                btnEmprestar.Enabled = false;
            }
            else // livro ainda pode ser emprestado
            {
                byte qtdLivros = osLeitores[linhaLeitor].QuantosLivrosComLeitor;
                osLeitores[linhaLeitor].CodigoLivroComLeitor[qtdLivros] = dgvLivro.CurrentRow.Cells[0].Value.ToString();

                // Procura a linha do livro selecionado
                // através da busca e comparação das chaves 
                for (int indice = 0; indice < osLivros.Tamanho; indice++)
                {
                    //                              Foreing Key              ==            Prime Key
                    if (osLeitores[linhaLeitor].CodigoLivroComLeitor[qtdLivros] == osLivros[indice].CodigoLivro)
                    {                    
                        // a variavel indice está na posição do registro de livro atual
                        linhaLivro = indice;
                        break;
                    }
                }
                stlbMensagem.Text = "Mensagem: Selecione uma data para fazer a devolução do livro";
                dtpDevolucao.Enabled = true;
            }            
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            try
            {
                // Os atributos do registro livro selecionado são atualizados para o empréstimo
                osLivros[linhaLivro].DataDevolucao = dtpDevolucao.Value.Date;
                osLivros[linhaLivro].CodigoLeitorComLivro = dgvLeitor.CurrentRow.Cells[0].Value.ToString();

                // Desabilita todos os controles do formulário
                // para que o usuario siga o fluxo de execução ideal para o programa
                // Seleciona Leitor --> Livro ---> Data de devolução ---> Botão de emprestar
                dgvLivro.Enabled = false;
                dtpDevolucao.Enabled = false;
                btnEmprestar.Enabled = false;

                stlbMensagem.Text = "Mensagem: Selecione o Leitor que deseja fazer um empréstimo";

                // Instancia um objeto da classe livro com todos os seus atributos atulizados para o empréstimo
                var novoLivro = new Livro(osLivros[linhaLivro].CodigoLivro, osLivros[linhaLivro].TituloLivro,
                osLivros[linhaLivro].TipoDoLivro, dtpDevolucao.Value.Date, dgvLeitor.CurrentRow.Cells[0].Value.ToString());


                osLivros.Excluir(linhaLivro); // Exclui o registro antigo desse livro gravado no arquivo texto 
                osLivros.Incluir(novoLivro, linhaLivro); // Inclui o registro novo com os atualizados no arquivo texto

                // Quantidade de livros aumenta com o empréstimo concluido
                osLeitores[linhaLeitor].QuantosLivrosComLeitor += 1;

                // Instancia um objeto da classe leitor com todos os seus atributos atulizados para o empréstimo
                var novoLeitor = new Leitor(Convert.ToString(osLeitores[linhaLeitor].CodigoLeitor), Convert.ToString(osLeitores[linhaLeitor].NomeLeitor),
                Convert.ToString(osLeitores[linhaLeitor].EnderecoLeitor), osLeitores[linhaLeitor].QuantosLivrosComLeitor, osLeitores[linhaLeitor].CodigoLivroComLeitor);


                osLeitores.Excluir(linhaLeitor); // Exclui o registro antigo desse leitor gravado no arquivo texto 
                osLeitores.Incluir(novoLeitor, linhaLeitor); // Inclui o registro novo com os atualizados no arquivo texto

                AtualizarTela(); // Apresenta os dados atualizados do leitor e do livro após o empréstimo concluido
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }

        }

        private void dtpDevolucao_ValueChanged(object sender, EventArgs e)
        {
            // Somente quando o usuario selecionar um leitor, um livro e uma data de devolução validas
            // o [Emprestar] é liberado para concluir os empréstimos
            btnEmprestar.Enabled = true;  
        }

        private void FrmEmprestimo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Gravação dos dados atualizados dos arquivos texto Leitor e Livro
            osLeitores.GravacaoEmDisco("C:\\Users\\aluno\\Music\\leitores.txt");
            osLivros.GravacaoEmDisco("C:\\Users\\aluno\\Music\\livros.txt");
        }

        // variavel que identifica se o leitor mudou a data atual do dtpDevolucao
        int clicks = 0;

        private void dtpDevolucao_Enter(object sender, EventArgs e)
        {
            // A data minima pra devolução do livro é a data atual, ou seja, 
            //a data que o usuario tentar fazer o empréstimo
            if(clicks == 0)
            {
                dtpDevolucao.MinDate = dtpDevolucao.Value;
                clicks++;
            }

        }
    }
}
