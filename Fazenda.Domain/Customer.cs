using Fazenda.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Domain
{
    public class Customer : IObjectValidation
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Cidade { get; set; }

        public List<Local> Locais { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(Telefone))
                throw new Exception("Telefone Inválido");

            }
        }
    
}
