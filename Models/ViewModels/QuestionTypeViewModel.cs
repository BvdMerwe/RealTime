using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealTime.Models.ViewModels {
    public class QuestionTypeViewModel {
        [Required]
        public int Id { get; set; }
    }
}