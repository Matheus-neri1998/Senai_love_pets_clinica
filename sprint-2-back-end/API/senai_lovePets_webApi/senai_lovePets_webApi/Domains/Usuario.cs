using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pets = new HashSet<Pet>();
            Veterinarios = new HashSet<Veterinario>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Veterinario> Veterinarios { get; set; }
    }
}
