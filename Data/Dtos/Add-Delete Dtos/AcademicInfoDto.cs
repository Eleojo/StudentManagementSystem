using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class AcademicInfoDto
    {
        //public Guid Id { get; set; }

        //[Required(ErrorMessage = "Enrollment date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "Course name must be at most 50 characters")]
        public string Course { get; set; }

        public string YearOfStudy { get; set; }
        public double GPA { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string EnrollmentStatus { get; set; }
    }

}
