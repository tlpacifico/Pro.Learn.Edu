﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pro.Learn.Edu.Database
{
    internal static class MappingExtensions
    {
        public static EntityTypeBuilder<T> MapPrimaryKey<T>(this EntityTypeBuilder<T> builder)
            where T : class, IHaveId
        {
           builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            return builder;
        }

        public static EntityTypeBuilder<T> MapExternalKey<T>(this EntityTypeBuilder<T> builder)
            where T: class, IHaveExternalId
        {
            builder.HasAlternateKey(e => e.ExternalId);

            builder.Property(e => e.ExternalId)
                .IsRequired();
              
              return builder;
        }

        public static EntityTypeBuilder<T> CreateTableWithIdAndExternalId<T>(this EntityTypeBuilder<T> opt, string tableName, string schema)
            where T : class, IHaveExternalId, IHaveId
        {
            opt.ToTable(tableName, schema);
            opt.MapPrimaryKey();
            opt.MapExternalKey();
            return opt;
        }


    }
}
