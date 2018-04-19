using MyNote.Contracts.DataContracts.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common.Interface
{
    public interface ISecurityCheckManager
    {
        ManagerResult<bool> CheckToken(int id, string token);

        ManagerResult<bool> CheckSignature(string signature, string timestamp, string nonce, string appId);
    }
}
