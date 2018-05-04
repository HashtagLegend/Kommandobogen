using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
   public class Afdeling
    {

        public string Navn { get; set; }
        public ObservableCollection<User> AfdelingList { get; set; }

        public Afdeling(string navn)
        {
            Navn = navn;
            AfdelingList = new ObservableCollection<User>();
        }

        public void AddUserToList(User user)
        {
            AfdelingList.Add(user);
        }

        public override string ToString()
        {
            return $"{nameof(Navn)}: {Navn}";
        }
    }
}
