using System;
using System.Collections.Generic;
using RealTime.Models;

namespace RealTime.Models.ViewModels
{
    public class SetlistsViewModel
    {
        public SetlistsViewModel()
        {
            Setlists = new List<Setlist>();
        }
        public List<Setlist> Setlists { get; set; }
    }
}