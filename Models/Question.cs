using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTime.Models {
    public class Question {
        public Question() {
            Answers = new List<Answer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get;set; }
        public QuestionType QuestionType { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual Setlist Setlist { get; set; }
    }
}