using Microsoft.AspNetCore.Mvc;
using Interview.Service;
using InterView.Model;

namespace api.Controllers
{
    [Route("[controller]")]
    public class PermisoController : Controller
    {
        private readonly PermisoService _permisoService;

        public PermisoController(PermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _permisoService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _permisoService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Permiso model)
        {
            return Ok(
                _permisoService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Permiso model)
        {
            return Ok(
                _permisoService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _permisoService.Delete(id)
            );
        }
    }
}
