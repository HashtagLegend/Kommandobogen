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




namespace KommandoBogApp.Persistency
{
    public class UserPersistency
    {
        
        public static async void SaveUsersAsJsonAsync(User user)
        {
            const string Url = "http://localhost:61818";
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
        }

        public static async Task<ObservableCollection<User>> LoadUsersFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:61818";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var responce = client.GetAsync("api/UserTables").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var userList = responce.Content.ReadAsAsync<IEnumerable<User>>().Result;

                        foreach (var user in userList)
                        {
                            UserCatalogSingleton.Instance.UserList.Add(user);
                        }

                       
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
