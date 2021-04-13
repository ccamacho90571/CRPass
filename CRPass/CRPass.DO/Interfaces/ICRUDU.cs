using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Interfaces
{
    public interface ICRUDU<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(string id);
    }
}
