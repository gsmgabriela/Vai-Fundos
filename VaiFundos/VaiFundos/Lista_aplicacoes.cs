using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VaiFundos
{
    class Lista_aplicacoes
    {
        List<Aplicacao> lista_aplicacoes = new List<Aplicacao>();



        //Metodo para fazer aplicação
        public void Aplicar(Aplicacao nova_aplicacao)
        {
            // criando a lista aqui, toda vez que for adicionar um fundo, se cria uma nova lista
            
            lista_aplicacoes.Add(nova_aplicacao);
            Atualiza_arq_aplicacoes();
            Console.WriteLine("Aplicação realizada com sucesso !  Cod: "+nova_aplicacao.getCod_aplicacao());
        }


        //Metodo para ler o arquivo de aplicações
        public void Aplicações_arq()
        {
            using (StreamReader reader = new StreamReader(@"../../Arq_Aplicacoes.txt"))
            {

                try
                {
                    string linha;
                    String[] Separador;
                    linha = reader.ReadLine();

                    

        int cod_aplicacao = 0;
        double valor_aplicacao =0;
        DateTime data_aplicacao;
        Cliente dados_cli = new Cliente(0,0,"");
        Fundo_de_investimento fundo = new Fundo_de_investimento(0,"","",0);


                    // Ler linha por linha e Adiciona na lista de clientes                    
                    while (linha != null)
                    {

                        Separador = linha.Split(new char[] { ';' });

                        cod_aplicacao = int.Parse(Separador[0]);
                        valor_aplicacao = double.Parse(Separador[1]);
                        data_aplicacao = Convert.ToDateTime(Separador[2]);
                        
                        linha = reader.ReadLine();

                        Aplicacao nova_aplicacao = new Aplicacao(valor_aplicacao, data_aplicacao, cod_aplicacao);

                        //atribuindo os dados do cliente a aplicação
                        nova_aplicacao.dados_cli = new Cliente(int.Parse(Separador[3]), int.Parse(Separador[4]), Separador[5]);
                        
                        //atribuindo os dados do fundo a aplicação
                        nova_aplicacao.fundo = new Fundo_de_investimento(int.Parse(Separador[6]), Separador[7], Separador[8], int.Parse(Separador[9]));

                        lista_aplicacoes.Add(nova_aplicacao);
                        

                    }
                    reader.Close();

                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao adicionar na lista");
                }
            }
        }



        //metodo para atualizar arquivo
        public void Atualiza_arq_aplicacoes()
        {

            using (StreamWriter escritor = new StreamWriter("../../Arq_Aplicacoes.txt"))
            {
                try
                {
                    foreach (Aplicacao aplicacao in lista_aplicacoes)
                    {
                        escritor.WriteLine(aplicacao.getCod_aplicacao() + ";"+ aplicacao.getValor_aplicacao() + ";" + aplicacao.getData_aplicacao()+";"+aplicacao.dados_cli.getCodigo_cliente()+";"+aplicacao.dados_cli.getCpf_cliente()+";"+aplicacao.dados_cli.getNome_cliente()+";"+aplicacao.fundo.getCodigo_fundo()+";"+aplicacao.fundo.getNome_fundo()+";"+aplicacao.fundo.getSigla_fundo()+";"+aplicacao.fundo.getOpcaomoeda());
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
       


        //buscar pelo codigo da aplicação

        public Aplicacao Buscar_aplicacao(int cod_apl)
        {

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {

                if (aplicacao.getCod_aplicacao() == cod_apl)
                {
                    return aplicacao;

                }

            }
            return null;
        }



            // Utilizando para buscar pelo CPF
           public void Buscar_aplicacao_Cliente(int b_cpf, int cod_fundo )
        {
            int cont = 0;
            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {

                if (aplicacao.dados_cli.getCpf_cliente() == b_cpf)
                {
                    
                    if (aplicacao.fundo.getCodigo_fundo() == cod_fundo)
                    {
                        cont++;
                        Console.WriteLine("Codigo do cliente: " + aplicacao.dados_cli.getCodigo_cliente() + " Código do fundo: " + aplicacao.fundo.getCodigo_fundo() + " Nome do fundo: " + aplicacao.fundo.getNome_fundo() + "- " + aplicacao.fundo.getSigla_fundo());
                        Console.WriteLine(" Data da aplicação" + aplicacao.getData_aplicacao() + "Valor: " + aplicacao.getValor_aplicacao());
                        Console.WriteLine(".......................................................................................................");
                    }

                    
                }
            }
            if (cont == 0)
            {
                Console.WriteLine("Você não possui aplicações nesse fundo");
            }

        }



     // metodo só pra ver se o cliente possui aplicações:
     public bool possui_apli(int cpf)
        {
            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {
                if (aplicacao.dados_cli.getCpf_cliente() == cpf)
                {
                    return true;
                }
            }
            return false;

        }
        //fim metodo.

            
        


        //calcula o acressimo de acordo com o periodo de aplicação
        public double RetornoAcressimo(int cod_apl)
        {
            DateTime Data_Hoje, data_apli;
            Data_Hoje = DateTime.Today;

            double Valor_Aplicacao=0;


            TimeSpan intervalo = new TimeSpan();
            
            
            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {

                if(aplicacao.getCod_aplicacao() == cod_apl)
                {
                    data_apli = aplicacao.getData_aplicacao();
                    intervalo = Data_Hoje - data_apli;
                    Valor_Aplicacao = aplicacao.getValor_aplicacao();
                    
                }


            }

            
            
            if(Convert.ToInt32(intervalo.Days) >= 365)
            {

                double acressimo = (Valor_Aplicacao * 5) / 100;
                Console.WriteLine("Dias que se passaram: " + intervalo);
                return acressimo;

            }
            else
            {
                Console.WriteLine("Sem acréssimo. Sua aplicação tem menos de um ano !");
            }

            return 0;
            
          
        }


        //verifica se fundo tem alguma aplicação
        public bool fundo_tem_aplicacao(int cod_fun)
        {
            foreach (Aplicacao apli in lista_aplicacoes)
            {
                if (apli.fundo.getCodigo_fundo() == cod_fun)
                {
                    return true;
                }
            }
            return false;
        }




        int quant = 1;
        //retorna o número de aplicações na lista+1.
        public int containvestimentos()
        {
            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {
                if (quant == aplicacao.getCod_aplicacao())
                {
                    quant++;
                    containvestimentos();
                }
            }
            return quant;
        }



        //gerar relatório mensal por fundo-
        //na main pedir para validar o codigo do fundo primeiro
        public void Relatorio_mensal(int cod_fundo)
        {
            List<Aplicacao> escolha_apli = new List<Aplicacao>();
            int conta_apli = 0;
            Aplicacao dados = new Aplicacao();

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {
                if (cod_fundo == aplicacao.fundo.getCodigo_fundo())
                {
                    dados = aplicacao;
                    escolha_apli.Add(aplicacao);
                    conta_apli++;
                }
            }
            int mes;
            int ano;
            Console.WriteLine("Digite o mês:");
            mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ano:");
            ano = int.Parse(Console.ReadLine());
            int cont = 0;

            if (conta_apli == 0)
            {
                Console.WriteLine("Esse fundo ainda não possui aplicações!");
            }
            else
            {




                List<Aplicacao> escolha_data = new List<Aplicacao>();

                Console.WriteLine("APLICAÇÕES FEITAS PARA O FUNDO: " + cod_fundo +"Nome: "+ dados.fundo.getNome_fundo()+"-" +dados.fundo.getSigla_fundo());
                Console.WriteLine("Para exibir na tela................ digite 1");
                Console.WriteLine("Para gerar relatório em arquivo.....digite 2");
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    foreach (Aplicacao aplicacao in escolha_apli)
                    {
                        if (aplicacao.getData_aplicacao().Month == mes && aplicacao.getData_aplicacao().Year == ano)
                        {
                            cont++;
                            escolha_data.Add(aplicacao);


                            if (aplicacao.fundo.getOpcaomoeda() == 1)
                            {
                                Console.WriteLine("Data" + aplicacao.getData_aplicacao() + "-Cliente: " + aplicacao.dados_cli.getNome_cliente() + " Valor: " + aplicacao.getValor_aplicacao() + " Moeda: Real");
                            }
                            else
                            {
                                if (aplicacao.fundo.getOpcaomoeda() == 2)
                                {
                                    Console.WriteLine("Data: " + aplicacao.getData_aplicacao() + "...Cliente: " + aplicacao.dados_cli.getCodigo_cliente() + "-" + aplicacao.dados_cli.getNome_cliente() + " ...Valor: " + aplicacao.getValor_aplicacao() + " Moeda: Dolar");

                                }
                            }
                        }
                        
                    }
                    if (cont == 0)
                    {
                        Console.WriteLine("Não há aplicações nesse fundo, no período solicitado");
                    }
                    Console.WriteLine(" ");

                }


                else
                {

                    if (opcao == 2)
                    {
                        using (StreamWriter escritor = new StreamWriter("../../Relatorio_Aplicacaoes_por_fundo_e_mes.txt"))
                        {
                            try
                            {
                                escritor.WriteLine("APLICAÇÕES FEITAS PARA O FUNDO: " + cod_fundo + " Nome: " + dados.fundo.getNome_fundo() + "-" + dados.fundo.getSigla_fundo());

                                foreach (Aplicacao aplicacao in escolha_apli)
                                {
                                    if (aplicacao.getData_aplicacao().Month == mes && aplicacao.getData_aplicacao().Year == ano)
                                    {
                                        cont++;
                                        escolha_data.Add(aplicacao);


                                        if (aplicacao.fundo.getOpcaomoeda() == 1)
                                        {
                                            escritor.WriteLine("Data: " + aplicacao.getData_aplicacao() + "...Cliente: " + aplicacao.dados_cli.getNome_cliente() + " ...Valor: " + aplicacao.getValor_aplicacao() + " Moeda: Real");
                                        }
                                        else
                                        {
                                            if (aplicacao.fundo.getOpcaomoeda() == 2)
                                            {
                                                escritor.WriteLine("Data: " + aplicacao.getData_aplicacao() + "...Cliente: " + aplicacao.dados_cli.getCodigo_cliente() + "-" + aplicacao.dados_cli.getNome_cliente() + " Valor: " + aplicacao.getValor_aplicacao() + " Moeda: Dolar");

                                            }
                                        }
                                        escritor.WriteLine("");
                                    }

                                    
                                }

                                if (cont == 0)
                                {
                                    Console.WriteLine("Não há aplicações nesse fundo, no período solicitado");
                                }
                                else
                                {
                                    Console.WriteLine("Relatório gerado em arquivo!");
                                }
                                escritor.Close();
                            }
                            catch (IOException)
                            {
                                Console.WriteLine("Erro ao Atualizar arquivo!");
                            }
                        }
                    }

                }
            }
        }

        //grava em arquivo aplicações separadas por cliente e fundo
        public void Gerar_relatorio_por_cliente_e_fundo(int b_cpf, int cod_fundo)
        {
            int cont=0;

            using (StreamWriter escritor = new StreamWriter("../../Relatorio_Aplicacoes_por_cliente_e_fundo.txt"))
            {
                try
                {
                    
                    foreach (Aplicacao aplicacao in lista_aplicacoes)
                    {
                        

                if (aplicacao.dados_cli.getCpf_cliente() == b_cpf)
                {
                    if (aplicacao.fundo.getCodigo_fundo() == cod_fundo)
                    {
                        cont++;
                        escritor.WriteLine("Codigo do cliente: " + aplicacao.dados_cli.getCodigo_cliente() +" Nome: "+aplicacao.dados_cli.getNome_cliente()+ " Código do fundo: " + aplicacao.fundo.getCodigo_fundo() + " Nome do fundo: " + aplicacao.fundo.getNome_fundo() + "- " + aplicacao.fundo.getSigla_fundo());
                        escritor.WriteLine(" Data da aplicação" + aplicacao.getData_aplicacao() + "Valor: " + aplicacao.getValor_aplicacao());
                        escritor.WriteLine(".......................................................................................................");
                    }             
                }
                        


                    }
                    if (cont == 0)
                    {
                        Console.WriteLine("Não há aplicações nesse fundo, no período solicitado");
                    }
                    else
                    {
                        
                        escritor.Close();
                        Console.WriteLine("Relatório gerado em arquivo!");
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao Atualizar arquivo!");
                }
            }
        }


        //gera em arquivo
        public void Gerar_relatorio_por_cliente(int b_cpf)
        {
            int cont = 0;

            using (StreamWriter escritor = new StreamWriter("../../Relatório_Aplicacoes_por_cliente_e_fundo.txt"))
            {
                try
                {

                    foreach (Aplicacao aplicacao in lista_aplicacoes)
                    {


                        if (aplicacao.dados_cli.getCpf_cliente() == b_cpf)
                        {
                            
                                cont++;
                                escritor.WriteLine("Codigo do cliente: " + aplicacao.dados_cli.getCodigo_cliente() + " Nome:"+aplicacao.dados_cli.getNome_cliente()+ " Código do fundo: " + aplicacao.fundo.getCodigo_fundo() + " Nome do fundo: " + aplicacao.fundo.getNome_fundo() + "- " + aplicacao.fundo.getSigla_fundo());
                                escritor.WriteLine(" Data da aplicação: " + aplicacao.getData_aplicacao() + "Valor: " + aplicacao.getValor_aplicacao());
                                escritor.WriteLine(".......................................................................................................");
                            
                        }

                        

                    }
                    if (cont == 0)
                    {
                        Console.WriteLine("Não há aplicações feitas por esse cliente");
                    }
                    else
                    {
                        Console.WriteLine("Relatório gerado em arquivo!");
                    }

                    escritor.Close();
                    
                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao Atualizar arquivo!");
                }
            }
        }

        // Exibe na tela
        public void Exibir_aplicacoes_por_cliente(int b_cpf)
        {
            int cont = 0;

            

                    foreach (Aplicacao aplicacao in lista_aplicacoes)
                    {


                        if (aplicacao.dados_cli.getCpf_cliente() == b_cpf)
                        {

                            cont++;
                            Console.WriteLine("Codigo do cliente: " + aplicacao.dados_cli.getCodigo_cliente() + " Nome: "+aplicacao.dados_cli.getNome_cliente()+" Código do fundo: " + aplicacao.fundo.getCodigo_fundo() + " Nome do fundo: " + aplicacao.fundo.getNome_fundo() + "- " + aplicacao.fundo.getSigla_fundo());
                            Console.WriteLine(" Data da aplicação" + aplicacao.getData_aplicacao() + "Valor: " + aplicacao.getValor_aplicacao());
                            Console.WriteLine(".......................................................................................................");

                        }

                        
                    }
            if (cont == 0)
            {
                Console.WriteLine("Não há aplicações feitas por esse cliente");
            }

        }


        // muda dados do fundo em uma aplicação
        public void transfere(Aplicacao aplicacao, Fundo_de_investimento fundo_novo)
        {
            int cont = 0;
            foreach(Aplicacao apli in lista_aplicacoes)
            {

                if(aplicacao.getCod_aplicacao() == apli.getCod_aplicacao())
                {
                    apli.fundo.setCodigo_fundo(fundo_novo.getCodigo_fundo());
                    apli.fundo.setNome_fundo(fundo_novo.getNome_fundo());
                    apli.fundo.setSigla_fundo(fundo_novo.getSigla_fundo());
                    cont++;
                }
            }

            Atualiza_arq_aplicacoes();

            if (cont != 0)
            {
                Console.WriteLine("Aplicação transferida com sucesso!");
            }
            else
            {
                Console.WriteLine("Transferência não realizada, verifique se os dados estão corretos!");
            }
            
        }

        
        //Método para resgatar aplicação
        public Aplicacao resgatar(Aplicacao aplicacao)
        {

            foreach (Aplicacao apli in lista_aplicacoes)
            {
                if(apli.getCod_aplicacao() == aplicacao.getCod_aplicacao())
                {
                    lista_aplicacoes.Remove(apli);
                    Atualiza_arq_aplicacoes();
                    Console.WriteLine("Aplicação resgatada");

                    return apli;

                }


            }
            return null;
            
        }





    }
        
    }




 









