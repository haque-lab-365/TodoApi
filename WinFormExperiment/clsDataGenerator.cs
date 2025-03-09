using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormExperiment
{
    public class clsDataGenerator
    {
        public clsDataGenerator() { }
        public List<Person> GetPersonList() 
        { 
        
            List<Person> personList = new List<Person>();

            personList.Add(new Person(1000, "Shahidul", "Haque", "+8801711146878", DateTime.Now.AddDays(-1000).Date, 45000));
            personList.Add(new Person(1001, "Shaheen", "Mahmud", "+8801711156878", DateTime.Now.AddDays(-2000).Date, 55000));
            personList.Add(new Person(1002, "Shajidul", "Abbas", "+8801711166878", DateTime.Now.AddDays(-3000).Date, 65000));
            personList.Add(new Person(1003, "Shahinul", "Jabber", "+8801711746878", DateTime.Now.AddDays(-4000).Date, 75000));
            personList.Add(new Person(1004, "Shahidul", "Mashrur", "+8801771146878", DateTime.Now.AddDays(-5000).Date, 45000));
            personList.Add(new Person(1005, "Shahidul", "Ehsan", "+8801718146878", DateTime.Now.AddDays(-6000).Date, 35000));
            personList.Add(new Person(1006, "Ahnaf", "Iqbal", "+8801733146878", DateTime.Now.AddDays(-7000).Date, 25000));
            personList.Add(new Person(1007, "Imtiaz", "Islam", "+8801722146878", DateTime.Now.AddDays(-8000).Date, 85000));
            personList.Add(new Person(1008, "Mahmudul", "Hassan", "+8801711133878", DateTime.Now.AddDays(-9000).Date, 60000));
            personList.Add(new Person(1009, "Hasibul", "Kabir", "+8801711142278", DateTime.Now.AddDays(-3300).Date, 77000));
            personList.Add(new Person(1010, "Shihab", "Mahmud", "+8801711146118", DateTime.Now.AddDays(-2200).Date, 86000));

            return personList;
        }       
    }

    public class Person
    {
    
        public Person(int id, string fname, string lname, string phoneNumber, DateTime joiningDate, decimal joiningSalary) 
        { 
            Id = id;
            FirstName = fname;
            LastName = lname;
            PhoneNumber = phoneNumber;
            JoiningDate = joiningDate;
            JoininggSalary = joiningSalary;
        }
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; }
        public decimal JoininggSalary { get; set; }

    }
}
