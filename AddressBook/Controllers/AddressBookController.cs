using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private static List<AddressBookEntity> _contacts = new List<AddressBookEntity>();
        private static int _idCounter = 1;

        [HttpGet("GetMethod")]
        public ActionResult<List<AddressBookEntity>> GetAllContacts()
        {
            return Ok(_contacts);
        }

        [HttpGet("Getbyid{id}")]
        public ActionResult<AddressBookEntity> GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.AddressBookEntityId == id);
            if (contact == null)
                return NotFound(new { Message = "Contact not found" });

            return Ok(contact);
        }

        [HttpPost("PostMethod")]
        public ActionResult<AddressBookEntity> AddContact([FromBody] AddressBookRequestDTO request)
        {
            var newContact = new AddressBookEntity
            {
                AddressBookEntityId = _idCounter++,
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            _contacts.Add(newContact);
            return CreatedAtAction(nameof(GetContactById), new { id = newContact.AddressBookEntityId }, newContact);
        }

        [HttpPut("Putbyid{id}")]
        public ActionResult<AddressBookEntity> UpdateContact(int id, [FromBody] AddressBookRequestDTO request)
        {
            var contact = _contacts.FirstOrDefault(c => c.AddressBookEntityId == id);
            if (contact == null)
                return NotFound(new { Message = "Contact not found" });

            contact.Name = request.Name;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;
            contact.Address = request.Address;

            return Ok(contact);
        }

        [HttpDelete("Deletebyid{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.AddressBookEntityId == id);
            if (contact == null)
                return NotFound(new { Message = "Contact not found" });

            _contacts.Remove(contact);
            return NoContent();
        }
    }
}
