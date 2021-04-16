using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader_2.Interfaces
{
    interface IPerson
    {
        int ID { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth{get;set;}
        bool Married { get; set; }
        string Phone { get; set; }
        decimal Salary { get; set; }

    }
}
