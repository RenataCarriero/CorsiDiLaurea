using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiDiLaurea
{
    public class Studente
    {
        
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoDiNascita { get; set; }
        public Immatricolazione Immatricolazione { get; set; }
        public bool RichiestaLaurea { get; set; }

        public List<Esame> Esami = new List<Esame>();

        public Studente()
        {

        }
        public Studente(string nome, string cognome, int annoDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = annoDiNascita;
            RichiestaLaurea = false;
        }

        public string GetInfo()
        {
            return $"Studente: {Nome} \t {Cognome} \t - RichiestaLaurea: {RichiestaLaurea} ";
        }
    }
}
