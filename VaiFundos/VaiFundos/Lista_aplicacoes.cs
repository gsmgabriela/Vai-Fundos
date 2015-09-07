using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Lista_aplicacoes
    {
        List<Aplicacao> lista_aplicacoes = new List<Aplicacao>();

        public void Aplicar(Aplicacao nova_aplicacao)
        {
            // criando a lista aqui, toda vez que for adicionar um fundo, se cria uma nova lista


            lista_aplicacoes.Add(nova_aplicacao);


            Console.WriteLine("Aplicação realizada com sucesso !");

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

            public void Buscar_aplicacao_Cliente(int b_cpf )
        {

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {

                if (aplicacao.dados_cli.getCpf_cliente() == b_cpf)
                {
                    Console.WriteLine("Codigo do fundo: {0}, Nome: {1}, Sigla: {2}, Data:{3}, Valor:{4}" + aplicacao.fundo.getCodigo_fundo()+ aplicacao.fundo.getNome_fundo()+ aplicacao.fundo.getSigla_fundo()+ aplicacao.getData_aplicacao()+ aplicacao.getValor_aplicacao());

                }

            }










        }



        public Aplicacao Retorna_aplicacao(int cpf, int cod_fundo)
        {

            foreach (Aplicacao aplicacao in lista_aplicacoes)
            {
                if (aplicacao.dados_cli.getCpf_cliente() == cpf)
                {
                    if (aplicacao.fundo.getCodigo_fundo() == cod_fundo)
                    {
                        return aplicacao;
                    }
                }
            }
            return null;

        }






        public int containvestimentos()
        {
            return lista_aplicacoes.Count + 1;

        }
        //

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
    }


}

 









