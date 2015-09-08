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


        //carrega clientes do arquivo para a lista de clientes.
        public void ClientesCadastrados()
        {
            using (StreamReader reader = new StreamReader(@"C:\\Users\\BRUNO\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\\Arq_Cliente.txt"))
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


        //Cadastra cliente na lista.
        public void  Cadatrar_cliente(Cliente novo_cliente) {

            // criando a lista aqui, toda vez que for adicionar um fundo, se cria uma nova lista

            if (Busca_cliente(novo_cliente.getCpf_cliente()) != null)
            {
                Console.WriteLine("CPF ja cadastrado, verifique se o mesmo está correto!");

            }
            else
            {

                Lista_de_clientes.Add(novo_cliente);
                Atualiza_arq_clientes();

                Console.WriteLine("Novo Cliente incluído com sucesso!");

            }
            
            
        }

        //atualiza o arquivo de clientes
        //Caminho varia de acordo com o pc!
        public void Atualiza_arq_clientes()
        {
            
            using (StreamWriter escritor = new StreamWriter(@"C:\\Users\\BRUNO\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\\Arq_Cliente.txt"))
            {
                try
                {
                    foreach (Cliente cliente in Lista_de_clientes)
                    {
                        escritor.WriteLine(cliente.getCodigo_cliente() + ";" + cliente.getCpf_cliente() + ";" + cliente.getNome_cliente());
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

        //exclui e atualuza arquivo
        public void excluir_cliente(int cpf)
        {
           
            Lista_de_clientes.Remove(Busca_cliente(cpf));
            Atualiza_arq_clientes();
            }

        

        //busca e retorna cliente
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




        //retorna o número de clientes na lista+1.
        public int contaClientes()
        {
            return Lista_de_clientes.Count+1;

        }
        
    }
}
