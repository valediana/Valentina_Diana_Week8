using RubricaTelefonica.Core.Entities;
using RubricaTelefonica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzi indirizziRepo;


        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito AddIndirizzo(Indirizzo i)
        {
            if (i.IdContatto != 0)
            {
                indirizziRepo.Add(i);
                return new Esito { Messaggio = "Indirizzo aggiunto correttamente", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "ERRORE! Il contatto a cui vuoi associare l'indirizzo non esiste", IsOk = false };
            }

        }

        public Esito AddContatto(Contatto c)
        {
            contattiRepo.Add(c);
            return new Esito { Messaggio = "Contatto aggiunto", IsOk = true };
        }



        public Contatto DeleteContatto(int id)
        {
            //controllo se esiste contatto con id indicato
            //se non esiste==Null o errore
            //se esiste: cerco indirizzi del contatto- se indirizzi non esistono elimino
            //metodo per controllare
            List<Contatto> contatti = ViewAllContatti();
            List<Indirizzo> indirizzi = GetAllIndirizzi();
            int idScelto = 0;
            Contatto contattoElim = new Contatto();
            foreach (var item in contatti)
            {
                if (id == item.IdContatto)
                {
                    idScelto = id;
                    contattoElim = item;
                }
                else
                {
                    idScelto = 0;
                }
            }
            if (contattoElim.Indirizzi!=null)
            {
                return null;
            }
            else
            {
                contattiRepo.Delete(contattoElim);
                return contattoElim;
            }



        }

        private List<Indirizzo> GetAllIndirizzi()
        {
            return indirizziRepo.GetAll();
        }
        public List<Contatto> ViewAllContatti()
        {
            return contattiRepo.GetAll();
        }
    }
}
