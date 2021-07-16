using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Pet
    {
        public Pet()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        public int IdPet { get; set; }
        public string NomePet { get; set; }
        public int? IdRaca { get; set; }
        public int? IdDono { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Dono IdDonoNavigation { get; set; }
        public virtual Raca IdRacaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
