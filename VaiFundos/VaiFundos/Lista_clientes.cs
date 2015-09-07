using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace VaiFundos
{
    class Lista_clientes
    {

        List<Cliente> Lista_de_clientes = new List<Cliente>();

        public void Ler_Arq_Cliente()
        {


            try
            {
                // Ler Arquivo para add clientes


                FileStream Arquivo_clientes = new FileStream("Arq_Cliente.txt", FileMode.Open, FileAccess.Read);
                StreamReader leitor = new StreamReader(Arquivo_clientes, Encoding.Unicode);
                // StreamWriter leitorEscrita = new StreamWriter(Arquivo_clientes, Encoding.Unicode);

                String linha;
                linha = leitor.ReadLine();


                while (linha != null)
                {

                    String[] Separador;

                    Separador = linha.Split(new Char[] { ';' });

                    int codigo = 0, cpf = 0;
                    String nome = "";

                    for (int i = 0; i < Separador.Length; i++)
                    {

                        if (i == 0)
                        {

                            codigo = int.Parse(Separador[i]);
                        }

                        else
                        {
                            if (i == 1)
                            {
                                cpf = int.Parse(Separador[i]);

                            }
                            else
                            {
                                if (i == 3)
                                {
                                    nome = Separador[i];


                                }
                            }


                        }


                    }

                    Cliente Novo = new Cliente(codigo, cpf, nome);

                    Lista_de_clientes.Add(Novo);


                    linha = leitor.ReadLine();
                }

                
              //  leitor.Close();
               // Arquivo_clientes.Close();
            }

            
           // catch (Exception e)
            //{
            //    Console.WriteLine("TEste Erro");
           // }


        }
        // Gravar cliente no Arquivo
        public void EscreverArquivo()
        {
            try { 


            FileStream Arquivo_clientes = new FileStream("Arq_Cliente.txt", FileMode.Open, FileAccess.Read);
            StreamWriter Escritor = new StreamWriter(Arquivo_clientes, Encoding.Unicode);


            foreach (Cliente cliente in Lista_de_clientes)
            {   try
                    {

                        Escritor.WriteLine(cliente.getCodigo_cliente() + ";" + cliente.getCpf_cliente() + ";" + cliente.getNome_cliente());

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("TEste Erro");
                    }

                }

                //Escritor.Close();
                //Arquivo_clientes.Close();
                

                    }

              catch (Exception e)
            {
                Console.WriteLine("TEste Erro");
            }

      
    
}





            // FileStream MeuArquivo2 = new FileStream("multiplos.txt", FileMode.Create, FileAccess.Write);
            // StreamWriter gravador = new StreamWriter(MeuArquivo2, Encoding.Unicode);

        public void Cadatrar_cliente(Cliente novo_cliente)
        {

            Ler_Arq_Cliente();
            Lista_de_clientes.Add(novo_cliente);
            EscreverArquivo();
            Console.WriteLine("Novo Cliente incluído com sucesso!");
            


            // criando a lista aqui, toda vez que for adicionar um fundo, se cria uma nova lista

            /*

            if (Busca_cliente(novo_cliente.getCodigo_cliente()) == null)
            {

                Lista_de_clientes.Add(novo_cliente);

                Console.WriteLine("Novo Cliente incluído com sucesso!");

            }
            else
            {

                Console.WriteLine("Erro ao salvar, verifique se codigo está correto!");
            }
            
    */

        }


        public Cliente Busca_cliente(int cpf)
        {

            foreach (Cliente cliente in Lista_de_clientes)
            {


                if (cliente.getCpf_cliente() == cpf)
                {
                    return cliente;
                }

            }

            return null;


        }


        public int contaClientes()
        {
            return Lista_de_clientes.Count;

        }
        
    }
}
