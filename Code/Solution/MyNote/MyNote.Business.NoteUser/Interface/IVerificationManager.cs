using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.NoteUser.Interface
{
    public interface IVerificationManager
    {
        ManagerResult<Verification> GetVerificationById(int id);

        ManagerResult<Verification> GetVerificationByPhoneNumber(string phoneNumber);

        ManagerResult<Verification> AddVerification(Verification verification);

        ManagerResult<Verification> GenerateVerification(string phoneNumber);

        ManagerResult<bool> CheckVerification(string phoneNumber, string code);
    }
}
