using Fazenda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Test
{
        public class ObjectMother
    {
            public static Customer GetCustomer()
            {
                Customer customer = new Customer();
                customer.Nome = "Vinícius Oliveira";
                customer.Telefone = "4999517803";
                customer.Endereco = "João Severiano Waltrick";
                customer.Cidade = "Lages";
                customer.Locais = new List<Local>()
            {
                new Local()
                {
                    Entrada = DateTime.Now,
                    Saida = DateTime.Now.AddDays(2),
                    Salario = 900,
                    
                }
            };

                return customer;
            }

            public static Local GetLocal()
            {
                Customer customer = new Customer();
                customer.Nome = "Vinícius Oliveira";
                customer.Telefone = "4999517803";
                customer.Endereco = "João Severiano Waltrick";
                customer.Cidade = "Lages";

                Local local = new Local();
                local.Entrada = DateTime.Now;
                local.Saida = DateTime.Now.AddDays(2);
                local.Salario = 900;
                local.Customer = customer;

                return local;

            }
    }
}
