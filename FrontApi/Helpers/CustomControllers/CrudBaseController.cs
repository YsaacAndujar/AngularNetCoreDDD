using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Helpers.CustomControllers
{
    public class CrudBaseController<TEntity, TEntityId> : ControllerBase
    {
        IBaseService<TEntity, TEntityId> service;
        protected CrudBaseController(IBaseService<TEntity, TEntityId> _service)
        {
            service = _service;
        }
        List<TEntity> GetAll()
        {
            return service.GetAll();
        }

    }
}
