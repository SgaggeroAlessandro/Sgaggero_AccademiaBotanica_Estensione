using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    public class CTropicali : CPianta
    {
        private int umidita;

        protected int Umidita
        {
            get
            {
                return umidita;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("La percentuale di umidità deve essere compresa tra 0% e 100%");
                }
                umidita = value;
            }
        }

        public CTropicali(string Nome, string Specie, int Eta, bool Foglie, int Umidita) : base(Nome, Specie, Eta, Foglie)
        {
            this.Umidita = Umidita;
        }

        public override string Descrizione()
        {

            return base.Descrizione() + $" - Umidità minima: {Umidita}";
        }

        public override bool Adeguata(CStatoAmbientale statoAmbientale)
        {
            if (statoAmbientale.Umidita> Umidita)
            {
                return true;
            }
            return false;
        }


    }
}
