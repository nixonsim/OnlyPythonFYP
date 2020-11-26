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
        public virtual DbSet<LecUser> LecUser { get; set; }
        public virtual DbSet<Mcqchoices> Mcqchoices { get; set; }
        public virtual DbSet<Qnsbank> Qnsbank { get; set; }
        public virtual DbSet<Qntemplate> Qntemplate { get; set; }
        public virtual DbSet<StdAnswer> StdAnswer { get; set; }
        public virtual DbSet<StdUser> StdUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("Class_Id");

                entity.Property(e => e.LecId).HasColumnName("Lec_Id");

                entity.Property(e => e.StdId).HasColumnName("Std_Id");

                entity.HasOne(d => d.Lec)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.LecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecUser_ToClass");

                entity.HasOne(d => d.Std)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.StdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StdUser_ToClass");
            });

            modelBuilder.Entity<LecUser>(entity =>
            {
                entity.HasKey(e => e.LecId)
                    .HasName("PK__LecUser__2E5B8E707214ECD7");

                entity.HasIndex(e => e.Email)
                    .HasName("AK_LecUser_Email")
                    .IsUnique();

                entity.Property(e => e.LecId).HasColumnName("Lec_Id");

                entity.Property(e => e.ClassId)
                    .IsRequired()
                    .HasColumnName("Class_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Mcqchoices>(entity =>
            {
                entity.HasKey(e => e.ChoiceId);

                entity.ToTable("MCQChoices");

                entity.Property(e => e.ChoiceId).HasColumnName("Choice_Id");

                entity.Property(e => e.Choices)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.IsCorrect)
                    .IsRequired()
                    .HasColumnName("Is_Correct")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("Question_Id");

                entity.Property(e => e.QuestionType).HasColumnName("Question_Type");
            });

            modelBuilder.Entity<Qnsbank>(entity =>
            {
                entity.HasKey(e => e.QnsId);

                entity.ToTable("QNSBank");

                entity.Property(e => e.QnsId).HasColumnName("Qns_Id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionType).HasColumnName("Question_Type");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Qntemplate>(entity =>
            {
                entity.ToTable("QNTemplate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Questions)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StdAnswer>(entity =>
            {
                entity.HasKey(e => e.AnsId)
                    .HasName("PK_Std_AnswerMCQ");

                entity.ToTable("Std_Answer");

                entity.Property(e => e.AnsId).HasColumnName("Ans_Id");

                entity.Property(e => e.Choice)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.MarksAwarded).HasColumnName("Marks_Awarded");

                entity.Property(e => e.QuestionId).HasColumnName("Question_Id");

                entity.Property(e => e.QuestionType).HasColumnName("Question_Type");

                entity.Property(e => e.StdId).HasColumnName("Std_Id");
            });

            modelBuilder.Entity<StdUser>(entity =>
            {
                entity.HasKey(e => e.StdId)
                    .HasName("PK__StdUser__FE2B448EA61C3450");

                entity.HasIndex(e => e.Email)
                    .HasName("AK_StdUser_Email")
                    .IsUnique();

                entity.Property(e => e.StdId).HasColumnName("Std_Id");

                entity.Property(e => e.ClassId)
                    .IsRequired()
                    .HasColumnName("Class_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
