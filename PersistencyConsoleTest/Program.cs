using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using KDOWS;
using System.Data.SqlClient;

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

            //using (var Db = new TestAdo())
            //{
            //    UserTable newUser = new UserTable();
            //    newUser.Navn = "Patrick";
            //    newUser.Adresse = "Rønnevænget 3";
            //    newUser.AfdId = "1";
            //    newUser.Email = "PatrickOerum@icloud.com";
            //    newUser.MaNummer = "370231";
            //    newUser.Password = "1234";
            //    newUser.Tlf = "30488592";
            //    newUser.UserType = "Admin";

            //    Db.UserTable.Add(newUser);
            //    Db.SaveChanges();
            //}

            //using (var Db = new TestAdo())
            //{
            //    UserTable newUser = new UserTable();
            //    newUser.Navn = "Frederik";
            //    newUser.Adresse = "København";
            //    newUser.AfdId = "2";
            //    newUser.Email = "Fluffer@BackDoorPirates.com";
            //    newUser.MaNummer = "69";
            //    newUser.Password = "1234";
            //    newUser.Tlf = "99887766";
            //    newUser.UserType = "Admin";

            //    Db.UserTable.Add(newUser);
            //    Db.SaveChanges();
            //}





            Console.WriteLine("kom her til");
            Console.ReadKey();


        }
        
    }
}
