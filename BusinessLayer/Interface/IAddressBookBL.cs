using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        IEnumerable<AddressBookResponseDTO> GetAllContacts();
        AddressBookResponseDTO GetContactById(int id);
        AddressBookResponseDTO AddContact(ModelLayer.Model.AddressBookEntry contact);
        AddressBookResponseDTO UpdateContact(int id, ModelLayer.Model.AddressBookEntry contact);
        bool DeleteContact(int id);
    }
}
