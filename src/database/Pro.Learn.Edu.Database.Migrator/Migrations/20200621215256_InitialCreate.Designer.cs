﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pro.Learn.Edu.Database;

namespace Pro.Learn.Edu.Database.Migrator.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200621215256_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.AnswerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.ToTable("Answer","Exam");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.ExamEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("ExamOccurredOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.ToTable("Exam","Exam");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionAnwserEntity", b =>
                {
                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long>("AnswerId")
                        .HasColumnType("bigint");

                    b.HasKey("QuestionId", "AnswerId");

                    b.ToTable("QuestionAnwser","Exam");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CorrectAnswerId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ExamEntityId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("ExamEntityId");

                    b.ToTable("Question","Exam");
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionAnwserEntity", b =>
                {
                    b.HasOne("Pro.Learn.Edu.Database.Entity.AnswerEntity", "Answer")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pro.Learn.Edu.Database.Entity.QuestionEntity", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pro.Learn.Edu.Database.Entity.QuestionEntity", b =>
                {
                    b.HasOne("Pro.Learn.Edu.Database.Entity.AnswerEntity", "CorrectAnsweer")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pro.Learn.Edu.Database.Entity.ExamEntity", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExamEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
