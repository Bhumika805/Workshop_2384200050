using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAddressBookRL
    {
        IEnumerable<AddressBookRequestDTO> GetAllContacts();
        AddressBookRequestDTO GetContactById(int id);
        AddressBookRequestDTO AddContact(Entity.AddressBookEntity contact);
        AddressBookRequestDTO UpdateContact(int id, Entity.AddressBookEntity contact);
        bool DeleteContact(int id);
    }
}
