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
    public partial class AddUserView : ContentView, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public User user { get; set; } = new User();

        public AddUserView()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private async void OK_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.LoginName) || string.IsNullOrEmpty(user.Phone))
            {
                //TODO: Show Alert values need to be filled
                return;
            }
            if (!VarContainer.sql.insertUser(user))
            {
                //TODO: Show Alert about feiled to insert
                return;
            }
            user = new User();
            RaiseAllProperties();
            MessagingCenter.Send<App>((App)Application.Current, "userAdded");
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<App>((App)Application.Current, "closeAddUser");
        }

        private void RaiseAllProperties()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}