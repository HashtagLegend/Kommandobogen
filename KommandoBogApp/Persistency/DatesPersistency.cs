using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;

namespace KommandoBogApp.Persistency
{
    class DatesPersistency
    { 
        
            public static async void SaveDates(ActivityDate date)
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
                        await client.PostAsJsonAsync("api/DateTables", date);
                        
                    }
                        catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }

        public static async Task<List<ActivityDate>> LoadDates()
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

                        var responce = client.GetAsync("api/DateTables").Result;
                        Debug.WriteLine(responce);
                        if (responce.IsSuccessStatusCode)
                        {
                            var dates = responce.Content.ReadAsAsync<IEnumerable<ActivityDate>>().Result;
                            Debug.WriteLine(responce);
                            return dates.ToList();
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

        public static async void DeleteDateAsync(int ID)
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
                    Debug.WriteLine(ServerUrl + "/api/DateTables/" + ID);
                    Debug.WriteLine(client.DeleteAsync("/api/DateTables/" + ID).Result);
                    await client.DeleteAsync("/api/DateTables/" + ID);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
