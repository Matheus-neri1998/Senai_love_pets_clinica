using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Veterinarios = new HashSet<Veterinario>();
        }

        public int IdClinica { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Veterinario> Veterinarios { get; set; }
    }
}
