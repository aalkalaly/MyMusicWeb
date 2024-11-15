﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebData.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);
        Task<TType> GetByIdAsync(TId id);
        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();
        TType FirstOrDefault(Func<TType, bool> predicate);
        Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);
        IQueryable<TType> GetAllAtached();
        void Add(TType item);
        Task AddAsync(TType item);
        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);
        bool Update(TType item);
        Task<bool> UpdateAsync(TType item);
    }
}
