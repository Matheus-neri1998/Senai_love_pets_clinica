using System;
using System.Collections.Generic;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Atendimento
    {
        public int IdAtendimento { get; set; }
        public int? IdPet { get; set; }
        public int? IdVeterinario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int IdSituacao { get; set; }

        public virtual Pet IdPetNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual Veterinario IdVeterinarioNavigation { get; set; }
    }
}
