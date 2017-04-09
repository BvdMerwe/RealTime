using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTime.Models {
    public class Question {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionContent { get;set; }
        public QuestionType QuestionType { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}