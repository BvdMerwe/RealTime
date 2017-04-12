using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RealTime.Models;

namespace RealTime.Models.ViewModels
{
    public class AddSetlistViewModel
    {
        public AddSetlistViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Theme { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}