using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VaiFundos
{
    class Lista_user
    {
        List<Usuario> lista_usuarios = new List<Usuario>();




        public void carrega_user()
        {
            using (StreamReader reader = new StreamReader(@"../../Arq_Usuarios.txt"))
            {

                try
                {
                    string linha;
                    String[] Separador;
                    linha = reader.ReadLine();
                    
                    string user = " ";
                    int senha = 0;
                    
                    
                    // Ler linha por linha e Adiciona na lista de clientes                    
                    while (linha != null)
                    {

                        Separador = linha.Split(new char[] { ';' });

                        user= Separador[0];
                        senha = int.Parse(Separador[1]);
                        

                        linha = reader.ReadLine();

                        Usuario dados_user = new Usuario();
                        dados_user.setUser(user);
                        dados_user.setSenha(senha);

                        lista_usuarios.Add(dados_user);


                    }
                    reader.Close();

                }
                catch (IOException)
                {
                    Console.WriteLine("Erro ao adicionar na lista");
                }
            }

            
        }

        //Atualiza user

        public void Atualiza_arq_user()
        {

            using (StreamWriter escritor = new StreamWriter("../../Arq_Usuarios.txt"))
            {
                try
                {
                    foreach (Usuario user in lista_usuarios)
                    {
                        escritor.WriteLine(user.getUser()+";"+user.getSenha());
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












        public void cadastra_user(Usuario novo)
        {
            int cont=0;
            foreach(Usuario user in lista_usuarios)
            {
                if (novo.getUser().Equals(user.getUser()))
                {
                    cont++;
                }
            }
            

            if (cont == 0)
            {
                lista_usuarios.Add(novo);
                Atualiza_arq_user();
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário já existente!");
            }

        }


        public Usuario Buscar_usuario(string us,int senha)
        {

            foreach (Usuario user in lista_usuarios)
            {

                if (user.getSenha() == senha && user.getUser().Equals(us))
                {
                    return user; ;

                }

            }
            return null;
        }















    }
}
