using CodingTest.EntityModels;
using System.Data.Entity.ModelConfiguration;

namespace CodingTest.Repositories.Configuration
{
    internal class UserNewsLetterConfiguration : EntityTypeConfiguration<UserNewsLetterEntityModel>
    {
        internal UserNewsLetterConfiguration()
        {
            ToTable("UserNewsLetters");

            HasKey(x => x.UserId)
            .Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

            Property(x => x.NewsLetterIds)
                .HasColumnName("NewsLetterIds")
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();


        }
    }
}
