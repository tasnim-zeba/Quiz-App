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
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public int QuizId { get; set; } // Foreign Key

        [Required]
        public string QuestionText { get; set; }

        public int CorrectOptionId { get; set; } // Foreign Key

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [ForeignKey("CorrectOptionId")]
        public Option CorrectOption { get; set; }
        public ICollection<Option> Options { get; set; }
    }

}