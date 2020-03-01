using Microsoft.EntityFrameworkCore;

namespace reactTest.Data {

    public class SomethingContext : DbContext {
        public DbSet<SomethingModel> somethingModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=something;Trusted_Connection=True");
        }

    }

    public class SomethingModel {
        public int ID { get; set; }
        public string something { get; set; }
    }
}