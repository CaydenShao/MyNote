using MyNote.Contracts.DataContracts.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteWinFormApp
{
    public static class SysConfigInfo
    {
        public static string WebServerBaseAddr { get; set; }

        public static User OnlineUser { get; set; }

        public static string Version { get; set; }
    }
}
