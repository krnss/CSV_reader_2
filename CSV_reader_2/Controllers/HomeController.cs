using CSV_reader_2.CSV;
using CSV_reader_2.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSV_reader_2.Controllers
{
    public class HomeController : Controller
    {
        PersonContext db = new PersonContext();
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase upload)
        {
            if (upload == null)
                return View(db.Persons.ToList());

            string fileMap = Server.MapPath("~/Files/" +  upload.FileName);
            upload.SaveAs(fileMap);
            db.Persons.AddRange(new CsvPerson().GetPersonFromCsv(fileMap));
            db.SaveChanges();            

            return View(db.Persons.ToList());
        }

        [HttpPost]
        public void Edit(int id, string name, string data, string married, string phone, string salary)
        {
            db.Persons.Find(id).Copy(new Person(id, name, data, married, phone, salary));
            db.SaveChanges();
        }
    }
}