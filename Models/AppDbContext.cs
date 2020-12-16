using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlyPythonFYP.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ExerPaper> ExerPaper { get; set; }
        public virtual DbSet<Opuser> Opuser { get; set; }
        public virtual DbSet<Qnsbank> Qnsbank { get; set; }
        public virtual DbSet<Qntemplate> Qntemplate { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("Class_Id");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnName("Class_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpId).HasColumnName("OP_Id");

                entity.HasOne(d => d.Op)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.OpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ToOPUser");
            });

            modelBuilder.Entity<ExerPaper>(entity =>
            {
                entity.HasIndex(e => e.ExerId)
                    .HasName("AK_ExerPaper_ExerId")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("Class_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ExerId).HasColumnName("Exer_Id");

                entity.Property(e => e.ExerName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.QnsId).HasColumnName("Qns_Id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ExerPaper)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerPaper_ToClass");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ExerPaper)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerPaper_ToOPUser");

                entity.HasOne(d => d.Qns)
                    .WithMany(p => p.ExerPaper)
                    .HasForeignKey(d => d.QnsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerPaper_ToQNSBank");
            });

            modelBuilder.Entity<Opuser>(entity =>
            {
                entity.ToTable("OPUser");

                entity.HasIndex(e => e.Email)
                    .HasName("AK_OPUser_Email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('student')");
            });

            modelBuilder.Entity<Qnsbank>(entity =>
            {
                entity.ToTable("QNSBank");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionType).HasColumnName("Question_Type");

                entity.Property(e => e.TemplateId).HasColumnName("Template_Id");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.WrongAnswer)
                    .IsRequired()
                    .HasColumnName("Wrong_Answer")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Qnsbank)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QNSBank_ToQNTemplate");
            });

            modelBuilder.Entity<Qntemplate>(entity =>
            {
                entity.ToTable("QNTemplate");

                entity.Property(e => e.QuestionType).HasColumnName("Question_Type");

                entity.Property(e => e.TemplateQuestion)
                    .IsRequired()
                    .HasColumnName("Template_Question")
                    .IsUnicode(false);

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Variables)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
