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
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }

        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Quiz (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedQuizzes) // ✅ FIXED: Use 'CreatedQuizzes' instead of 'Quizzes'
                .WithOne(q => q.Creator)
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);

            // Quiz -> Questions (One-to-Many)
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // Question -> CorrectAnswer (Required)
            modelBuilder.Entity<Question>()
                .Property(q => q.CorrectAnswer)
                .IsRequired();

            // QuizAttempt -> Quiz (Many-to-One)
            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Quiz)
                .WithMany() // No navigation property in Quiz
                .HasForeignKey(qa => qa.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // QuizAttempt -> Student (Many-to-One)
            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Student)
                .WithMany(u => u.QuizAttempts)
                .HasForeignKey(qa => qa.StudentId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete to keep student data
        }

    }

}