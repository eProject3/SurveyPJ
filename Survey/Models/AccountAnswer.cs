﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    [Table("Account_answers")]
    public class AccountAnswer
    {
        [Required]
        [Key]
        public int AccountAnswerId { get; set; }
        [ForeignKey("Survey")]
        [Required]
        public int SurveyId { get; set; }
        public virtual AllSurvey Survey { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public int QuestionAnswerId { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public int Status { get; set; }
        [Required]
        public int Description { get; set; }
    }
}