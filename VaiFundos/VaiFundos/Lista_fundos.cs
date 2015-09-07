using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Lista_fundos
    {


        List<Fundo_de_investimento> Lista_de_fundos = new List<Fundo_de_investimento>();


        public void Cadatrar_fundo(Fundo_de_investimento novo_fundo)
        {
            // criando a lista aqui, toda vez que for adicionar um fundo, se cria uma nova lista


            //bool result = false;
            if (Busca_fundo(novo_fundo.getCodigo_fundo()) == null)
            {
                //Salvo msg = new Salvo();
                Lista_de_fundos.Add(novo_fundo);
                //result = true;
                //msg.Show();
                Console.WriteLine("Novo fundo incluído com sucesso!");

            }
            else
            {
                //Não_salvo msgn = new Não_salvo();
                //msgn.Show();
                //result = false;
                Console.WriteLine("Erro ao salvar, verifique se codigo está correto!");
            }
            //return result; ;
        }


        public Fundo_de_investimento Busca_fundo(int cod)
        {

            foreach (Fundo_de_investimento fundo in Lista_de_fundos)
            {


                if (fundo.getCodigo_fundo() == cod)
                {
                    return fundo;
                }

            }

            return null;

        }


        public int contaFundos()
        {
            return Lista_de_fundos.Count;

        }

        public void Imprimir_fundo(int opc_moeda)
        {

            foreach (Fundo_de_investimento fundo in Lista_de_fundos)
            {
                if (fundo.getOpcaomoeda() == opc_moeda)
                {

                    Console.WriteLine("Codigo: {0}, Nome: {1}, Sigla: {2}" + fundo.getCodigo_fundo()+ fundo.getNome_fundo()+ fundo.getSigla_fundo());
                }
            }
            
        }


        public Fundo_de_investimento Validar_fundo(int cod_fundo, int opc_moeda)
        {

            foreach (Fundo_de_investimento fundo in Lista_de_fundos)
            {
                if (fundo.getOpcaomoeda() == opc_moeda && cod_fundo == fundo.getCodigo_fundo())
                {
                    return fundo;
                }
            }
            return null;
            

        }










    }
}
