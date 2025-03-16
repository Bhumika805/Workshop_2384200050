using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        UserContactBook? GetUserByEmail(string email);
        void AddUser(UserContactBook user);

        void UpdateUser(UserContactBook user);
    }
}
