using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        public int IdSituacao { get; set; }
        public string NomeSituacao { get; set; }

        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
