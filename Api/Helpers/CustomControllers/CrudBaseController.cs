using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Helpers.CustomControllers
{
    public class CrudBaseController<TEntity, TEntityId> : ControllerBase
    {
        IBaseService<TEntity, TEntityId> service;
        public CrudBaseController(IBaseService<TEntity, TEntityId> _service)
        {
            service = _service;
        }
        public List<TEntity> GetAll()
        {
            return service.GetAll();
        }
        public TEntity FindById(TEntityId id)
        {
            return service.FindById(id);
        }
        public void Edit(TEntity entity)
        {
            service.Edit(entity);
        }
        public TEntity AddEntity(TEntity entity)
        {
            return service.AddEntity(entity);
        }
        public void DeleteEntity(TEntityId id)
        {
            service.Delete(id);
        }

    }
}
