using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHIS.API.Helpers
{
    internal class ODataResponse<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
