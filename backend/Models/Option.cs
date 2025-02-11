using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{

    public class Option
    {
        [Key]
        public int OptionId { get; set; }

        [Required]
        public int QuestionId { get; set; } // Foreign Key

        [Required]
        public string OptionText { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }

}