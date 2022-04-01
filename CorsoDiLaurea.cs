using System;
using System.Collections.Generic;

namespace CorsiDiLaurea
{
    public class CorsoDiLaurea
    {
        public CdL Nome { get; set; }
        public int AnniDiCorso { get; set; }
        public int CFU { get; set; } //CFU Totali del Corso di Laurea

        public List<Corso> Corsi = new List<Corso>();

        //Costruttore

        public CorsoDiLaurea(CdL nome, int anni, int cfu)
        {
            Nome = nome;
            AnniDiCorso = anni;
            CFU = cfu;
        }
        public override string ToString()
        {
            return $"{Nome} \t {CFU} \t {AnniDiCorso}";
        }

    }
    public enum CdL
    {
        Matematica = 1,
        Fisica = 2,
        Lettere = 3        
    }
}