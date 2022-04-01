using System;

namespace CorsiDiLaurea
{
    public class Esame
    {
        public Corso Corso { get; set; }
        public bool Passato { get; set; }

        public Esame(Corso corso, bool passato)
        {
            Corso = corso;
            Passato = passato;
        }
        public string GetInfo()
        {
            return $"{Corso.Nome} \t {Corso.CFU} \t {Passato}";
        }

        //public bool RichiediIscrizioneEsame(Studente studente, Corso corso)
        //{
        //    if (studente.RichiestaLaurea == false &&
        //        studente.Immatricolazione.CorsoDiLaurea.Corsi.Contains(corso) && 
        //        corso.CFU<=studente.Immatricolazione.CorsoDiLaurea.CFU)
        //    {
        //        Console.WriteLine("Esame prenotato!");
        //        return true;
        //    }
        //    Console.WriteLine("L'esame non fa parte del tuo Corso di Laurea oppure non puoi prenotarlo");
        //    return false;
        //}
    }
}