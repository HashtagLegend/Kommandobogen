using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateUserView : Page
    {

        public UserCatalogSingleton Singleton { get; set; }
       

        public CreateUserView()
        {
            this.InitializeComponent();
            Singleton = UserCatalogSingleton.Instance;
            SearchBox.TextChanged += new TextChangedEventHandler(SearchBox_TextChanged);
            CreateButton.Click += CreateButton_Click;
            DeleteButton.Click += DeleteButton_Click;
            bindingToList();
        }

        public void bindingToList()
        {
            if (UserViewModel.ViewSearch == null)
            {
                this.UserListView.ItemsSource = Singleton.UserList;
            }
            else
            {
                Singleton.SearchUserList.Clear();
                foreach (User user in Singleton.UserList)
                {
                    if (user.ToString().Contains(UserViewModel.ViewSearch))
                    {
                        Singleton.SearchUserList.Add(user);
                    }
                }

                this.UserListView.ItemsSource = Singleton.SearchUserList;
            }
        }

        public void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bindingToList();
        }

        public void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            bindingToList();
        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            bindingToList();
        }


    }
}
