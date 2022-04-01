using System;
using System.Collections.Generic;
using System.Text;

namespace CorsiDiLaurea
{
    public class Corso
    {
        public string Nome { get; set; }
        public int CFU { get; set; }

        public Corso()
        {

        }
        public Corso(string nome, int cfu)
        {
            Nome = nome;
            CFU = cfu;
        }

        public string GetInfo()
        {
            return $"{Nome} (CFU {CFU})";
        }
    }
}