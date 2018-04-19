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
    public interface INoteUserServices
    {
        Response<User> GetUserById(TokenRequest<GetUserByIdRequest> request);

        Response<User> GetUserByAccount(TokenRequest<GetUserByPhoneNumberRequest> request);

        Response<User> GetUserByToken(TokenRequest<GetUserByTokenRequest> request);

        Response<User> Login(SignedRequest<LoginRequest> request);

        Response<User> Register(SignedRequest<RegisterRequest> request);

        Response<bool> CheckPhoneNumberRegistered(SignedRequest<CheckPhoneNumberRegisteredRequest> request);
    }
}
