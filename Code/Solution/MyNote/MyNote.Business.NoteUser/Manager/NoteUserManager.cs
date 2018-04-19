using MyNote.Business.Common;
using MyNote.Business.Common.Extensions;
using MyNote.Business.NoteUser.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.NoteUser.DAL;
using MyNote.DataAccess.NoteUser.Extensions;
using MyNote.DataAccess.NoteUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNote.Business.Common.Bases;
using MyNote.Business.NoteUser.Business;

namespace MyNote.Business.NoteUser.Manager
{
    public class NoteUserManager : ManagerBase, INoteUserManager
    {
        #region Constructors

        public NoteUserManager(string version)
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<User> GetUserById(int id)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.GetUserById(id);
        }

        public ManagerResult<User> GetUserByPhoneNumber(string phoneNumber)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.GetUserByPhoneNumber(phoneNumber);
        }

        public ManagerResult<User> GetUserByToken(string token)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.GetUserByToken(token);
        }

        public ManagerResult<User> GetUserByIdAndToken(int id, string token)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.GetUserByIdAndToken(id, token);
        }

        public ManagerResult<User> Register(User user, string pwdHashStr)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.Register(user, pwdHashStr);
        }

        public ManagerResult<User> Login(string phoneNumber, string password)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.Login(phoneNumber, password);
        }

        public ManagerResult<bool> CheckPhoneNumberRegistered(string phoneNumber)
        {
            INoteUserManager business = NoteUserBusinessFactory.Instance.Create(this.Version);
            return business.CheckPhoneNumberRegistered(phoneNumber);
        }

        #endregion
    }
}
