using Fazenda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicattion
{
    public interface ILocalService
    {
        Local Create(Local local);
        Local Retrieve(int id);
        Local Update(Local local);
        Local Delete(int id);
        List<Local> RetrieveAll();
    }
}
