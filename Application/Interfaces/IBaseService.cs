using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
namespace Application.Interfaces
{
    public interface IBaseService<TEntity, TEntityId>
        :IAddEntity<TEntity>, IList<TEntity, TEntityId>,IEdit<TEntity>, IDelete<TEntityId>
    {
    }
}
