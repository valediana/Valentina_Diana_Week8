using RubricaTelefonica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.InterfaceRepositories
{
    public interface IRepositoryIndirizzi : IRepository<Indirizzo>
    {
        List<Indirizzo> GetAll();
    }
}
