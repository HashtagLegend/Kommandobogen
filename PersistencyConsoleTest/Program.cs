using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebService;

namespace PersistencyConsoleTest
{
    class Program
    {
        static void Main(string[] args)
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
                    var responce = client.GetAsync("api/UserTables").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var userList = responce.Content.ReadAsAsync<IEnumerable<UserTable>>().Result.ToList();
                        ObservableCollection<UserTable> users = new ObservableCollection<UserTable>();

                        foreach (var user in userList)
                        {
                            users.Add(user);
                            Console.WriteLine(user);
                        }

                        foreach (var user in users)
                        {
                            Console.WriteLine(user);
                        }
                        

                        
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        
    }
}
