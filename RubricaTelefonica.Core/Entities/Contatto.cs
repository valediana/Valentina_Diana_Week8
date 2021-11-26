using System;
using System.Collections.Generic;

namespace RubricaTelefonica.Core.Entities

{
    public class Contatto
    {
        public int IdContatto { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<Indirizzo> Indirizzi { get; set; }
        public int IdIndirizzo { get; set; }  //FK
        public Contatto()
        {

        }
        public override string ToString()
        {
            return $"Nome : {Nome}--Cognome: {Cognome}--{IdContatto}";
        }
    }
}
