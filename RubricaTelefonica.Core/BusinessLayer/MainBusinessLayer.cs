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



        public Esito DeleteContatto(int id)
        {
            //controllo se esiste contatto con id indicato
            //se non esiste==Null o errore
            //se esiste: cerco indirizzi del contatto- se indirizzi non esistono elimino
            //metodo per controllare
            Contatto contattoDaElim = new Contatto();
            Esito messaggio = new Esito();
            List<Contatto> contatti = ViewAllContatti();
            List<Indirizzo> indirizzi = GetAllIndirizzi();
            foreach (var item in contatti)
            {
                if (id == item.IdContatto)
                {
                    contattoDaElim = item;
                }
                else
                {
                    messaggio = new Esito { Messaggio = "Questo ID  non esiste" };
                }
            }
               
            foreach(var item in indirizzi)
            {
                if (item.IdContatto==id)
                {
                    messaggio = new Esito { Messaggio = "ERRORE. Non puoi eliminare questo contatto" };
                }
            }
            messaggio = contattiRepo.Delete(contattoDaElim);
            return messaggio;
             
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
