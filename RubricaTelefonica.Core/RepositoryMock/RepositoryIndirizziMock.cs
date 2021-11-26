using RubricaTelefonica.Core.Entities;
using RubricaTelefonica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.RepositoryMock
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        public static List<Indirizzo> indirizzi = new List<Indirizzo>()
        {
            new Indirizzo{Tipologia="Residenza", Via="Gramsci", Citta="Cagliari", Cap=09122, Provincia="CA", Nazione="Italia", IdIndirizzo=10, IdContatto=10},
            new Indirizzo{Tipologia="Domicilio", Via="Roma", Citta="Cagliari", Cap=09121, Provincia="CA", Nazione="Italia", IdIndirizzo=11, IdContatto=11},
        };
        public Indirizzo Add(Indirizzo item)
        {
            if (indirizzi.Count == 0)
            {
                item.IdIndirizzo = 10;
            }
            else //se la lista è piena trova l'id più alto e, dopo aver incrementato di 1, lo assegna ad item
            {
                int maxId = 10;
                foreach (var ind in indirizzi)
                {
                    if (ind.IdIndirizzo > maxId)
                    {
                        maxId = ind.IdIndirizzo;
                    }
                }
                item.IdIndirizzo = maxId + 1;
            }
            indirizzi.Add(item);
            return item;
        }

        public List<Indirizzo> GetAll()
        {
            List<Indirizzo> indirizziTrovati = new List<Indirizzo>();
            foreach (var item in indirizzi)
            {
                indirizziTrovati.Add(item);
            }
            return indirizziTrovati;
        }

        public Indirizzo GetByID(int id)
        {
            
            return null;
        }
    }
}
