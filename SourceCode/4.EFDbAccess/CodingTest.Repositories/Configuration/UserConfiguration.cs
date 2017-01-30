using CodingTest.EntityModels.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodingTest.Repositories.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<UserEntityModel>
    {
        internal UserConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.UserId)
                .Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            //Property(x => x.UserName)
            //    .HasColumnName("UserName")
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(256)
            //    .IsRequired();

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.Claims)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);

            HasOptional(x => x.UserNewsLetter)
            .WithRequired(x => x.User).WillCascadeOnDelete();
        }
    }
}
