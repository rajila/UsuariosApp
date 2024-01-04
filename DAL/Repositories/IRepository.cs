using System;
namespace DAL.Repositories
{
	public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAll();
        Task<bool> Insert(T data);
        Task<bool> Update(T data);
        Task<bool> Delete(int id);
    }
}