using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.NoteUser.Interface
{
    public interface INoteUserManager
    {
        ManagerResult<User> GetUserById(int id);

        ManagerResult<User> GetUserByPhoneNumber(string phoneNumber);

        ManagerResult<User> GetUserByToken(string account);

        ManagerResult<User> GetUserByIdAndToken(int id, string token);

        ManagerResult<User> Register(User user, string pwdHashStr);

        ManagerResult<User> Login(string account, string password);

        ManagerResult<bool> CheckPhoneNumberRegistered(string phoneNumber);
    }
}
