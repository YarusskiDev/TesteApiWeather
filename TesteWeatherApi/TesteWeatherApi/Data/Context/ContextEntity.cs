using Microsoft.EntityFrameworkCore;
using TesteWeatherApi.Data.Models;

namespace TesteWeatherApi.Data.Context
{
    public class ContextEntity : DbContext
    {

        public ContextEntity(DbContextOptions<ContextEntity> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseWeatherEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedNever();

                entity.HasOne(c => c.Clouds).WithOne(b => b.BaseWeatherEntity).HasForeignKey<CloudsEntity>(f => f.BaseWeatherEntityId);
                entity.HasOne(c => c.Coord).WithOne(b => b.BaseWeatherEntity).HasForeignKey<CoordEntity>(f => f.BaseWeatherEntityId);
                entity.HasOne(c => c.Main).WithOne(b => b.BaseWeatherEntity).HasForeignKey<MainEntity>(f => f.BaseWeatherEntityId);
                entity.HasMany(c => c.Weather).WithOne(b => b.BaseWeatherEntity).HasForeignKey(f => f.BaseWeatherEntityId);
                entity.HasOne(c => c.Sys).WithOne(b => b.BaseWeatherEntity).HasForeignKey<SysEntity>(f => f.BaseWeatherEntityId);
                entity.HasOne(c => c.Rain).WithOne(b => b.BaseWeatherEntity).HasForeignKey<RainEntity>(f => f.BaseWeatherEntityId);
                entity.HasOne(c => c.Wind).WithOne(b => b.BaseWeatherEntity).HasForeignKey<WindEntity>(f => f.BaseWeatherEntityId);


            });

            modelBuilder.Entity<WeatherEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SysEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedNever();
            });



           base.OnModelCreating(modelBuilder);
        }


        public DbSet<BaseWeatherEntity> BaseWeather { get; set; }
        public DbSet<CloudsEntity> Clouds { get; set; }
        public DbSet<CoordEntity> Coord { get; set; }
        public DbSet<MainEntity> Main { get; set; }
        public DbSet<RainEntity> Rain { get; set; }
        public DbSet<SysEntity> Sys { get; set; }
        public DbSet<WeatherEntity> Weather { get; set; }
        public DbSet<WindEntity> Wind { get; set; }
    }




}
