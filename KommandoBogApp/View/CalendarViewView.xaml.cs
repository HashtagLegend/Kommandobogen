using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarViewView : Page
    {
        public ActivitySingleton ActivitiySingleton { get; set; }

        public CalendarViewView()
        {
            this.InitializeComponent();
            ActivitiySingleton = ActivitySingleton.Instance;
        }

        public static List<DateTimeOffset> DateSelected { get; set; }

        private void CalendarView_OnSelectedDatesChanged(object sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            CalendarViewModel.CalendarViewSelectedDates = CalendarView1.SelectedDates;

        }

        public void CalenderViewViewUpdate()
        {
            CalendarViewModel.CalendarViewSelectedDates = CalendarView1.SelectedDates;
        }

        public void CalendarView_CalendarViewDayItemChanging(CalendarView sender,
            CalendarViewDayItemChangingEventArgs args)
        {
            if (args.Phase == 0)
            {

                args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
            }
            else if (args.Phase == 2)
            {
                //var CurrentActivities = PlaceHolderActivitySingleton.ActivityList.GetActivityDate

            }

        }


    }
}
