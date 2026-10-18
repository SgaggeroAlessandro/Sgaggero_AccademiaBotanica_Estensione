using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    public abstract class CPianta : IEquatable<CPianta>, IComparable<CPianta>
    {
        public string Nome { get; set; }
        public string Specie { get; set; }
        public int Eta { get; set; }
        public bool Foglie { get; set; }

        public CPianta(string Nome, string Specie, int Eta, bool Foglie)
        {
            this.Nome = Nome;
            this.Specie = Specie;
            this.Eta = Eta;
            this.Foglie = Foglie;
        }

        public virtual string Descrizione()
        {
            string foglieString = "";
            if (Foglie == true)
            {
                foglieString = "Ha le foglie";
            }
            else
            {
                foglieString = "Non ha le foglie";
            }
            return $"Nome della pianta: {Nome} - Specie: {Specie} - Età: {Eta} - {foglieString}";
        }

        public abstract bool Adeguata(CStatoAmbientale statoAmbientale);

        public bool Equals(CPianta other)
        {
            if (other == null) return false;
            return ((this.Nome.ToLower() == other.Nome.ToLower()) && (this.Specie.ToLower() == other.Specie.ToLower()));

        }

        public int CompareTo(CPianta other)
        {
            int confrontaSpecie = this.Specie.CompareTo(other.Specie);
            if (confrontaSpecie != 0)
            {
                return confrontaSpecie;
            }

            int confrontaNome = this.Nome.ToLower().CompareTo(other.Nome.ToLower());
            if (confrontaNome != 0)
            {
                return confrontaNome;
            }
            return this.Eta.CompareTo(other.Eta);
        }
    }
}
