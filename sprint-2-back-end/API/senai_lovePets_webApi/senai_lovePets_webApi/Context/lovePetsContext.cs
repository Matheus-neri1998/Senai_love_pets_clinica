using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_lovePets_webApi.Domains;

#nullable disable

namespace senai_lovePets_webApi.Context
{
    public partial class lovePetsContext : DbContext
    {
        public lovePetsContext()
        {
        }

        public lovePetsContext(DbContextOptions<lovePetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atendimento> Atendimentos { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Dono> Donos { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Raca> Racas { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoPet> TipoPets { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-30RGV41\\SQLEXPRESS; Initial Catalog=lovePets_tarde; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(e => e.IdAtendimento)
                    .HasName("PK__atendime__CCF8C80CB7EB6635");

                entity.ToTable("atendimento");

                entity.Property(e => e.IdAtendimento).HasColumnName("idAtendimento");

                entity.Property(e => e.DataAtendimento)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataAtendimento");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdPet).HasColumnName("idPet");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdVeterinario).HasColumnName("idVeterinario");

                entity.HasOne(d => d.IdPetNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdPet)
                    .HasConstraintName("FK__atendimen__idPet__44FF419A");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__atendimen__idSit__46E78A0C");

                entity.HasOne(d => d.IdVeterinarioNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdVeterinario)
                    .HasConstraintName("FK__atendimen__idVet__45F365D3");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__clinica__C73A6055720AA849");

                entity.ToTable("clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__clinica__35BD3E4827678561")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__clinica__9456D40612E723A7")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__clinica__9BF93A3029905CC3")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Dono>(entity =>
            {
                entity.HasKey(e => e.IdDono)
                    .HasName("PK__dono__DE143B4F79260C79");

                entity.ToTable("dono");

                entity.Property(e => e.IdDono).HasColumnName("idDono");

                entity.Property(e => e.NomeDono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeDono");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("PK__pet__3D78D112BC7C6D31");

                entity.ToTable("pet");

                entity.Property(e => e.IdPet).HasColumnName("idPet");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.IdDono).HasColumnName("idDono");

                entity.Property(e => e.IdRaca).HasColumnName("idRaca");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomePet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomePet");

                entity.HasOne(d => d.IdDonoNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdDono)
                    .HasConstraintName("FK__pet__idDono__398D8EEE");

                entity.HasOne(d => d.IdRacaNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdRaca)
                    .HasConstraintName("FK__pet__idRaca__38996AB5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__pet__idUsuario__3A81B327");
            });

            modelBuilder.Entity<Raca>(entity =>
            {
                entity.HasKey(e => e.IdRaca)
                    .HasName("PK__raca__E1222B0233316313");

                entity.ToTable("raca");

                entity.HasIndex(e => e.NomeRaca, "UQ__raca__CCCCA2DF6E83910B")
                    .IsUnique();

                entity.Property(e => e.IdRaca).HasColumnName("idRaca");

                entity.Property(e => e.IdTipoPet).HasColumnName("idTipoPet");

                entity.Property(e => e.NomeRaca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeRaca");

                entity.HasOne(d => d.IdTipoPetNavigation)
                    .WithMany(p => p.Racas)
                    .HasForeignKey(d => d.IdTipoPet)
                    .HasConstraintName("FK__raca__idTipoPet__2F10007B");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD19784CDF937");

                entity.ToTable("situacao");

                entity.HasIndex(e => e.NomeSituacao, "UQ__situacao__E5144E4B82EB074E")
                    .IsUnique();

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.NomeSituacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeSituacao");
            });

            modelBuilder.Entity<TipoPet>(entity =>
            {
                entity.HasKey(e => e.IdTipoPet)
                    .HasName("PK__tipoPet__FE6B57ABAB379588");

                entity.ToTable("tipoPet");

                entity.HasIndex(e => e.NomeTipoPet, "UQ__tipoPet__9A5D8CB8B3A424AD")
                    .IsUnique();

                entity.Property(e => e.IdTipoPet).HasColumnName("idTipoPet");

                entity.Property(e => e.NomeTipoPet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoPet");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF196AC3AA");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9F8D3C4C4D")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6F5CA8182");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164151B243C")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__35BCFE0A");
            });

            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.HasKey(e => e.IdVeterinario)
                    .HasName("PK__veterina__50972613549CF082");

                entity.ToTable("veterinario");

                entity.HasIndex(e => e.Crmv, "UQ__veterina__2C9DB75B4A4667AB")
                    .IsUnique();

                entity.Property(e => e.IdVeterinario).HasColumnName("idVeterinario");

                entity.Property(e => e.Crmv)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("crmv")
                    .IsFixedLength(true);

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeVeterinario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeVeterinario");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Veterinarios)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__veterinar__idCli__3E52440B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Veterinarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__veterinar__idUsu__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
