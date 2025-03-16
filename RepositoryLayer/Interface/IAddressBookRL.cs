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
        IEnumerable<AddressBookResponseDTO> GetAllContacts();
        AddressBookResponseDTO GetContactById(int id);
        AddressBookResponseDTO AddContact(Entity.AddressBookEntity contact);
        AddressBookResponseDTO UpdateContact(int id, Entity.AddressBookEntity contact);
        bool DeleteContact(int id);
    }
}
