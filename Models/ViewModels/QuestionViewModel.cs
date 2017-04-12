using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealTime.Models.ViewModels {
    public class QuestionViewModel {
        public QuestionViewModel() {
            Answers = new List<AnswerViewModel>();
        }
        [Required]
        public string QuestionContent { get; set; }
        [Required]
        public QuestionTypeViewModel Type { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}