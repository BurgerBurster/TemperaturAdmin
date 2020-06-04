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

        List<User> users = new List<User>();
        public UserView()
        {
            InitializeComponent();

            VarContainer.userView = this;

            BindingContext = this;

            Task.Run(loadData);
        }

        private async void loadData()
        {
            users = VarContainer.sql.getUsers();
            await Device.InvokeOnMainThreadAsync(() => RaiseAllProperties());
        }

        private void RaiseAllProperties()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}