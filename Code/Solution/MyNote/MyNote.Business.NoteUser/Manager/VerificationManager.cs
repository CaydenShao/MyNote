using MyNote.Business.Common;
using MyNote.Business.Common.Bases;
using MyNote.Business.Common.Extensions;
using MyNote.Business.NoteUser.Business;
using MyNote.Business.NoteUser.Interface;
using MyNote.Common.Containers;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.NoteUser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.NoteUser.Manager
{
    public class VerificationManager : ManagerBase, IVerificationManager
    {
        #region Constructors

        public VerificationManager(string version)
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<Verification> GetVerificationById(int id)
        {
            IVerificationManager business = VerificationBisinessFactory.Instance.Create(this.Version);
            return business.GetVerificationById(id);
        }

        public ManagerResult<Verification> GetVerificationByPhoneNumber(string phoneNumber)
        {
            IVerificationManager business = VerificationBisinessFactory.Instance.Create(this.Version);
            return business.GetVerificationByPhoneNumber(phoneNumber);
        }

        public ManagerResult<Verification> AddVerification(Verification verification)
        {
            IVerificationManager business = VerificationBisinessFactory.Instance.Create(this.Version);
            return business.AddVerification(verification);
        }

        public ManagerResult<Verification> GenerateVerification(string phoneNumber)
        {
            IVerificationManager business = VerificationBisinessFactory.Instance.Create(this.Version);
            return business.GenerateVerification(phoneNumber);
        }

        public ManagerResult<bool> CheckVerification(string phoneNumber, string code)
        {
            IVerificationManager business = VerificationBisinessFactory.Instance.Create(this.Version);
            return business.CheckVerification(phoneNumber, code);
        }

        #endregion
    }
}
