using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VaiFundos
{
    class Lista_fundos
    {


        List<Fundo_de_investimento> Lista_de_fundos = new List<Fundo_de_investimento>();

        // Metodo carrega os dados dos fundos cadastrados pelo arquivo
        public void FundosCadastrados()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\BRUNO\Source\Repos\Vai-Fundos\VaiFundos\VaiFundos\Fundos_Cadastrados.txt"))
            {

                try
                {
                    string linha;
                    String[] Separador;
                    linha = reader.ReadLine();

                    int codigoFundo = 0, OpMoeda = 0; String NomeFundo = "", SiglaFundo = "";

                    // Fundos cadastrados no Arquivo                   
                    while (linha != null)
                    {

                        Separador = linha.Split(new char[] { ';' });

                        codigoFundo = int.Parse(Separador[0]);
                        NomeFundo = (Separador[1]);
                        SiglaFundo = (Separador[2]);
                        OpMoeda = int.Parse(Separador[3]);

                        
                        linha = reader.ReadLine();

                        Fundo_de_investimento NovoFundo = new Fundo_de_investimento(codigoFundo,NomeFundo,SiglaFundo,OpMoeda);
                        Lista_de_fundos.Add(NovoFundo);

                    }
                    reader.Close();

                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao adicionar na lista");
                }
            }
        }

        //atualiza arquivo de fundos.
        public void Atualiza_arq_fundos()
        {

            using (StreamWriter escritor = new StreamWriter(@"C:\\Users\\BRUNO\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\\Fundos_Cadastrados.txt"))
            {
                try
                {
                    foreach (Fundo_de_investimento fundo in Lista_de_fundos)
                    {
                        escritor.WriteLine(fundo.getCodigo_fundo()+";"+fundo.getNome_fundo()+";"+fundo.getSigla_fundo()+";"+fundo.getOpcaomoeda());
                    }


                    escritor.Close();
                    Console.WriteLine("Atualizou!");
                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao Atualizar arquivo!");
                }


            }
        }











        //cadastra novo fundo na lista
        public void Cadatrar_fundo(Fundo_de_investimento novo_fundo)
        {
            
            
            if (Busca_fundo(novo_fundo.getCodigo_fundo()) == null)
            {
                
                Lista_de_fundos.Add(novo_fundo);
                Atualiza_arq_fundos();

                Console.WriteLine("Novo fundo incluído com sucesso!");

            }
            else
            {
                
                Console.WriteLine("Erro ao salvar, verifique se codigo está correto!");
            }
            
        }





        //busca fundo pelo codigo
        public Fundo_de_investimento Busca_fundo(int cod)
        {

            foreach (Fundo_de_investimento fundo in Lista_de_fundos)
            {


                if (fundo.getCodigo_fundo() == cod)
                {
                    return fundo;
                }

            }

            return null;

        }


        //retorna quantidade de fundos na lista+1
        public int contaFundos()
        {
            return Lista_de_fundos.Count+1;

        }


        //Inprime fundos na tela
        public void Imprimir_fundo(int opc_moeda)
        {

            foreach (Fundo_de_investimento fundo in Lista_de_fundos)
            {
                if (fundo.getOpcaomoeda() == opc_moeda)
                {

                    Console.WriteLine("Codigo: {0}, Nome: {1}, Sigla: {2}" + fundo.getCodigo_fundo()+ fundo.getNome_fundo()+ fundo.getSigla_fundo());
                }
            }
            
        }

        
        //verifica se fundo existe
        public Fundo_de_investimento Validar_fundo(int cod_fundo)
        {

            foreach (Fundo_de_investimento fundo in Lista_de_fundos)
            {
                if (cod_fundo == fundo.getCodigo_fundo())
                {
                    return fundo;
                }
            }
            return null;
            

        }

        //exclui e atualuza arquivo
        public void excluir_fundo(int cod)
        {

            Lista_de_fundos.Remove(Busca_fundo(cod));
            Atualiza_arq_fundos();
        }









    }
}
