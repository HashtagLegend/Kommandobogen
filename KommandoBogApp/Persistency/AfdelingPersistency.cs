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

namespace KommandoBogApp.Persistency
{
    class AfdelingPersistency
    {
        public static async Task<ObservableCollection<Afdeling>> LoadAfdelinger()
        {
            const string Url = "http://localhost:55000";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            try
            {
                using (var client = new HttpClient(handler, false))
                {
                    client.BaseAddress = new Uri(Url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var responce = client.GetAsync("api/AfdelingTables").Result;
                    Debug.WriteLine(responce);
                    if (responce.IsSuccessStatusCode)
                    {
                        var Afdelinger = responce.Content.ReadAsAsync<IEnumerable<Afdeling>>().Result;
                        ObservableCollection<Afdeling> _afdelinger = new ObservableCollection<Afdeling>();
                        foreach (var afdelinger in Afdelinger)
                        {
                            _afdelinger.Add(afdelinger);
                        }
                        return _afdelinger;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
            return null;
        }
    }
}
