using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.MAUIData.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public int? Value { get; set; }

        public string? Comment { get; set; }

        public DateTime? Date { get; set; }
    }
}
