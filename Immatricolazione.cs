using System;

namespace CorsiDiLaurea
{
    
    public class Immatricolazione
    {
        private static int matricolaPartenza = 1000;

        public  int  Matricola { get; }
        public  DateTime DataIscrizione { get; set; }
        public  CorsoDiLaurea CorsoDiLaurea { get; set; }
        public  bool FuoriCorso { get; set; }
        public  int CFUAccumulati { get; set; }

        public Immatricolazione()
        {
            Matricola = ++matricolaPartenza;
            CFUAccumulati = 0;
            FuoriCorso = false;
            DataIscrizione = DateTime.Today;
        }
        public string GetInfo()
        {
            return $"matricola: {Matricola} \t CFU ACCUMULATI: {CFUAccumulati} \t - {CorsoDiLaurea.Nome} \t CFU TOT{CorsoDiLaurea.CFU}";
        }
    }
}