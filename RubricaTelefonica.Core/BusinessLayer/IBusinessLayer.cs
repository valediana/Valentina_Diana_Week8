using RubricaTelefonica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        public List<Contatto> ViewAllContatti();
        public Esito AddContatto(Contatto c);
        public Esito AddIndirizzo(Indirizzo i);
        public Esito DeleteContatto(int id);
    }
}
