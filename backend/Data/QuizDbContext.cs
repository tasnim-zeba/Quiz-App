using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizAttempt>()
                .HasOne(q => q.Quiz)
                .WithMany()
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade); // Keep cascade delete for Quiz

            modelBuilder.Entity<QuizAttempt>()
                .HasOne(q => q.Student)
                .WithMany()
                .HasForeignKey(q => q.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete on Student

            modelBuilder.Entity<Question>()
        .HasOne(q => q.CorrectOption)
        .WithMany()
        .HasForeignKey(q => q.CorrectOptionId)
        .OnDelete(DeleteBehavior.NoAction); // Fix cycle issue

    modelBuilder.Entity<Option>()
        .HasOne(o => o.Question)
        .WithMany(q => q.Options)
        .HasForeignKey(o => o.QuestionId)
        .OnDelete(DeleteBehavior.Cascade);
        }

    }
}