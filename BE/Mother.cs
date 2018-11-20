using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Mother
    {
        public Mother()
        {
            Day_of_keep = new DayOfWork[6];
            for (int i = 0; i < 6; i++)
            {
                Day_of_keep[i] = new DayOfWork();
            }
            NeedsDay = new bool[6];
        }
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string MotherAddress { get; set; }
        public string ResearchAddress { get; set; }
        public string Phone { get; set; }
        public bool[] NeedsDay { get; set; }
        public DayOfWork[] Day_of_keep { get; set;}
        public string Remarks { get; set; }

        public override string ToString()
        {
            string[] Days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            string days = null;
            for (int i = 0; i < 6; i++)
                if (NeedsDay[i])
                {
                    days += Days[i] + ": From " + Day_of_keep[i].start.ToString(@"hh\:mm") + " to "
                        + Day_of_keep[i].end.ToString(@"hh\:mm") + "\n";

                }

            ResearchAddress = ResearchAddress == null ? MotherAddress : ResearchAddress;
            Remarks = Remarks == null ? Remarks : "Remarks: " + Remarks;

            return "ID: " + Id.ToString() + "\n" +
                "Name: " + FirstName + " " + FamilyName + "\n" +
                "Phone number: " + Phone.ToString() + "\n" +
                "Address: " + MotherAddress.ToString() + "\n" +
                "Research Address: " + ResearchAddress + "\n" + days + Remarks + "\n";

        }
    }

    public class  DayOfWork
    {
        public int day;
        public TimeSpan start;
        public TimeSpan end;
        public DayOfWork(){ start = new TimeSpan(); end = new TimeSpan(); }
    }
}
