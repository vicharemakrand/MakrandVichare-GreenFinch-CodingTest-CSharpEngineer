using CodingTest.EntityModels;
using CodingTest.EntityModels.Core;
using CodingTest.EntityModels.Identity;
using CodingTest.EntityModels.Localization;
using CodingTest.IRepositories.Core;
using CodingTest.Repositories.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace CodingTest.Repositories.Core
{
    public class DataContext : DbContext,IDataContext
    {
        public IDbSet<UserEntityModel> Users { get; set; }
        public IDbSet<ClaimEntityModel> Claims { get; set; }

        public IDbSet<UserNewsLetterEntityModel> UserNewsLetters { get; set; }
        public IDbSet<NewsLetterEntityModel> NewsLetters { get; set; }

        public IDbSet<KeyGroupEntityModel> KeyGroups { get; set; }
        public IDbSet<LocalizationKeyEntityModel> LocalizationKeys { get; set; }

        public const string DATABASE_CONNECTION = "DefaultConnection";


        public DataContext()
        : base(DATABASE_CONNECTION)
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, CodingTest.Repositories.Migrations.Configuration>(DATABASE_CONNECTION));
        }

        public virtual IDbSet<T> DbSet<T>() where T : BaseEntityModel
        {
            return Set<T>();
        }

        public new DbEntityEntry Entry<T>(T entity) where T : BaseEntityModel
        {
            return base.Entry(entity);
        }

        public virtual int Commit()
        {
           return base.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }

        public virtual Task<int> CommitAsync(System.Threading.CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());

            modelBuilder.Configurations.Add(new NewsLetterConfiguration());
            modelBuilder.Configurations.Add(new UserNewsLetterConfiguration());

            modelBuilder.Configurations.Add(new KeyGroupConfiguration());
            modelBuilder.Configurations.Add(new LocalizationKeyConfiguration());
        }
    }
}
