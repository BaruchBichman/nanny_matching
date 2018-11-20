using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : INotifyPropertyChanged
    {
        public Nanny()
        {
            Week_of_work = new DayOfWork[6];
            for (int i = 0; i < 6; i++)
            {
                Week_of_work[i] = new DayOfWork();
            }
            DaysOfWork = new bool[6];
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        private DateTime dob = DateTime.Now.AddYears(-18);
        public DateTime Dob
        {
            get { return dob; }
            set
            {
                dob = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Dob"));
            }

        }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int ExpYears { get; set; }
        public int MaxChildren { get; set; }
        public int MinAgeMonth { get; set; }
        public int MaxAgeMonth { get; set; }
        public bool IsSalPerHour { get; set; }
        public double SalPerHour { get; set; }
        public double SalPerMonth { get; set; }
        public bool[] DaysOfWork { get; set; }
        public DayOfWork[] Week_of_work { get; set; }
        public int Floor { get; set; }
        public bool Elevator { get; set; }
        public bool IsTamat { get; set; }
        public string Recommendations { get; set; }

        public override string ToString()
        {
            string elevator;
            if (Elevator)
                elevator = "Elevator: Yes";
            else
                elevator = "Elevator: No";

            string salary;
            if (IsSalPerHour)
                salary = "Salary: " + SalPerHour.ToString() + " /hour";
            else
                salary = "Salary: " + SalPerMonth.ToString() + " /month";

            string[] Days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            string days = null;
            for (int i = 0; i < 6; i++)
                if (DaysOfWork[i])
                {
                    days += Days[i] + ": From " + Week_of_work[i].start.ToString(@"hh\:mm") + " to "
                        + Week_of_work[i].end.ToString(@"hh\:mm") + "\n";

                }

            string tamat;
            if (IsTamat)
                tamat = "Vacations: TAMAT vacations";
            else
                tamat = "Vacations: Not TAMAT vacations";

            Recommendations = Recommendations == null ? Recommendations : "Recommendations: " + Recommendations;

            return "ID: " + Id.ToString() + "\n" +
                "Name: " + FirstName + " " + FamilyName + "\n" +
                "Date of Birth: " + Dob.ToShortDateString() + "\n" +
                "Phone number: " + Phone + "\n" +
                "Address: " + Address + "\n" + elevator + "\n" +
                "Floor: " + Floor.ToString() + "\n" +
                "Experience: " + ExpYears.ToString() + " years" + "\n" +
                "Maximun children allowed: " + MaxChildren.ToString() + "\n" +
                "Minimum age allowed: " + MinAgeMonth.ToString() + " months" + "\n" +
                "Maximum age allowed: " + MaxAgeMonth.ToString() + " months" + "\n" +
                salary + "\n" + days + tamat + "\n" + Recommendations + "\n";
        }
    }

}
