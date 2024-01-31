using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bernardi.davide._4i.rubricaWPF
{
    internal class Contatto
    {
        public enum TipoContatto { nessuno, EMail, Telefono, Web, Instagram }

        public int idPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }


        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');
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

        public Contatto()
        {
            Tipo = TipoContatto.nessuno;
        }
    }
}