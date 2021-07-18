using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apBiblioteca
{
    class TipoLivro : IComparable<TipoLivro>, IRegistro
    {
        public const int tamanhoCodigoLivro = 3;
        const int tamanhoDescricao          = 20;

        const int inicioCodigoTipoLivro     = 0;
        const int inicioDescricaoLivro      = inicioCodigoTipoLivro + tamanhoCodigoLivro;

        string descricaoTipo;
        byte tipoDoLivro;

        public TipoLivro()
        {

        }

        public TipoLivro(byte codigo)
        {
            CodigoTipoLivro = codigo;
        }

        public TipoLivro(byte tipo, string descricao)
        {
            CodigoTipoLivro     = tipo;
            DescricaoDoLivro    = descricao;
        }

        public byte CodigoTipoLivro
        {
            get => tipoDoLivro;
            set
            {                
                if (value >= 0 && value <= 255)
                {
                    string tipo = Convert.ToString(value);
                    if (tipo.Length > tamanhoCodigoLivro)
                    {
                        tipo    = tipo.PadLeft(tamanhoCodigoLivro, '0').Substring(0, tamanhoCodigoLivro);
                    }
                    tipoDoLivro = Convert.ToByte(tipo.PadLeft(tamanhoCodigoLivro, '0'));
                }
            }
        }

        public string DescricaoDoLivro
        {
            get => descricaoTipo;
            set => descricaoTipo = value;
        }

        public void LerRegistro(StreamReader arq)
        {
            if (!arq.EndOfStream)
            {
                String linha        = arq.ReadLine();
                CodigoTipoLivro     = byte.Parse(linha.Substring(inicioCodigoTipoLivro, tamanhoCodigoLivro));
                DescricaoDoLivro    = linha.Substring(inicioDescricaoLivro); 
            }
        }

        public int CompareTo(TipoLivro outro)
        {
            return tipoDoLivro.CompareTo(outro.tipoDoLivro);
        }

        public override String ToString()
        {            
            string saida = $"{CodigoTipoLivro}" + $"{DescricaoDoLivro}";                       
            return saida;
        }

        public string FormatoDeArquivo()
        {
            string saida = CodigoTipoLivro.ToString().PadLeft(tamanhoCodigoLivro, '0') + DescricaoDoLivro;
            return saida;
        }        
    }
}
