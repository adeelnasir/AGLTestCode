using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace AGLTest.Models
{
    public class PeopleModel
    {
        public PeopleModel()
        {
            Pets = new List<PetModel>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("pets")]
        public List<PetModel> Pets { get; set; }
    }
    public class GroupedPeopleModel
    {   
        public string Gender { get; set; }
        public List<PetModel> Cats { get; set; }
    }
}