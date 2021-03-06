﻿using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempAdmeme.Helper;
using Xamarin.Forms;

namespace TempAdmeme
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<App>((App)Application.Current, "closeMenu", (sender) =>
            {
                IsPresented = false;
            });

            LogManager.Configuration = new XmlLoggingConfiguration(Device.RuntimePlatform == Device.Android ? "assets/NLog.config" : "NLog.config");
            VarContainer.logger = LogManager.GetLogger("TempAdmin");
        }

        public void pushToDetail(Page page)
        {
            Detail = page;
        }
    }
}
