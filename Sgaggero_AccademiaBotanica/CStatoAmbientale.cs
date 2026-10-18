using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    public class CStatoAmbientale : IEquatable<CStatoAmbientale>
    {
        private int mese;
        public int Mese
        {
            get
            {
                return mese;
            }
            set
            {
                if (value < 1 || value > 12)
                    throw new ArgumentException("Il numero del mese deve essere compreso tra 1 e 12");
                mese = value;
            }
        }

        private int temperatura;
        public int Temperatura
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
        private int umidita;
        public int Umidita
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

        private int luminosita;
        public int Luminosita
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

        public CStatoAmbientale(int Mese, int Temperatura, int Umidita, int Luminosita)
        {
            this.Mese = Mese;
            this.Temperatura = Temperatura;
            this.Umidita = Umidita;
            this.Luminosita = Luminosita;
        }

        public bool Equals(CStatoAmbientale other)
        {
            if (other == null) return false;
            return (this.Mese == other.Mese) && (this.Umidita == other.Umidita) && (this.Luminosita == other.Luminosita) && (this.Temperatura == other.Temperatura);

        }
    }
}
