using System;
using Newtonsoft.Json;

using MobileTemplateCSharp.Core.Enums;

namespace MobileTemplateCSharp.Core.Models.Rest {
    public class ResponseModel {
        [JsonProperty("Result")]
        public ResponseType Result { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
