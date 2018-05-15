using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HubTest : Page
    {
        public static DateTime ShownMonth {get; set; }


        public HubTest()
        {
            UserViewModel.DatesInMonth = new ObservableCollection<int>();
            ShownMonth = DateTime.Today;
            this.InitializeComponent();
            datesInMonth();
        }

        public void datesInMonth()
        {
            UserViewModel.DatesInMonth.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(ShownMonth.Year, ShownMonth.Month); i++)
            {
                UserViewModel.DatesInMonth.Add(i);
            }
        }

        private void MonthPlusOne(object sender, RoutedEventArgs e)
        {
            ShownMonth = ShownMonth.AddMonths(1);
            datesInMonth();
            UserViewModel.SetCurrentShownMonth();
            MonthShownTextBox.Text = ShownMonth.Month.ToString();
        }

        private void MonthMinusOne(object sender, RoutedEventArgs e)
        {
            ShownMonth = ShownMonth.AddMonths(-1);
            datesInMonth();
            UserViewModel.SetCurrentShownMonth();
            MonthShownTextBox.Text = ShownMonth.Month.ToString();
        }

        private void MonthShownTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UserHandler.UserVM.Handler.FixDaysWithActivities();
        }
        private void OnPointEnter(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "VisualStateNormal", false);
        }

        private void OnPointExit(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "VisualStateAnimate", false);
        }
    }
}
