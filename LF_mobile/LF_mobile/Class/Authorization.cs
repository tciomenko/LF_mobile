using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF_mobile.Model;
using Plugin.DeviceInfo;

namespace LF_mobile.Class
{
    class Authorization
    {
        public static int UserID { get; private set; }
        public static string UserName { get; set; }
        public static string UserFirstName { get; set; }
        public static string UseUID { get; set; }
        public static bool IsAuth { get; private set; } = false;



        public Authorization()
        {
            ImportExportUser serverUser = new ImportExportUser();
            User usr = new User();
            usr =  serverUser.GetUser(CrossDeviceInfo.Current.Id.ToString());
            if (usr == null) return;
            UserName = usr.name;
            UserFirstName = usr.first_name;
            UseUID = usr.uid;
            UserID = usr.id;
            IsAuth = true;
        }

       
    }
}