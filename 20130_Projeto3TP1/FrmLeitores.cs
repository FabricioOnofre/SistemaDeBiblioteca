using System;
using System.IO;
using System.Windows.Forms;

namespace apBiblioteca
{        
    // Autor: Fabricio Onofre Rezende de Camargo

    public partial class FrmLeitores : Form
    {
        public FrmLeitores()
        {
            InitializeComponent();
        }




        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        VetorDados<Livro>       osLivros;
        VetorDados<Leitor>      osLeitores;
        VetorDados<TipoLivro>   osTipos;

        int posicaoDeInclusao = -1;

        /*************************************************************************************************************/






        /**************************************    MÉTODOS DA CLASSE        *****************************************/

        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmLeitores_Load(object sender, EventArgs e)
        {
            tsBotoes.ImageList = imlBotoes;
            int indice = 0;
            foreach (ToolStripItem item in tsBotoes.Items)
            {
                if (item is ToolStripButton) // se não é separador:
                {
                    (item as ToolStripButton).ImageIndex = indice++; // Adiciona a imagem no botão
                }
            }

            // Leitura dos arquivos textos
            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osLeitores = new VetorDados<Leitor>(50);
            osLeitores.LerDados("C:\\Users\\aluno\\Music\\leitores.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");

            
            btnInicio.PerformClick();       // Posiciona o formulário para exibir o primeiro leitor cadastrado
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibir somente os botões correspondentes ao modo atual do programa 
        private void TestarBotoes()
        {
            // Habilita os botões do menu de acordo com a necessidade do usuario
            btnInicio.Enabled           = true;
            btnAnterior.Enabled         = true;
            btnProximo.Enabled          = true;
            btnUltimo.Enabled           = true;
            btnEditar.Enabled           = true;
            btnExcluir.Enabled          = true;
            btnBuscar.Enabled           = true;
            txtCodigoLeitor.Enabled     = true;

            if (osLeitores.EstaNoInicio)
            {
                btnInicio.Enabled       = false;
                btnAnterior.Enabled     = false;
            }

            if (osLeitores.EstaNoFim)
            {
                btnProximo.Enabled      = false;
                btnUltimo.Enabled       = false;
            }

            if (osLeitores.EstaVazio)
            {
                btnEditar.Enabled       = false;
                btnExcluir.Enabled      = false;
                btnBuscar.Enabled       = false;
                txtCodigoLeitor.Enabled = false;
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a atualização do datagridview para que assim exiba a versão mais recente dos arquivos de livros e leitores
        private void AtualizarTela()
        {
            if (!osLeitores.EstaVazio)
            {
                int posicaoAtual = osLeitores.PosicaoAtual;

                // Preenche os campos de identiicação do leitor
                txtCodigoLeitor.Text    = osLeitores[posicaoAtual].CodigoLeitor;
                txtNomeLeitor.Text      = osLeitores[posicaoAtual].NomeLeitor;
                txtEndereco.Text        = osLeitores[posicaoAtual].EnderecoLeitor;

                // Preenche e exibe os livros com o leitor 
                txtLivros.Text = "Código            Título                             Devolução";
                for (int indLivro = 0; indLivro < osLeitores[posicaoAtual].QuantosLivrosComLeitor; indLivro++)
                {
                    int ondeLivro = 0;
                    // Buscamos o livro cujo código esta em
                    // osLeitores[indice].CodigoLivroComLeitor[indLivro].
                    // O parâmetro ondeLivro é retornado com o índice desse livro no
                    // vetor dados interno a osLivros.
                    var livroProc = new Livro(osLeitores[posicaoAtual].CodigoLivroComLeitor[indLivro]);

                    if (osLivros.Existe(livroProc, out ondeLivro))
                    {
                        // acessamos, no vetor dados de osLivros, a entidade armazenada
                        // na posicao ondeLivro para então acessar o registro de livro
                        // que está encapsulado nessas classes:
                        txtLivros.AppendText(Environment.NewLine + $"{osLivros[ondeLivro].CodigoLivro}   " +
                        $"{osLivros[ondeLivro].TituloLivro}           " + $"   {osLivros[ondeLivro].DataDevolucao.ToShortDateString()}");
                    }
                }
                osLeitores.ExibirDados(lbLeitores);
                stlbMensagem.Text = $"Mensagem: Registro {posicaoAtual + 1} / {osLeitores.Tamanho}";
            }
            else
            {
                txtCodigoLeitor.Text    = null;
                txtNomeLeitor.Text      = null;
                txtEndereco.Text        = null;
            }
            TestarBotoes();
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para limpar os campos da tela para deixá-los prontos para digitação  
        private void LimparTela()
        {
            // Limpamos os campos da tela para deixá-los prontos para digitação            
            txtCodigoLeitor.Clear();
            txtNomeLeitor.Clear();
            txtEndereco.Clear();
            txtLivros.Clear();
            stlbMensagem.Text = "Mensagem: ";
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para verificar o código digitado e continuar o programa de acordo com o modo atual
        private void txtCodigoLeitor_Leave(object sender, EventArgs e)
        {
            try
            {
                // se conseguiu converter o código digitada
                // ou se ela não está em branco
                if (!String.IsNullOrEmpty(txtCodigoLeitor.Text) && !String.IsNullOrWhiteSpace(txtCodigoLeitor.Text))
                {
                    MessageBox.Show("Digite um código de leitor válido!");
                    txtCodigoLeitor.Focus();
                }
                else
                {
                    Leitor leitorProc = new Leitor(txtCodigoLeitor.Text); // valores ficticios, o que importa é apenas o código do leitor digitado
                    switch (osLeitores.SituacaoAtual)
                    {
                        case Situacao.incluindo:
                            {
                                if (osLeitores.Existe(leitorProc, out posicaoDeInclusao)) // leitor está cadastrado?
                                {
                                    MessageBox.Show("Código de leitor repetido!");
                                    btnCancelar.PerformClick(); // cancela a operação de inclusão
                                }
                                else // nao está cadastrado, podemos continuar incluindo esse livro 
                                {
                                    btnSalvar.Enabled = true;
                                    txtNomeLeitor.Focus();
                                    stlbMensagem.Text = "Mensagem: Digite os demais dados";
                                }
                            }
                            break;

                        case Situacao.pesquisando:
                            {
                                int ondeExibir;
                                if (osLeitores.Existe(leitorProc, out ondeExibir))
                                {
                                    // o parâmetro ondeExibir recebeu o índice de onde está o leitor procurado
                                    osLeitores.PosicaoAtual = ondeExibir;
                                    AtualizarTela(); // o leitor procurdo é exibido na tela
                                }
                                else  // leitor não está cadastrado
                                {
                                    MessageBox.Show("Código de leitor não encontrado!");
                                    btnCancelar.PerformClick();
                                }
                            }
                            break;
                    }
                    txtCodigoLeitor.ReadOnly = true; // usuário nao poderá mais digitar nesese campo a menos que pressione [Novo] ou [Buscar]
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/












                    /********************************************************************/
                    /******************************* CRUD *******************************/
                    /********************************************************************/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para deixar o programa no modo de inclusão - CREATE
        private void btnNovo_Click(object sender, EventArgs e)
        {
            osLeitores.SituacaoAtual    = Situacao.incluindo;
            txtCodigoLeitor.ReadOnly    = false;
            btnSalvar.Enabled           = false;
            txtCodigoLeitor.Enabled     = true;
            LimparTela();
            txtCodigoLeitor.Focus();
            stlbMensagem.Text = "Mensagem: Digite o código do novo leitor";
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a busca de leitores no arquivo leitores.txt - READ
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimparTela(); // limpamos os campos da tela para deixá-los prontos para digitação
            osLeitores.SituacaoAtual    = Situacao.pesquisando; // o programa entrou no modo de pesquisa
            // libera os campos para o usuario digitar o codigo do leitor procurado
            txtCodigoLeitor.ReadOnly    = false;
            txtCodigoLeitor.Enabled     = true;
            txtCodigoLeitor.Focus();
            stlbMensagem.Text           = "Mensagem: Digite a matrícula do leitor que busca";
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para edição de leitores no arquivo leitores.txt - UPDATE
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor > 0) // leitor possui empréstimos?
            {
                MessageBox.Show("Náo se pode editar Leitor com livros em sua posse!");
            }
            else  // não tem empréstimos, podemos continuar editando esse leitor
            {
                osLeitores.SituacaoAtual = Situacao.editando;  // programa entra no modo de edição
                txtCodigoLeitor.ReadOnly = true;               // não deixa usuário alterar o código (prime key)
                btnSalvar.Enabled       = true;
                stlbMensagem.Text       = "Mensagem: Digite os dados atualizados pressione [Salvar] para registrá-los.";
                txtNomeLeitor.Focus();
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exclusão de um leitor no arquivo leitores.txt - DELETE
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor > 0) // leitor tem empréstimos?
            {
                MessageBox.Show("Náo se pode excluir Leitor com livros em sua posse!");
            }
            else // não tem empréstimos, podemos continuar excluindo esse leitor
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    osLeitores.Excluir(osLeitores.PosicaoAtual);    // Exclui o leitor selecionado
                    btnProximo.PerformClick();
                    AtualizarTela();                                // Atualiza a tela com os dados do próximo leitor do arquivo

                }
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para salvar um novo leitor no arquivo leitores.txt
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (osLeitores.SituacaoAtual)
                {
                    case Situacao.incluindo:
                        {
                            // Instancia um objeto da classe Leitor, com a quantidade livros 0 e os códigos de livros vazios.
                            // para que depois possamos fazer empréstimos com esse leitor.
                            var novoLeitor              = new Leitor(txtCodigoLeitor.Text, txtNomeLeitor.Text, txtEndereco.Text, 0, new string[5]);

                            osLeitores.Incluir(novoLeitor, posicaoDeInclusao);  // inclui um novo registro de leitor no arquivo texto 
                            osLeitores.SituacaoAtual    = Situacao.navegando;   // programa entra no modo de navegação
                            osLeitores.PosicaoAtual     = posicaoDeInclusao;    // reposiciona no novo registro de leitor
                            btnCancelar.PerformClick();                         // atualiza a tela para mostrar o novo leitor
                        }
                        break;

                    case Situacao.editando:
                        {
                            // os atributos do leitor são atualizados 
                            osLeitores[osLeitores.PosicaoAtual].NomeLeitor      = txtNomeLeitor.Text;
                            osLeitores[osLeitores.PosicaoAtual].EnderecoLeitor  = txtEndereco.Text;
                            btnCancelar.PerformClick(); // atualiza a tela para mostrar o leitor com os novos dados
                        }
                        break;
                }
                txtCodigoLeitor.ReadOnly    = true;     // usuário nao poderá mais digitasr nesese campo a menos que pressione [Novo]
                txtCodigoLeitor.Enabled     = false;    // usuário nao poderá mais entrar nesse campo atépressionar [Novo] ou [Buscar]
                btnSalvar.Enabled           = false;    // desabilita novamente o btnSalvar até que se pressione [Novo] ou [Editar]
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para cancelar o modo atual do programa
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            osLivros.SituacaoAtual = Situacao.navegando;  // desfaz o modo anterior do programa e volta ao modo de navegação
            AtualizarTela();              // restaura na tela o registro que era exibido antes da operação que foi cancelada
        }
        /*-----------------------------------------------------------------------------------------------------*/












                    /********************************************************************/
                    /******************** BOTOÕES DE NAVEGAÇÃO **************************/
                    /********************************************************************/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do 1° leitor do arquivo leitores.txt
        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            // O primeiro registro do arquivo é apresentado na tela
            txtCodigoLeitor.ReadOnly = true;
            osLeitores.PosicionarNoPrimeiro();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do livro anterior ao atual do arquivo livros.txt
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // O registro anterior do arquivo é apresentado na tela
            txtCodigoLeitor.ReadOnly = true;
            osLeitores.RetrocederPosicao();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do próximo leitor em relação ao atual do arquivo leitores.txt
        private void btnProximo_Click(object sender, EventArgs e)
        {
            // O próximo registro do arquivo é apresentado na tela
            txtCodigoLeitor.ReadOnly = true;
            osLeitores.AvancarPosicao();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do último leitor do arquivo leitores.txt
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // O último registro do arquivo é apresentado na tela
            txtCodigoLeitor.ReadOnly = true;
            osLeitores.PosicionarNoUltimo();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/













        /********************************************************************/
        /************************ FIM DO FORMULÁRIO *************************/
        /********************************************************************/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a gravação dos leitores atualizados no arquivo leitores.txt, após o formulário ser fechado
        private void FrmLivros_FormClosing(object sender, FormClosingEventArgs e)
        {
            osLeitores.GravacaoEmDisco("C:\\Users\\aluno\\Music\\leitores.txt"); // Grava os dados atualizados no arquivo texto
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para fechar o formulário de livros
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close(); // Fecha o programa
        }
        /*-----------------------------------------------------------------------------------------------------*/


    }
}
