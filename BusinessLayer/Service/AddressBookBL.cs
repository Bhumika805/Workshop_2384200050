using AutoMapper;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        private readonly IAddressBookRL _addressBookRL;
        private readonly IMapper _mapper;

        public AddressBookBL(IAddressBookRL addressBookRL, IMapper mapper)
        {
            _addressBookRL = addressBookRL;
            _mapper = mapper;
        }

        public IEnumerable<ModelLayer.Model.AddressBookEntry> GetAllContacts()
        {
            try
            {
                var contacts = _addressBookRL.GetAllContacts();
                return _mapper.Map<IEnumerable<ModelLayer.Model.AddressBookEntry>>(contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllContacts: {ex.Message}");
                return null;
            }
        }

        public ModelLayer.Model.AddressBookEntry GetContactById(int id)
        {
            try
            {
                var contact = _addressBookRL.GetContactById(id);
                return contact == null ? null : _mapper.Map<ModelLayer.Model.AddressBookEntry>(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetContactById: {ex.Message}");
                return null;
            }
        }

        public ModelLayer.Model.AddressBookEntry AddContact(AddressBookRequestDTO contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact), "Contact data cannot be null.");
            }

            try
            {
                var entity = _mapper.Map<RepositoryLayer.Entity.AddressBookEntity>(contact);
                var newContact = _addressBookRL.AddContact(entity);
                return _mapper.Map<ModelLayer.Model.AddressBookEntry>(newContact);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddContact: {ex.Message}");
                return null;
            }
        }

        public ModelLayer.Model.AddressBookEntry UpdateContact(int id, AddressBookRequestDTO contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact), "Contact data cannot be null.");
            }

            try
            {
                var entity = _mapper.Map<RepositoryLayer.Entity.AddressBookEntity>(contact);
                var updatedContact = _addressBookRL.UpdateContact(id, entity);
                return updatedContact == null ? null : _mapper.Map<ModelLayer.Model.AddressBookEntry>(updatedContact);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateContact: {ex.Message}");
                return null;
            }
        }

        public bool DeleteContact(int id)
        {
            try
            {
                return _addressBookRL.DeleteContact(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteContact: {ex.Message}");
                return false;
            }
        }
    }
}
