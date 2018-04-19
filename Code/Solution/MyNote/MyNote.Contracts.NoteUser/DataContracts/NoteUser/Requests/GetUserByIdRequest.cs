using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.NoteUser.Requests
{
    public class GetUserByIdRequest
    {
        public int UserId { get; set; }
    }
}
