using CodingTest.EntityModels.Localization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodingTest.Repositories.Configuration
{
    internal class LocalizationKeyConfiguration : EntityTypeConfiguration<LocalizationKeyEntityModel>
    {
        internal LocalizationKeyConfiguration()
        {
            ToTable("LocalizationKeys");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.LocalizationKey)
                .HasColumnName("LocalizationKey")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.EnglishValue)
                .HasColumnName("EnglishValue")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.IrishValue)
                .HasColumnName("IrishValue")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.IsActive)
            .HasColumnName("IsActive")
            .HasColumnType("bit")
            .IsRequired();
        }
    }
}
