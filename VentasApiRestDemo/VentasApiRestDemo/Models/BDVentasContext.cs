using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VentasApiRestDemo.Models
{
    public partial class BDVentasContext : DbContext
    {
        public BDVentasContext()
        {
        }

        public BDVentasContext(DbContextOptions<BDVentasContext> options)
            : base(options)
        {
        }


        public virtual DbSet<TblGrupos> TblGrupos { get; set; }
        public virtual DbSet<TblLineas> TblLineas { get; set; }
        public virtual DbSet<TblProductos> TblProductos { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
                   

            modelBuilder.Entity<TblGrupos>(entity =>
            {
                entity.HasKey(e => e.CodGrup)
                    .HasName("PK_Grupos_COD_GRUP");

                entity.ToTable("tblGrupos");

                entity.Property(e => e.CodGrup)
                    .HasColumnName("COD_GRUP")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NomGrup)
                    .IsRequired()
                    .HasColumnName("NOM_GRUP")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLineas>(entity =>
            {
                entity.HasKey(e => e.CodLin)
                    .HasName("PK_Lineas_COD_LIN");

                entity.ToTable("tblLineas");

                entity.Property(e => e.CodLin)
                    .HasColumnName("COD_LIN")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NomLin)
                    .IsRequired()
                    .HasColumnName("NOM_LIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductos>(entity =>
            {
                entity.HasKey(e => e.CodProd)
                    .HasName("PK_Productos_COD_PROD");

                entity.ToTable("tblProductos");

                entity.Property(e => e.CodProd)
                    .HasColumnName("COD_PROD")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodGrup)
                    .IsRequired()
                    .HasColumnName("COD_GRUP")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodLin)
                    .HasColumnName("COD_LIN")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CosPromC)
                    .HasColumnName("COS_PROM_C")
                    .HasColumnType("money");

                entity.Property(e => e.Marca)
                    .HasColumnName("MARCA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomProd)
                    .IsRequired()
                    .HasColumnName("NOM_PROD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioVta)
                    .HasColumnName("PRECIO_VTA")
                    .HasColumnType("money");

                entity.HasOne(d => d.CodGrupNavigation)
                    .WithMany(p => p.TblProductos)
                    .HasForeignKey(d => d.CodGrup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProductos_tblGrupos");

                entity.HasOne(d => d.CodLinNavigation)
                    .WithMany(p => p.TblProductos)
                    .HasForeignKey(d => d.CodLin)
                    .HasConstraintName("FK_tblProductos_tblLineas");
            });

           
        }
    }
}
