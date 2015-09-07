using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Program
    {
        static void Main(string[] args)
        {

            Lista_aplicacoes chamar = new Lista_aplicacoes();
            Lista_clientes chamar_cli = new Lista_clientes();
            Lista_aplicacoes chamar_investimentos = new Lista_aplicacoes();

            int opcao1 = -1, opcao0 = -1;

            while (opcao0 != 0)
            {

                Console.WriteLine("Para acesso ADM,...........digite 1:");
                Console.WriteLine("Para acesso de cliente,.........digite 2:");
                Console.WriteLine("Para sair,......................digite 0:");

                opcao0 = Convert.ToInt32(Console.ReadLine());

                switch (opcao0)
                {
                    case 1:


                        while (opcao1 != 0)
                        {

                            Console.WriteLine("Para cadastrar novo fundo de investimentos,......digite 1");
                            Console.WriteLine("Para buscar fundo de investimento,.............. digite 2");
                            Console.WriteLine("Para gerar relatórios de aplicações,.............digite 3");
                            Console.WriteLine("Para cadastrar novo cliente,.....................digite 4");
                            Console.WriteLine("Para buscar cliente,.............................digite 5");
                            Console.WriteLine("Para sair,.......................................digite 0");

                            opcao1 = Convert.ToInt32(Console.ReadLine());

                            switch (opcao1)
                            {
                                case 1:
                                    int codigo_fundo;
                                    string nome_fundo;
                                    string sigla_fundo;

                                    if (chamar.contaFundos() == 0)
                                    {
                                        codigo_fundo = 01;
                                    }
                                    else
                                    {
                                        codigo_fundo = chamar.contaFundos();
                                    }


                                    Console.WriteLine("Digite o nome do fundo de investimento a cadastrar: ");
                                    nome_fundo = Console.ReadLine();
                                    Console.WriteLine("Digite a sigla do fundo de investimento: ");
                                    sigla_fundo = Console.ReadLine();

                                    Fundo_de_investimento novo_fundo = new Fundo_de_investimento(codigo_fundo, nome_fundo, sigla_fundo);

                                    Console.WriteLine("Codigo do fundo: " + codigo_fundo);
                                    chamar.Cadatrar_fundo(novo_fundo);
                                    //carregar arquivo de fundos em uma lista
                                    //atualizar a lista e gravar a mesma novamente em arquivo;

                                    //vai ter um arquivo para - fundos_completos, fundos, clientes
                                    //para buscar carregar do arquivo para a lista e depois fazer a busca na lista


                                    break;

                                case 2:
                                    int codigo;

                                    Console.WriteLine("Digite o codigo do fundo de investimento: ");
                                    codigo = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Nome: " + chamar.Busca_fundo(codigo).getNome_fundo());

                                    break;


                                case 3:








                                    break;




                                case 4:

                                    int codigo_cli;
                                    int cpf;
                                    string nome;

                                    Console.WriteLine("Digite cpf: ");
                                    cpf = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Digite nome: ");
                                    nome = Console.ReadLine();

                                    if (chamar_cli.contaClientes() == 0)
                                    {
                                        codigo_cli = 01;
                                    }
                                    else
                                    {
                                        codigo_cli = chamar_cli.contaClientes();
                                    }

                                    Console.WriteLine("Código do cliente: " + codigo_cli);
                                    Cliente novo = new Cliente(codigo_cli, cpf, nome);

                                    chamar_cli.Cadatrar_cliente(novo);


                                    break;


                                case 5:

                                    int b_cpf;
                                    Console.WriteLine("Digite o seu CPF: ");
                                    b_cpf = int.Parse(Console.ReadLine());

                                    if (chamar_cli.Busca_cliente(b_cpf) == null)
                                    {
                                        Console.WriteLine("Dado inválido, verifique o CPF cadastrado");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Código: " + chamar_cli.Busca_cliente(b_cpf).getCodigo_cliente());
                                        Console.WriteLine("Nome: " + chamar_cli.Busca_cliente(b_cpf).getNome_cliente());

                                    }

                                    break;
                                case 0:

                                    Console.WriteLine("Menu Principal");

                                    break;

                            }
                        }

                        break;

                    case 2:

                        int opcao2 = -1;

                        while (opcao2 != 0)
                        {
                            //opções para o cliente

                            Console.WriteLine("Para aplicar em fundo,..........digite 1");
                            Console.WriteLine("Consultar aplicações,...........digite 2");
                            Console.WriteLine("Para fazer resgate,.............digite 3");
                            Console.WriteLine("Para sair,......................digite 0");

                            opcao2 = Convert.ToInt32(Console.ReadLine());

                            switch (opcao2)
                            {



                                case 1:
                                    //case para aplicar

                                    int b_cpf;
                                    Console.WriteLine("Digite o seu CPF: ");
                                    b_cpf = int.Parse(Console.ReadLine());

                                    if (chamar_cli.Busca_cliente(b_cpf) == null)
                                    {
                                        Console.WriteLine("Dado inválido..






        }

        }
}
