using Fazenda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicattion
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Retrieve(int id);
        Customer Update(Customer customer);
        Customer Delete(int id);
        List<Customer> GetAll();
    }
}
