using AutoMapper;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<AddressBookRequestDTO> GetAllContacts()
        {
            var contacts = _addressBookRL.GetAllContacts();

            return _mapper.Map<IEnumerable<AddressBookRequestDTO>>(contacts);
        }

        public AddressBookRequestDTO GetContactById(int id)
        {
            var contact = _addressBookRL.GetContactById(id);
            return contact == null ? null : _mapper.Map<AddressBookRequestDTO>(contact);
        }

        public AddressBookRequestDTO AddContact(ModelLayer.Model.AddressBookEntry contact)
        {
            //var entity = _mapper.Map<AddressBookEntry>(contact);
            // Map RequestAddressBook to AddressBookEntry
            var entity = _mapper.Map<RepositoryLayer.Entity.AddressBookEntity>(contact);
            var newContact = _addressBookRL.AddContact(entity);
            return _mapper.Map<AddressBookRequestDTO>(newContact);
        }

        public AddressBookRequestDTO UpdateContact(int id, ModelLayer.Model.AddressBookEntry contact)
        {
            var entity = _mapper.Map<RepositoryLayer.Entity.AddressBookEntity>(contact);  
            var updatedContact = _addressBookRL.UpdateContact(id, entity); 

            return updatedContact == null ? null : _mapper.Map<AddressBookRequestDTO>(updatedContact);
        }

        public bool DeleteContact(int id)
        {
            return _addressBookRL.DeleteContact(id);
        }
    }

}
