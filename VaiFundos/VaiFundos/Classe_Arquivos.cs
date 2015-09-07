using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VaiFundos
{
    class Classe_Arquivos
    {


        public void Ler_Arq_Cliente()
        {
            //try
            //{
            // Ler Arquivo para add clientes

            try
            {

                FileStream Arquivo_clientes = new FileStream("C:\\Users\\R.ROMUALDOL\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\bin\\Debug\\Arq_Cliente", FileMode.Open, FileAccess.Read);
                StreamReader leitor = new StreamReader(Arquivo_clientes, Encoding.Unicode);
                // StreamWriter leitorEscrita = new StreamWriter(Arquivo_clientes, Encoding.Unicode);

                ///////////////////////////////////////////////////////////
                String testeliha;
                testeliha = leitor.ReadLine();


                //String[] TesteV = testeliha
                //TesteV = testeliha.Split(new Char[] { ';' });

            while (testeliha != null)
            {

                Console.WriteLine(testeliha);
                leitor.ReadLine();

            }

                leitor.Close();
                Arquivo_clientes.Close();
            }
            catch (Exception)
            
            {
                Console.WriteLine("TEste Erro");
            }


        }






    }
}
