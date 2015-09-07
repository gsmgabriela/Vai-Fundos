using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Fundo_de_investimento
    {
        
            private int codigo_fundo;
            private string nome_fundo;
            private string sigla_fundo;
            private int opcao_moeda;


            
                   

            public Fundo_de_investimento(int cod_fun, string nom_fun, string sig_fun, int op_m)
            {
                codigo_fundo = cod_fun;
                nome_fundo = nom_fun;
                sigla_fundo = sig_fun;
                opcao_moeda = op_m;

            }



            public int getCodigo_fundo()
            {
                return codigo_fundo;
            }
            public void setCodigo_fundo(int cod_fun)
            {
                codigo_fundo = cod_fun;
            }

            public string getNome_fundo()
            {
                return nome_fundo;
            }
            public void setNome_fundo(string nom_fun)
            {
                nome_fundo = nom_fun;
            }

            public string getSigla_fundo()
            {
                return sigla_fundo;
            }
            public void setSigla_fundo(string sig_fun)
            {
                sigla_fundo = sig_fun;
            }
            public int getOpcaomoeda()
            {
            return opcao_moeda;
            }
            public void setOpcaomoeda(int op_m)
            {
           opcao_moeda = op_m;
            }






    }

}
