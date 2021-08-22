using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SalesManagementSystem.Domain
{
    public interface IRepository<T>
    {
        void Add(T t);
        void Delete(int id);
        IEnumerable<T> List();
        T GetById(int id);
        void Update(T t);
    }
}
