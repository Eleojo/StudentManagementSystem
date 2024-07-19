using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public ContactInfoDto ContactInfo { get; set; }
        public AcademicInfoDto AcademicInfo { get; set; }
        public AdvisorInfoDto AdvisorInfo { get; set; }
    }

}
