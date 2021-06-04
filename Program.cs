using System;
//-Mostrare tutti gli agenti di polizia 
//- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area 
//- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto  all’input 
//- Inserire un nuovo agente solo se non è già presente nel database 

namespace Prova6SaraUras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Menu----------------");
            Console.WriteLine("\t Premi A per visualizzare tutti gli agenti");
            Console.WriteLine("\t Premi B per mostrare gli agenti assegnati all area geografica");
            Console.WriteLine("\t Premi C per mostrare gli agenti con anni di servizio maggiori o uguali rispetto alla tua scelta");
            Console.WriteLine("\t Premi D per inserire un nuovo agente");
            Console.WriteLine("\t Premi E per uscire");


            do
            {
                char scelta = Console.ReadKey().KeyChar;

                switch (scelta)
                {
                    case 'A': DBManager.VisualizzaAgenti();
                        break;
                    case 'B':
                      
                        helperM();
                        break;
                    case 'C':
                        HelperMostraAnniServizio();
                      
                        break;
                      
                    case 'D':
                        HelperInserisciAgente();
                        break;
                    case 'E': return;
                        

                }

            } while (true);

        }

        private static void HelperInserisciAgente()
        {
            do
            {
                Agente agente = new Agente();
                Console.WriteLine("\t Inserisci Nome");
                agente.Nome = Console.ReadLine();
                Console.WriteLine("\t Inserisci Cognome");
                agente.Cognome = Console.ReadLine();
                Console.WriteLine("\t Inserisci CodiceFiscale");
                agente.CodiceFiscale = Console.ReadLine();
                Console.WriteLine("\t Inserisci Area Geografica");
                agente.AreaGeo = Console.ReadLine();
                Console.WriteLine("\t Inserisci Anno");
                agente.AnnoInizioAttivita = Convert.ToInt32(Console.ReadLine());
                DBManager.InserisciAgente(agente.Nome, agente.Cognome, agente.CodiceFiscale, agente.AnnoInizioAttivita, agente.AreaGeo);
                Console.WriteLine("\t Agente Inserito");
              
            } while (true);
           
        }

        private static void HelperMostraAnniServizio()
        {
            Agente agente = new Agente();
            Console.WriteLine("\t Inserisci Numero anni di servizio");
            agente.AnniServizio = Convert.ToInt32(Console.ReadLine());
            DBManager.MostraAgentiAnniServizio(agente.AnniServizio);
         
          

        }

        private static void helperM()
        {
            
            Agente agente = new Agente();
            Console.WriteLine("\t Inserisci Area Geografica");
            agente.AreaGeo = Console.ReadLine();
         
            DBManager.MostraAgentiAreaGeo(agente.AreaGeo);

        }
    }
}
