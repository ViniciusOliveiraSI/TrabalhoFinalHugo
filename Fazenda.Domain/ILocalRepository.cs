using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Domain
{
    public interface ILocalRepository
    {
        Local Save(Local local);
        Local Get(int id);
        Local Update(Local local);
        Local Delete(int i);
        List<Local> GetAll();
        List<Local> GetByDate(DateTime beginDate, DateTime endDate);
    }
}
