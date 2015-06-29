using Fazenda.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Domain
{
    public class Local : IObjectValidation
    {
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public double Salario { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { set; get; }


        public void Validate()
        {
            if (Entrada < DateTime.Today)
                throw new Exception("Data de Check In inválida");

            if (Entrada > Saida)
                throw new Exception("Data de Check Out inválida");
        }
    }
}
