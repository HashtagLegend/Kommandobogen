using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.ViewModel
{
    public class UserViewModel
    {


        public UserCatalogSingleton UserCatalogSingleton { get; set; }
        public string ViewMaNr { get; set; }
        public string ViewNavn { get; set; }
        public string ViewTlf { get; set; }
        public string ViewAdresse { get; set; }
        public string ViewEmail { get; set; }
        public string Type { get; set; }
        public Afdeling Afdeling { get; set; }
        public User SelectedUser { get; set; }



        public UserHandler Handler { get; set; }

       
        public UserViewModel()
        {
            UserCatalogSingleton = UserCatalogSingleton.Instance;
            Handler = new UserHandler(this);
        }

        
    }
}
