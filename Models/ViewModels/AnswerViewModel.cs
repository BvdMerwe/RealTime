using System.ComponentModel.DataAnnotations;

namespace RealTime.Models.ViewModels
{
    public class AnswerViewModel
    {
        [Required]
        public string AnswerContent { get; set; }
        public bool Correct { get; set; }
    }
}