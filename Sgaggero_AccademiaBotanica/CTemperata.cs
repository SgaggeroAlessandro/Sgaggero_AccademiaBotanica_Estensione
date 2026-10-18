using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    public class CTemperata : CPianta, IFoglie
    {
        private int temperatura;
        protected int Temperatura
        {
            get
            {
                return temperatura;
            }
            set
            {
                if (value < -5 || value > 35)
                    throw new ArgumentException("La temperatura deve essere compresa tra -5°C e 35°C");
                temperatura = value;
            }
        }

        public CTemperata(string Nome, string Specie, int Eta, bool Foglie, int Temperatura) : base(Nome, Specie, Eta, Foglie)
        {
            this.Temperatura = Temperatura;
        }

        public override string Descrizione()
        {
            return base.Descrizione() + $" - Temperatura ideale: {Temperatura}";
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
            if (statoAmbientale.Temperatura <= Temperatura + 3 && statoAmbientale.Temperatura >= Temperatura - 3)
            {
                return true;
            }
            return false;
        }
    }
}
