using System;
using System.Diagnostics.Contracts;
using DAL.Persitencia;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Repositories
{
	public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly RdajilaDbContext _contextDB;

        public UsuarioRepository(RdajilaDbContext context)
        {
            _contextDB = context;
        }

        public async Task<IQueryable<Usuario>> GetAll()
        {
            IQueryable<Usuario> _queryData = _contextDB.Users.OrderByDescending(el => el.Id).Where(el => el.Estado == 1);
            return _queryData.AsQueryable();
        }

        public async Task<bool> Insert(Usuario data)
        {
            _contextDB.Users.Add(data);
            await _contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Usuario data)
        {
            _contextDB.Users.Update(data);
            await _contextDB.SaveChangesAsync();
            return true;
        }

        /**
         * Eliminación logica del registro
         */
        public async Task<bool> Delete(int id)
        {
            // Eliminación logica del registro
            Usuario _data = _contextDB.Users.First(c => c.Id == id);
            _data.Email = _data.Email + "_delete_" + _data.Id.ToString();
            _data.Estado = -1;

            _contextDB.Users.Update(_data);
            await _contextDB.SaveChangesAsync();
            return true;
        }
    }
}