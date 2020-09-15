using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace diaryAPI.Model
{
    public partial class diaryContext : DbContext
    {
        public diaryContext()
        {
        }

        public diaryContext(DbContextOptions<diaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diary> Diary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:dwondiary.database.windows.net,1433;Initial Catalog=Diary;Persist Security Info=False;User ID=dwon782;Password=dwonDiary20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.Entry).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
