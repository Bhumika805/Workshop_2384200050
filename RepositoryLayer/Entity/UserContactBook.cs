using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Model
{
    public class UserContactBook
    {
        [Key] //  Ensures UserId is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Optional: Auto-increment
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Navigation property for AddressBookEntries
        public ICollection<AddressBookEntry> AddressBookEntries { get; set; }
    }
}
