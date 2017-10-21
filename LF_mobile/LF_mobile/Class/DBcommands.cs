using System.Collections.Generic;
using System.Linq;
using LF_mobile.Interface;
using LF_mobile.Model;
using SQLite;
using Xamarin.Forms;

namespace LF_mobile.Class
{
    public class DBcommands
    {
        SQLiteConnection database;
        public DBcommands(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);

            database.CreateTable<Category>();
            database.CreateTable<SubCategory>();
            database.CreateTable<Catalog>();
            database.CreateTable<Forum>();
            database.CreateTable<ForumSubTheme>();
            database.CreateTable<ForumMessage>();
            database.CreateTable<Good>();
            database.CreateTable<GoodPhoto>();
            database.CreateTable<Preview>();
            database.CreateTable<Reportage>();
            database.CreateTable<ReportageImg>();
            database.CreateTable<News>();
            database.CreateTable<ReklamaCatalog>();
            database.CreateTable<Book>();
            database.CreateTable<BookCategory>();
            database.CreateTable<BookCatalog>();
        }

        public IEnumerable<Category> GetCategories()
        {
            return (from i in database.Table<Category>() select i).ToList();
        }
        public int ClearCategories()
        {
            return database.DeleteAll<Category>();
        }
        public int SaveCategories(List<Category> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<Book> GetBook()
        {
            return (from i in database.Table<Book>() select i).ToList();
        }
        public int ClearBook()
        {
            return database.DeleteAll<Book>();
        }
        public int SaveBook(List<Book> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<BookCategory> GetBookCategory()
        {
            return (from i in database.Table<BookCategory>() select i).ToList();
        }
        public int ClearBookCategory()
        {
            return database.DeleteAll<BookCategory>();
        }
        public int SaveBookCategory(List<BookCategory> items)
        {
            return database.InsertAll(items);
        }

        public IEnumerable<BookCatalog> GetBookCatalog()
        {
            return (from i in database.Table<BookCatalog>() select i).ToList();
        }
        public int ClearBookCatalog()
        {
            return database.DeleteAll<BookCatalog>();
        }
        public int SaveBookCatalog(List<BookCatalog> items)
        {
            return database.InsertAll(items);
        }




        public IEnumerable<SubCategory> GetSubCategories()
        {
            return (from i in database.Table<SubCategory>() select i).ToList();
        }
        public int ClearSubCategories()
        {
            return database.DeleteAll<SubCategory>();
        }
        public int SaveSubCategories(List<SubCategory> items)
        {
            return database.InsertAll(items);
        }




        public IEnumerable<Catalog> GetCatalogs()
        {
            return (from i in database.Table<Catalog>() select i).ToList();
        }
        public int ClearCatalogs()
        {
            return database.DeleteAll<Catalog>();
        }
        public int SaveCatalogs(List<Catalog> items)
        {
            return database.InsertAll(items);
        }



        public IEnumerable<ReklamaCatalog> GetReklamaCatalog()
        {
            return (from i in database.Table<ReklamaCatalog>() select i).ToList();
        }
        public int ClearReklamaCatalog()
        {
            return database.DeleteAll<ReklamaCatalog>();
        }
        public int SaveReklamaCatalog(List<ReklamaCatalog> items)
        {
            return database.InsertAll(items);
        }



        public IEnumerable<Forum> GetForum()
        {
            return (from i in database.Table<Forum>() select i).ToList();
        }
        public int ClearForum()
        {
            return database.DeleteAll<Forum>();
        }
        public int SaveForum(List<Forum> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<ForumSubTheme> GetForumSubTheme()
        {
            return (from i in database.Table<ForumSubTheme>() select i).ToList();
        }
        public int ClearForumSubTheme()
        {
            return database.DeleteAll<ForumSubTheme>();
        }
        public int SaveForumSubTheme(List<ForumSubTheme> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<ForumMessage> GetForumMessage()
        {
            return (from i in database.Table<ForumMessage>() select i).ToList();
        }
        public int ClearForumMessage()
        {
            return database.DeleteAll<ForumMessage>();
        }
        public int SaveForumMessage(List<ForumMessage> items)
        {
            return database.InsertAll(items);
        }



        public IEnumerable<Good> GetGood()
        {
            return (from i in database.Table<Good>() select i).ToList();
        }
        public int ClearGood()
        {
            return database.DeleteAll<Good>();
        }
        public int SaveGood(List<Good> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<GoodPhoto> GetGoodPhoto()
        {
            return (from i in database.Table<GoodPhoto>() select i).ToList();
        }
        public int ClearGoodPhoto()
        {
            return database.DeleteAll<GoodPhoto>();
        }
        public int SaveGoodPhoto(List<GoodPhoto> items)
        {
            return database.InsertAll(items);
        }




        public IEnumerable<Preview> GetPreview()
        {
            return (from i in database.Table<Preview>() select i).ToList();
        }
        public int ClearPreview()
        {
            return database.DeleteAll<Preview>();
        }
        public int SavePreview(List<Preview> items)
        {
            return database.InsertAll(items);
        }



        public IEnumerable<Reportage> GetReportage()
        {
            return (from i in database.Table<Reportage>() select i).ToList();
        }
        public int ClearReportage()
        {
            return database.DeleteAll<Reportage>();
        }
        public int SaveReportage(List<Reportage> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<ReportageImg> GetReportageImg()
        {
            return (from i in database.Table<ReportageImg>() select i).ToList();
        }
        public int ClearReportageImg()
        {
            return database.DeleteAll<ReportageImg>();
        }
        public int SaveReportageImg(List<ReportageImg> items)
        {
            return database.InsertAll(items);
        }


        public IEnumerable<News> GetNews()
        {
            return (from i in database.Table<News>() select i).ToList();
        }
        public int ClearNews()
        {
            return database.DeleteAll<News>();
        }
        public int SaveNews(List<News> items)
        {
            return database.InsertAll(items);
        }
        //public Category GetItem(int id)
        //{
        //    return database.Get<Category>(id);
        //}
    }
}
