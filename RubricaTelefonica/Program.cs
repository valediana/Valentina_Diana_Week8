using RubricaTelefonica.Core.BusinessLayer;
using RubricaTelefonica.Core.Entities;
using RubricaTelefonica.Core.RepositoryMock;
using System;
using System.Collections.Generic;

namespace RubricaTelefonica.ConsoleApp
{
    class Program
    {
       
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        


        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nella Rubrica");

            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    InserisciContatto();
                    break;
                case 3:
                    AggiungiIndirizzo();
                    break;
                case 4:
                    EliminaContatto();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Riprova");
                    break;
            }
            return true;
        }
        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu*********************");
            //Funzionalità Corsi
            Console.WriteLine("\nBenvenuto in RUBRICA");
            Console.WriteLine("1. Visualizza Contatti");
            Console.WriteLine("2. Inserisci nuovo contatto");
            Console.WriteLine("3. Aggiungi indirizzo");
            //Console.WriteLine("4. Elimina un Contatto");
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) && (scelta>=0 && scelta <= 4)))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta:");
            }
            return scelta;
        }
        private static void EliminaContatto()
        {
            Console.WriteLine("Contatti presenti");
            List<Contatto> contatti = new List<Contatto>();
            contatti = bl.ViewAllContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessun contatto trovato");
            }
            else
            {
                foreach (var item in contatti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("Inserisci l'ID del contatto da eliminare");
            int codice;
            while (!(int.TryParse(Console.ReadLine(), out codice)))
            {
                Console.WriteLine("Inserisci un intero!");
            }
            Contatto contattoDaEliminare = new Contatto();
            Esito elimin = bl.DeleteContatto(codice);
           
                Console.WriteLine($"{elimin.Messaggio}");
       }

        private static void AggiungiIndirizzo()
        {
            Console.WriteLine("Contatti presenti");
            List<Contatto> contatti = new List<Contatto>();
            contatti = bl.ViewAllContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessun contatto trovato");
            }
            else
            {
                foreach (var item in contatti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("Inserisci un nuovo indirizzo per un contatto esistente");
            Indirizzo indirizzoNuovo = new Indirizzo();
            Console.WriteLine("Inserisci la via");
            indirizzoNuovo.Via = Console.ReadLine();
            Console.WriteLine("Inserisci la città");
            indirizzoNuovo.Citta = Console.ReadLine();
            Console.WriteLine("Inserisci la provincia");
            indirizzoNuovo.Provincia = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione");
            indirizzoNuovo.Nazione = Console.ReadLine();
            Console.WriteLine("Inserisci il CAP");
            indirizzoNuovo.Cap = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci ID Contatto");
            indirizzoNuovo.IdContatto = int.Parse(Console.ReadLine());
            Esito esito = bl.AddIndirizzo(indirizzoNuovo);
            Console.WriteLine(esito.Messaggio);
        }
    

        private static void InserisciContatto()
        {
            Contatto contatto = new Contatto();
            Console.WriteLine("Inserisci i dati del nuovo contatto");
            Console.WriteLine("Inserisci il nome:");
            contatto.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome:");
            contatto.Cognome = Console.ReadLine();
            Esito esito=bl.AddContatto(contatto);
            Console.WriteLine(esito.Messaggio);
        }

        private static void VisualizzaContatti()
        {
            List<Contatto> contatti = new List<Contatto>();
            contatti = bl.ViewAllContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessun contatto trovato");
            }
            else
            {
               foreach(var item in contatti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}

