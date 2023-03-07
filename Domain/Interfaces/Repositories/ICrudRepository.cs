using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
namespace Domain.Interfaces.Repositories
{
    public interface ICrudRepository<TEntity, TEntityId>
        : IAddEntity<TEntity>, IList<TEntity, TEntityId>, IDelete<TEntityId>, IEdit<TEntity>, ISaveChanges
    {

    }
}
