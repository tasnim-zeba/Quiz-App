using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public int CreatedBy { get; set; } // Foreign Key

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("CreatedBy")]
        public User Teacher { get; set; }
    }
}