using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTime.Models {
    public class Answer {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        public bool Correct { get; set; }
        public virtual Question Question { get; set; }
    }
}