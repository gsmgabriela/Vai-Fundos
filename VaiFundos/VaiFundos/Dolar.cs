using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Dolar:Moeda
    {


        public Dolar(string nom_moed, char simb) : base(nom_moed, simb)
        {

        }





        public override double desconto_resgate(Aplicacao aplicacao)
        {
            double valor_resgate;

            valor_resgate = aplicacao.getValor_aplicacao() - ((aplicacao.getValor_aplicacao() * 1) / 100);
            Console.WriteLine("classe Dolar!");
            return valor_resgate;
            

        }


        }
}
