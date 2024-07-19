using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{


    public class AcademicInfo
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(50)]
        public string Course { get; set; }

        public string YearOfStudy { get; set; }
        public double GPA { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string EnrollmentStatus { get; set; }
    }

}
