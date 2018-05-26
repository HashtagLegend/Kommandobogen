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
using KommandoBogApp.Singleton;
using Newtonsoft.Json;


namespace KommandoBogApp.Persistency
{
    public class UserPersistency
    {

       

        public static async void SaveUsers(User user)
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
                    await client.PostAsJsonAsync("api/UserTables", user);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public static async Task<ObservableCollection<User>> LoadUsers()
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

                    var responce = client.GetAsync("api/UserTables").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var users = responce.Content.ReadAsAsync<IEnumerable<User>>().Result;
                        ObservableCollection<User> _users = new ObservableCollection<User>();
                        foreach (var Users in users)
                        {
                            _users.Add(Users);
                        }
                        return _users;
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
