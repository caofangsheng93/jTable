using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jTable.Entities
{
    public class Mark
    {
        [Key]
        public string ID { get; set; }

         [Required]
        public int RollNumber { get; set; }

         [Required]
        public string Name { get; set; }

        [Required]
        public string MarksObtained { get; set; }
        [Required]
        public string TotalMarks { get; set; }  
    }
}