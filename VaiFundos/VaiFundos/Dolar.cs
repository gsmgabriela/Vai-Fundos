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


        public void Contar_Notas(double Valor_Resgate)
        {
            double Aux1 = 0;
            int ND100 = 0;
            int ND50 = 0;
            int ND20 = 0;
            int ND10 = 0;
            int ND05 = 0;
            int ND02 = 0;
            int ND01 = 0;
           double Desconta100 = 100;
            double Desconta50 = 50;
            double Desconta20 = 20;
            double Desconta10 = 10;
            double Desconta05 = 5;
            double Desconta02 = 2;
            double Desconta01 = 1;


            // Conta as notas
            while (Valor_Resgate >= 100)
            {
                ND100++;
                Valor_Resgate = Valor_Resgate - Desconta100;
            }

            while (Valor_Resgate >= Desconta50)
            {
                ND50++;
                Valor_Resgate = Valor_Resgate - Desconta50;
            }

            while (Valor_Resgate >= Desconta20)
            {
                ND20++;
                Valor_Resgate = Valor_Resgate - Desconta20;
            }

            while (Valor_Resgate >= Desconta10)
            {
                ND10++;
                Valor_Resgate = Valor_Resgate - Desconta10;
            }

            while (Valor_Resgate >= Desconta05)
            {
                ND05++;
                Valor_Resgate = Valor_Resgate - Desconta05;
            }


            while (Valor_Resgate >= Desconta02)
            {
                ND02++;
                Valor_Resgate = Valor_Resgate - Desconta02;
            }

            while(Valor_Resgate >= Desconta01)
            {
                Valor_Resgate = Valor_Resgate - Desconta01;
            }


            // Imprime na tela
            Console.WriteLine("Nota 100: " + ND100 + " Nota 50: " + ND50 + " Nota 20: " + ND20 + " Nota 10: " + ND10 + " Nota 5: " + ND05 + " Nota2: " + ND02 + " Nota1: " + ND01);             
        }
           

    }
}
