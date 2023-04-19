
using System.Text.Json.Serialization;

namespace Chapter10.HttpModel.Exercise1
{
    public class AddDetailsRequestModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
