using Eticaret.Core.Entities.Concrete;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
   

    public class WebDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=94.73.170.2; Initial Catalog=u9888118_radyogr; User Id=u9888118_radyogr;Password=RTfr49U3KNrw41A;  Integrated Security=True; Persist Security Info=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsRadio>()
                    .HasKey(c => new { c.radioApiId, c.newsId });

            modelBuilder.Entity<DjRadio>()
                  .HasKey(c => new { c.radioApiId, c.djId });
        }

     
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<RadioApi> RadioApi { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<RadioCategory> RadioCategories { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Broadcast> Broadcasts { get; set; }
        public DbSet<Dj> Djs { get; set; }
        public DbSet<Frequency> Frequencys { get; set; }
        public DbSet<MusicList> MusicLists { get; set; }
        public DbSet<PodcastMusicList> PodcastMusicLists { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<TopMusicList> TopMusicLists { get; set; }
        public DbSet<Seo> Seos { get; set; }

        public DbSet<Page> Page { get; set; }

        public DbSet<RoleClaims> AspNetRoleClaims { get; set; }


        public DbSet<Bildir> Bildirler { get; set; }

    }
}
