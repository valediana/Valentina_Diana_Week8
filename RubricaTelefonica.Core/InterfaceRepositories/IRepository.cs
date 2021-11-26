using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        
        public T Add(T item);
        public T GetByID(int id);
        
        
    }
}
