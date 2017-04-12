using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTime.Models {
    public class Setlist {
        public Setlist() {
            Questions = new List<Question>();
            DateCreated = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}