using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;
using Newtonsoft.Json;

namespace KommandoBogApp.Persistency
{
    class ActivityPersistency
    { 



            public static async void SaveActivity(Activity activity)
            {
                const string Url = "http://localhost:55000";
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;


                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(Url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                    try
                    {
                        Debug.WriteLine("Activity " + activity.ID);
                        await client.PostAsJsonAsync("api/ActivityTables", activity);
                    }
                        catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }   
            }

    public static async Task<List<Activity>> LoadActivities()
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

                var responce = client.GetAsync("api/ActivityTables").Result;
                Debug.WriteLine(responce);
                if (responce.IsSuccessStatusCode)
                {
                    var activities = responce.Content.ReadAsAsync<IEnumerable<Activity>>().Result;
                    return activities.ToList();
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

        public static async void DeleteActivityAsync(Activity activity)
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
                    Debug.WriteLine(ServerUrl + "/api/ActivityTables/" + activity.ID);
                    Debug.WriteLine(client.DeleteAsync("/api/ActivityTables/" + activity.ID).Result);
                    await client.DeleteAsync("/api/ActivityTables/" + activity.ID);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
    
}
