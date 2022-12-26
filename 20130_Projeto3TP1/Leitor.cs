using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apBiblioteca
{
    class Leitor : IComparable<Leitor>, IRegistro
    {
        public const int tamanhoCodigoLeitor    = 6;
        const int tamanhoCpf                    = 11;
        const int tamanhoDataNascimento         = 10;
        const int tamanhoTelefone               = 11;
        const int tamanhoNome                   = 50;
        const int tamanhoEndereco               = 50;
        const int tamanhoQuantosLivros          = 2;
        const int tamanhoCodigoLivro            = Livro.tamanhoCodigoLivro;
        const int maximoLivrosComLeitor         = 5;

        const int inicioCodigoLeitor            = 0;
        const int inicioCpfLeitor               = inicioCodigoLeitor + tamanhoCodigoLeitor;
        const int inicioDataNascimentoLeitor    = inicioCpfLeitor + tamanhoCpf;
        const int inicioTelefoneLeitor          = inicioDataNascimentoLeitor + tamanhoDataNascimento;
        const int inicioNome                    = inicioTelefoneLeitor + tamanhoTelefone;
        const int inicioEndereco                = inicioNome + tamanhoNome;
        const int inicioQuantosLivros           = inicioEndereco + tamanhoEndereco;
        const int inicioCodigosLivros           = inicioQuantosLivros + tamanhoQuantosLivros;

        string codigoLeitor;
        string cpfLeitor;
        DateTime dataNascimentoLeitor;
        string telefoneLeitor;
        string nomeLeitor;
        string enderecoLeitor;
        byte quantosLivrosComLeitor;
        string[] codigoLivroComLeitor;


        public Leitor()  // para que esta classe seja compatível com a interface IVetorDados e a classe genérica Registro
        {

        }
        public Leitor(string cl)  // usado na Inclusão
        { 
            CodigoLeitor = cl;
        }
        public Leitor(string leitor, string cpf, DateTime data, string telefone, string nome, string endereco, byte quantos, string[] livros)
        {
            CodigoLeitor            = leitor;
            CpfLeitor               = cpf;
            DataNascimento          = data;
            TelefoneLeitor          = telefone;
            NomeLeitor              = nome;
            EnderecoLeitor          = endereco;
            QuantosLivrosComLeitor  = quantos;
            CodigoLivroComLeitor    = livros;
        }


        public string CodigoLeitor
        {
            get => codigoLeitor;
            set
            {
                if (value.Length > tamanhoCodigoLeitor)
                {
                    value = value.Substring(0, tamanhoCodigoLeitor);
                }
                codigoLeitor = value.PadLeft(tamanhoCodigoLeitor, '0');
            }
        }

        public string CpfLeitor
        {
            get => cpfLeitor;
            set
            {
                if (value.Length > tamanhoCpf)
                {
                    value = value.Substring(0, tamanhoCpf);
                }
                cpfLeitor = value.PadLeft(tamanhoCpf, '0');
            }
        }

        public DateTime DataNascimento
        {
            get => dataNascimentoLeitor;
            set => dataNascimentoLeitor = value;
        }

        public string TelefoneLeitor
        {
            get => telefoneLeitor;
            set
            {
                if (value.Length > tamanhoTelefone)
                {
                    value = value.Substring(0, tamanhoTelefone);
                }
                telefoneLeitor = value.PadLeft(tamanhoTelefone, ' ');
            }
        }

        public string NomeLeitor
        {
            get => nomeLeitor;
            set
            {
                if (value.Length > tamanhoNome)
                {
                    value = value.Substring(0, tamanhoNome);
                }
                nomeLeitor = value.PadRight(tamanhoNome, ' ');
            }
        }
        public string EnderecoLeitor
        {
            get => enderecoLeitor;
            set
            {
                if(value.Length > tamanhoEndereco)
                {
                    value = value.Substring(0, tamanhoEndereco);
                }
                enderecoLeitor = value.PadRight(tamanhoEndereco, ' ');
            }
        }

        public byte QuantosLivrosComLeitor
        {
            get => quantosLivrosComLeitor;
            set
            {
                if (value >= 0 && value <= maximoLivrosComLeitor)
                {
                    quantosLivrosComLeitor = value;
                }
            }
        }

        public string[] CodigoLivroComLeitor
        {
            get => codigoLivroComLeitor;
            set => codigoLivroComLeitor = value;
        }

        public int CompareTo(Leitor outro)
        {
            return codigoLeitor.CompareTo(outro.codigoLeitor);
        }

        public string FormatoDeArquivo()
        {
            string saida = CodigoLeitor + CpfLeitor + DataNascimento.ToShortDateString() + TelefoneLeitor + NomeLeitor + EnderecoLeitor + 
                           QuantosLivrosComLeitor.ToString().PadLeft(tamanhoQuantosLivros, ' ');

            for (int indice = 0; indice < QuantosLivrosComLeitor; indice++)
            {
                saida   = saida + CodigoLivroComLeitor[indice];
            }

            return saida;
        }

        public void LerRegistro(StreamReader arq)
        {
            if (!arq.EndOfStream)
            {
                String linha            = arq.ReadLine();
                CodigoLeitor            = linha.Substring(inicioCodigoLeitor, tamanhoCodigoLeitor);
                CpfLeitor               = linha.Substring(inicioCpfLeitor, tamanhoCpf);
                DataNascimento          = DateTime.Parse(linha.Substring(inicioDataNascimentoLeitor, tamanhoDataNascimento));
                TelefoneLeitor          = linha.Substring(inicioTelefoneLeitor, tamanhoTelefone);
                NomeLeitor              = linha.Substring(inicioNome, tamanhoNome);
                EnderecoLeitor          = linha.Substring(inicioEndereco, tamanhoEndereco);
                QuantosLivrosComLeitor  = byte.Parse(linha.Substring(inicioQuantosLivros, tamanhoQuantosLivros));
                CodigoLivroComLeitor    = new string[maximoLivrosComLeitor];

                for (int indice = 0; indice < QuantosLivrosComLeitor; indice++)
                {
                   CodigoLivroComLeitor[indice] = linha.Substring(inicioCodigosLivros + tamanhoCodigoLivro * indice, tamanhoCodigoLivro);
                }                    
            }
        }

        public override String ToString()
        {
            string saida = CodigoLeitor + " " + CpfLeitor + " "+ DataNascimento + " " + TelefoneLeitor + " " +NomeLeitor + " " + EnderecoLeitor + " " +
                           QuantosLivrosComLeitor.ToString().PadLeft(tamanhoQuantosLivros, ' ');
            for (int indice = 0; indice < QuantosLivrosComLeitor; indice++)
            {
                saida   += " " + CodigoLivroComLeitor[indice];
            }
            return saida;
        }
    }
}
