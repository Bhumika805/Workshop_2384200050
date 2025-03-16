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
        IEnumerable<ModelLayer.Model.AddressBookEntry> GetAllContacts();
        ModelLayer.Model.AddressBookEntry GetContactById(int id);
        ModelLayer.Model.AddressBookEntry AddContact(AddressBookRequestDTO contact);
        ModelLayer.Model.AddressBookEntry UpdateContact(int id, AddressBookRequestDTO contact);
        bool DeleteContact(int id);
    }
}
