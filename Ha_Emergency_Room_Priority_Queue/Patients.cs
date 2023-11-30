using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ha_Emergency_Room_Priority_Queue
{
    internal class Patients
    {
        public string _lastname { get; set; }
        public string _firstname { get; set; }
        public DateTime DateOfBirth { get; }
        public int _priority { get; set;  }


        public Patients(string SirName, string Name, DateTime DOB, int Priority)
        {
            _lastname = SirName;
            _firstname = Name;
            DateOfBirth = DOB;
            SetPriority(Priority);
        }

        private void SetPriority(int Priority)
        {
            int age = DateTime.Now.Year - DateOfBirth.Year; // sets age with DateTime
            _priority = Priority;

            if(age < 21 ||  age > 65) // Filter by age
            {
                _priority = 1;
            }
        }
        public override string ToString()
        {
            return $"{_lastname}, {_firstname}, {DateOfBirth:MM/dd/yyyy}, {_priority}";
        }

    }
}
