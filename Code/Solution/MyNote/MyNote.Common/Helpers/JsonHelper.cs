using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Helpers
{
    public static class JsonHelper
    {
        public static string Serialized(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
