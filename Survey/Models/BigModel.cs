using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    public class BigModel
    {
        public AllSurvey AllSurvey { get; set; }
        public Question Question { get; set; }
        public QuestionAnswer QuestionAnswer { get; set; }
    }
}