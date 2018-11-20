using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract: INotifyPropertyChanged
    {
         
        public int ContractNumber { get; set; }
        public int Id_Nanny { get; set; }
        public int IdChild { get; set; }
        public bool IsPerMonth { get; set; }
        public double Sal_Per_Hour { get; set; }
        public double Sal_Per_Month { get; set; }
        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("startDate"));
            }
        }
        private DateTime endDate = DateTime.Now.AddMonths(1);
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("endDate"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool Theyknow { get; set; }
        public bool IsSigned { get; set; }
        public override string ToString()
        {
            string meeting;
            if (Theyknow)
                meeting = "The Mother and the Nanny had a meeting";
            else
                meeting = "The Mother and the Nanny never had a meeting";

            string signed;
            if (IsSigned)
                signed = "The contract is signed";
            else
                signed = "The contract is not signed";

            string salary;
            if (IsPerMonth)
                salary = "Salary per Month: " + Sal_Per_Month.ToString();
            else
                salary = "Salay per Hour: " + Sal_Per_Hour.ToString();

            return "Contract Number: "+ContractNumber.ToString()+"\n"+
                "Nanny's ID: "+Id_Nanny.ToString()+"\n"+
                "Child's ID: "+IdChild.ToString()+"\n"+
                meeting+"\n"+signed+"\n"+salary+"\n"+
                "Start Date: "+StartDate.ToShortDateString()+"\n"+
                "End Date: "+EndDate.ToShortDateString();

        }

    }
}
