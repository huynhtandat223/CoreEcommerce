using Infrastructures.RepositoryEntities.Data;
using Infrastructures.RepositoryEntities.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace RCommerce.Module.Core.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<T> : ODataController where T : EntityBase
    {
        protected readonly IRepository<T> _repo;
        public GenericController(IRepository<T> repo)
        {
            _repo = repo;
        }

        [EnableQuery]
        public IQueryable<T> Get()
        {
            return _repo.Query();
        }

        [EnableQuery]
        public SingleResult<T> Get([FromODataUri] int key)
        {
            var result = _repo.Query().Where(i => i.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public IActionResult Post([FromBody]T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _repo.Add(entity);
            return Ok(entity);
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri]int key, [FromBody]T update)
        {
            if (!ModelState.IsValid || key != update.Id) return BadRequest(ModelState);
            _repo.Update(update);
            return Ok(update);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            if (key < 0) return BadRequest("key == 0");

            var entity = Activator.CreateInstance<T>();
            entity.Id = key;
            _repo.Remove(entity);
            return Ok(entity);
        }



    }
}
