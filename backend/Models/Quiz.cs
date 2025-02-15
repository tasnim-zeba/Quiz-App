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
        [Key] // Primary Key
        public int QuizId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public int CreatedBy { get; set; }  // Foreign Key

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        // Foreign Key Relationship
        [ForeignKey("CreatedBy")]
        public User Creator { get; set; }

        public ICollection<Question> Questions { get; set; }
    }

}