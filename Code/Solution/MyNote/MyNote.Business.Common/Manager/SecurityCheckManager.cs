using MyNote.Business.Common.Bases;
using MyNote.Business.Common.Business;
using MyNote.Business.Common.Extensions;
using MyNote.Business.Common.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Common.Models;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.NoteUser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common.Manager
{
    public class SecurityCheckManager : ManagerBase, ISecurityCheckManager
    {
        #region Constructors

        public SecurityCheckManager(string version) 
            : base(version)
        { }

        #endregion

        #region Public methods

        public ManagerResult<bool> CheckToken(int id, string token)
        {
            ISecurityCheckManager business = SecurityCheckBusinessFactory.Instance.Create(this.Version);
            return business.CheckToken(id, token);
        }

        public ManagerResult<bool> CheckSignature(string signature, string timestamp, string nonce, string appId)
        {
            ISecurityCheckManager business = SecurityCheckBusinessFactory.Instance.Create(this.Version);
            return business.CheckSignature(signature, timestamp, nonce, appId);
        }

        #endregion
    }
}
