using Fazenda.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Data
{
    public class LocalRepository : ILocalRepository
    {
        private CustomerContext context;

        public LocalRepository()
        {
            context = new CustomerContext();
        }

        public Local Save(Local local)
        {
            var newLocal = context.Locais.Add(local);
            context.SaveChanges();
            return newLocal;
        }


        public Local Get(int id)
        {
            var local = context.Locais.Find(id);
            return local;
        }


        public Local Update(Local local)
        {
            DbEntityEntry entry = context.Entry(local);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return local; 
        }


        public Local Delete(int id)
        {
            var local = context.Locais.Find(id);
            DbEntityEntry entry = context.Entry(local);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return local;
        }

        public List<Local> GetAll()
        {
            return context.Locais.ToList();
        }

        public List<Local> GetByDate(DateTime beginDate, DateTime endDate)
        {
            return context.Locais.Where(local => local.Entrada >= beginDate && local.Saida <= endDate).ToList();
        }
    }
    
}
