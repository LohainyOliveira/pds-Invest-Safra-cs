using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestSafra.Database;

namespace InvestSafra.Models
{
    /// <summary>
    ///     Abstract Class para classes DAO
    /// </summary>
    /// <typeparam name="I"></typeparam>
    class AbstractDAO<I>
    {
        protected Conexao conn = new Conexao();

        public virtual void Delete(I i)
        {
            throw new NotImplementedException();
        }

        public virtual I GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(I i)
        {
            throw new NotImplementedException();
        }

        public virtual List<I> List()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(I i)
        {
            throw new NotImplementedException();
        }
    }
}
