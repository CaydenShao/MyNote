using MyNote.Business.Common;
using MyNote.Business.Common.Bases;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.WebApi.Common.Extensions
{
    public static class ResponseExtensions
    {
        public static void GetResultInfo(this ResponseBase response, ResultBase result)
        {
            response.Code = result.Code;
            response.Description = result.Description;
        }
    }
}
