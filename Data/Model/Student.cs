using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Model
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public Guid ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public Guid AcademicInfoId { get; set; }
        public AcademicInfo AcademicInfo { get; set; }

        public Guid AdvisorInfoId { get; set; }
        public AdvisorInfo AdvisorInfo { get; set; }

        public DateTime LastUpdated { get; set; }
    }

}
