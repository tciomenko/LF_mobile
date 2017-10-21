using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF_mobile.Class;

namespace LF_mobile.Class
{
    public class UpdateFromServer
    {
        public void update()
        {
            ImportCategory category = new ImportCategory();
            category.GetCategory();

            ImportSubCategory subCategory = new ImportSubCategory();
            subCategory.GetSubCategory();

            ImportCatalog catalogs = new ImportCatalog();
            catalogs.GetCatalog();

            ImportForum forum = new ImportForum();
            forum.GetForum();

            ImportGood good = new ImportGood();
            good.GetGood();

            ImportGoodPhoto goodPhoto = new ImportGoodPhoto();
            goodPhoto.GetGoodPhoto();

            ImportPreview preview = new ImportPreview();
            preview.GetPreview();

            ImportReportage reportage = new ImportReportage();
            reportage.GetReportage();

            ImportReportageImg reportageImg = new ImportReportageImg();
            reportageImg.GetReportageImg();

            ImportNews news = new ImportNews();
            news.GetNews();


            ImportBook book = new ImportBook();
            book.GetBooks();


            ImportBookCategory bookCategory = new ImportBookCategory();
            bookCategory.GetBooksCalegory();


            ImportBookCatalog bookCatalog = new ImportBookCatalog();
            bookCatalog.GetBookCatalog();


            ImportReklamaCatalog reklamaCatalog = new ImportReklamaCatalog();
            reklamaCatalog.GetReklamaCatalog();
        }
    }
}
