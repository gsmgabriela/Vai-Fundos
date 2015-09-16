using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Moeda
    {

        protected string nome_moeda;
        protected char simbolo;
        protected List<Moeda> notas = new List<Moeda>(); 
        protected int Qtd_Nota;
        protected int nota;

        // Metodo de carregar notas
        public virtual void Contar_Notas(double Valor_Resgate)
        {
          
        }

        public virtual void CarregarNotas()
        {
        }


        public Moeda(string nom_moed, char simb)
        {
            nome_moeda = nom_moed;
            simbolo = simb;
        }

        
        public string getNome_moeda()
        {
            return nome_moeda;
        }
        public void setNome_moeda(string nom_moed)
        {
            nome_moeda = nom_moed;
        }


        public char getSimbolo()
        {
            return simbolo;
        }
        public void setSimbolo(char simb)
        {
            simbolo = simb;
        }

        
        //usar esse método para o dolar
        public virtual double desconto_resgate(Aplicacao aplicacao)
        {
            double valor_resgate;

           valor_resgate = aplicacao.getValor_aplicacao();

            Console.WriteLine("Aqui é o pai dele");

            return valor_resgate;

        }

        // Para os filhos usar o do pai
        public virtual void Contar_Notas(Aplicacao aplicacao)
        {
           


        }









    }
}
