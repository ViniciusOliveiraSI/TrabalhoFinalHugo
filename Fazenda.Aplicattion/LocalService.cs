using Fazenda.Domain;
using Fazenda.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicattion
{
         public class LocalService : ILocalService
    {
             private ILocalRepository _localRepository;

             public LocalService(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public Local Create(Local local)
        {
            Validator.Validate(local);

            var savedLocal = _localRepository.Save(local);

            return savedLocal;
        }


        public Local Retrieve(int id)
        {
            return _localRepository.Get(id);
        }


        public Local Update(Local local)
        {
            Validator.Validate(local);

            var updatedLocal = _localRepository.Update(local);

            return updatedLocal;
        }


        public Local Delete(int id)
        {
            return _localRepository.Delete(id);
        }


        public List<Local> RetrieveAll()
        {
            return _localRepository.GetAll();
        }
    }
}
