using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiDiLaurea
{
    public static class Universita
    {
        
        //Per richiamarli si usa "Universita." 
        public static List<Studente> RestituisciIscritti()
        {
            //crea corsi e corsi di laurea e restituisce la lista dei corsi disponibili
            List<CorsoDiLaurea> elencoCdl= ElencoCorsiDiLaurea();
        
            //Creo Lista Studenti immatricolati
            List<Studente> Studenti = new List<Studente>();
            var s1 = new Studente("Renata", "Carriero", 1987);
            var s2 = new Studente("Paperino", "Pluto", 1950);            
            Studenti.Add(s1);
            Studenti.Add(s2);
            //creo Immatricolazione studente1
            var i1 = new Immatricolazione();
            i1.CorsoDiLaurea = elencoCdl[0]; 
            s1.Immatricolazione = i1;
            //creo Immatricolazione studente2
            var i2 = new Immatricolazione();
            i2.CorsoDiLaurea = elencoCdl[1];
            s2.Immatricolazione = i2;
            return Studenti;
        }

        public static List<CorsoDiLaurea> ElencoCorsiDiLaurea()
        {
            //creo Corsi
            var m1 = new Corso("Algebra", 180);
            var m2 = new Corso("Analisi1", 159);
            var m3 = new Corso("Analisi2", 6);
            var m4 = new Corso("Geometria", 1);
            var l1 = new Corso("Letteratura", 9);
            var l2 = new Corso("Letteratura Straniera", 6);
            var f1 = new Corso("Fisica1", 6);
            var f2 = new Corso("Fisica2", 9);
            //creare corso di laurea
            var matematica = new CorsoDiLaurea(CdL.Matematica, 3, 160);
            var fisica = new CorsoDiLaurea(CdL.Lettere, 3, 6);
            var lettere = new CorsoDiLaurea(CdL.Fisica, 5, 9);
            //aggiungo i corsi al corso di laurea
            matematica.Corsi.Add(m1);
            matematica.Corsi.Add(m2);
            matematica.Corsi.Add(m3);
            matematica.Corsi.Add(m4);
            fisica.Corsi.Add(f1);
            fisica.Corsi.Add(f2);
            lettere.Corsi.Add(l1);
            lettere.Corsi.Add(l2);
            //aggiungo corsi di laurea ad una lista che "ritorno"
            List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>();
            corsiDiLaurea.Add(matematica);
            corsiDiLaurea.Add(lettere);
            corsiDiLaurea.Add(fisica);
            return corsiDiLaurea;
        }

        //Controllo se lo studente è già immatricolato.
        public static Studente Esiste(string nome, string cognome, List<Studente> studentiIscritti)
        {
            foreach (var item in studentiIscritti)
            {
                if (nome == item.Nome && cognome == item.Cognome)
                {
                    return item;
                }
            }
            return null;
        }

        public static Esame GetEsame(Studente s, string esameScelto)
        {
            foreach (var item in s.Esami)
            {
                if (item.Corso.Nome == esameScelto)
                {
                    return item;
                }
            }
            return null;
        }
        public static Esame GetEsamePrenotato(Studente s, string esameScelto)
        {
            foreach (var item in s.Esami)
            {
                if (item.Corso.Nome == esameScelto && item.Passato == false)
                {
                    return item;
                }
            }
            return null;
        }

        public static Corso GetCorso(string esameCorso, List<Corso> corsi)
        {
            foreach (var item in corsi)
            {
                if (esameCorso == item.Nome)
                {
                    return item;
                }
            }
            return null;
        }
        public static Esame GetEsame(string esameCorso, List<Esame> esami)
        {
            foreach (var item in esami)
            {
                if (esameCorso == item.Corso.Nome)
                {
                    return item;
                }
            }
            return null;
        }

        public static CorsoDiLaurea GetCorsoDiLaurea(CdL corsoDiLaurea, List<CorsoDiLaurea> elencoCDL)
        {
            foreach (var item in elencoCDL)
            {
                if (corsoDiLaurea == item.Nome)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
