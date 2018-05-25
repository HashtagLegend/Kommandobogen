using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;
using Newtonsoft.Json;

namespace KommandoBogApp.Persistency
{
    public class PersistencyUser
    {

        public static async Task<List<User>> LoadFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:55000";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var responce = client.GetAsync("api/Users").Result;
                    Debug.WriteLine(responce);
                    if (responce.IsSuccessStatusCode)
                    {
                        var eventdata = responce.Content.ReadAsAsync<IEnumerable<User>>().Result;
                        return eventdata.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
