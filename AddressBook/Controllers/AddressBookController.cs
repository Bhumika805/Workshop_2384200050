using AutoMapper;
using FluentValidation;
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
        private readonly IMapper _mapper;
        private readonly IValidator<AddressBookRequestDTO> _validator;

<<<<<<< HEAD
        [HttpGet("GetMethod")]
        public ActionResult<List<AddressBookEntity>> GetAllContacts()
=======
        public AddressBookController(IMapper mapper, IValidator<AddressBookRequestDTO> validator)
>>>>>>> Section2_UC1
        {
            _mapper = mapper;
            _validator = validator;
        }

<<<<<<< HEAD
        [HttpGet("Getbyid{id}")]
        public ActionResult<AddressBookEntity> GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.AddressBookEntityId == id);
=======
        [HttpGet("GetMethod")]
        public ActionResult<List<AddressBookEntity>> GetAllContacts()
        {
            var contactDtos = _mapper.Map<IEnumerable<AddressBookEntry>>(_contacts);
            return Ok(new ResponseBody<IEnumerable<AddressBookEntry>>
            {
                Success = true,
                Message = "Contacts retrieved successfully",
                Data = contactDtos
            });
        }

        [HttpGet("Getbyid/{id}")]
        public ActionResult<ResponseBody<AddressBookEntry>> GetContactById(int id)
        {
            var contact = _contacts.Find(c => c.AddressBookEntityId == id);
>>>>>>> Section2_UC1
            if (contact == null)
                return NotFound(new { Message = "Contact not found" });

            var response = _mapper.Map<AddressBookEntry>(contact);
            return Ok(new ResponseBody<AddressBookEntry>
            {
                Success = true,
                Message = "Contact retrieved successfully",
                Data = response
            });
        }

        [HttpPost("PostMethod")]
<<<<<<< HEAD
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
=======
        public ActionResult<ResponseBody<AddressBookEntry>> AddContact([FromBody] AddressBookRequestDTO request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseBody<AddressBookEntry>
                {
                    Success = false,
                    Message = "Validation failed",
                    Data = null
                });

            var newContact = _mapper.Map<AddressBookEntity>(request);
            newContact.AddressBookEntityId = _idCounter++;

            _contacts.Add(newContact);

            var response = _mapper.Map<AddressBookEntry>(newContact);
            return CreatedAtAction(nameof(GetContactById), new { id = newContact.AddressBookEntityId }, new ResponseBody<AddressBookEntry>
            {
                Success = true,
                Message = "Contact added successfully",
                Data = response
            });
        }

        [HttpPut("Putbyid/{id}")]
        public ActionResult<ResponseBody<AddressBookEntry>> UpdateContact(int id, [FromBody] AddressBookRequestDTO request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseBody<AddressBookEntry>
                {
                    Success = false,
                    Message = "Validation failed"
                });

            var contact = _contacts.Find(c => c.AddressBookEntityId == id);
>>>>>>> Section2_UC1
            if (contact == null)
                return NotFound(new ResponseBody<AddressBookEntry>
                {
                    Success = false,
                    Message = $"Contact with ID {id} not found"
                });

            _mapper.Map(request, contact);
            var response = _mapper.Map<AddressBookEntry>(contact);

            return Ok(new ResponseBody<AddressBookEntry>
            {
                Success = true,
                Message = "Contact updated successfully",
                Data = response
            });
        }

        [HttpDelete("Deletebyid/{id}")]
        public ActionResult<ResponseBody<string>> DeleteContact(int id)
        {
<<<<<<< HEAD
            var contact = _contacts.FirstOrDefault(c => c.AddressBookEntityId == id);
=======
            var contact = _contacts.Find(c => c.AddressBookEntityId == id);
>>>>>>> Section2_UC1
            if (contact == null)
                return NotFound(new ResponseBody<string>
                {
                    Success = false,
                    Message = $"Contact with ID {id} not found"
                });

            _contacts.Remove(contact);
            return Ok(new ResponseBody<string>
            {
                Success = true,
                Message = "Contact deleted successfully",
                Data = $"Deleted contact ID: {id}"
            });
        }
    }
}
