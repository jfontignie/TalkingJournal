using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TalkingJournal.services
{
    public class DataService  
    {  
        public static async Task<dynamic> GetDataFromService(string queryString)  
        {  
            var client = new HttpClient();  
            var response = await client.GetAsync(queryString);

            if (response == null) return null;
            var json = response.Content.ReadAsStringAsync().Result;  
            dynamic data = JsonConvert.DeserializeObject(json);

            return data;  
        }  
    }  }
