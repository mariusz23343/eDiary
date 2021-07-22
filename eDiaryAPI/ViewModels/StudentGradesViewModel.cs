using eDiaryAPI.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.ViewModels
{
    public class StudentGradesViewModel
    {
        public List<Grade> grades { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
