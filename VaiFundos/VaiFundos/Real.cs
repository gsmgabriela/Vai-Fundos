using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Real:Moeda
    {





        public Real(string nom_moed, char simb) : base(nom_moed,simb)
        {



        }

        


        public override double desconto_resgate(Aplicacao aplicacao)
        {
            double valor_resgate;

            valor_resgate = aplicacao.getValor_aplicacao() - ((aplicacao.getValor_aplicacao() * 20) /100);
            
            return valor_resgate;

        }








    }
}
