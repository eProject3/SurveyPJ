using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    [Table("Question_answers")]
    public class QuestionAnswer
    {
        [Required]
        [Key]
        public int QuestionAnswerId { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public string Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


        public virtual ICollection<AccountAnswer> AccountAnswers { get; set; }
       
    }
}