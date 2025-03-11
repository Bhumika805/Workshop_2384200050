using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class AddressBookEntry
    {
        [Key]  //  Ensure AddressBookEntryId is a primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressBookEntryId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Foreign key
        public int UserId { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public UserContactBook UserContactBooks { get; set; }
    }
}
