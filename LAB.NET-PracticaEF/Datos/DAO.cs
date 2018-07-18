using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public interface DAO <T>
    {
        void Create(T t);
        List<T> GetList();
        void Delete(T t);
        void Update(T t);
        void Attach(T t);
    }
}
