using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class AdvisorInfoDto
    {
        //public Guid Id { get; set; }

        [StringLength(50, ErrorMessage = "First name must be at most 50 characters")]
        public string AdvisorFirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name must be at most 50 characters")]
        public string AdvisorLastName { get; set; }
    }

}
