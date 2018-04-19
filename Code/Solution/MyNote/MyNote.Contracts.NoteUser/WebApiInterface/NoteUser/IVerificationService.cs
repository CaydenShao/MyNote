using MyNote.Contracts.Bases;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.Contracts.DataContracts.NoteUser.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.WebApiInterface.NoteUser
{
    public interface IVerificationService
    {
        Response<Verification> GetVerificationById(SignedRequest<GetVerificationByIdRequest> request);

        Response<Verification> GetVerificationByPhoneNumber(SignedRequest<GetVerificationByPhoneNumberRequest> request);

        Response<Verification> AddVerification(SignedRequest<Verification> request);

        Response<bool> GenerateVerification(SignedRequest<GenerateVerificationRequest> request);

        Response<bool> CheckVerification(SignedRequest<CheckVerificationRequest> request);
    }
}
