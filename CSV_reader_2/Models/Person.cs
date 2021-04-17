using CSV_reader_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSV_reader_2.Models
{
    public class Person : IPerson
    {
        public Person(){}
        public Person(int id, string name, DateTime dateOfBirth, bool married, string phone, decimal salary)=>
            (ID, Name, DateOfBirth, Married, Phone, Salary) = (id, name, dateOfBirth, married, phone, salary);

        public Person(int id, string name, string dateOfBirth, string married, string phone, string salary)             
        {
            ID = id;
            Name = name;

            string[] datas = dateOfBirth.Split('-');
            DateOfBirth = new DateTime(int.Parse(datas[0]), int.Parse(datas[1]), int.Parse(datas[2]));

            Married = Convert.ToBoolean(married);
            Phone = phone;
            Salary = Convert.ToDecimal(salary.Replace('.',','));
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set ; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

        public void Copy(Person p) =>
            (ID, Name, DateOfBirth, Married, Phone, Salary) = (p.ID, p.Name, p.DateOfBirth, p.Married, p.Phone, p.Salary);       
    }
}