using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static bernardi.davide._4i.rubricaWPF.Contatto;

namespace bernardi.davide._4i.rubricaWPF
{
    public class Persona
    {
        public int idPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona() 
        {
        }
        public Persona(string riga)
        {
            string[] campi = riga.Split(';');
            if(campi.Count() != 3 )
            {
                throw new Exception("Le righe del file Persone.csv devono essere di almeno 3 righe");
            }
            {
                int id = 0;
                int.TryParse(campi[0], out id);
                idPersona = id;

                Nome = campi[1];
                Cognome = campi[2];
            }
        }

    }

    public class Persone : List<Persona> 
    {
        public Persone() { }
        public Persone(string nomeFile) 
        {
            StreamReader fin = new StreamReader( nomeFile );
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                Add(new Persona(fin.ReadLine()));
            }
            fin.Close();
        }
    }
}
