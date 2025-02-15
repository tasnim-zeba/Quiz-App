using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Question
    {
        [Key] // Primary Key
        public int QuestionId { get; set; }

        [Required]
        public int QuizId { get; set; }  // Foreign Key

        [Required]
        public string QuestionText { get; set; }

        // Storing Options Inside
        [Required]
        public string QuestionOption1 { get; set; }

        [Required]
        public string QuestionOption2 { get; set; }

        [Required]
        public string QuestionOption3 { get; set; }

        [Required]
        public string QuestionOption4 { get; set; }

        [Required]
        public int CorrectAnswer { get; set; } // 1, 2, 3, or 4 (Index of correct option)

        // Foreign Key Relationship
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
    }
}