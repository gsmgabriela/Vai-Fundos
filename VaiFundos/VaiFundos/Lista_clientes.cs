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
        
        public void ClientesCadastrados()
        {
            using (StreamReader reader = new StreamReader(@"C:\\Users\\R.ROMUALDOL\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\\Arq_Cliente.txt"))
            {

                try { 
                string linha;
                String[] Separador;
                linha = reader.ReadLine();
                
                int codigo = 0, cpf = 0;
                String nome = "";
                    // Ler linha por linha e Adiciona na lista de clientes                    
                 while (linha != null)
                {

                        Separador = linha.Split(new char[] { ';' });

                        codigo = int.Parse(Separador[0]);
                        cpf = int.Parse(Separador[1]);
                        nome = (Separador[2]);
                   
                        Console.WriteLine(" " + codigo + " " + cpf + " " + nome);
                        linha = reader.ReadLine();

                       Cliente Novo = new Cliente(codigo,cpf,nome);
                       Lista_de_clientes.Add(Novo);
                                        
                }
                reader.Close();

                } catch (IOException )
                {
                    Console.WriteLine("Erro ao adicionar na lista");
                }
            }
        }       
////////////////////////////////////////////////////////////////////////////////////////////////////         

                // FileStream MeuArquivo2 = new FileStream("multiplos.txt", FileMode.Create, FileAccess.Write);
                // StreamWriter gravador = new StreamWriter(MeuArquivo2, Encoding.Unicode);

        public void  Cadatrar_cliente(Cliente novo_cliente)
        {
            

            
            Lista_de_clientes.Add(novo_cliente);
            
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
