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

            Lista_fundos chamar_fundo = new Lista_fundos();
            Lista_clientes chamar_cli = new Lista_clientes();
            Lista_aplicacoes chamar_investimentos = new Lista_aplicacoes();
            Classe_Arquivos Arquvo_tste = new Classe_Arquivos();

            int opcao1 = -1, opcao0 = -1;

            while (opcao0 != 0)
            {

                Console.WriteLine("Para acesso ADM,...........digite 1:");
                Console.WriteLine("Para acesso de cliente,.........digite 2:");
                Console.WriteLine("Para sair,......................digite 0:");

                opcao0 = Convert.ToInt32(Console.ReadLine());

                switch (opcao0)
                {
                    
                    case 10:
                        // Teste para add clientes 
                        chamar_cli.ClientesCadastrados();
                        //chamar_cli.Cadatrar_cliente(novo_cliente);

                        break;

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

                                    if (chamar_fundo.contaFundos() == 0)
                                    {
                                        codigo_fundo = 01;
                                    }
                                    else
                                    {
                                        codigo_fundo = chamar_fundo.contaFundos() + 1;
                                    }
                                    int opcaomoeda;
                                    Console.WriteLine("Escolha o tipo de moeda para este fundo!");
                                    Console.WriteLine("Digite 1, para Real");
                                    Console.WriteLine("Digite 2, para Dolar");
                                    opcaomoeda = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Digite o nome do fundo de investimento a cadastrar: ");
                                    nome_fundo = Console.ReadLine();
                                    Console.WriteLine("Digite a sigla do fundo de investimento: ");
                                    sigla_fundo = Console.ReadLine();

                                    Fundo_de_investimento novo_fundo = new Fundo_de_investimento(codigo_fundo, nome_fundo, sigla_fundo, opcaomoeda);

                                    Console.WriteLine("Codigo do fundo: " + codigo_fundo);
                                    chamar_fundo.Cadatrar_fundo(novo_fundo);
                                    //carregar arquivo de fundos em uma lista
                                    //atualizar a lista e gravar a mesma novamente em arquivo;

                                    //vai ter um arquivo para - fundos_completos, fundos, clientes
                                    //para buscar carregar do arquivo para a lista e depois fazer a busca na lista


                                    break;

                                case 2:
                                    int codigo;

                                    Console.WriteLine("Digite o codigo do fundo de investimento: ");
                                    codigo = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Nome: " + chamar_fundo.Busca_fundo(codigo).getNome_fundo());

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
                                        Console.WriteLine("Dado incorreto, verifique CPF!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bem vindo(a): " + chamar_cli.Busca_cliente(b_cpf).getNome_cliente());
                                    }

                                    int opcaomoeda;
                                    Console.WriteLine("Escolha a moeda para a aplicação: ");
                                    Console.WriteLine("Para Real,................digite 1");
                                    Console.WriteLine("Para dolar,...............digite 2");
                                    opcaomoeda = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Lista de fundos disponíveis para a moeda escolhida: ");
                                    chamar_fundo.Imprimir_fundo(opcaomoeda);
                                    

                                    int cod_fundo;
                                    Console.WriteLine("Digite o codigo do fundo que deseja aplicar:");
                                    cod_fundo = int.Parse(Console.ReadLine());



                                    if (chamar_fundo.Validar_fundo(cod_fundo) != null)
                                    {
                                        double valor_apl;
                                        DateTime dt_apl;
                                        Console.WriteLine("Digite o valor que deseja aplicar: ");
                                        valor_apl = double.Parse(Console.ReadLine());
                                        dt_apl = DateTime.Today;
                                        Console.WriteLine("Data da aplicação:" + dt_apl);

                                        chamar_investimentos.containvestimentos();

                                        Aplicacao nova_aplicacao = new Aplicacao(valor_apl, dt_apl, chamar_investimentos.containvestimentos());

                                        //atribuindo os dados do cliente a aplicação
                                        nova_aplicacao.dados_cli = new Cliente(chamar_cli.Busca_cliente(b_cpf).getCodigo_cliente(), b_cpf, chamar_cli.Busca_cliente(b_cpf).getNome_cliente());
                                      
                                         


                                        //atribuindo os dados do fundo a aplicação
                                        nova_aplicacao.fundo = new Fundo_de_investimento(cod_fundo,chamar_fundo.Busca_fundo(cod_fundo).getNome_fundo(),chamar_fundo.Busca_fundo(cod_fundo).getSigla_fundo(), opcaomoeda);
                                    
                                        chamar_investimentos.Aplicar(nova_aplicacao);

                                    }
                                    else
                                    {
                                        Console.WriteLine("Codigo inválido !");
                       
                                    }

                                                                     
                                        break;
                                    // Consultar aplicações pelo codigo
                                case 2:

                                    Console.WriteLine("Digite o código do fundo para ver a sua aplicações");
                                    int cod_fundo_consulta = int.Parse(Console.ReadLine());

                                    if (chamar_fundo.Validar_fundo(cod_fundo_consulta) != null)
                                    {
                                        Console.WriteLine("Digite o seu CPF");
                                        b_cpf = int.Parse(Console.ReadLine());


                                        chamar_investimentos.Buscar_aplicacao_Cliente(b_cpf);
                                    }




                                    break;
    


                                    }

                            }
                            break;
                        }
                }
            }
        }
    }

