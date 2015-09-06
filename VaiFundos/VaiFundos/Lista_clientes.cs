using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Lista_clientes
    {

        List<Cliente> Lista_de_clientes = new List<Cliente>();

        public void Cadatrar_cliente(Cliente novo_cliente)
        {
            // criando a lista aqui, toda vez que for adicionar um fundo, se cria uma nova lista
            

            if (Busca_cliente(novo_cliente.getCodigo_cliente()) == null)
            {

                Lista_de_clientes.Add(novo_cliente);

                Console.WriteLine("Novo Cliente incluído com sucesso!");

            }
            else
            {

                Console.WriteLine("Erro ao salvar, verifique se codigo está correto!");
            }

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
            return Lista_de_clientes.Count + 1;

        }
        
    }
}
