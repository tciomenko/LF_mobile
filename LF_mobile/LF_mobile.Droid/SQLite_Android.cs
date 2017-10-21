using System;
using Android.OS;
using System.IO;
using LF_mobile.Droid;
using LF_mobile.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace LF_mobile.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}