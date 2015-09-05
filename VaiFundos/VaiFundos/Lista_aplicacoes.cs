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



       
    }
}











