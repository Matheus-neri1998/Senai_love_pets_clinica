using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Veterinario
    {
        public Veterinario()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        public int IdVeterinario { get; set; }
        public int? IdClinica { get; set; }
        public string Crmv { get; set; }
        public string NomeVeterinario { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
