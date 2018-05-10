using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Client.Services
{
    public class Commands
    {
        private static async Task<string> ExecuteGetCommand(string command)
        {
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await http.GetAsync(command);
                    string jsonString = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(jsonString);
                    return jsonString;
                }
                catch (Exception)
                {
                    return "ERROR";
                }
            }

        }

        public static async Task<string> ExecutePostCommand(string command, string content)
        {
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    StringContent cont = new StringContent(content, Encoding.UTF8, Constants.ContentType);
                    HttpResponseMessage response = await http.PostAsync(command, cont);
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return jsonString;
                }
                catch (Exception)
                {
                    return "ERROR";
                }
            }
        }

        public static async Task<int[,]> GetNextGeneration(int[,] data)
        {
            JObject content = JObject.FromObject(new Models.NextDataRequest() { Data = data });

            string response = await Commands.ExecutePostCommand(Constants.NextGeneration, content.ToString());

            try
            {
                Models.NextDataRequest responseData = JsonConvert.DeserializeObject<Models.NextDataRequest>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return responseData.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
