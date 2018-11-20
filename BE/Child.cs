using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Child:INotifyPropertyChanged
    {
        private int motherId;
        public int MotherId {
            get { return motherId; }
            set {
                motherId = value;
                //if (value.ToString().Length != 9)
                //    throw new Exception("The id has to be 9 digits");
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MotherId"));
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set {
                id = value;
                //if (value.ToString().Length != 9)
                //    throw new Exception("The id has to be 9 digits");
                //foreach (var item in value.ToString().ToLower())
                //    if (item < '0'|| item>'9')
                //        throw new Exception("The id has to be only with digits");
               //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
            
        }
        private DateTime dobChild =DateTime.Now.AddMonths(-3);
        public DateTime DobChild
        {
            get { return dobChild; }
            set
            {
                dobChild = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DobChild"));
            }

        }

        private bool isSpecialNeeds;
        public bool IsSpecialNeeds
        {
            get { return isSpecialNeeds; }
            set
            {
                isSpecialNeeds = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSpecialNeeds"));
            }

        }

        private string specialNeeds;
        public string SpecialNeeds
        {
            get { return specialNeeds; }
            set
            {
                specialNeeds = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SpecialNeeds"));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {

            string special;
            if (isSpecialNeeds)
                special = "This Child has special needs";
            else
                special = "This Child doesn't have special needs";

            string result = null;
            result += string.Format("{0}\n",FirstName);
            result += string.Format("Date of birth: {0}\n", DobChild.ToShortDateString());
            result += string.Format("ID: {0}\n", Id);
            result += string.Format("Mother's ID: {0}\n", MotherId);
            result += special;
            return result;
        }

    }
}
