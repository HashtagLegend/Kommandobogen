using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;

namespace KommandoBogApp.Persistency
{
    public class AfdelingPersistency
    {
        public static async Task<ObservableCollection<Afdeling>> LoadAfdelingsFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:55000";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler,false))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var responce = client.GetAsync("api/AfdelingTables").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var afdelingsdata = responce.Content.ReadAsAsync<IEnumerable<Afdeling>>().Result;
                        ObservableCollection<Afdeling> Listen = new ObservableCollection<Afdeling>();
                        foreach (Afdeling afd in afdelingsdata)
                        {
                            Listen.Add(afd);
                        }
                        return Listen;
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }

                return null;
            }
        }
    }
}
