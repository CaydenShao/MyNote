using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.Bases
{
    public class TokenRequired : RequestBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户令牌
        /// </summary>
        public string Token { get; set; }
    }
}
