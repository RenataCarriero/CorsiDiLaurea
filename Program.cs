using System;
using System.Collections.Generic;

namespace CorsiDiLaurea
{
    class Program
    {
        static void Main(string[] args)
        {
            //Richiesta credenziali
            Console.WriteLine("Hello World!");
            Console.WriteLine("Ciao. Inserisci i tuoi dati:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            //Mi faccio restituire la lista degli studenti iscritti
            List<Studente> studentiIscritti = Universita.RestituisciIscritti();

            //Controllo se lo studente è iscritto e recupero i suoi dati
            Studente studenteIscritto = Universita.Esiste(nome, cognome, studentiIscritti);

            //Opzionale:
            //Se non lo è chiedo se vuole immatricolarsi e se si immatricola lo aggiungo alla lista iscritti.
            while (studenteIscritto == null)
            {
                char risposta;
                Console.WriteLine("Vuoi immatricolarti?  s/n");
                do
                {

                } while (!char.TryParse(Console.ReadLine(), out risposta) && (risposta != 's') && (risposta != 'n'));
                
                if (risposta == 's')
                {

                    Console.WriteLine($"Bene, {nome} {cognome}! Inserisci i seguenti dati per completare l'immatricolazione:");
                    Console.WriteLine("Anno di Nascita");
                    var anno = int.Parse(Console.ReadLine());
                    Studente newStudent = new Studente(nome, cognome, anno);
                    Immatricolazione newImm = new Immatricolazione();
                    Console.WriteLine("A quale corso di Laurea vorresti iscriverti? \nCorsi di Laurea disponibili:");
                    var elencoCDL = Universita.ElencoCorsiDiLaurea();
                    int i = 1;
                    CdL corsoDiLaurea;
                    foreach (var item in elencoCDL)
                    {
                        Console.WriteLine($"{i} : {item.Nome}");
                        i++;
                    }
                    do
                    {
                        Console.Write("Scegli-> ");
                    } while (!CdL.TryParse(Console.ReadLine(), out corsoDiLaurea));
                    
                    var CorsoDiLaureaScelto = Universita.GetCorsoDiLaurea(corsoDiLaurea, elencoCDL);
                    newImm.CorsoDiLaurea = CorsoDiLaureaScelto;
                    newStudent.Immatricolazione = newImm;
                    studentiIscritti.Add(newStudent);
                    studenteIscritto = newStudent;
                    Console.WriteLine("Complimenti Ti sei iscritto!");
                }
                else
                {
                    Console.WriteLine("Ciao");
                    return;
                }
            }


            //Riepilogo Dati studente iscritto
            Console.WriteLine(studenteIscritto.GetInfo());
            Console.WriteLine(studenteIscritto.Immatricolazione.GetInfo());
            bool continua = true;
            while (continua)
            {
                int scelta = SceltaMenu();
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Scegli tra i seguenti corsi:");
                        foreach (var item in studenteIscritto.Immatricolazione.CorsoDiLaurea.Corsi)
                        {
                            //Console.WriteLine($"- {item.Nome} \t CFU: {item.CFU}");
                            Console.WriteLine(item.GetInfo());
                        }

                        var corsoScelto = Console.ReadLine();
                        var corso = Universita.GetCorso(corsoScelto, studenteIscritto.Immatricolazione.CorsoDiLaurea.Corsi);
                        if (corso == null)
                        {
                            Console.WriteLine("Corso errato o non presente tra i corsi a tua disposizione.");
                        }
                        else
                        {
                            if (studenteIscritto.RichiestaLaurea == false &&
                                //studenteIscritto.Immatricolazione.CorsoDiLaurea.Corsi.Contains(corso) &&
                                ((studenteIscritto.Immatricolazione.CFUAccumulati + corso.CFU) <= studenteIscritto.Immatricolazione.CorsoDiLaurea.CFU))
                            {
                                Esame esame =  Universita.GetEsame(corso.Nome, studenteIscritto.Esami);
                                if (esame != null)
                                {
                                    Console.WriteLine("Esame già presente.");
                                }
                                else
                                {
                                    esame = new(corso, false);
                                    studenteIscritto.Esami.Add(esame);
                                    Console.WriteLine("Esame agiunto.");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Non è possibile aggiungere questo esame perchè supera i crediti totali del corso di laurea e/o hai già fatto richiesta di laurea");
                                break;
                            }
                        }
                        break;
                    case 2:

                        Console.WriteLine("Quale esame vuoi Verbalizzare?");
                        //SE l'utente ha esami nella sua lista di esami prenotati
                        if (studenteIscritto.Esami.Count != 0)
                        {
                            //vedo se ci sono esami NON passati quindi "li conto"
                            int numEsamiNONPassati = 0;
                            foreach (var item in studenteIscritto.Esami)
                            {
                                if (item.Passato == false)
                                {
                                    numEsamiNONPassati++;
                                }
                            }
                            //se c'è almeno un esame non passato 
                            if (numEsamiNONPassati > 0)
                            {
                                //stampo quelli non passati
                                foreach (var item in studenteIscritto.Esami)
                                {
                                    if (item.Passato == false)
                                    {
                                        Console.WriteLine($"- {item.Corso.Nome}");
                                    }
                                }
                                Console.Write("Scegli-> ");
                                var esameScelto = Console.ReadLine();
                                var esameDaVerbalizzare = Universita.GetEsamePrenotato(studenteIscritto, esameScelto);
                                if (esameDaVerbalizzare == null)
                                {
                                    Console.WriteLine("Nome Esame errato o non presente nella lista.");
                                }
                                else
                                {
                                    VerbalizzaEsame(esameDaVerbalizzare, studenteIscritto);                                    
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Non ci sono Esami Prenotati");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lista esami vuota");
                        }
                        break;
                    case 3:
                        Console.WriteLine(studenteIscritto.GetInfo());
                        Console.WriteLine(studenteIscritto.Immatricolazione.GetInfo());
                        Console.WriteLine("Esami passati:");
                        foreach (var item in studenteIscritto.Esami)
                        {
                            if(item.Passato==true)
                            Console.WriteLine($"{item.Corso.GetInfo()}");
                            break;
                        }
                        Console.WriteLine("Esami prenotati:");
                        foreach (var item in studenteIscritto.Esami)
                        {
                            if (item.Passato == false)
                                Console.WriteLine($"{item.Corso.GetInfo()}");
                            break;
                        }
                        break;

                    case 0:
                        continua = false;
                        break;
                }
            }
        }



        private static void VerbalizzaEsame(Esame e, Studente s)
        {
            int cfuDaAggiungere = e.Corso.CFU;
            int cfuAggiornati = s.Immatricolazione.CFUAccumulati + cfuDaAggiungere;
            //s.Immatricolazione.CFUAccumulati += cfuDaAggiungere;

            if (cfuAggiornati == s.Immatricolazione.CorsoDiLaurea.CFU)
            {
                Esame esamePassato = Universita.GetEsame(s, e.Corso.Nome);
                esamePassato.Passato = true;
                s.Immatricolazione.CFUAccumulati = cfuAggiornati;
                Console.WriteLine($"{esamePassato.GetInfo()}");
                Console.WriteLine("Esame Verbalizzato!");
                s.RichiestaLaurea = true;
                Console.WriteLine("Bravo. Puoi richiedere la Laurea!");
            }            
            if (cfuAggiornati < s.Immatricolazione.CorsoDiLaurea.CFU)
            {
                Esame esamePassato = Universita.GetEsame(s, e.Corso.Nome);
                esamePassato.Passato = true;
                s.Immatricolazione.CFUAccumulati = cfuAggiornati;
                Console.WriteLine($"{esamePassato.GetInfo()}");
                Console.WriteLine("Esame Verbalizzato!");
            }
            else
            {
                Console.WriteLine("Non puoi verbalizzare l'esame, supera i crediti totali del Corso di Laurea"); 
            }
        }

        

        private static int SceltaMenu()
        {
            Console.WriteLine("---------Menu--------:");
            Console.WriteLine("1: Prenota esame");
            Console.WriteLine("2: Verbalizza esame");
            Console.WriteLine("3: Riepiloga dati studente");
            Console.WriteLine("\n0: Esci");

            int scelta;
            do
            {
                Console.Write("Scegli-> ");
            } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >=0 && scelta<=3)); 
            return scelta;
        }
    }
}
