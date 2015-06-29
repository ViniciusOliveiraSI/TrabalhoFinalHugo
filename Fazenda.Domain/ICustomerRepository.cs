using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Domain
{
    public interface ICustomerRepository
    {
        Customer Save(Customer customer);
        Customer Get(int id);
        Customer Update(Customer customer);
        Customer Delete(int i);        
        List<Customer> GetAll();

        List<Customer> GetByNome(string nome);
      
    }
}
