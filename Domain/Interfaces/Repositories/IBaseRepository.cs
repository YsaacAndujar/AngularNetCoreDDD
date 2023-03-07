using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityId>
        : IAddEntity<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>
    {
        
    }
}
