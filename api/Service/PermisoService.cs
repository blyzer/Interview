using InterView.Model;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Service
{

    public class PermisoService
    {
        private readonly PermisoDbContext _permisoDbContext;

        public PermisoService(
            PermisoDbContext permisoDbContext
        )
        {
            _permisoDbContext = permisoDbContext;
        }

        public IEnumerable<Permiso> GetAll()
        {
            var result = new List<Permiso>();

            try
            {
                result = _permisoDbContext.permisos.ToList();
            }
            catch (System.Exception)
            {
                
            }

            return result;
        }

        public Permiso Get(int id)
        {
            var result = new Permiso();

            try
            {
                result = _permisoDbContext.permisos.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Permiso model)
        {
            try
            {
                _permisoDbContext.Add(model);
                _permisoDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Permiso model)
        {
            try
            {
                var originalModel = _permisoDbContext.permisos.Single(x =>
                    x.Id == model.Id
                );

                originalModel.NombreEmpleado = model.NombreEmpleado;
                originalModel.ApellidosEmpleado = model.ApellidosEmpleado;
                originalModel.FechaPermiso = model.FechaPermiso;
                originalModel.TipoPermiso = model.TipoPermiso;

                _permisoDbContext.Update(originalModel);
                _permisoDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _permisoDbContext.Entry(new Permiso { Id = id }).State = EntityState.Deleted; ;
                _permisoDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
