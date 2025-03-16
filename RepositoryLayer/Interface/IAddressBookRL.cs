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
        IEnumerable<Entity.AddressBookEntity> GetAllContacts();
        Entity.AddressBookEntity GetContactById(int id);
        Entity.AddressBookEntity AddContact(Entity.AddressBookEntity contact);
        Entity.AddressBookEntity UpdateContact(int id, Entity.AddressBookEntity contact);
        bool DeleteContact(int id);
    }
}
