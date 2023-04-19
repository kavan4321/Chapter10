﻿
using Newtonsoft.Json;

namespace Chapter10.HttpModel.Exercise1
{
    public class AddDetailsResponceModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
