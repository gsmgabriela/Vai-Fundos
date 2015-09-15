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


        public void Contar_Notas(double Valor_Resgate)
        {
            double Aux1 = 0;
            int C100 = 0;
            int C50 = 0;
            int C20 = 0;
            int C10 = 0;
            int C05 = 0;
            int C02 = 0;
            double Desconta100 = 100;
            double Desconta50 = 50;
            double Desconta20 = 20;
            double Desconta10 = 10;
            double Desconta05 = 5;
            double Desconta02 = 2;


            // Conta as notas
            while (Valor_Resgate >= 100)
            {
                C100++;
                Valor_Resgate = Valor_Resgate - Desconta100;
            }

            while (Valor_Resgate >= Desconta50)
            {
                C50++;
                Valor_Resgate = Valor_Resgate - Desconta50;
            }

            while (Valor_Resgate >= Desconta20)
            {
                C20++;
                Valor_Resgate = Valor_Resgate - Desconta20;
            }

            while (Valor_Resgate >= Desconta10)
            {
                C10++;
                Valor_Resgate = Valor_Resgate - Desconta10;
            }

            while (Valor_Resgate >= Desconta05)
            {
                C05++;
                Valor_Resgate = Valor_Resgate - Desconta50;
            }


            while (Valor_Resgate >= Desconta02)
            {
                C02++;
                Valor_Resgate = Valor_Resgate - Desconta50;
            }

            if (Valor_Resgate >= 0 && Valor_Resgate < 2)
            {
                C02++;
            }
            // Imprime na tela
            Console.WriteLine("Nota 100: " + C100 + " Nota 50: " + C50 + " Nota 20: " + C20 + " Nota 10: " + C10 + " Nota 5: " + C05 + " Nota2: " + C02);

        }















    }
}
