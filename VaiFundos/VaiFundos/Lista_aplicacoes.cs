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
            Console.WriteLine("Aplicação realizada com sucesso !");
        }


        //Metodo para ler o arquivo de aplicações
        public void Aplicações_arq()
        {
            using (StreamReader reader = new StreamReader(@"C:\\Users\\BRUNO\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\\Arq_Aplicacões.txt"))
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

            using (StreamWriter escritor = new StreamWriter(@"C:\\Users\\BRUNO\\Source\\Repos\\Vai-Fundos\\VaiFundos\\VaiFundos\\Arq_Aplicacões.txt"))
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

        public void Buscar_aplicacao(int cod_apl)
        {

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {

                if (aplicacao.getCod_aplicacao() == cod_apl)
                {
                    Console.WriteLine("Codigo do fundo: {0}, Nome: {1}, Sigla: {2}, Data:{3}, Valor:{4}" + aplicacao.fundo.getCodigo_fundo(), aplicacao.fundo.getNome_fundo(), aplicacao.fundo.getSigla_fundo(), aplicacao.getData_aplicacao(), aplicacao.getValor_aplicacao());

                }

            }
        }



            // Utilizando para buscar pelo CPF
           public void Buscar_aplicacao_Cliente(int b_cpf, int cod_fundo )
        {

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {

                if (aplicacao.dados_cli.getCpf_cliente() == b_cpf)
                {
                    if (aplicacao.fundo.getCodigo_fundo() == cod_fundo)
                    {
                        Console.WriteLine("Codigo do fundo: {0}, Nome: {1}, Sigla: {2}, Data:{3}, Valor:{4}" + aplicacao.fundo.getCodigo_fundo() + aplicacao.fundo.getNome_fundo() + aplicacao.fundo.getSigla_fundo() + aplicacao.getData_aplicacao() + aplicacao.getValor_aplicacao());
                    }
                }
                else
                {
                    Console.WriteLine("Cliente Não possui aplicações nesse fundo");
                }

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

            
        


        //ver pra que serve
        public void RetornoAplicacaoDados(int cod_apl)
        {
            DateTime Data_Hoje;
            Data_Hoje = DateTime.Now;
            int Total_Dias;
            int Qtd_Ano_Dias = 365;
            int Ano = 365;
            double Porcentagem = 5;            
            double Valor_Corrigido_porcentagem;
            double Valor_Aplicacao;
            double Valor_Aplicacao_anterior;
            int QTD_ANO = 1;
            double PorcentagemAtualizada = 5;

           

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {
                if (aplicacao.getCod_aplicacao() == cod_apl)
                {
                    TimeSpan Data_Dias = Convert.ToDateTime(Data_Hoje) - Convert.ToDateTime(aplicacao.getData_aplicacao());

                    Total_Dias = Data_Dias.Days;


                    if (Total_Dias == Qtd_Ano_Dias)
                    {
                        Valor_Aplicacao = aplicacao.getValor_aplicacao();
                        Valor_Aplicacao_anterior = aplicacao.getValor_aplicacao();
                        Valor_Corrigido_porcentagem = Valor_Aplicacao * Porcentagem;
                        Valor_Aplicacao = Valor_Aplicacao + Valor_Corrigido_porcentagem;

                        aplicacao.setValor_aplicacao(Valor_Aplicacao);
                        Console.WriteLine("Valor Anterior da Aplicação: R${0}  Aplicação Atualizada com a Remuneração de 5% 1 ano  Atualizou para: R$" + Valor_Aplicacao_anterior, Valor_Aplicacao);
                        
                    } else
                    {
                        if (Total_Dias < Qtd_Ano_Dias)
                        {
                            Console.WriteLine("Sua aplicação não tem um ano");
                        }

                        else
                        {
                            while (Total_Dias > Qtd_Ano_Dias)
                            {
                                QTD_ANO++;
                                Qtd_Ano_Dias += Ano; 
                                PorcentagemAtualizada += Porcentagem;
                             
                            }

                            Valor_Aplicacao = aplicacao.getValor_aplicacao();
                            Valor_Aplicacao_anterior = aplicacao.getValor_aplicacao();
                            Valor_Corrigido_porcentagem = Valor_Aplicacao * PorcentagemAtualizada;
                            Valor_Aplicacao = Valor_Aplicacao + Valor_Corrigido_porcentagem;

                            aplicacao.setValor_aplicacao(Valor_Aplicacao);
                            Console.WriteLine("Valor Anterior da Aplicação: R${0} , Aplicação Atualizada de {1} Anos Valor Atual depois da % de {2} Valor Atual R${3}  " + Valor_Aplicacao_anterior + QTD_ANO + Valor_Corrigido_porcentagem + Valor_Aplicacao);
                            


                        }
                    }
                }
            }
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









    }


}

 









