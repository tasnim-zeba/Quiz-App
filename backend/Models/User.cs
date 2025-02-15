using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class User
    {
        [Key] // Primary Key
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public int Role { get; set; } // Teacher or Student

        // Relationships
        public ICollection<Quiz> CreatedQuizzes { get; set; }
        public ICollection<QuizAttempt> QuizAttempts { get; set; }
    }

}