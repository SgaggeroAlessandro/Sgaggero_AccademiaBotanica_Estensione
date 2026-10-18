using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    public class CMediterranea : CPianta, IFoglie
    {
        private int luminosita;

        protected int Luminosita
        {
            get
            {
                return luminosita;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("La percentuale di luminosità per la pianta deve essere compresa tra 0 e 100");
                luminosita = value;
            }
        }

        public CMediterranea(string Nome, string Specie, int Eta, bool Foglie, int Luminosita) : base(Nome, Specie, Eta, Foglie)
        {
            this.Luminosita = Luminosita;
        }

        public override string Descrizione()
        {
            return base.Descrizione() + $" - Luminosità minima richiesta: {Luminosita}";
        }

        public void RicresciFoglie()
        {
            Foglie = true;
        }
        public void PerdiFoglie()
        {
            Foglie = false;
        }

        public override bool Adeguata(CStatoAmbientale statoAmbientale)
        {
            if (statoAmbientale.Luminosita > Luminosita)
            {
                return true;
            }

            return false;
        }
    }
}
