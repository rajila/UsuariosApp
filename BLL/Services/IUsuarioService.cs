using System;
using Models.Entities;

namespace BLL.Services
{
	public interface IUsuarioService
	{
        Task<IQueryable<Usuario>> GetAll();
        Task<bool> Insert(Usuario data);
        Task<bool> Update(Usuario data);
        Task<bool> Delete(int id);
        Task<Usuario> Login(string emailIn, string passwordIn);
    }
}