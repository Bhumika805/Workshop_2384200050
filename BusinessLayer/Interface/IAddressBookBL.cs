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
        IEnumerable<AddressBookEntry> GetAllContacts();
        AddressBookEntry GetContactById(int id);
        AddressBookEntry AddContact(AddressBookRequestDTO contact);
        AddressBookEntry UpdateContact(int id, AddressBookRequestDTO contact);
        bool DeleteContact(int id);
    }
}
