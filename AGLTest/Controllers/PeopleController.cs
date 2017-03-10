using AGLTest.Configuration;
using AGLTest.Configuration.Interfaces;
using AGLTest.Models;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AGLTest.Controllers
{
    public class PeopleController : Controller
    {
        protected IApplicationConfiguration _configuration;

        public PeopleController()
        {
            _configuration = new ApplicationConfiguration();
        }

        public async Task<ActionResult> GetCats()
        {
            var responseContent = "";
            List<GroupedPeopleModel> groupedPeople = new List<GroupedPeopleModel>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.JsonWebServiceBaseUrl);

            var response = client.GetAsync(_configuration.JsonWebServiceRequestUri).Result;

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                var people = JsonConvert.DeserializeObject<List<PeopleModel>>(responseContent).Where(p => (p.Pets != null && p.Pets.Any(c => c.Type == "Cat")));
                people.ToList().ForEach(x => x.Pets.RemoveAll(c => c.Type != "Cat"));

                groupedPeople = people
                .GroupBy(a => a.Gender)
                .Select(
                    x => new GroupedPeopleModel
                    {
                        Gender = x.Key,
                        Cats = x.SelectMany(c => c.Pets).OrderBy(p => p.Name).ToList()
                    })
                .ToList();
            }
            return View(groupedPeople);
        }        
    }
}