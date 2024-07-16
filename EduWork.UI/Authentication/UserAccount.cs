using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Text.Json.Serialization;

namespace EduWork.UI.Authentication
{
    public class UserAccount : RemoteUserAccount
    {
        [JsonPropertyName("roles")]
        public List<string>? Roles { get; set; }

        [JsonPropertyName("wids")]
        public List<string>? Wids { get; set; }

        [JsonPropertyName("oid")]
        public string? Oid { get; set; }
    }
}
