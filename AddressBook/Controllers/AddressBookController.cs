using AutoMapper;
using BusinessLayer.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("api/addressbook")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookBL _addressBookBL;
        private readonly IValidator<AddressBookRequestDTO> _validator;

        public AddressBookController(IAddressBookBL addressBookBL, IValidator<AddressBookRequestDTO> validator)
        {
            _addressBookBL = addressBookBL;
            _validator = validator;
        }

        // GET: Fetch all contacts
        [HttpGet]
        public ActionResult<ResponseBody<IEnumerable<AddressBookEntry>>> GetAllContacts()
        {
            var contacts = _addressBookBL.GetAllContacts();
            return Ok(new ResponseBody<IEnumerable<AddressBookEntry>>
            {
                Success = true,
                Message = "Contacts retrieved successfully.",
                Data = contacts
            });
        }

        // GET: Fetch contact by ID
        [HttpGet("get/{id}")]
        public ActionResult<ResponseBody<AddressBookEntry>> GetContactById(int id)
        {
            var contact = _addressBookBL.GetContactById(id);
            if (contact == null)
            {
                return NotFound(new ResponseBody<AddressBookEntry>
                {
                    Success = false,
                    Message = $"Contact with ID {id} not found.",
                    Data = null
                });
            }

            return Ok(new ResponseBody<AddressBookEntry>
            {
                Success = true,
                Message = "Contact retrieved successfully.",
                Data = contact
            });
        }

        // POST: Add new contact
        [HttpPost("add")]
        public ActionResult<ResponseBody<AddressBookEntry>> AddContact([FromBody] AddressBookRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseBody<object>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Data = validationResult.Errors.Select(e => e.ErrorMessage)
                });
            }

            var newContact = _addressBookBL.AddContact(dto);
            return CreatedAtAction(nameof(GetContactById), new { id = newContact.Id }, new ResponseBody<AddressBookEntry>
            {
                Success = true,
                Message = "Contact added successfully.",
                Data = newContact
            });
        }

        // PUT: Update contact
        [HttpPut("update/{id}")]
        public ActionResult<ResponseBody<AddressBookEntry>> UpdateContact(int id, [FromBody] AddressBookRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseBody<object>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Data = validationResult.Errors.Select(e => e.ErrorMessage)
                });
            }

            var updatedContact = _addressBookBL.UpdateContact(id, dto);
            if (updatedContact == null)
            {
                return NotFound(new ResponseBody<AddressBookEntry>
                {
                    Success = false,
                    Message = $"Contact with ID {id} not found.",
                    Data = null
                });
            }

            return Ok(new ResponseBody<AddressBookEntry>
            {
                Success = true,
                Message = "Contact updated successfully.",
                Data = updatedContact
            });
        }

        // DELETE: Delete contact
        [HttpDelete("delete/{id}")]
        public ActionResult<ResponseBody<string>> DeleteContact(int id)
        {
            var isDeleted = _addressBookBL.DeleteContact(id);
            if (!isDeleted)
            {
                return NotFound(new ResponseBody<string>
                {
                    Success = false,
                    Message = $"Contact with ID {id} not found.",
                    Data = null
                });
            }

            return Ok(new ResponseBody<string>
            {
                Success = true,
                Message = "Contact deleted successfully.",
                Data = "Deleted"
            });
        }
    }
}