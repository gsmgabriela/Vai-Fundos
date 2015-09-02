using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos
{
    class Cliente
    {
        
            private int codigo_cliente;
            private int cpf_cliente;
            private string nome_cliente;


            public Cliente(int cod_cli, int cpf_cli, string nome_cli)
            {
                codigo_cliente = cod_cli;
                cpf_cliente = cpf_cli;
                nome_cliente = nome_cli;
            }

          
            public int getCodigo_cliente()
            {
                return codigo_cliente;
            }
            public void setCodigo_cliente(int cod_cli)
            {
                codigo_cliente = cod_cli;
            }


            public int getCpf_cliente()
            {
                return cpf_cliente;
            }
            public void setCpf_cliente(int cpf_cli)
            {
                cpf_cliente = cpf_cli;
            }


            public string getNome_cliente()
            {
                return nome_cliente;
            }
            public void setNome_cliente(string nome_cli)
            {
                nome_cliente = nome_cli;
            }

        


        }
}
