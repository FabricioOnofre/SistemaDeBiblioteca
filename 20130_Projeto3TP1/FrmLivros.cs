using System;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmLivros : Form
    {

        public FrmLivros()
        {
            InitializeComponent();
        }

        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        VetorDados<Livro> osLivros;
        VetorDados<Leitor> osLeitores;
        VetorDados<TipoLivro> osTipos;

        int posicaoDeInclusao = -1;

        /*************************************************************************************************************/


        /**************************************    MÉTODOS DA CLASSE        *****************************************/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmFunc_Load(object sender, EventArgs e)
        {
            // Exibição das imagens nos botões do menu de navegação
            tsBotoes.ImageList = imlBotoes;
            int indice = 0;
            foreach (ToolStripItem item in tsBotoes.Items)
            {
                if (item is ToolStripButton) // se não é separador:
                {
                    (item as ToolStripButton).ImageIndex = indice++; // Adiciona a imagem no botão
                }
            }

            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osLeitores = new VetorDados<Leitor>(50);
            osLeitores.LerDados("C:\\Users\\aluno\\Music\\leitores.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");

            btnInicio.PerformClick();  // Posiciona o formulário para exibir o primeiro livro cadastrado
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a atualização do datagridview para que assim exiba a versão mais recente dos arquivos de livros e leitores
        private void AtualizarTela()
        {
            if (!osLivros.EstaVazio)
            {
                // Preenche os campos de identiicação do livro
                txtCodigoLivro.Text = osLivros[osLivros.PosicaoAtual].CodigoLivro + "";
                txtTituloLivro.Text = osLivros[osLivros.PosicaoAtual].TituloLivro + "";

                if (osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro != "000000") // livro emprestado?
                {
                    int ondeLeitor = 0;
                    var leitorProc = new Leitor(osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro);

                    // Preenche e exibe os dados do leitor com o livro
                    if (osLeitores.Existe(leitorProc, out ondeLeitor))
                    {
                        txtLeitorComLivro.Text = osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro;
                        txtNomeLeitor.Text = osLeitores[ondeLeitor].NomeLeitor;
                        dtpDevolucao.Value = osLivros[osLivros.PosicaoAtual].DataDevolucao;
                    }
                }

                osLivros.ExibirDados(lbLivros);
            }
            else
            {
                LimparTela();
            }

            if (!osTipos.EstaVazio)
            {
                // Preenche e exibe as categorias do livros
                dgvTipoLivro.RowCount = osTipos.Tamanho;
                for (int indice = 0; indice < dgvTipoLivro.RowCount; indice++)
                {
                    dgvTipoLivro[0, indice].Value = osTipos[indice].CodigoTipoLivro;
                    dgvTipoLivro[1, indice].Value = osTipos[indice].DescricaoDoLivro;
                }

                // Desabilita as linhas atuais selecionadas
                dgvTipoLivro.ClearSelection();
            }
            else
            {
                dgvTipoLivro.Rows.Clear();
            }

            if (!osLivros.EstaVazio && !osTipos.EstaVazio)
            {

                for (int linha = 0; linha < osTipos.Tamanho; linha++)
                {
                    int pkTipoLivro = Convert.ToInt32(dgvTipoLivro.Rows[linha].Cells[0].Value.ToString()); // Prime Key
                    int fkTipoLivro = Convert.ToInt32(osLivros[osLivros.PosicaoAtual].TipoDoLivro);        // Foreing Key
                    if (pkTipoLivro == fkTipoLivro) // Se esse tipo for a categoria do livro atual
                    {
                        dgvTipoLivro.Rows[linha].Selected = true; // Habilita essa linha como selecionada
                        break;
                    }
                }

                txtLeitorComLivro.Text = "000000";
                dtpDevolucao.Value = dtpDevolucao.MaxDate;
                txtNomeLeitor.Text = "";
            }
            

            TestarBotoes();
            stlbMensagem.Text = "Mensagem: Registro " + (osLivros.PosicaoAtual + 1) + "/" + osLivros.Tamanho;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para limpar os campos da tela para deixá-los prontos para digitação  
        private void LimparTela()
        {
            txtCodigoLivro.Clear();
            txtTituloLivro.Clear();
            txtLeitorComLivro.Clear();
            txtNomeLeitor.Clear();
            dtpDevolucao.Value = dtpDevolucao.MaxDate;
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
            txtCodigoLivro.Enabled      = true;

            if (osLivros.EstaNoInicio)
            {
                btnInicio.Enabled       = false;
                btnAnterior.Enabled     = false;
            }

            if (osLivros.EstaNoFim)
            {
                btnProximo.Enabled      = false;
                btnUltimo.Enabled       = false;
            }

            if (osLivros.EstaVazio)
            {
                btnEditar.Enabled       = false;
                btnExcluir.Enabled      = false;
                btnBuscar.Enabled       = false;
                txtCodigoLivro.Enabled  = false;
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para deixar o programa no modo de inclusão
        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCodigoLivro.Enabled  = true;
            txtCodigoLivro.ReadOnly = false;
            dgvTipoLivro.ReadOnly   = false;
            osLivros.SituacaoAtual  = Situacao.incluindo; // programa entrou no modo de inclusão
            LimparTela();  // limpamos os campos da tela para deixá-los prontos para digitação
            stlbMensagem.Text = "Mensagem: Digite o novo código de livro e pressione a tecla [Tab] para continuar";  // mensagem orientando o usuário
            txtCodigoLivro.Focus(); // cursor é posicionado para iniciar a digitação do código
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para limpar os campos da tela para deixá-los prontos para digitação  
        private void txtCodigoLivro_Leave(object sender, EventArgs e)
        {
            try
            {
                // se conseguiu converter a matricula digitada
                // ou se ela não está em branco
                if (!String.IsNullOrEmpty(txtCodigoLivro.Text) && !String.IsNullOrWhiteSpace(txtCodigoLivro.Text))
                {
                    var procurado = new Livro(txtCodigoLivro.Text);
                    switch (osLivros.SituacaoAtual)
                    {
                        case Situacao.incluindo:
                            {
                                if (osLivros.Existe(procurado, out posicaoDeInclusao)) // livro está cadastrado?
                                {
                                    MessageBox.Show("Código já existe. Não pode ser incluído novamente!");
                                    btnCancelar.PerformClick();  // cancela a operação de inclusão
                                }
                                else  // o parâmetro posicaoDeInclusao recebeu o índice de onde o novo livro deveria estar no vetor dados
                                {
                                    txtTituloLivro.Focus();  // cursor é posicionado no campo de digitaçao do nome do funcionário
                                    stlbMensagem.Text = "mensagem: Digite o título do novo livro";
                                    btnSalvar.Enabled = true;
                                }
                                break;
                            }
                        case Situacao.pesquisando:
                            {
                                int posicaoDoRegistro = -1;
                                if (!osLivros.Existe(procurado, out posicaoDoRegistro))
                                {
                                    MessageBox.Show("Código não existe!");
                                }
                                else     // o parâmetro posicaoDoRegistro recebeu o índice de onde está o livro procurada
                                {
                                    osLivros.PosicaoAtual   = posicaoDoRegistro;
                                }

                                osLivros.SituacaoAtual      = Situacao.navegando;  // retornamos ao modo de navegação 
                                AtualizarTela();                            // e reexibimos o registro que anteriormente esteva na tela
                                break;
                            }
                    }
                }
                else   // O campo matrícula não foi digitado corretamente
                {
                    MessageBox.Show("Código inválido. Digite corretamente!");
                    txtCodigoLivro.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/




        /*-----------------------------------------------------------------------------------------------------*/
        // Método para salvar um novo livro no arquivo livro.txt
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                byte codigoTipoLivro = byte.Parse(dgvTipoLivro.CurrentRow.Cells[0].Value.ToString());
                switch (osLivros.SituacaoAtual)
                {
                    case Situacao.incluindo:
                        {
                            // Instancia um objeto da classe Livro, com a data de devolução maxima e o código leitor vazio
                            // para podermos depois fazer um empréstimo desse livro.
                            var novo = new Livro(txtCodigoLivro.Text, txtTituloLivro.Text,
                             codigoTipoLivro, new DateTime(1899, 1, 1), "000000");

                            osLivros.Incluir(novo, posicaoDeInclusao);      // inclui um novo registro de livro no arquivo texto 
                            osLivros.SituacaoAtual  = Situacao.navegando;   // programa entra no modo de navegação
                            osLivros.PosicaoAtual   = posicaoDeInclusao;    // reposiciona no novo registro de livro
                            btnCancelar.PerformClick();                     // atualiza a tela para mostrar o novo livro
                        }
                        break;
                    case Situacao.editando:
                        {
                            // o atributo tipo do livro e titulo do livro são atualizados 
                            osLivros[osLivros.PosicaoAtual].TituloLivro = txtTituloLivro.Text;
                            osLivros[osLivros.PosicaoAtual].TipoDoLivro = codigoTipoLivro;
                            btnCancelar.PerformClick(); // exibi o livro recentemente editado
                        }
                        break;
                }
                txtCodigoLivro.ReadOnly = true;  // usuário nao poderá mais digitar nesese campo a menos que pressione [Novo] ou [Buscar]
                btnSalvar.Enabled       = false; // desabilita novamente o btnSalvar até que se pressione [Novo] ou [Editar]
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a gravação dos livros atualizados no arquivo livro.txt, após o formulário ser fechado
        private void FrmLivros_FormClosing(object sender, FormClosingEventArgs e)
        {
            osLivros.GravacaoEmDisco("C:\\Users\\aluno\\Music\\livros.txt");// Grava os dados atualizados no arquivo texto
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exclusão de um livro no arquivo livros.txt
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro != "000000") // o livro está emprestado?
            {
                MessageBox.Show("Não é possível concluir a exclusão, pois o livro está emprestado.");
            }
            else  // nao está emprestado, podemos continuar excluindo esse leitor
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    osLivros.Excluir(osLivros.PosicaoAtual); // Exclui o livro selecionado
                    btnProximo.PerformClick();
                    AtualizarTela();    // Atualiza a tela com os dados do próximo livro do arquivo

                }
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a busca de livros no arquivo livros.txt
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimparTela();                                   // limpamos os campos da tela para deixá-los prontos para digitação
            txtCodigoLivro.ReadOnly = false;
            osLivros.SituacaoAtual  = Situacao.pesquisando; // programa entrou no modo de pesquisa
            txtCodigoLivro.Focus();                         // cursor é posicionado para iniciar a digitação do código
            stlbMensagem.Text       = "Mensagem: Digite o código do livro desejado e pressione [Tab] para buscá-lo.";
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para cancelar o modo atual do programa
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            osTipos.SituacaoAtual   = Situacao.navegando;   // desfaz o modo anterior do programa e volta ao modo de navegação
            AtualizarTela();                                // restaura na tela o registro que era exibido antes da operação que foi cancelada
            txtCodigoLivro.ReadOnly = true;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para edição de livros no arquivo livros.txt
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro != "000000") // o livro está emprestado?
            {
                MessageBox.Show("Não é possível concluir a edição, pois o livro está emprestado.");
            }
            else // esse livro não tem relação com os demais arquivos
            {
                osLivros.SituacaoAtual  = Situacao.editando;
                txtCodigoLivro.ReadOnly = true;               // não deixa usuário alterar a matrícula (prime key)
                btnSalvar.Enabled       = true;
                stlbMensagem.Text       = "Mensagem: Digite os dados atualizados pressione [Salvar] para registrá-los.";
                txtTituloLivro.Focus();
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do 1° livro do arquivo livros.txt
        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            // O primeiro registro do arquivo é apresentado na tela
            osLivros.PosicionarNoPrimeiro();
            AtualizarTela();
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do livro anterior ao atual do arquivo livros.txt
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // O registro anterior do arquivo é apresentado na tela
            osLivros.RetrocederPosicao();
            AtualizarTela();
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do próximo livro ao atual do arquivo livros.txt
        private void btnProximo_Click(object sender, EventArgs e)
        {
            // O próximo registro do arquivo é apresentado na tela
            osLivros.AvancarPosicao();
            AtualizarTela();
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição do último livro do arquivo livros.txt
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // O último registro do arquivo é apresentado na tela
            osLivros.PosicionarNoUltimo();
            AtualizarTela();
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para fazer a escolha do tipo de livro que será incluido no arquivo livros.txt
        private void dgvTipoLivro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Exibição da linha do dgvTipoLivro
            if (osLivros.SituacaoAtual != Situacao.incluindo && !osLivros.EstaVazio)
            {
                // Não deixa outro tipo de livro ficar selecionada, há não ser o do livro atual
                dgvTipoLivro.Rows[Convert.ToInt32(dgvTipoLivro.CurrentRow.Index)].Selected = false;
                for (int linha = 0; linha < osTipos.Tamanho; linha++)
                {
                    int pkTipoLivro = Convert.ToInt32(dgvTipoLivro.Rows[linha].Cells[0].Value.ToString()); // Prime Key
                    int fkTipoLivro = Convert.ToInt32(osLivros[osLivros.PosicaoAtual].TipoDoLivro);        // Foreing Key

                    if (pkTipoLivro == fkTipoLivro)                 // Se esse tipo for a categoria do livro atual
                    {
                        dgvTipoLivro.Rows[linha].Selected = true;   // Habilita essa linha como selecionada e para a busca
                        break;
                    }
                }
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método que faz o código que está sendo digiitado ficar sem espaços em branco
        private void txtCodigoLivro_TextChanged(object sender, EventArgs e)
        {
            txtCodigoLivro.Text = txtCodigoLivro.Text.Trim();
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para fechar o formulário de livros
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        /*-----------------------------------------------------------------------------------------------------*/

        /*************************************************************************************************************/

    }
}
