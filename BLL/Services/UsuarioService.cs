using System;
using DAL.Repositories;
using Models.Entities;

namespace BLL.Services
{
	public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repositoryEntity;

        public UsuarioService(IRepository<Usuario> repEntity)
        {
            _repositoryEntity = repEntity;
        }

        public async Task<IQueryable<Usuario>> GetAll()
        {
            return await _repositoryEntity.GetAll();
        }

        public async Task<bool> Insert(Usuario data)
        {
            return await _repositoryEntity.Insert(data);
        }

        public async Task<bool> Update(Usuario data)
        {
            return await _repositoryEntity.Update(data);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repositoryEntity.Delete(id);
        }

        public async Task<Usuario> Login(string emailIn, string passwordIn)
        {
            IQueryable<Usuario> _queryData = await _repositoryEntity.GetAll();
            Usuario _data = _queryData.AsQueryable().Where(el => el.Email == emailIn && el.Password == passwordIn).FirstOrDefault();
            return _data;
        }
    }
}

