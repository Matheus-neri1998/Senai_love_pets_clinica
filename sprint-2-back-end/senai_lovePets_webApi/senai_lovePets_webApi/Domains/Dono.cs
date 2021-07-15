using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Dono
    {
        public Dono()
        {
            Pets = new HashSet<Pet>();
        }

        public int IdDono { get; set; }
        public string NomeDono { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
