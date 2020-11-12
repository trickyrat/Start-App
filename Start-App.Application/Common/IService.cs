/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Collections.Generic;
using System.Threading.Tasks;
using Start_App.Domain.Common;

namespace Start_App.Application.Interface
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entityToAdd);

        T Add(T entityToAdd);

        Task<bool> DeleteAsync(int id);

        bool Delete(int id);

        Task<bool> UpdateAsync(int id, T entityToUpdate);
        bool Update(int id, T entityToUpdate);

        Task<T> DetailsAsync(int id);
        T Details(int id);

        Task<PagedList<T>> GetPagedAllAsync(IPagedRequestBase request);
        PagedList<T> GetPagedAll(IPagedRequestBase request);

        Task<List<T>> GetAllAsync();
        List<T> GetAll();

        Task<bool> ExistsAsync(int id);
        bool Exists(int id);
        Task SaveChangesAsync(string message);
        void SaveChanges(string message);
    }
}
