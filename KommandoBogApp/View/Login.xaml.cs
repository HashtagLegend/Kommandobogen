using KommandoBogApp.Handler;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;
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
using Microsoft.Xaml.Interactions.Core;
using System.Diagnostics;
using Windows.System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public UserCatalogSingleton Singleton { get; set; }
        public UserViewModel VM { get; set; }
        public static string LoadFromDBGoneWrong { get; set; }
        
        public Login()
        {
            this.InitializeComponent();
            VM = new UserViewModel();
            Singleton = UserCatalogSingleton.Instance;
            LoginButton.Click += LoginButton_Click;
            LoadFromDBGoneWrong = " ";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (VM.UserHandler.CheckCredentials(UserViewModel.LoginString))
            {
                this.Frame.Navigate(typeof(KommandoBogApp.View.CalendarViewView));
            }
            SomethingIsWrong.Text = LoadFromDBGoneWrong;
        }

        private void UIElement_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}
