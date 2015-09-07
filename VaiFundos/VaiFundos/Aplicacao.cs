using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Aplicacao
    {
        private int cod_aplicacao;
        private double valor_aplicacao;
        private DateTime data_aplicacao;
        public Cliente dados_cli;
         
        public Fundo_de_investimento fundo;




        public Aplicacao(double val_apli, DateTime dt_apli, int cod_apl)
        {
            cod_aplicacao = cod_apl;
            valor_aplicacao = val_apli;
            data_aplicacao = dt_apli;
            
        }
        
        public Aplicacao()
        {

        }

        public int getCod_aplicacao()
        {
            return cod_aplicacao;
        }
        public void setCod_aplicacao(int cod_apl)
        {
            cod_aplicacao = cod_apl;
        }
        
        public double getValor_aplicacao()
        {
            return valor_aplicacao;
        }

        public void setValor_aplicacao(double val_apli)
        {
            valor_aplicacao = val_apli;
        }

        public DateTime getData_aplicacao()
        {
            return data_aplicacao;
        }

        public void setData(DateTime dt_apli)
        {
            data_aplicacao = dt_apli;
        }





    }
}
