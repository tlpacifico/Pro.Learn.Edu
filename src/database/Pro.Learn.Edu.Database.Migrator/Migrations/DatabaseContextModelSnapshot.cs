﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pro.Learn.Edu.Database;

namespace Pro.Learn.Edu.Database.Migrator.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.AnswerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.ExamEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("ExamOccurredOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.ExamQuestionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamQuestion");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionAnwserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AnswerId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnwser");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CorrectAnswerId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.HasIndex("CorrectAnswerId")
                        .IsUnique();

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.ExamQuestionEntity", b =>
                {
                    b.HasOne("Pro.Learn.Edu.Database.Entity.ExamEntity", null)
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pro.Learn.Edu.Database.Entity.QuestionEntity", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionAnwserEntity", b =>
                {
                    b.HasOne("Pro.Learn.Edu.Database.Entity.AnswerEntity", null)
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pro.Learn.Edu.Database.Entity.QuestionEntity", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionEntity", b =>
                {
                    b.HasOne("Pro.Learn.Edu.Database.Entity.AnswerEntity", null)
                        .WithOne()
                        .HasForeignKey("Pro.Learn.Edu.Database.Entity.QuestionEntity", "CorrectAnswerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
