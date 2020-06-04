using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using TempAdmeme.Views;
using Xamarin.Forms;

namespace TempAdmeme.Helper
{
    public class VarContainer
    {
        public static UserView userView = null;
        public static LogView logView = null;
        public static MainPage main = null;

        public static Logger logger = null;

        public static SQLHelper sql = new SQLHelper();
    }
}
