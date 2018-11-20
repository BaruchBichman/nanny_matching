using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class Dal_imp : Idal
    {
        private Dal_imp()
        {
            initNanysMothersandChilds();
        }

        private void initNanysMothersandChilds()
        {
            addNanny(new Nanny
            {
                Address = "10, avenue de la paix, strasbourg, france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "Baya",
                FirstName = "sari",
                Floor = 2,
                Id = 300,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
{
                   new DayOfWork { day = 0, end = new TimeSpan(8, 30, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(9, 20, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(8, 0, 0), start = new TimeSpan(7, 0, 0) } ,
},

            });
            addNanny(new Nanny
            {
                Address = "14, avenue de la paix, strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman5",
                FirstName = "sari5",
                Floor = 2,
                Id = 301,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },

            });
            addNanny(new Nanny
            {
                Address = "20 rue de la paix, paris,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman1",
                FirstName = "sari1",
                Floor = 2,
                Id = 302,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
              {
                   new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(14, 0, 0), start = new TimeSpan(10, 30, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(19, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
              },

            });
            addNanny(new Nanny
            {
                Address = "10 rue des arquebusiers,strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman3",
                FirstName = "sari3",
                Floor = 2,
                Id = 303,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
             {
                   new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(11, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(20, 0, 0), start = new TimeSpan(10, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(11, 0, 0), start = new TimeSpan(7, 0, 0) } ,
             },

            });
            addNanny(new Nanny
            {
                Address = "5 rue turenne,strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman2",
                FirstName = "sari2",
                Floor = 2,
                Id = 304,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 1,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
           {
                   new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(12, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(11, 0, 0), start = new TimeSpan(7, 0, 0) } ,
           },

            });
            addNanny(new Nanny
            {
                Address = "40 avenue des vosges,strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 1,
                SalPerHour = 23,
                FamilyName = "gutman4",
                FirstName = "sari4",
                Floor = 2,
                Id = 305,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
             {
                   new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(7, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 20, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(15, 30, 0), start = new TimeSpan(7, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(17, 45, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(10, 0, 0), start = new TimeSpan(7, 0, 0) } ,
             },

            });

            addNanny(new Nanny
            {
                Address = "120 Pesach Chevroni,Jerusalem",
                FirstName = "Ruhami",
                FamilyName = "Vorona",
                Id = 306,

                //rangeOfAge="gg",

                Dob = new DateTime(1996, 09, 22),
                MaxChildren = 8,
                MinAgeMonth = 0,
                MaxAgeMonth = 6,
                Elevator = false,
                SalPerHour = 40,
                SalPerMonth = 4000,
                Recommendations = "good",
                Phone = "0543216766",
                ExpYears = 0,
                Floor = 1,
                IsSalPerHour = true,
                IsTamat = false,
                Week_of_work = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                DaysOfWork = new bool[] { true, true, true, true, true, true },

            });
            addNanny(new Nanny
            {
                Address = "10 avenue des vosges,strasbourg",
                FirstName = "Sarah",
                FamilyName = "Cohen",
                Id = 307,

                //rangeOfAge="gg",

                Dob = new DateTime(1970, 09, 22),
                MaxChildren = 8,
                MinAgeMonth = 0,
                MaxAgeMonth = 6,
                Elevator = false,
                SalPerHour = 40,
                SalPerMonth = 4000,
                Recommendations = "good",
                Phone = "0543216766",
                ExpYears = 0,
                Floor = 1,
                IsSalPerHour = true,
                IsTamat = true,
                Week_of_work = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(18, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                 },
                DaysOfWork = new bool[] { true, false, true, true, true, true },

            });


            addMother(new Mother
            {
                MotherAddress = "14 avenue de la paix,strasbourg,france",
                Id = 203,
                FirstName = "Avia",
                FamilyName = "Abitan",
                Phone = "056787677",
                ResearchAddress = "14 avenue de la paix,strasbourg,france",
                Remarks = "not good",
                Day_of_keep = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                NeedsDay = new bool[] { true, true, true, true, true, true },

            });
            addMother(new Mother
            {
                MotherAddress = "12 allee de la robertsau,strasbourg",
                Id = 202,
                FirstName = "Chaya",
                FamilyName = "Levi",
                Phone = "056787677",
                ResearchAddress = "Jerusalem Pesach Chevroni 120 Israel",
                Remarks = "not good",
                Day_of_keep = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                NeedsDay = new bool[] { true, true, true, true, true, true },
            });
            addMother(new Mother
            {
                FamilyName = "geleer",
                Phone = "0556691448",
                ResearchAddress = "4 rue strauss durkheim,strasbourg",
                FirstName = "chaya",
                Id = 200,
                MotherAddress = "פסח חברוני 120, ירושלים",
                Day_of_keep
    = new DayOfWork[]
    {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
    },
                NeedsDay = new bool[] { true, true, true, true, true, true },

            });
            addMother(new Mother
            {
                FamilyName = "cohen",
                Phone = "0556691448",
                ResearchAddress = "2 avenue des vosges, strasbourg",
                FirstName = "rivki",
                Id = 201,
                MotherAddress = "פסח חברוני 120, ירושלים",
                Day_of_keep
                = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                NeedsDay = new bool[] { true, true, true, true, true, true },

            });

            addChild(new Child
            {
                Id = 100,
                DobChild = new DateTime(2014, 11, 27),
                FirstName = "yosi",
                IsSpecialNeeds = false,
                MotherId = 200

            });
            addChild(new Child
            {
                Id = 101,
                DobChild = new DateTime(1990, 4, 28),
                FirstName = "yosi2",
                IsSpecialNeeds = false,
                MotherId = 200
            });
            addChild(new Child
            {
                Id = 102,
                DobChild = new DateTime(2015, 4, 28),
                FirstName = "yosi5",
                IsSpecialNeeds = true,
                MotherId = 201
            });
            addChild(new Child
            {
                Id = 103,
                DobChild = new DateTime(2016, 4, 28),
                FirstName = "yosi7",
                IsSpecialNeeds = false,
                MotherId = 201
            });



            addContract(contract: new Contract
            {
                Id_Nanny = 300,
                IdChild = 100,
                EndDate = new DateTime(2017, 12, 30),
                StartDate = new DateTime(2017, 11, 30),
                IsPerMonth = true,
                IsSigned = true,
                Sal_Per_Hour = 30,
                Sal_Per_Month = 4500,
                Theyknow = false
            });
            addContract(contract: new Contract
            {
                Id_Nanny = 301,
                IdChild = 101,
                EndDate = new DateTime(2017, 12, 30),
                StartDate = new DateTime(2017, 11, 30),
                IsPerMonth = true,
                IsSigned = true,
                Sal_Per_Hour = 30,
                Sal_Per_Month = 4500,
                Theyknow = false
            });
            addContract(contract: new Contract
            {
                Id_Nanny = 300,
                IdChild = 102,
                EndDate = new DateTime(2017, 12, 30),
                StartDate = new DateTime(2017, 11, 30),
                IsPerMonth = true,
                IsSigned = true,
                Sal_Per_Hour = 30,
                Sal_Per_Month = 4500,
                Theyknow = false
            });

        }

        protected static Dal_imp dal;

        public static Dal_imp Dal
        {
            get
            {
                if (dal == null)
                    dal = new Dal_imp();
                return dal;
            }
        }

        public static int contract_number = 10000000;

        #region add func

        public void addContract(Contract contract) //Add a contract to the contracts list 
        {

            getMotherFromContract(contract); //Checks if the mother in the contract exists
            if (getNanny(contract.Id_Nanny) == null) //checks if the nanny in the contract exists
                throw new Exception("There is no nanny who corresponds to the one on the contract");
            if(contract.ContractNumber==0)
            contract.ContractNumber = contract_number++;
            DataSource.ContractsList.Add(contract);
        }
      
        public void addMother(Mother mother) //Add a mother to the mothers list
        {
            if(getMother(mother.Id)!=null) //checks if the mother already exists
                throw new Exception("This mother already exists");
            DataSource.MothersList.Add(mother);
        }

        public void addNanny(Nanny nanny) //Add a nanny to the nannies list
        {
            if (getNanny(nanny.Id)!=null) //checks if the nanny already exists
                throw new Exception("This nanny already exists");
            DataSource.NanniesList.Add(nanny);
        }

        public void addChild(Child child) //Add a child to the children list
        {
            if (getChild(child.Id)!=null) //checks if the child already exists 
                throw new Exception("This child already exists");
            DataSource.ChildrenList.Add(child);
        }
        #endregion

        #region lists func
        public List<Nanny> nannyList(Func<Nanny, bool> predicate = null) //return a list of nannies
        {
            if (predicate == null)
                return DataSource.NanniesList;
            return DataSource.NanniesList.Where(predicate).ToList(); //return a specific list of nannies
        }

        public List<Mother> motherList(Func<Mother, bool> predicate = null)//return a list of mothers
        {
            if (predicate == null)
                return DataSource.MothersList;
            return DataSource.MothersList.Where(predicate).ToList(); //return a specific list of mothers
        }

        public List<Child> childrenList(int idMother, Func<Child, bool> predicate = null) //return a list of children from the same mother
        {
            if (DataSource.ChildrenList.Exists(item => item.MotherId == idMother)) 
                return DataSource.ChildrenList.FindAll(item => item.MotherId == idMother);
            else
                throw new Exception("This mother doesn't have children");
        }

        public List<Child> childrenList(Func<Child, bool> predicate = null)//return a list of children
        {
            if (predicate == null)
                return DataSource.ChildrenList;
            return DataSource.ChildrenList.Where(predicate).ToList(); //return a specific list of children
        }

        public List<Contract> contractsList(Func<Contract, bool> predicate = null)//return a list of contracts
        {
            if (predicate == null)
                return DataSource.ContractsList;
            return DataSource.ContractsList.Where(predicate).ToList(); //return a specific list of contracts
        }
        #endregion

        #region del func
        public void delContract(Contract contract) //delete a contract from the list
        {
            if (getContract(contract.ContractNumber) == null) //checks if the contract exists
                throw new Exception("There is no such contract");
            DataSource.ContractsList.RemoveAll(item => item.ContractNumber == contract.ContractNumber);
            
        }

        public void delMother(Mother mother) //delete a mother from the list
        {
            if(getMother(mother.Id)==null) //checks if the mother exists
                throw new Exception("There is no such mother");
            DataSource.MothersList.RemoveAll(item => item.Id == mother.Id);
        }

        public void delNanny(Nanny nanny) //delete a nanny from the list
        {
            if(getNanny(nanny.Id)==null) //checks if the nanny exists
                throw new Exception("There is no such nanny");
            DataSource.NanniesList.RemoveAll(item => item.Id == nanny.Id);
        }

        
        
        public void delChild(Child child) //delete a chils from the list
        {
            if(getChild(child.Id)==null) //checks if the child exists
                throw new Exception("There is no such child");
            DataSource.ChildrenList.RemoveAll(item=>item.Id==child.Id);
        }

        #endregion

        #region update func

        public void updateContract(Contract contract) //update a contract
        {
                delContract(contract);
                addContract(contract); 
        }

        public void updateMother(Mother mother) //update a mother
        {
                delMother(mother);
                addMother(mother);
            
        }

        public void updateNanny(Nanny nanny) //update a nanny
        {
            delNanny(nanny);
            addNanny(nanny);
        }

        public void updateChild(Child child) //update a child
        {
            delChild(child);
            addChild(child);
        }
        #endregion

        #region get func

        public Nanny getNanny(int id) //return a Nanny from her id
        {
            return DataSource.NanniesList.FirstOrDefault(item => item.Id == id); //if the nanny is not found null is returned
        }

        public Mother getMother(int id) //return a mother from her id
        {
            return DataSource.MothersList.FirstOrDefault(item => item.Id == id);//if the mother is not found null is returned
        }

        public Mother getMotherFromContract(Contract contract) //return a mother from a contract
        {
                return getMother(getChild(contract.IdChild).MotherId);
        }

        public Contract getContract(int contractNumber) //return a contract from a contract number
        {
            return DataSource.ContractsList.FirstOrDefault(item => item.ContractNumber == contractNumber);//if the contract is not found null is returned
        }

        public Child getChild(int id) //return a child from his id
        {
            return DataSource.ChildrenList.FirstOrDefault(item => item.Id == id); //if the child is not found null is returned
        }
#endregion
    }
}
