using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Update_Dtos
{
    public class UpdateAcademicInfoDto
    {
        public string Course { get; set; }
        public string YearOfStudy { get; set; }
        public double? GPA { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
    }

}
