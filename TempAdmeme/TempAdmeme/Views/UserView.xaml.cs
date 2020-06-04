﻿using MySql.Data.MySqlClient;
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
    public partial class UserView : ContentPage
    {
        public UserView()
        {
            InitializeComponent();

            VarContainer.userView = this;

            Task.Run(loadData);
        }

        private void loadData()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.UserID = "u25461";
            sb.Server = ""
            MySqlConnection
        }
    }
}