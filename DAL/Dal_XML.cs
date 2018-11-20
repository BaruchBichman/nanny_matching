using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace DAL
{
    class Dal_XML : Idal
    {

        private Dal_XML()
        {

            if (!File.Exists(motherPath))
                CreateFiles();
            else
                LoadData();
            initNanysMothersandChilds();

        }

        protected static Dal_XML dal;
        public static Dal_XML Dal
        {
            get
            {
                if (dal == null)
                    dal = new Dal_XML();
                return dal;
            }
        }

        XElement motherRoot;
        string motherPath = @"motherXml.xml";

        XElement childRoot;
        string childPath = @"childXml.xml";

        XElement contractRoot;
        string contractPath = @"contractXml.xml";

        XElement nannyRoot;
        string nannyPath = @"nannyXml.xml";

        private void CreateFiles()
        {
            motherRoot = new XElement("mothers");
            motherRoot.Save(motherPath);

            childRoot = new XElement("children");
            childRoot.Save(childPath);

            contractRoot = new XElement("contracts");
            contractRoot.Save(contractPath);

            nannyRoot = new XElement("nannies");
            nannyRoot.Save(nannyPath);

        }
        private void LoadData()
        {
            try
            {
                motherRoot = XElement.Load(motherPath);
                childRoot = XElement.Load(childPath);
                contractRoot = XElement.Load(contractPath);
                nannyRoot = XElement.Load(nannyPath);

                motherRoot.RemoveAll();
                childRoot.RemoveAll();
                contractRoot.RemoveAll();
                nannyRoot.RemoveAll();
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }


        #region child func

        XElement ConvertChild(BE.Child child)
        {
            XElement childElement = new XElement("child");
            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                if (item.GetValue(child, null) != null)
                {
                    childElement.Add(new XElement(item.Name, item.GetValue(child, null).ToString()));
                }
                else
                {
                    childElement.Add(new XElement(item.Name, ""));
                }
            }
            return childElement;

        }

        BE.Child ConvertChild(XElement element)
        {
            Child child = new Child();
            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = null;
                if (item != null)
                    convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
                if (item.CanWrite)
                    item.SetValue(child, convertValue);
            }
            return child;
        }

        public void addChild(Child child)
        {
            if (getChild(child.Id) != null)
                throw new Exception("This child already exists");
            childRoot.Add(ConvertChild(child));
            childRoot.Save(childPath);
        }

        public void delChild(Child child)
        {
            XElement toRemove = (from item in childRoot.Elements()
                                 where int.Parse(item.Element("Id").Value) == child.Id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Child with the same id not found");

            toRemove.Remove();
            childRoot.Save(childPath);
        }

        public void updateChild(Child child)
        {
            delChild(child);
            addChild(child);
        }

        public Child getChild(int id)
        {
            XElement childTemp = null;
            try
            {
                childTemp = (from item in childRoot.Elements()
                             where int.Parse(item.Element("Id").Value) == id
                             select item).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
            if (childTemp == null)
                return null;
            return ConvertChild(childTemp);
        }

        
        public List<Child> childrenList(int idMother, Func<Child, bool> predicate = null)
        {
            //if (DataSource.ChildrenList.Exists(item => item.MotherId == idMother))
            //    return DataSource.ChildrenList.FindAll(item => item.MotherId == idMother);
            //else
            //    throw new Exception("This mother doesn't have children");
            List<Child> children = (from item in childRoot.Elements()
                                    let a = ConvertChild(item)
                                    where a.MotherId == idMother
                                    select a).ToList();
            if (children.Count == 0)
                throw new Exception("This mother doesn't have children");
          
                return children; 
                
        }

        public List<Child> childrenList(Func<Child, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (from item in childRoot.Elements()
                        let a = ConvertChild(item)
                        where predicate(a)
                        select a).ToList();
            }
            return (from item in childRoot.Elements()
                    select ConvertChild(item)).ToList();
        }

        #endregion

        #region mother func

        XElement convertDayOfWork(DayOfWork dayOfWork)
        {
            XElement day = new XElement("day", dayOfWork.day.ToString());
            XElement start = new XElement("start", dayOfWork.start.ToString());
            XElement end = new XElement("end", dayOfWork.end.ToString());
            XElement dayOfWorkElement = new XElement("dayOfWork");
            dayOfWorkElement.Add(day, start, end);
            return dayOfWorkElement;
        }

        DayOfWork convertDayOfWork(XElement xElement)
        {
            DayOfWork dayOfWork = new DayOfWork();
            dayOfWork.day = Convert.ToInt32(xElement.Element("day").Value);
            dayOfWork.start = TimeSpan.Parse(xElement.Element("start").Value);
            dayOfWork.end = TimeSpan.Parse(xElement.Element("end").Value);
            return dayOfWork;
        }



        XElement convertDay_of_keep(DayOfWork[] Day_of_keep, string name)
        {
            XElement Day_of_keepElement = new XElement(name);
            foreach (var item in Day_of_keep)
            {
                Day_of_keepElement.Add(new XElement(convertDayOfWork(item)));
            }
            return Day_of_keepElement;
        }

        BE.DayOfWork[] convertDay_of_keep(XElement xElement)
        {
            BE.DayOfWork[] dayOfWork = new BE.DayOfWork[6];
            for (int i = 0; i < 6; i++)
            {
                dayOfWork[i] = convertDayOfWork(xElement.Elements().ToList()[i]);
            }
            return dayOfWork;
        }

        XElement convertNeedsDay(bool[] needsDay, string name)
        {
            XElement needsDayElement = new XElement(name);
            foreach (var item in needsDay)
            {
                needsDayElement.Add(new XElement("day", item.ToString()));
            }
            return needsDayElement;
        }

        bool[] convertNeedsDay(XElement xElement)
        {
            bool[] needsday = new bool[6];
            for (int i = 0; i < 6; i++)
                needsday[i] = bool.Parse(xElement.Elements().ToList()[i].Value);

            return needsday;
        }

        XElement convertMother(BE.Mother mother)
        {
            XElement motherElement = new XElement("mother");
            motherElement.Add(new XElement("Id", mother.Id.ToString()));
            motherElement.Add(new XElement("FamilyName", mother.FamilyName));
            motherElement.Add(new XElement("FirstName", mother.FirstName));
            motherElement.Add(new XElement("MotherAddress", mother.MotherAddress));
            motherElement.Add(new XElement("ResearchAddress", mother.ResearchAddress));
            motherElement.Add(new XElement("Phone", mother.Phone));
            motherElement.Add(convertNeedsDay(mother.NeedsDay, "needs_day"));
            motherElement.Add(convertDay_of_keep(mother.Day_of_keep, "Day_of_keep"));
            motherElement.Add(new XElement("Remarks", mother.Remarks));
            return motherElement;
        }

        BE.Mother convertMother(XElement xElement)
        {
            Mother mother = new Mother();
            mother.Id = Convert.ToInt32(xElement.Element("Id").Value);
            mother.FamilyName = xElement.Element("FamilyName").Value;
            mother.FirstName = xElement.Element("FirstName").Value;
            mother.MotherAddress = xElement.Element("MotherAddress").Value;
            mother.Phone = xElement.Element("Phone").Value;
            mother.Remarks = xElement.Element("Remarks").Value;
            mother.ResearchAddress = xElement.Element("ResearchAddress").Value;
            mother.NeedsDay = convertNeedsDay(xElement.Element("needs_day"));
            mother.Day_of_keep = convertDay_of_keep(xElement.Element("Day_of_keep"));
            return mother;
        }
        public void addMother(Mother mother)
        {
            motherRoot.Add(convertMother(mother));
            motherRoot.Save(motherPath);
        }
        public void delMother(Mother mother)
        {
            XElement toRemove = (from item in motherRoot.Elements()
                                 where int.Parse(item.Element("Id").Value) == mother.Id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Mother with the same id not found...");

            toRemove.Remove();
            motherRoot.Save(motherPath);
        }
        public Mother getMother(int id)
        {

            XElement motherTemp = null;
            try
            {
                motherTemp = (from item in motherRoot.Elements()
                              where int.Parse(item.Element("Id").Value) == id
                              select item).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
            if (motherTemp == null)
                return null;
            return convertMother(motherTemp);

        }
        public Mother getMotherFromContract(Contract contract)
        {
            return getMother(getChild(contract.IdChild).MotherId);
        }
        public List<Mother> motherList(Func<Mother, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (from item in motherRoot.Elements()
                        let a = convertMother(item)
                        where predicate(a)
                        select a).ToList();
            }
            return (from item in motherRoot.Elements()
                    select convertMother(item)).ToList();

        }
        public void updateMother(Mother mother)
        {
            delMother(mother);
            addMother(mother);
        }

        #endregion

        #region contract func

        public static int contract_number = 10000000;
        XElement ConvertContract(BE.Contract contract)
        {
            XElement contractElement = new XElement("contract");

            foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
                contractElement.Add
                     (new XElement(
                    item.Name, item.GetValue(contract, null).ToString()
                    ));

            return contractElement;
        }
        BE.Contract ConvertContract(XElement element)
        {
            BE.Contract contract = new Contract();
            foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                if (item.CanWrite)
                    item.SetValue(contract, convertValue);
            }

            return contract;
        }

        public void addContract(Contract contract)
        {
            if (getContract(contract.ContractNumber) != null)
                throw new Exception("This contract already exists");
            if (contract.ContractNumber == 0)
                contract.ContractNumber = contract_number++;
            contractRoot.Add(ConvertContract(contract));
            contractRoot.Save(contractPath);

        }
        public List<Contract> contractsList(Func<Contract, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (from item in contractRoot.Elements()
                        let a = ConvertContract(item)
                        where predicate(a)
                        select a).ToList();
            }
            return (from item in contractRoot.Elements()
                    select ConvertContract(item)).ToList();
        }
        public void delContract(Contract contract)
        {
            XElement toRemove = (from item in contractRoot.Elements()
                                 where int.Parse(item.Element("ContractNumber").Value) == contract.ContractNumber
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Contract with the same number not found...");

            toRemove.Remove();
            contractRoot.Save(contractPath);
        }
        public Contract getContract(int contractNumber)
        {
            XElement contractTemp = null;
            try
            {
                contractTemp = (from item in contractRoot.Elements()
                                where int.Parse(item.Element("ContractNumber").Value) == contractNumber
                                select item).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
            if (contractTemp == null)
                return null;
            return ConvertContract(contractTemp);
        }
        public void updateContract(Contract contract)
        {
            delContract(contract);
            addContract(contract);
        }

        #endregion

        #region nanny func

        BE.Nanny convertNanny(XElement xElement)
        {
            Nanny nanny = new Nanny();
            nanny.Id = int.Parse(xElement.Element("Id").Value);
            nanny.FamilyName = xElement.Element("FamilyName").Value;
            nanny.FirstName = xElement.Element("FirstName").Value;
            nanny.Phone = xElement.Element("Phone").Value;
            nanny.Address = xElement.Element("Address").Value;
            nanny.Recommendations = xElement.Element("Recommendations").Value;
            nanny.ExpYears = int.Parse(xElement.Element("ExpYears").Value);
            nanny.MaxChildren = int.Parse(xElement.Element("MaxChildren").Value);
            nanny.MinAgeMonth = int.Parse(xElement.Element("MinAgeMonth").Value);
            nanny.MaxAgeMonth = int.Parse(xElement.Element("MaxAgeMonth").Value);
            nanny.Floor = int.Parse(xElement.Element("Floor").Value);
            nanny.IsSalPerHour = bool.Parse(xElement.Element("IsSalPerHour").Value);
            nanny.Elevator = bool.Parse(xElement.Element("Elevator").Value);
            nanny.IsTamat = bool.Parse(xElement.Element("IsTamat").Value);
            nanny.Dob = DateTime.Parse(xElement.Element("Dob").Value);
            nanny.SalPerHour = double.Parse(xElement.Element("SalPerHour").Value);
            nanny.SalPerMonth = double.Parse(xElement.Element("SalPerMonth").Value);
            nanny.DaysOfWork = convertNeedsDay(xElement.Element("DaysOfWork"));
            nanny.Week_of_work = convertDay_of_keep(xElement.Element("Week_of_work"));
            return nanny;
        }

        XElement convertNanny(BE.Nanny nanny)
        {
            XElement nannyElement = new XElement("nanny");
            nannyElement.Add(new XElement("Id", nanny.Id.ToString()));
            nannyElement.Add(new XElement("FamilyName", nanny.FamilyName));
            nannyElement.Add(new XElement("FirstName", nanny.FirstName));
            nannyElement.Add(new XElement("Phone", nanny.Phone));
            nannyElement.Add(new XElement("Address", nanny.Address));
            nannyElement.Add(new XElement("Recommendations", nanny.Recommendations));
            nannyElement.Add(new XElement("ExpYears", nanny.ExpYears.ToString()));
            nannyElement.Add(new XElement("MaxChildren", nanny.MaxChildren.ToString()));
            nannyElement.Add(new XElement("MinAgeMonth", nanny.MinAgeMonth.ToString()));
            nannyElement.Add(new XElement("MaxAgeMonth", nanny.MaxAgeMonth.ToString()));
            nannyElement.Add(new XElement("Floor", nanny.Floor.ToString()));
            nannyElement.Add(new XElement("IsSalPerHour", nanny.IsSalPerHour.ToString()));
            nannyElement.Add(new XElement("Elevator", nanny.Elevator.ToString()));
            nannyElement.Add(new XElement("IsTamat", nanny.IsTamat.ToString()));
            nannyElement.Add(new XElement("Dob", nanny.Dob.ToString()));
            nannyElement.Add(new XElement("SalPerHour", nanny.SalPerHour.ToString()));
            nannyElement.Add(new XElement("SalPerMonth", nanny.SalPerMonth.ToString()));
            nannyElement.Add(convertNeedsDay(nanny.DaysOfWork, "DaysOfWork"));
            nannyElement.Add(convertDay_of_keep(nanny.Week_of_work, "Week_of_work"));
            return nannyElement;
        }

        public void updateNanny(Nanny nanny)
        {
            delNanny(nanny);
            addNanny(nanny);
        }
        public void addNanny(Nanny nanny)
        {
            nannyRoot.Add(convertNanny(nanny));
            nannyRoot.Save(nannyPath);
        }
        public void delNanny(Nanny nanny)
        {
            XElement toRemove = (from item in nannyRoot.Elements()
                                 where int.Parse(item.Element("Id").Value) == nanny.Id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("This Nanny doesn't exist");

            toRemove.Remove();
            nannyRoot.Save(motherPath);
        }
        public Nanny getNanny(int id)
        {
            XElement nannyTemp = null;
            try
            {
                nannyTemp = (from item in nannyRoot.Elements()
                             where int.Parse(item.Element("Id").Value) == id
                             select item).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
            if (nannyTemp == null)
                return null;
            return convertNanny(nannyTemp);
        }
        public List<Nanny> nannyList(Func<Nanny, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (from item in nannyRoot.Elements()
                        let a = convertNanny(item)
                        where predicate(a)
                        select a).ToList();
            }
            return (from item in nannyRoot.Elements()
                    select convertNanny(item)).ToList();
        }
        #endregion



        private void initNanysMothersandChilds()
        {
            addNanny(new Nanny
            {
                Address = "בית ישראל 3, ירושלים",
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
                Address = "מלכי ישראל 20, ירושלים",
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
                Address = "הועד הלאומי 21, ירושלים",
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
                Address = "פסח חברוני 120, ירושלים",
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
                Address = "הקבלן 16, ירושלים",
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
                Address = "כנפי נשרים 30, ירושלים",
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
                MaxAgeMonth = 18,
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
                Address = "הרצל 80, ירושלים",
                FirstName = "Ruhami",
                FamilyName = "Vorona",
                Id = 306,

                
                Dob = new DateTime(1996, 09, 22),
                MaxChildren = 8,
                MinAgeMonth = 0,
                MaxAgeMonth = 18,
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
                Address = "הרב קוק 10, ירושלים",
                FirstName = "Sarah",
                FamilyName = "Cohen",
                Id = 307,

                
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
                MotherAddress = "הרב פרנק 17, ירושלים",
                Id = 203,
                FirstName = "Avia",
                FamilyName = "Abitan",
                Phone = "056787677",
                ResearchAddress = "הפיסגה 20, ירושלים",
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
                MotherAddress = "שאולזון 30, ירושלים",
                Id = 202,
                FirstName = "Chaya",
                FamilyName = "Levi",
                Phone = "056787677",
                ResearchAddress = "הקבלן 48, ירושלים",
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
                ResearchAddress = "שרי ישראל 20, ירושלים",
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
                ResearchAddress = " סורוצקין 30, ירושלים",
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


    }
}
