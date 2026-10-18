using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    public class CHabitat : IEquatable<CHabitat>, IComparable<CHabitat>
    {
        public string Nome { get; set; }
        public CStatoAmbientale StatoAttuale { get; set; }

        public List<CPianta> piantePerHabitat;

        public CHabitat(string Nome, CStatoAmbientale StatoAttuale)
        {
            this.Nome = Nome;
            this.StatoAttuale = StatoAttuale;
            piantePerHabitat = new List<CPianta>();
        }

        public string DescrizioneHabitat()
        {
            return $"Nome dell'habitat: {Nome} \n Mese corrente: {StatoAttuale.Mese} \n Temperatura registrata: {StatoAttuale.Temperatura} \n Umidità registrata: {StatoAttuale.Umidita} \n Luminosità registrata: {StatoAttuale.Luminosita}";
        }
        public bool AggiungiPianta(CPianta p)
        {

            foreach (CPianta pianta in piantePerHabitat)
            {
                if (pianta.Equals(p))
                {
                    return false;
                }
            }

            piantePerHabitat.Add(p);
            return true;
        }


        public bool Equals(CHabitat other)
        {
            if (other == null) return false;
            return ((this.Nome.ToLower() == other.Nome.ToLower()));

        }

        public int CompareTo(CHabitat other)
        {
           
            int confrontaNome = this.Nome.ToLower().CompareTo(other.Nome.ToLower());
            return confrontaNome;
          
        }

    }
}
