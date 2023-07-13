using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public sealed class BoredAPIStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        public BoardAPI _boardAPI;
        public bool ResponseCode;
        public string Key;
        public string responseBody;
        public BoredAPIStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        static readonly HttpClient client = new HttpClient();

        [Given(@"I have the (.*) activity to be provided to (.*)")]
        public void GivenIHaveTheSocialActivityToBeProvidedTo(string ActivityType, int CountofPeople)
        {
            Console.WriteLine("This is a " + ActivityType + "activity for" + CountofPeople + "people.");
        }

        [Given(@"the name of the (.*) based on (.*)")]
        public void GivenTheNameOfTheTextAFriendYouHavenTTalkedToInALongTimeBasedOn(string Activitiy, string UniqueKey)
        {
            Key = UniqueKey;
            Console.WriteLine("This Activity: " + Activitiy + "is unique with key =" + UniqueKey);
        }

        [When(@"the Activities are created")]
        public async System.Threading.Tasks.Task WhenTheActivitiesAreCreated()
        {
            try
            {
                string endPoint = "https://www.boredapi.com/api/activity?key=" + Key;
                HttpResponseMessage response = await client.GetAsync(endPoint);
                responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                ResponseCode = response.IsSuccessStatusCode;
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        [Then(@"verify the sucess response")]
        public void ThenVerifyTheSucessResponse()
        {
                        
            if(ResponseCode)
            {
                Console.WriteLine("The response code is a SUCCESS");
            }
            else
            {
                Console.WriteLine("The response code is a FAILURE");
            }
        }

        [Then(@"verify the (.*), (.*) & (.*) are correct in the response")]
        public void ThenVerifyTheSocialTextAFriendYouHavenTTalkedToInALongTimeAreCorrectInTheResponse(string ActivityType, string Activitiy, int CountofPeople)
        {
            try
            {                
                _boardAPI = JsonConvert.DeserializeObject<BoardAPI>(responseBody);
                string activity = _boardAPI.Activity;
                string type = _boardAPI.Type;
                string participnts = _boardAPI.Participants;
                string countOfPeople = CountofPeople.ToString();
                Assert.AreEqual(Activitiy, activity);
                Assert.AreEqual(ActivityType, type);
                Assert.AreEqual(countOfPeople, participnts);

            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }

    }
