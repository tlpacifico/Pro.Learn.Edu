using Microsoft.EntityFrameworkCore;
using Pro.Learn.Edu.Database.Entity;
using System;

namespace Pro.Learn.Edu.Database
{
    public class DatabaseContext : DbContext
    {
        private const string ExamSchema = "Exam";

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
                opt.CreateTableWithIdAndExternalId("Answer", ExamSchema);
                opt.Property(e => e.Description)
                   .IsRequired();
            });

            builder.Entity<ExamEntity>(opt =>
            {
                opt.CreateTableWithIdAndExternalId("Exam", ExamSchema);
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
                opt.CreateTableWithIdAndExternalId("Question", ExamSchema);

                opt.Property(e => e.Description)
                    .IsRequired();

                opt.Property(e => e.CreatedOn)
                    .IsRequired();

                opt.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64);
                opt.HasOne(q => q.CorrectAnsweer)
                    .WithMany()
                    .HasForeignKey(q => q.CorrectAnswerId);

            });


            builder.Entity<QuestionAnwserEntity>(opt =>
            {
                opt.ToTable("QuestionAnwser", ExamSchema);

                opt.HasKey(qa => new { qa.QuestionId, qa.AnswerId });

                opt.HasOne(bc => bc.Question)
                    .WithMany(b => b.Answers)
                    .HasForeignKey(bc => bc.QuestionId);

                opt.HasOne(bc => bc.Answer)
                    .WithMany(c => c.Questions)
                    .HasForeignKey(bc => bc.QuestionId);

            });
        }
    }

}
