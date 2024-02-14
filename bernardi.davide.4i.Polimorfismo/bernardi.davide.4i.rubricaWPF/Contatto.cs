using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bernardi.davide._4i.rubricaWPF
{
    public enum TipoContatto { nessuno, EMail, Telefono, Web, Instagram, Facebook, Cellullare }

    public class Contatto
    {
        public int idPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }


        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');
            if (campi.Count() != 3)
            {
                throw new Exception("Le righe del file Contatti.csv devono essere di almeno 3 righe");
            }
            {
                int id = 0;
                int.TryParse(campi[0], out id);
                idPersona = id;

                TipoContatto c;
                Enum.TryParse(campi[1], out c);
                this.Tipo = c;

                this.Valore = campi[2];

            }
            
        }
        public static Contatto MakeContatto(string riga)
        {
            string[] campi = riga.Split(';');

            TipoContatto c;
            Enum.TryParse(campi[1], out c);

            switch (c)
            {
                case TipoContatto.EMail:
                    return new ContattoEMail(riga);
                    break;
            }
            return new Contatto();
        }

        public Contatto()
        {
            Tipo = TipoContatto.nessuno;
        }
    }
    public class ContattoEMail : Contatto
    {
        ContattoEMail() { }

        public ContattoEMail(string riga)
            : base(riga)
        {

        }       
    
    }
    public class Contatti : List<Contatto>
    {
        public Contatti() { }

        public Contatti(string nomeFile)
        {
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                Add(Contatto.MakeContatto(fin.ReadLine()));
            }
            fin.Close();
        }

    }
}