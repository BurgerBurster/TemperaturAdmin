using System;
using System.Collections.Generic;
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
    public partial class MasterMenu : ContentPage
    {
        private List<Models.MenuItem> _MenuItems = new List<Models.MenuItem>();
        public List<Models.MenuItem> MenuItems
        {
            get
            {
                return _MenuItems;
            }
        }

        private bool load_finished = false;

        public MasterMenu()
        {
            InitializeComponent();

            initItems();
            BindingContext = this;

            list.SelectedItem = MenuItems[0];

            load_finished = true;
        }

        private void initItems()
        {
            MenuItems.Add(new Models.MenuItem()
            {
                Text = "Nutzer",
                Image = "user.png",
                Scale = 0.8,
                Page = VarContainer.userView
            });
            MenuItems.Add(new Models.MenuItem()
            {
                Text = "Log",
                Image = "log.png",
                Page = new LogView()
            });
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (load_finished)
            {
                VarContainer.main.pushToDetail(new NavigationPage((e.SelectedItem as Models.MenuItem).Page));
                MessagingCenter.Send<App>((App)Application.Current, "closeMenu");
            }
        }
    }
}