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
using KommandoBogApp.Handler;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HelpView : Page
    {
        public HelpView()
        {
            this.InitializeComponent();
            UserSingleton = UserCatalogSingleton.Instance;
            MAFraloginTest.Text = UserHandler.UserVM.UserCatalogSingleton.LoginUser.MaNummer;
            NavnFraLoginTest.Text = UserHandler.UserVM.UserCatalogSingleton.LoginUser.Navn;
        }

        public ActivityViewModel ActivityViewModel { get; set; }

        public UserCatalogSingleton UserSingleton { get; set; }

        public void LeavingPage(object sender, RoutedEventArgs e)
        {
            if (ActivityHandler.CalendarViewSelectedDates != null)
            {
                ActivityHandler.CalendarViewSelectedDates.Clear();
            }
        }

        public void NavigateToPageOpretBruger(object sender, RoutedEventArgs e)
        {
            if (UserSingleton.LoginUser.UserType == "Admin")
            {
                LeavingPage(sender, e);
                this.Frame.Navigate(typeof(KommandoBogApp.View.CreateUserView));
            }
        }

        private void HelpBlock6_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
