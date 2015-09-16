using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VaiFundos
{
    class Real : Moeda
    {
        List<Real> Lista_Real = new List<Real>();


        public override void CarregarNotas()
        {
            using (StreamReader reader = new StreamReader("../../Notas_Real.txt"))
            {

                try
                {
                    string linha;
                    String[] Separador;
                    linha = reader.ReadLine();

                    int nota;
                    int Qtd_Nota;

                    // Ler linha por linha e Adiciona na lista de clientes                    
                    while (linha != null)
                    {

                        Separador = linha.Split(new char[] { ';' });

                        nota = int.Parse(Separador[0]);
                        Qtd_Nota = int.Parse(Separador[1]);

                        linha = reader.ReadLine();

                        Real Novo = new Real(nota, Qtd_Nota, nome_moeda, simbolo);
                        
                        

                    }
                    reader.Close();

                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao adicionar na lista");
                }
            }
        }

        

        public Real(string nom_moed, char simb) : base(nom_moed, simb)
        {



        }

        public Real(int nota, int Qtd_Nota, string nom_moed, char simb) : base(nom_moed, simb)
        {
            this.nota = nota;
            this.Qtd_Nota = Qtd_Nota;
        }




        public override double desconto_resgate(Aplicacao aplicacao)
        {
            double valor_resgate;

            valor_resgate = aplicacao.getValor_aplicacao() - ((aplicacao.getValor_aplicacao() * 20) / 100);

            return valor_resgate;

        }


        public  override  void Contar_Notas(double Valor_Resgate)
        {
            double Aux1 = 0;
            double C100 = 0;
            double C50 = 0;
            double C20 = 0;
            double C10 = 0;
            double C05 = 0;
            double C02 = 0;
            double Desconta100 = 100;
            double Desconta50 = 50;
            double Desconta20 = 20;
            double Desconta10 = 10;
            double Desconta05 = 5;
            double Desconta02 = 2;

            // Lista Real


            // Conta as notas

            /*
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

            */




            foreach (Real Real in Lista_Real)
            {

                while(Real.nota == 100 && Real.Qtd_Nota > 0 && Valor_Resgate >= 100) { 
                if(Real.nota == 100)
                {
         
                    if(Real.Qtd_Nota > 0)
                    {
                        
                        if(Valor_Resgate >= 100)
                        C100++;
                        Real.Qtd_Nota--;
                        Valor_Resgate = Valor_Resgate - 100;                   
                    }
                }
                }


                while (Real.nota == 50 &&  Real.Qtd_Nota > 0 && Valor_Resgate >= 50) { 
                if(Real.nota == 50)
                {
                    if(Real.Qtd_Nota > 0)
                    {
                        if(Valor_Resgate >= 50) { 
                            C50++;
                            Real.Qtd_Nota--;
                            Valor_Resgate = Valor_Resgate - 50;
                            }
                        }

                }
                }
                while (Real.nota == 20 && Real.Qtd_Nota > 0 && Valor_Resgate >= 20) { 
                    if (Real.nota == 20)
                {
                    while(Real.Qtd_Nota > 0)
                    {
                        
                        while(Valor_Resgate >= 20) { 
                                C20++;
                                Real.Qtd_Nota--;
                                Valor_Resgate = Valor_Resgate - 20;
                            }

                        }
                }
                }

                while (Real.nota == 10 && Real.Qtd_Nota > 0 && Valor_Resgate >= 10)
                {
                    if (Real.nota == 10)
                    {
                        if (Real.Qtd_Nota > 0)
                        {
                            if (Valor_Resgate >= 10)
                                C10++;
                                Real.Qtd_Nota--;
                                Valor_Resgate = Valor_Resgate - 10;
                        }
                    }
                }

                while (Real.nota == 5 && Real.Qtd_Nota > 0 && Valor_Resgate >= 5) { 
                if (Real.nota == 5)
                {
                    if(Real.Qtd_Nota > 0)
                    {
                        if(Valor_Resgate >= 5)
                        C05++;
                            Real.Qtd_Nota--;
                            Valor_Resgate = Valor_Resgate - 5;
                    }
                }
                }
            

            while (Real.nota == 2 && Real.Qtd_Nota > 0 && Valor_Resgate >= 2) { 
                if (Real.nota == 2)
                {
                    if(Real.Qtd_Nota > 0)
                    {
                        if(Valor_Resgate >= 2)
                        {
                            C02++;
                                Real.Qtd_Nota--;
                                Valor_Resgate = Valor_Resgate - 2;
                        }
                    }
                }
            }

            while(Valor_Resgate > 0 && Valor_Resgate < 2)
                {
                    C02++;
                    Valor_Resgate = 0;
                    
                }


                Console.WriteLine("Nota 100: " + C100 + " Nota 50: " + C50 + " Nota 20: " + C20 + " Nota 10: " + C10 + " Nota 5: " + C05 + " Nota2: " + C02);



            }
                     
        }

    }
}

