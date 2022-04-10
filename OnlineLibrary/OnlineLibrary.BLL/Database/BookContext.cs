﻿using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Models;

namespace OnlineLibraryASP
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            
        }
        public DbSet<Book>Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder
                .UseSqlServer("Server=DESKTOP-C21RB03;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(m => m.Author)
                .WithMany()
                .HasForeignKey("AuthorId");

            modelBuilder.Entity<Author>()
                .HasMany(b => b.BooksWriten)
                .WithOne(m => m.Author)
                .HasForeignKey(m=>m.AuthorId);
                
            

          
            
        }
    }
}
