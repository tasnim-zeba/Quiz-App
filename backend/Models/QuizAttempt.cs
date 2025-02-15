using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class QuizAttempt
    {
        [Key] // Primary Key
        public int AttemptId { get; set; }

        [Required]
        public int QuizId { get; set; }  // Foreign Key

        [Required]
        public int StudentId { get; set; }  // Foreign Key

        [Required]
        public int Score { get; set; }

        public DateTime AttemptDate { get; set; } = DateTime.UtcNow;

        // Foreign Key Relationships
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }
    }

}