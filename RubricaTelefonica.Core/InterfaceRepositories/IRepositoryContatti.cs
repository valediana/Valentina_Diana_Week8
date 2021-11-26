using RubricaTelefonica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.InterfaceRepositories
{
    public interface IRepositoryContatti: IRepository<Contatto>
    {
        public List<Contatto> GetAll();
        public Esito Delete(Contatto cont);
    }
}
