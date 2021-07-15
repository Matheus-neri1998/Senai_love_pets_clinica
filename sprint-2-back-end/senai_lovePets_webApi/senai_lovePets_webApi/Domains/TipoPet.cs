using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class TipoPet
    {
        public TipoPet()
        {
            Racas = new HashSet<Raca>();
        }

        public int IdTipoPet { get; set; }
        public string NomeTipoPet { get; set; }

        public virtual ICollection<Raca> Racas { get; set; }
    }
}
