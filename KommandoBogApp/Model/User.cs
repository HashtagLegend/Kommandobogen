using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.View;

namespace KommandoBogApp.Model
{
    [Serializable]
    public class User
    {
        public string AfdId { get; set; }
        public string UserType { get; set; }
        public string MaNummer { get; set; }
        public string Navn { get; set; }
        public string Tlf { get; set; }
        public string Adresse { get; set; }
        [NonSerialized] public Afdeling Afd;
        public string Email { get; set; }
        [NonSerialized] public List<Activity> Activities;
        [NonSerialized] public ObservableCollection<Activity> DaysWithActivities;

        public string Password { get; set; }

        public User(string maNummer, string navn, string tlf, string adresse, string email, string password)
        {
            MaNummer = maNummer;
            Navn = navn;
            Tlf = tlf;
            Adresse = adresse;
            Email = email;
            AfdId = "";

            Password = password;

            Activities = new List<Activity>();
            DaysWithActivities = new ObservableCollection<Activity>();
            FillDaysWithActivities();
            Password = password;
    
        }

        public void CreateActivity()
        {

        }



        public void EditActivity()
        {

        }

        public void FillDaysWithActivities()
        {
            for (int i = 1; i <= DateTime.DaysInMonth(HubTest.ShownMonth.Year,HubTest.ShownMonth.Month); i++)
            {
                DaysWithActivities.Add(null);
            }
        }

        public override string ToString()
        {
            return $"{MaNummer} {Navn} {Tlf} {Afd} {Email} {Adresse} {UserType}";
        }

        public string DatabaseString()
        {
            return $"{nameof(MaNummer)}: {MaNummer}, {nameof(Navn)}: {Navn}, {nameof(Adresse)}: {Adresse}, {nameof(Email)}: {Email}, {nameof(Tlf)}: {Tlf}, {nameof(Password)}: {Password}, {nameof(AfdId)}: {AfdId}, {nameof(UserType)}: {UserType}";
        }
    }
}
