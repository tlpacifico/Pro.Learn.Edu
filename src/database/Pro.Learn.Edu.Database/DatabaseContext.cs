using Microsoft.EntityFrameworkCore;
using Pro.Learn.Edu.Database.Entity;
using System;

namespace Pro.Learn.Edu.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            base.OnModelCreating(builder);

            builder.Entity<AnswerEntity>(opt =>
            {
                opt.CreateTableWithIdAndExternalId("Answer");
                opt.Property(e => e.Description)
                   .IsRequired();
            });

            builder.Entity<ExamEntity>(opt =>
            {
                opt.CreateTableWithIdAndExternalId("Exam");
                opt.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(64);

                opt.Property(e => e.ExamOccurredOn)
                    .IsRequired();

                opt.Property(e => e.Quantity)
                    .IsRequired();

                opt.Property(e => e.CreatedOn)
                    .IsRequired();

                opt.Property(e => e.CreatedBy)
                   .IsRequired();

            });

            builder.Entity<QuestionEntity>(opt =>
            {
                opt.CreateTableWithIdAndExternalId("Question");

                opt.Property(e => e.Description)
                    .IsRequired();

                opt.Property(e => e.CreatedOn)
                    .IsRequired();

                opt.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64);

                opt.HasOne<AnswerEntity>().WithOne()
                .HasForeignKey<QuestionEntity>(e => e.CorrectAnswerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            });

            builder.Entity<ExamQuestionEntity>(opt =>
            {
                opt.ToTable("ExamQuestion");
                opt.MapPrimaryKey();

                opt.HasOne<ExamEntity>()
                .WithMany()
                .HasForeignKey(p => p.ExamId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

                opt.HasOne<QuestionEntity>()
                .WithMany()
                .HasForeignKey(p => p.QuestionId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            });


            builder.Entity<QuestionAnwserEntity>(opt =>
            {
                opt.ToTable("QuestionAnwser");
                opt.MapPrimaryKey();

                opt.HasOne<QuestionEntity>()
                .WithMany()
                .HasForeignKey(p => p.QuestionId)
                 .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

                opt.HasOne<AnswerEntity>()
                 .WithMany()
                 .HasForeignKey(p => p.AnswerId)
                  .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();

            });
        }
    }

}
