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

                
        public int containvestimentos()
        {
            return lista_aplicacoes.Count + 1;

        }


    }
}











