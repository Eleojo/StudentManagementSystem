using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
        public class ContactInfo
        {
            [Key]
            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

            public Guid Id { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            public string PhoneNumber { get; set; }

            [StringLength(100)]
            public string Address { get; set; }
        }

}
