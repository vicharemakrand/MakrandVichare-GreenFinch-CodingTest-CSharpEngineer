using CodingTest.EntityModels.Localization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodingTest.Repositories.Configuration
{
    internal class KeyGroupConfiguration : EntityTypeConfiguration<KeyGroupEntityModel>
    {
        internal KeyGroupConfiguration()
        {
            ToTable("KeyGroups");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.KeyGroup)
                .HasColumnName("KeyGroup")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.LocalizationKeys)
                .HasColumnName("LocalizationKeys")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();
        }
    }
}
