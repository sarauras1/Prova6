using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Area geografica 
//Anno di inizio attività 

namespace Prova6SaraUras
{
    public class Agente : Persona
    {
        public  DateTime Date { get; set; }
        public int AnniServizio { get; set; }
        public string AreaGeo { get; set; }
        public int AnnoInizioAttivita { get; set; } 

        public Agente(string nome, string cognome, string codicefiscale, string areageo, int anno)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codicefiscale;
            AnnoInizioAttivita = anno;
            AnniServizio = Date.Year - anno;
           AreaGeo = areageo;
        }
        public Agente()
        {

        }
    }
}
