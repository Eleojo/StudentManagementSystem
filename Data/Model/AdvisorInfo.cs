using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{ 
    public class AdvisorInfo
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        [StringLength(50)]
        public string AdvisorFirstName { get; set; }
        [StringLength(50)]
        public string AdvisorLastName { get; set; }
    }

}
