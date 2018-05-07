using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.RelayCommands;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.ViewModel
{
    class ActivityViewModel : INotifyPropertyChanged
    {
        public DateTime ViewDateFrom { get; set; }
        public DateTime ViewDateTo { get; set; }
        public string ViewKommentar { get; set; }
        public string ViewNavn { get; set; }
        public Color ViewColor { get; set; }
        public ActivitySingleton ActivityList { get; set; }
        public ActivityHandler ActivityHandler { get; set; }

        public static Activity SavedActivity { get; set; }

        public string ViewActivityType { get { return SavedActivity.Navn;}}
        

        public ActivityViewModel()
        {
            ActivityList = ActivitySingleton.Instance;
            ActivityHandler = new ActivityHandler(this);

            ActivityList.AddActivity(new Activity(DateTime.Now, DateTime.Today, "Er væk hele dagen", "Kursus i vredeshåndtering", Colors.YellowGreen, "Ferie"));
        }

        private ICommand _createActivity;

        public ICommand CreateActivityCommand
        {
            get {return _createActivity ?? (_createActivity = new RelayArgCommand<Activity>(ac => ActivityHandler.CreateActivity()));}
            set { _createActivity = value; }
        }
        
        #region ActivityType

        public void ActivityFerie()
        {
            SavedActivity.Navn = "Ferie";
            SavedActivity.Color = Colors.Yellow;
            OnPropertyChanged();
            //Save
        }
        public void ActivityFri()
        {
            SavedActivity.Navn = "Fri";
            SavedActivity.Color = Colors.Red;
            OnPropertyChanged();
            //Save
        }

        public void ActivityKursus()
        {
            SavedActivity.Navn = "Kursus";
            SavedActivity.Color = Colors.Green;
            //Save
        }

        public void ActivityVagt()
        {
            SavedActivity.Navn = "Vagt";
            SavedActivity.Color = Colors.Blue;
            OnPropertyChanged();
            //Save
        }

        #endregion
        
        #region PropertyChangeSupport

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
