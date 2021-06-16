using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class ODataResponse<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
