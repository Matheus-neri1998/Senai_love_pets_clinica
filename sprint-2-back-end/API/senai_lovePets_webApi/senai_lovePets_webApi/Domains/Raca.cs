using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Raca
    {
        public Raca()
        {
            Pets = new HashSet<Pet>();
        }

        public int IdRaca { get; set; }
        public int? IdTipoPet { get; set; }
        public string NomeRaca { get; set; }

        public virtual TipoPet IdTipoPetNavigation { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
