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

            //pra que isso gente !!
            Classe_Arquivos Arquvo_tste = new Classe_Arquivos();

            chamar_fundo.FundosCadastrados();
            chamar_cli.ClientesCadastrados();
            chamar_investimentos.Aplicações_arq();




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



                        break;

                    case 1:


                        while (opcao1 != 0)
                        {

                            Console.WriteLine("Para cadastrar novo fundo de investimentos,......digite 1");
                            Console.WriteLine("Para buscar fundo de investimento,.............. digite 2");
                            Console.WriteLine("Para gerar relatório de aplicações por mês,......digite 3");
                            Console.WriteLine("Para gerar relatório de aplicações por cliente,..digite 4");
                            Console.WriteLine("Para cadastrar novo cliente,.....................digite 5");
                            Console.WriteLine("Para buscar cliente,.............................digite 6");
                            Console.WriteLine("Para excluir cliente,............................digite 7");
                            Console.WriteLine("Para excluir fundo,..............................digite 8");
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
                                        codigo_fundo = chamar_fundo.contaFundos();
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

                                    if (chamar_fundo.Busca_fundo(codigo) == null)
                                    {
                                        Console.WriteLine("Não foi possível encontrar o fundo, verifique o codigo!");
                                    }
                                    else
                                    {

                                        Console.WriteLine("Nome: " + chamar_fundo.Busca_fundo(codigo).getNome_fundo()+"- "+chamar_fundo.Busca_fundo(codigo).getSigla_fundo());
                                    }

                                    break;


                                case 3:
                                    
                                    Console.WriteLine("codigo do Fundo_de_investimento");
                                    int cod1 = int.Parse(Console.ReadLine());
                                    if(chamar_fundo.Validar_fundo(cod1) != null)
                                    {
                                        chamar_investimentos.Relatorio_mensal(cod1);

                                    }
                                    else
                                    {
                                        Console.WriteLine("Código inválido");
                                    }
                                    
                                    
                                    break;


                                case 4:

                                    Console.Write("Digite o cpf do cliente: ");
                                    int cpf_cli = int.Parse(Console.ReadLine());

                                   if(chamar_cli.Busca_cliente(cpf_cli) !=null){


                                        Console.WriteLine("para escolher fundo, digite.....1");
                                        Console.WriteLine("Para imprimir todos,............2");
                                        int escolha = int.Parse(Console.ReadLine());

                                        if (escolha == 1)
                                        {
                                            Console.WriteLine("digite o código do fundo");
                                            int cod_fun = int.Parse(Console.ReadLine());
                                            if (chamar_fundo.Validar_fundo(cod_fun)!= null)
                                            {
                                                chamar_investimentos.Buscar_aplicacao_Cliente(cpf_cli, cod_fun);
                                                




                                            }
                                            else
                                            {
                                                Console.WriteLine("Fundo não encontrado!");
                                            }


                                        }
                                        
                                        else
                                        {
                                            if (escolha == 2)
                                            {








                                            }
                                            else
                                            {
                                                Console.WriteLine("Opção inválida!");
                                            }
                                        }
                                   
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cliente não encontrado, verifique o cpf!");
                                    }
                                    
                                   




                                    break;
                                    

                                case 5:
                                    

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

                                    
                                    Cliente novo = new Cliente(codigo_cli, cpf, nome);

                                    if (chamar_cli.Cadatrar_cliente(novo))
                                    {
                                        Console.WriteLine("Código do cliente: " + codigo_cli);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Menu:");
                                    }
                                    


                                    break;


                                case 6:

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


                                case 7:

                                    int cpf_ex;
                                    Console.WriteLine("Digite o CPF do cliente!");
                                    cpf_ex = int.Parse(Console.ReadLine());

                                    if (chamar_cli.Busca_cliente(cpf_ex) != null)
                                    {

                                        if (chamar_investimentos.possui_apli(cpf_ex))
                                        {

                                            Console.WriteLine("Cliente possui aplicações.......Resgate ou transfira as mesmas!");

                                        }
                                        else
                                        {


                                            Console.WriteLine("O cliente: {0}, CPF: {1} " + chamar_cli.Busca_cliente(cpf_ex).getNome_cliente() + chamar_cli.Busca_cliente(cpf_ex).getCpf_cliente() + "Será excluído!");
                                            Console.WriteLine("Para confirmar digite 1");
                                            Console.WriteLine("Para cancelar digite 0");
                                            int opcao = int.Parse(Console.ReadLine());

                                            if (opcao == 1)
                                            {

                                                chamar_cli.excluir_cliente(cpf_ex);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Exclusão cancelada!");
                                            }

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cliente não existente!");
                                    }
                                    

                                    break;

                                case 8:

                                    Console.WriteLine("Digite o código do fundo:");
                                    int cod = int.Parse(Console.ReadLine());


                                    if(chamar_fundo.Validar_fundo(cod) != null)
                                    {
                                        //fazer metodo que verifica se há cliente no fundo.
                                        if (chamar_investimentos.fundo_tem_aplicacao(cod))
                                        {

                                            Console.WriteLine("Fundo não pode ser excluído, o mesmo possui aplicações");
                                        }
                                        else
                                        {
                                            Console.WriteLine("O fundo: {0}, Cod: {1}-Sigla{2} " + chamar_fundo.Busca_fundo(cod).getCodigo_fundo()+ chamar_fundo.Busca_fundo(cod).getNome_fundo()+ chamar_fundo.Busca_fundo(cod).getSigla_fundo() + "Será excluído!");
                                            Console.WriteLine("Para confirmar digite 1");
                                            Console.WriteLine("Para cancelar digite 0");
                                            int opcao = int.Parse(Console.ReadLine());

                                            if (opcao == 1)
                                            {
                                                chamar_fundo.excluir_fundo(cod);

                                            }
                                            else
                                            {
                                                Console.WriteLine("Exclusão cancelada!");
                                            }
                                            


                                        }
                                           
                                    }
                                    else
                                    {
                                        Console.WriteLine("Código inválido!");
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


                                        int opcaomoeda;
                                        Console.WriteLine("Escolha a moeda para a aplicação: ");
                                        Console.WriteLine("Para Real,................digite 1");
                                        Console.WriteLine("Para dolar,...............digite 2");
                                        opcaomoeda = int.Parse(Console.ReadLine());
                                        //se digitar moeda inesistente:
                                        if (opcaomoeda == 1 || opcaomoeda == 2)
                                        {
                                            Console.WriteLine("Lista de fundos disponíveis para a moeda escolhida: ");
                                            if (chamar_fundo.Imprimir_fundo(opcaomoeda) == false) 
                                            {
                                                Console.WriteLine("não há fundos cadastrados!");
                                            }
                                            else
                                            {
                                                
                                                int cod_fundo;
                                                Console.WriteLine("Digite o codigo do fundo que deseja aplicar:");
                                                cod_fundo = int.Parse(Console.ReadLine());
                                                


                                                if (chamar_fundo.Validar_fundo(cod_fundo) != null)
                                                {
                                                    Console.WriteLine("...." + chamar_fundo.Busca_fundo(cod_fundo).getNome_fundo() + "...." + chamar_fundo.Busca_fundo(cod_fundo).getSigla_fundo());
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
                                                    nova_aplicacao.fundo = new Fundo_de_investimento(cod_fundo, chamar_fundo.Busca_fundo(cod_fundo).getNome_fundo(), chamar_fundo.Busca_fundo(cod_fundo).getSigla_fundo(), opcaomoeda);

                                                    chamar_investimentos.Aplicar(nova_aplicacao);


                                                }
                                                else
                                                {
                                                    Console.WriteLine("Código incorreto!");
                                                }
                                            }
                                        }

                                        else
                                        {
                                            Console.WriteLine("Moeda inválida!");
                                        }

                                    }                      
                                        break;
                                    // Consultar aplicações pelo codigo
                                case 2:

                                    Console.WriteLine("Digite o código do fundo para ver suas aplicações");
                                    int cod_fundo_consulta = int.Parse(Console.ReadLine());

                                    if (chamar_fundo.Validar_fundo(cod_fundo_consulta) != null)
                                    {
                                        Console.WriteLine("Digite o seu CPF");
                                        b_cpf = int.Parse(Console.ReadLine());


                                        chamar_investimentos.Buscar_aplicacao_Cliente(b_cpf, cod_fundo_consulta);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Código não encontrado!");
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

//vai rodrigo agora é com vc !!