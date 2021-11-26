using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.Entities
{
    public class Indirizzo
    {
        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public int Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }
        public Contatto Contatto { get; set; }
        public int IdContatto { get; set; } //FK
        public Indirizzo()
        {

        }
        public override string ToString()
        {
            return $"ID Indirizzo:{IdIndirizzo} appartenente a:{IdContatto}";
        }
    }
}
