﻿using System;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmTipoLivro : Form
    {
        public FrmTipoLivro()
        {
            InitializeComponent();
        }

        /**************************************    ATRIBUTOS DA CLASSE        *****************************************/

        VetorDados<Livro> osLivros;
        VetorDados<TipoLivro> osTipos;

        int posicaoDeInclusao = -1;

        /*************************************************************************************************************/



        /**************************************    MÉTODOS DA CLASSE        *****************************************/

        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void txtCodigoTipoLivro_Leave_1(object sender, EventArgs e)
        {
            try
            {
                // se conseguiu converter a matricula digitada
                // ou se ela não está em branco
                if (!String.IsNullOrEmpty(txtCodigoTipoLivro.Text) && !String.IsNullOrWhiteSpace(txtCodigoTipoLivro.Text))
                {
                    byte codigo = byte.Parse(txtCodigoTipoLivro.Text);
                    if (codigo > 0 && codigo < 255) // se o código digitado é valido
                    {
                        codigo = byte.Parse(txtCodigoTipoLivro.Text);
                        var procurado = new TipoLivro(codigo); 

                        switch (osTipos.SituacaoAtual)
                        {
                            // Confere o que o usuario deseja fazer
                            case Situacao.incluindo:
                                {
                                    if (osTipos.Existe(procurado, out posicaoDeInclusao)) // categoria já cadastrada?
                                    {
                                        MessageBox.Show("Código já existe. Não pode ser incluído novamente!");
                                        btnCancelar.PerformClick();  // cancela a operação de inclusão
                                    }
                                    else  // o parâmetro posicaoDeInclusao recebeu o índice de onde a nova matrícula deveria estar no vetor dados
                                    {
                                        txtDescricaoLivro.Focus();  // cursor é posicionado no campo de digitaçao do nome do funcionário
                                        stlbMensagem.Text = "mensagem: Digite o título do novo livro";
                                    }
                                    break;
                                }
                            case Situacao.pesquisando:
                                {
                                    int posicaoDoRegistro = -1;
                                    if (!osTipos.Existe(procurado, out posicaoDoRegistro)) // categoria existe no arquivo?
                                    {
                                        MessageBox.Show("Código não existe, por favor digite outro código!");
                                        txtCodigoTipoLivro.Focus();
                                    }
                                    else   // o parâmetro posicaoDoRegistro recebeu o índice de onde está a matrícula procurada
                                    {
                                        osTipos.PosicaoAtual = posicaoDoRegistro;
                                    }
                                    txtCodigoTipoLivro.ReadOnly = true;
                                    txtCodigoTipoLivro.Text = null;
                                    btnCancelar.PerformClick(); // a categoria de livro procurada é exibida
                                    break;
                                }
                        }
                    }
                    else // o código não é valido
                    {
                        txtCodigoTipoLivro.Text = null;
                        btnCancelar.PerformClick(); // programa volta pro modo de navegãção
                        MessageBox.Show(" Operação cancelada, digite um código que esteja entre 0 e 255!");
                    }

                }
                else
                {
                    txtCodigoTipoLivro.Text = null;
                    MessageBox.Show("Código inválido. Digite corretamente!");
                    txtCodigoTipoLivro.Focus();
                }
            }
            catch (Exception erro)
            {
                txtCodigoTipoLivro.Focus();
                txtCodigoTipoLivro.Text = null;
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para salvar um nova categoria de livro no arquivo tipoLivro.txt
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Confere o que o usuario deseja salvar
                switch (osTipos.SituacaoAtual)
                {
                    case Situacao.incluindo:
                        {
                            var novo = new TipoLivro(Convert.ToByte(txtCodigoTipoLivro.Text), txtDescricaoLivro.Text); // Instancia um objeto da classe TipoLivro
                            osTipos.Incluir(novo, posicaoDeInclusao); // inclui um novo registro de tipo livro no arquivo texto correspondente
                            osTipos.SituacaoAtual = Situacao.navegando; // programa entra no modo de navegação
                            osTipos.PosicaoAtual = posicaoDeInclusao; // reposiciona no novo registro
                            btnCancelar.PerformClick();  // exibi o novo tipo de livro recentemente incluido
                        }
                        break;
                    case Situacao.editando:
                        {
                            // atualiza o atributo descrição do tipo de livro selecionado
                            osTipos[osTipos.PosicaoAtual].DescricaoDoLivro = txtDescricaoLivro.Text;
                            btnCancelar.PerformClick(); // exibi o tipo de livro recentemente editado
                        }
                        break;
                }
                txtCodigoTipoLivro.ReadOnly = true;  // usuário nao poderá mais digitasr nesese campo a menos que pressione [Novo]
                btnSalvar.Enabled = false; // desabilita novamente o btnSalvar até que se pressione [Novo] ou [Editar]
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a atualização das informações do formularioe e exibindo a versão mais recente do arquivo tipoLivro.txt
        private void AtualizarTela()
        {            

            if (!osTipos.EstaVazio)
            {
                int indice = osTipos.PosicaoAtual;
                txtCodigoTipoLivro.Text = $"{osTipos[indice].CodigoTipoLivro}"; // atributo chave 
                txtDescricaoLivro.Text = $"{osTipos[indice].DescricaoDoLivro}"; // atributo descrição do livro

                stlbMensagem.Text = $"Mensagem: Registro {(osTipos.PosicaoAtual + 1)} / {osTipos.Tamanho}";
                osTipos.ExibirDados(lbTipoLivro);
            }            
            else
            {
                LimparTela();
                lbTipoLivro.Items.Clear();
            }
            TestarBotoes(); // Habilita os botões de acordo com a necessidade do usuario

        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para deixar o programa no modo de inclusão
        private void btnNovo_Clic(object sender, EventArgs e)
        {
            txtCodigoTipoLivro.ReadOnly = false;
            txtCodigoTipoLivro.Enabled = true;
            osTipos.SituacaoAtual = Situacao.incluindo; // programa entrou no modo de inclusão
            LimparTela();  // limpamos os campos da tela para deixá-los prontos para digitação
            stlbMensagem.Text = "Mensagem: Digite o novo código de livro e pressione a tecla [Tab] para continuar";  // mensagem orientando o usuário
            txtCodigoTipoLivro.Focus(); // cursor é posicionado para iniciar a digitação do código (campo chave)
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição da 1° categoria de livro do arquivo tipoLivro.txt
        private void btnInicio_Click(object sender, EventArgs e)
        {
            // O primeiro registro do arquivo é apresentado na tela
            txtCodigoTipoLivro.ReadOnly = true;
            osTipos.PosicionarNoPrimeiro();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição da categoria de livro anterior em relação a atual do arquivo tipoLivro.txt
        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            // O registro anterior do arquivo é apresentado na tela
            txtCodigoTipoLivro.ReadOnly = true;
            osTipos.RetrocederPosicao();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição da próxima categoria de livro em relação a atual do arquivo tipoLivro.txt
        private void btnProximo_Click_1(object sender, EventArgs e)
        {
            // O próximo registro do arquivo é apresentado na tela
            txtCodigoTipoLivro.ReadOnly = true;
            osTipos.AvancarPosicao();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/




        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exibição da última categoria de livro do arquivo tipoLivro.txt
        private void btnUltimo_Click_1(object sender, EventArgs e)
        {
            // O último registro do arquivo é apresentado na tela
            txtCodigoTipoLivro.ReadOnly = true;
            osTipos.PosicionarNoUltimo();
            AtualizarTela();
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/
        


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a busca de categorias de livro no arquivo tipoLivro.txt
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            LimparTela(); // limpamos os campos da tela para deixá-los prontos para digitação e exibição dos dados
            txtCodigoTipoLivro.ReadOnly = false;
            osTipos.SituacaoAtual = Situacao.pesquisando;
            txtCodigoTipoLivro.Focus(); // foco é colocado no atributo chave de pesquisa
            stlbMensagem.Text = "Mensagem: Digite o código do livro desejado e pressione [Tab] para buscá-lo.";
            btnSalvar.Enabled = false;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para limpar os campos da tela para deixá-los prontos para digitação  
        private void LimparTela()
        {
            // Limpamos os campos da tela para deixá-los prontos para digitação ou exibição         
            txtCodigoTipoLivro.Clear();
            txtDescricaoLivro.Clear();
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para habilitar somente os botões correspondentes ao modo atual do programa  
        private void TestarBotoes()
        {
            // Habilita os botões do menu de acordo com a necessidade do usuario
            btnInicio.Enabled = true;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnBuscar.Enabled = true;
            txtCodigoTipoLivro.Enabled = true;

            if (osTipos.EstaNoInicio)
            {
                btnInicio.Enabled = false;
                btnAnterior.Enabled = false;
            }

            if (osTipos.EstaNoFim)
            {
                btnProximo.Enabled = false;
                btnUltimo.Enabled = false;
            }

            if (osTipos.EstaVazio)
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnBuscar.Enabled = false;
                txtCodigoTipoLivro.Enabled = false;
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a gravação das categorias de livro atualizados no arquivo tipoLivro.txt, após o formulário ser fechado
        private void FrmTipoLivro_FormClosing(object sender, FormClosingEventArgs e)
        {
            osTipos.GravacaoEmDisco("C:\\Users\\aluno\\Music\\tipolivro.txt"); // Grava dos dados atualizados no arquivo texto
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para exclusão de uma categoria de livro no arquivo tipoLivro.txt
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            int  indice = 0;
            bool achou  = false;
            if(!osLivros.EstaVazio)
            {
                for (indice = 0; indice < osLivros.Tamanho; indice++) // Percorre todos os livros para saber se a categoria está sendo usada
                {
                    //       Foreing Key             ==           Prime Key
                    if (osLivros[indice].TipoDoLivro == osTipos[osTipos.PosicaoAtual].CodigoTipoLivro) // tipo de livro está sendo usado?
                    {
                        MessageBox.Show("Não é possível concluir a exclusão, pois existem livros que estão registrados com esse tipo de livro.");
                        achou = true;
                    }
                }
            }
            
            if (!achou)  // Se chegou ao final do arquivo e não achou relação entre as chaves, pode-se excluir o tipo 
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    osTipos.Excluir(osTipos.PosicaoAtual); // Exclui o tipo de livro selecionado
                    btnProximo.PerformClick();
                    AtualizarTela(); // Atualiza a tela com os dados do próximo tipo de livro do arquivo
                }
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para cancelar o modo atual do programa
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            osTipos.SituacaoAtual = Situacao.navegando;  // desfaz o modo anterior do programa e volta ao modo de navegação
            AtualizarTela();        // restaura na tela o registro que era exibido antes da operação que foi cancelada
            txtCodigoTipoLivro.ReadOnly = true;
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para edição de categorias de livro no arquivo tipoLivro.txt
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            int indice;
            for (indice = 0; indice < osLivros.Tamanho; indice++) // Percorre todos os livros para saber se a categoria está sendo usada
            {
                if (osLivros[indice].TipoDoLivro == osTipos[osTipos.PosicaoAtual].CodigoTipoLivro) // tipo de livro está sendo usado?
                {
                    MessageBox.Show("Não é possível concluir a edição, pois existem livros que estão registrados com esse tipo de livro.");
                    break;
                }
            }
            if (indice == osLivros.Tamanho) // Se chegou ao final do arquivo e não achou relação entre as chaves, pode-se editar o tipo 
            {
                osTipos.SituacaoAtual = Situacao.editando;
                txtCodigoTipoLivro.ReadOnly = true;               // não deixa usuário alterar a matrícula
                txtDescricaoLivro.Focus();                        // cursor é colocado no campo que é possível editar
                btnSalvar.Enabled = true;                         // deixa o usuario salvar a edição
                stlbMensagem.Text = "Mensagem: Digite a nova descrição e pressione [Salvar] para registrar.";
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------------------------*/
        // Método para fechar o formulário de livros
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();  // fecha o formulário  tipo de livro
        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmTipoLivro_Load(object sender, EventArgs e)
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

            // Leitura dos arquivos textos
            osLivros = new VetorDados<Livro>(50);
            osLivros.LerDados("C:\\Users\\aluno\\Music\\livros.txt");

            osTipos = new VetorDados<TipoLivro>(50);
            osTipos.LerDados("C:\\Users\\aluno\\Music\\tipolivro.txt");

            btnInicio.PerformClick();  // Posiciona o formulário para exibir o primeiro tipo de livro cadastrado

        }
        /*-----------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------------------------------------------------------*/
        // Método que faz o código que está sendo digiitado ficar sem espaços em branco
        private void txtCodigoTipoLivro_TextChanged(object sender, EventArgs e)
        {
            txtCodigoTipoLivro.Text = txtCodigoTipoLivro.Text.Trim();
        }

        private void txtDescricaoLivro_Leave(object sender, EventArgs e)
        {
            try
            {
                // se conseguiu converter a matricula digitada
                // ou se ela não está em branco
                if (!String.IsNullOrEmpty(txtDescricaoLivro.Text) && !String.IsNullOrWhiteSpace(txtDescricaoLivro.Text))
                {
                    byte codigo = byte.Parse(txtCodigoTipoLivro.Text);
                    if (codigo > 0 && codigo < 255) // se o código digitado é valido
                    {
                        codigo = byte.Parse(txtCodigoTipoLivro.Text);
                        var procurado = new TipoLivro(codigo);

                        if(osTipos.SituacaoAtual == Situacao.incluindo)
                        {
                            if (osTipos.Existe(procurado, out posicaoDeInclusao)) // categoria já cadastrada?
                            {
                                MessageBox.Show("Código já existe. Não pode ser incluído novamente!");
                                btnCancelar.PerformClick();  // cancela a operação de inclusão
                            }
                            else  // o parâmetro posicaoDeInclusao recebeu o índice de onde a nova matrícula deveria estar no vetor dados
                            {
                                btnSalvar.Enabled = true;
                            }
                        }
                    }
                    else // o código não é valido
                    {
                        txtCodigoTipoLivro.Text = null;
                        btnCancelar.PerformClick(); // programa volta pro modo de navegãção
                        MessageBox.Show(" Operação cancelada, digite um código que esteja entre 0 e 255!");
                    }

                }
                else
                {
                    txtCodigoTipoLivro.Text = null;
                    MessageBox.Show("Descrição inválida. Digite corretamente!");
                    txtCodigoTipoLivro.Focus();
                }
            }
            catch (Exception erro)
            {
                txtCodigoTipoLivro.Focus();
                txtCodigoTipoLivro.Text = null;
                MessageBox.Show("Erro de arquivo: " + erro.Message);
            }
        }
        /*-----------------------------------------------------------------------------------------------------*/

        /*************************************************************************************************************/

    }
}
