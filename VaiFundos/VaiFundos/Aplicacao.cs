using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Aplicacao
    {
        private double valor_aplicacao;
        private DateTime data_aplicacao;
        Cliente dados_cli;
        Fundo_de_investimento fundo;

        public Aplicacao(double val_apli, DateTime dt_apli)
        {
            valor_aplicacao = val_apli;
            data_aplicacao = dt_apli;
        }

        public Aplicacao()
        {

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
