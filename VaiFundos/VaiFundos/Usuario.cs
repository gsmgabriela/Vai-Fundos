using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Usuario
    {
        private string user;
        private int senha;


        public string getUser()
        {
            return user;
        }

        public void setUser(string use)
        {
            user = use;
        }

        public int getSenha()
        {
            return senha;
        }
        public void setSenha(int sen)
        {
            senha = sen;
        }


    }
}
