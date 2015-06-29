using Fazenda.Domain;
using Fazenda.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicattion
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            Validator.Validate(customer);

            var savedCustomer = _customerRepository.Save(customer);

            return savedCustomer;
        }


        public Customer Retrieve(int id)
        {
            return _customerRepository.Get(id);
        }


        public Customer Update(Customer customer)
        {
            Validator.Validate(customer);

            var updatedCustomer = _customerRepository.Update(customer);

            return updatedCustomer;
        }


        public Customer Delete(int id)
        {
            return _customerRepository.Delete(id);
        }


        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
