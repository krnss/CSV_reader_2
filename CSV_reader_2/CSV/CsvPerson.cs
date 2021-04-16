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
        public IEnumerable<Person> GetPersonFromCsv( string roadToFile)
        {
            using (var reader = new StreamReader(roadToFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Person>();              
            }
        } 
    }
}