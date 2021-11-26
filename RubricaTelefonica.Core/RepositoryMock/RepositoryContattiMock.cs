using RubricaTelefonica.Core.Entities;
using RubricaTelefonica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.RepositoryMock
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        public static List<Contatto> contatti = new List<Contatto>()
        {
            new Contatto{Nome="Anna", Cognome="Bianchi", IdContatto=10},
            new Contatto{Nome="Marco", Cognome="Verdi", IdContatto=11}
        };
        public Contatto Add(Contatto item)
        {
            if (contatti.Count == 0)
            {
                item.IdContatto = 10;
            }
            else //se la lista è piena trova l'id più alto e, dopo aver incrementato di 1, lo assegna ad item
            {
                int maxId = 10;
                foreach (var cont in contatti)
                {
                    if (cont.IdContatto > maxId)
                    {
                        maxId = cont.IdContatto;
                    }
                }
                item.IdContatto = maxId + 1;
            }
            contatti.Add(item);
            return item;
        }

        public Esito Delete(Contatto cont)
        {
            if(cont.IdIndirizzo!=0 || cont.Indirizzi==null)
                {
                    contatti.Remove(cont);
                    return new Esito { Messaggio = "Contatto rimosso", IsOk = true };
                }
            
            return new Esito { Messaggio = "Non puoi rimuovere il contatto", IsOk = false };
            
        }

      

        public List<Contatto> GetAll()
        {
            List<Contatto> contattiTrovati = new List<Contatto>();
            foreach(var item in contatti )
            {
                contattiTrovati.Add(item);
            }
            return contattiTrovati;
        }

        public Contatto GetByID(int id)
        {
            foreach(var item in contatti)
            {
                if (item.IdContatto == id)
                {
                    return item;
                }
                
            }
            return null;
        }
    }
}
