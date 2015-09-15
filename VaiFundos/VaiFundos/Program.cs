using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Program
    {

        //Ajustar relatórios de aplicações por cliente case 4!!!!!!!!!!!!
        

        static void Main(string[] args)
        {

            Lista_fundos chamar_fundo = new Lista_fundos();
            Lista_clientes chamar_cli = new Lista_clientes();
            Lista_aplicacoes chamar_investimentos = new Lista_aplicacoes();

            //pra que isso gente !!
           

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

                                        Console.WriteLine("");
                                        Console.WriteLine("Cliente: " + chamar_cli.Busca_cliente(cpf_cli).getCodigo_cliente()+"- "+chamar_cli.Busca_cliente(cpf_cli).getNome_cliente());
                                        Console.WriteLine(" ");
                                        Console.WriteLine("para escolher fundo, digite.....1");
                                        Console.WriteLine("Para imprimir todos,............2");
                                        int escolha = int.Parse(Console.ReadLine());

                                        if (escolha == 1)
                                        {
                                            Console.WriteLine("digite o código do fundo");
                                            int cod_fun = int.Parse(Console.ReadLine());
                                            if (chamar_fundo.Validar_fundo(cod_fun)!= null)
                                            {
                                                Console.WriteLine("Para exibir na tela......digite 1");
                                                Console.WriteLine("Para gerar relatório.....digite 2");
                                                int escolha1 = int.Parse(Console.ReadLine());

                                                if (escolha1 ==1) {

                                                    chamar_investimentos.Buscar_aplicacao_Cliente(cpf_cli, cod_fun);
                                                }
                                                else
                                                {
                                                    if (escolha1 ==2)
                                                    {
                                                        //chamar método de gerar arquivo
                                                        chamar_investimentos.Gerar_relatorio_por_cliente_e_fundo(cpf_cli, cod_fun);


                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Opção inválida!");
                                                    }
                                                }
                                                
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

                                                //imprimir todos na tela ou no arquivo
                                                Console.WriteLine("Para exibir na tela......digite 1");
                                                Console.WriteLine("Para gerar relatório.....digite 2");
                                                int escolha1 = int.Parse(Console.ReadLine());

                                                if (escolha1 == 1)
                                                {
                                                    chamar_investimentos.Exibir_aplicacoes_por_cliente(cpf_cli);
                                                }
                                                else
                                                {
                                                    if (escolha1 ==2 )
                                                    {
                                                        chamar_investimentos.Gerar_relatorio_por_cliente(cpf_cli);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Opção inválida!");
                                                    }
                                                }
                                                
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
                                    cpf = Convert.ToInt32(Console.ReadLine());
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

                        Console.WriteLine("Digite o CPF do investidor: ");
                        int cpf_inv = int.Parse(Console.ReadLine());

                        //validar cliente
                        if (chamar_cli.Busca_cliente(cpf_inv) != null)
                        {
                            Console.WriteLine("Bem vindo @ - " + chamar_cli.Busca_cliente(cpf_inv).getNome_cliente());


                            int opcao2 = -1;

                            while (opcao2 != 0)
                            {
                                //opções para o cliente


                                Console.WriteLine("Para aplicar em fundo,...........................digite 1");
                                Console.WriteLine("Consultar aplicações,............................digite 2");
                                Console.WriteLine("Para fazer resgate,..............................digite 3");
                                Console.WriteLine("Para transferiri aplicação para outro fundo,.....digite 4");
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

                                                        Console.WriteLine("Confirmar aplicação: ");
                                                        Console.WriteLine("Se sim, digite 1.........Se não digite 0");
                                                        int conf = int.Parse(Console.ReadLine());

                                                        if (conf == 1)
                                                        {
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
                                                            Console.WriteLine("Aplicação cancelada!");
                                                        }

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

                                    case 3:

                                        Console.WriteLine("Digite o código da aplicação:");
                                        int cod_aplic = int.Parse(Console.ReadLine());

                                        if (chamar_investimentos.Buscar_aplicacao(cod_aplic) == null)
                                        {
                                            Console.WriteLine("Aplicação não encontrada verifique o código digitado!");
                                        }
                                        else
                                        {

                                            if (chamar_investimentos.Buscar_aplicacao(cod_aplic).dados_cli.getCpf_cliente() == cpf_inv)//cpf_inv é validado no menu de clientes
                                            {
                                                Console.WriteLine(chamar_investimentos.Buscar_aplicacao(cod_aplic).dados_cli.getNome_cliente() + " - Resgatar a aplicação abaixo?");
                                                Console.WriteLine("Código da aplicação: " + chamar_investimentos.Buscar_aplicacao(cod_aplic).getCod_aplicacao() + " Valor: " + chamar_investimentos.Buscar_aplicacao(cod_aplic).getValor_aplicacao() + " Data: " + chamar_investimentos.Buscar_aplicacao(cod_aplic).getData_aplicacao());
                                                Console.WriteLine("Cógdigo do fundo: " + chamar_investimentos.Buscar_aplicacao(cod_aplic).fundo.getCodigo_fundo() + " Nome: " + chamar_investimentos.Buscar_aplicacao(cod_aplic).fundo.getNome_fundo() + "-" + chamar_investimentos.Buscar_aplicacao(cod_aplic).fundo.getSigla_fundo());

                                                Console.WriteLine("Se sim, digite 1");
                                                Console.WriteLine("");
                                                int esc_resg = int.Parse(Console.ReadLine());

                                                if (esc_resg == 1)
                                                {

                                                    if (chamar_investimentos.Buscar_aplicacao(cod_aplic).fundo.getOpcaomoeda() == 1)
                                                    {

                                                        //usar classe real
                                                        Real apli_real = new Real("real", 'R');//verificar tam da variavel pq não aceita o $

                                                        Console.WriteLine("-20% IRRF: " + apli_real.desconto_resgate(chamar_investimentos.Buscar_aplicacao(cod_aplic)));

                                                        double acressimo = chamar_investimentos.RetornoAcressimo(cod_aplic);


                                                        double total_resgate = acressimo + apli_real.desconto_resgate(chamar_investimentos.Buscar_aplicacao(cod_aplic));

                                                        Console.WriteLine("Valor total do resgate: " + total_resgate);

                                                        Console.WriteLine("Confirma o resgate ?");
                                                        Console.WriteLine("Se sim, digite 1");
                                                        Console.WriteLine("Para cancelar , digite 0");
                                                        int confirma = int.Parse(Console.ReadLine());

                                                        if (confirma == 1)
                                                        {
                                                            //meétodo que retorna as notas utilizadas
                                                            apli_real.Contar_Notas(total_resgate);


                                                            //resgatar--------------excluir aplicação
                                                            chamar_investimentos.resgatar(chamar_investimentos.Buscar_aplicacao(cod_aplic));

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Resgate cancelado!");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (chamar_investimentos.Buscar_aplicacao(cod_aplic).fundo.getOpcaomoeda() == 2)
                                                        {
                                                            //usar classe dolar
                                                            Dolar apli_dolar = new Dolar("Dolar", 'D');

                                                            Console.WriteLine("-1% IOF: " + apli_dolar.desconto_resgate(chamar_investimentos.Buscar_aplicacao(cod_aplic)));

                                                            double acressimo = chamar_investimentos.RetornoAcressimo(cod_aplic);

                                                            Console.WriteLine("Valor total do resgate: " + acressimo + apli_dolar.desconto_resgate(chamar_investimentos.Buscar_aplicacao(cod_aplic)));

                                                            Console.WriteLine("Confirma o resgate ?");
                                                            Console.WriteLine("Se sim, digite 1");
                                                            Console.WriteLine("Para cancelar , digite 0");
                                                            int confirma = int.Parse(Console.ReadLine());

                                                            if (confirma == 1)
                                                            {

                                                                //meétodo que retorna as notas utilizadas
                                                                //resgatar--------------excluir aplicação


                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Resgate cancelado!");
                                                            }


                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Resgate não pode ser feito");
                                                        }
                                                    }


                                                }
                                                else
                                                {
                                                    Console.WriteLine("Resgate cancelado!");

                                                }

                                            }


                                            else
                                            {
                                                Console.WriteLine("Cliente não associado a essa aplicação, consulte suas aplicações e confira o código!");
                                            }
                                        }



                                        break;

                                    case 4:
                                        Console.WriteLine("Digite o cpf do investidor: ");
                                        int cpf = int.Parse(Console.ReadLine());

                                        if (chamar_cli.Busca_cliente(cpf) != null)
                                        {
                                            Console.WriteLine(".........." + chamar_cli.Busca_cliente(cpf).getNome_cliente() + "..........");
                                            Console.WriteLine("Digite o código da aplicação a transferir:");
                                            int cod_apli = int.Parse(Console.ReadLine());

                                            if (chamar_investimentos.Buscar_aplicacao(cod_apli) != null)
                                            {
                                                if (chamar_investimentos.Buscar_aplicacao(cod_apli).dados_cli.getCodigo_cliente() == chamar_cli.Busca_cliente(cpf).getCodigo_cliente())
                                                {


                                                    Console.WriteLine("Transferir a aplicação: ");
                                                    Console.WriteLine("Codigo da aplicação: " + cod_apli + " Data: " + chamar_investimentos.Buscar_aplicacao(cod_apli).getData_aplicacao() + " Valor: " + chamar_investimentos.Buscar_aplicacao(cod_apli).getValor_aplicacao());
                                                    Console.WriteLine("Codigo do fundo atual: " + chamar_investimentos.Buscar_aplicacao(cod_apli).fundo.getCodigo_fundo() + " Nome: " + chamar_investimentos.Buscar_aplicacao(cod_apli).fundo.getNome_fundo() + "-" + chamar_investimentos.Buscar_aplicacao(cod_apli).fundo.getSigla_fundo());

                                                    Console.WriteLine(" ");

                                                    Console.WriteLine("Digite o codigo do fundo a receber a aplicação: ");
                                                    int cod_fun = int.Parse(Console.ReadLine());

                                                    if (chamar_fundo.Validar_fundo(cod_fun) != null)
                                                    {

                                                        if (chamar_investimentos.Buscar_aplicacao(cod_apli).fundo.getOpcaomoeda() == chamar_fundo.Busca_fundo(cod_fun).getOpcaomoeda())
                                                        {

                                                            Console.WriteLine(" Código: " + chamar_fundo.Busca_fundo(cod_fun).getCodigo_fundo() + " Nome:" + chamar_fundo.Busca_fundo(cod_fun).getNome_fundo() + "- " + chamar_fundo.Busca_fundo(cod_fun).getSigla_fundo());
                                                            Console.WriteLine("Para confirmar transferência para o fundo acima........Digite 1 ");
                                                            Console.WriteLine("Para cancelar transferência ...........................Digite 2");
                                                            int opc_tr = int.Parse(Console.ReadLine());

                                                            if (opc_tr == 1)
                                                            {


                                                                chamar_investimentos.transfere(chamar_investimentos.Buscar_aplicacao(cod_apli), chamar_fundo.Busca_fundo(cod_fun));


                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Transferência cancelada!");
                                                            }





                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Transferência não permitida, moeda incompatível!");
                                                        }




                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Fundo não encontrado, verifique o codigo!");
                                                    }

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Aplicação não encontrada!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cliente não está associado a esta aplicação.");


                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Cliente não encontrado, verifique CPF!");
                                        }



                                        break;

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cliente não pode ser encontrado, verifique cpf!");
                        }

                        break;

                        }//término de menu para cliente

                        break;
                        } //término de menu para adm
                }







            }
        }
    

