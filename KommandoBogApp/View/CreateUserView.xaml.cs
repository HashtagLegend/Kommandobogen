using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;
using User = KommandoBogApp.Model.User;

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
        //Her bindes til enten searchlist eller orignal user list
        public void bindingToList()
        {
            if (UserViewModel.ViewSearch == null || UserViewModel.ViewSearch == "")
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
        //Oberservers
        public void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bindingToList();
        }

        public async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);
            bindingToList();
        }

        public async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);
            bindingToList();

        }

        private void UserListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserViewModel.SelectedUser != null)
            {
                MA_Nummer.Background = new SolidColorBrush(Colors.LightGray);
                MA_Nummer.IsReadOnly = true;
                MA_Nummer.Text = UserViewModel.SelectedUser.MaNummer;
                Navn.Text = UserViewModel.SelectedUser.Navn;
                Telefon_Nummer.Text = UserViewModel.SelectedUser.Tlf;
                Adresse.Text = UserViewModel.SelectedUser.Adresse;
                char[] chararray = UserViewModel.SelectedUser.AfdNavn.ToCharArray();
                string endswith = chararray[chararray.Length - 1].ToString();
                foreach (var Afdelinger in AfdelingBox.Items)
                {
                    if (Afdelinger.ToString().EndsWith(endswith))
                    {
                        AfdelingBox.SelectedItem = Afdelinger;
                    }
                }
                PasswordBox.Password = UserViewModel.SelectedUser.Password;
                Email.Text = UserViewModel.SelectedUser.Email;
                BrugertypeBox.SelectedItem = UserViewModel.SelectedUser.UserType;
            }
        }

        private void UserListView_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape)
            {
                MA_Nummer.Background = new SolidColorBrush(Colors.Transparent);
                MA_Nummer.IsReadOnly = false;
                UserListView.SelectedItem = null;
                MA_Nummer.Text = "";
                Navn.Text = "";
                Telefon_Nummer.Text = "";
                Adresse.Text = "";
                AfdelingBox.SelectedItem = null;
                PasswordBox.Password = "";
                Email.Text = "";
                BrugertypeBox.SelectedItem = null;
            }
        }
    }
}
