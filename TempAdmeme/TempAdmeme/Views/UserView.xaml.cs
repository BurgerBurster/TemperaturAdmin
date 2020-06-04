using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempAdmeme.Helper;
using TempAdmeme.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempAdmeme.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserView : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private object context_lock = new object();

        public List<User> users { get; set; }

        public UserView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<App>((App)Application.Current, "userAdded", (sender) => userAdded());
            MessagingCenter.Subscribe<App>((App)Application.Current, "closeAddUser", (sender) => closeAddUserPopup());

            VarContainer.userView = this;

            BindingContext = this;

            Task.Run(loadData);
        }

        private async void loadData()
        {
            users = VarContainer.sql.getUsers();
            await Device.InvokeOnMainThreadAsync(RaiseAllProperties);
        }

        private void RaiseAllProperties()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void Fab_Clicked(object sender, EventArgs e)
        {
            addUserView.IsVisible = true;
        }

        private void closeAddUserPopup()
        {
            addUserView.IsVisible = false;
        }

        private void userAdded()
        {
            closeAddUserPopup();
            Task.Run(loadData);
        }

        private async void grid_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItemIndex == -1)
            {
                return;
            }

            string res = await DisplayActionSheet("Aktion wählen", "Abbrechen", null, "Löschen");

            if(res == "Löschen")
            {
                if (!VarContainer.sql.removeUser(users[e.SelectedItemIndex].ID))
                {

                }
                else
                {
                    Task.Run(loadData);
                }
            }
        }
    }
}