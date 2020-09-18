using Microsoft.EntityFrameworkCore;
using SimpleNotes.DAL.Models;
using System;

namespace SimpleNotes.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Note>(note => note.HasKey(n => n.Id));

            builder.Entity<Note>().HasData(new Note[]
            {
                new Note() { Date = DateTime.Now, Text = "First initial Note", Id=1},
                new Note() { Date = DateTime.Now, Text = "Second initial Note", Id=2 },
                new Note() { Date = DateTime.Now, Text = "Third initial Note", Id=3 }
            });

        }


    }
}
