using Microsoft.AspNetCore.Mvc;
using Interview.Service;
using InterView.Model;
using Interview.Model;

namespace api.Controllers
{
    [Route("[controller]")]
    public class TipoPermisoController : Controller
    {
        private readonly TipoPermisoService _tipoPermisoService;

        public TipoPermisoController(TipoPermisoService tipoPermisoService)
        {
            _tipoPermisoService = tipoPermisoService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _tipoPermisoService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _tipoPermisoService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] TipoPermiso model)
        {
            return Ok(
                _tipoPermisoService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] TipoPermiso model)
        {
            return Ok(
                _tipoPermisoService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _tipoPermisoService.Delete(id)
            );
        }
    }
}
