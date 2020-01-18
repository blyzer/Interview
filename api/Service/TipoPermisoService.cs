using Interview.Model;
using InterView.Model;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Service
{

    public class TipoPermisoService
    {
        private readonly PermisoDbContext _permisoDbContext;

        public TipoPermisoService(
            PermisoDbContext permisoDbContext
        )
        {
            _permisoDbContext = permisoDbContext;
        }

        public IEnumerable<TipoPermiso> GetAll()
        {
            var result = new List<TipoPermiso>();

            try
            {
                result = _permisoDbContext.tipoPermisos.ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public TipoPermiso Get(int id)
        {
            var result = new TipoPermiso();

            try
            {
                result = _permisoDbContext.tipoPermisos.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(TipoPermiso model)
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

        public bool Update(TipoPermiso model)
        {
            try
            {
                var originalModel = _permisoDbContext.tipoPermisos.Single(x =>
                    x.Id == model.Id
                );

                originalModel.Descripcion = model.Descripcion;

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
