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

namespace CSV_reader_2.CSV
{
    public class CsvPerson
    {
        public List<Person> GetPersonFromCsv(string roadToFile)
        {
            List<Person> people = new List<Person>();

            using (var reader = new StreamReader(roadToFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Person>();

                foreach (var item in records)                
                    people.Add(item);
                
            }            
            return people;
        } 
    }
}