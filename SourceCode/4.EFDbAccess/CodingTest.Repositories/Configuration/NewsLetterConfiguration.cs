using CodingTest.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodingTest.Repositories.Configuration
{
    internal class NewsLetterConfiguration : EntityTypeConfiguration<NewsLetterEntityModel>
    {
        internal NewsLetterConfiguration()
        {
            ToTable("NewsLetters");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
               .IsRequired();

            Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.Publisher)
                .HasColumnName("Publisher")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.Author)
            .HasColumnName("Author")
            .HasColumnType("nvarchar")
            .HasMaxLength(256)
            .IsRequired();

            Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("nvarchar")
            .HasMaxLength(1000)
            .IsRequired();
        }
    }
}
