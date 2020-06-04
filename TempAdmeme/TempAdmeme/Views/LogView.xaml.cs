using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempAdmeme.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempAdmeme.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogView : ContentPage
    {
        public LogView()
        {
            InitializeComponent();

            VarContainer.logView = this;
        }
    }
}