using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace PL
{
    class Program
    {
        static IBL bl = FactoryBl.getBL();

        static void Main(string[] args)
        {
        //    bl.addChild(new Child
        //    {
        //        Id = 100,
        //        DobChild = new DateTime(2014, 11, 27),
        //        FirstName = "yosi",
        //        IsSpecialNeeds = false,
        //        MotherId = 200

        //    });
        //    bl.addChild(
        //        new Child
        //        {
        //            Id = 101,
        //            DobChild = new DateTime(1990, 4, 28),
        //            FirstName = "yosi2",
        //            IsSpecialNeeds = false,
        //            MotherId = 200
        //        });

        //    bl.addChild(
        //       new Child
        //       {
        //           Id = 102,
        //           DobChild = new DateTime(2015, 4, 28),
        //           FirstName = "yosi5",
        //           IsSpecialNeeds = true,
        //           MotherId = 201
        //       });

        //    bl.addChild(
        //      new Child
        //      {
        //          Id = 103,
        //          DobChild = new DateTime(2016, 4, 28),
        //          FirstName = "yosi7",
        //          IsSpecialNeeds = false,
        //          MotherId = 201
        //      });
        
        //    bl.addMother(new Mother
        //    {
        //        FamilyName = "geleer",
        //        Phone = "0556691448",
        //        ResearchAddress = "בית ישראל 3 , ירושלים",
        //        FirstName = "chaya",
        //        Id = 200,
        //        MotherAddress = "פסח חברוני 120, ירושלים",
        //        Day_of_keep
        //        = new DayOfWork[]
        //        {
        //           new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //        },
        //        NeedsDay = new bool[] { true, true, true, true, true, true },

        //    });

        //    bl.addMother(new Mother
        //    {
        //        FamilyName = "cohen",
        //        Phone = "0556691448",
        //        ResearchAddress = "בית ישראל 3 , ירושלים",
        //        FirstName = "rivki",
        //        Id = 201,
        //        MotherAddress = "פסח חברוני 120, ירושלים",
        //        Day_of_keep
        //        = new DayOfWork[]
        //        {
        //           new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //        },
        //        NeedsDay = new bool[] { true, true, true, true, true, true },

        //    });

        //    bl.addNanny(new Nanny
        //    {
        //        Address = "צפניה 19, ירושלים",
        //        Dob = new DateTime(1990, 3, 3),
        //        Elevator = true,
        //        ExpYears = 12,
        //        SalPerHour = 23,
        //        FamilyName = "Baya",
        //        FirstName = "sari",
        //        Floor = 2,
        //        Id = 300,
        //        Phone = "0548455555",
        //        IsSalPerHour = true,
        //        IsTamat = false,
        //        MaxAgeMonth = 36,
        //        MaxChildren = 5,
        //        SalPerMonth = 4000,
        //        MinAgeMonth = 4,
        //        DaysOfWork = new bool[] { true, true, true, true, true, true },
        //        Week_of_work = new DayOfWork[]
        //{
        //           new DayOfWork { day = 0, end = new TimeSpan(8, 30, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(9, 20, 0), start = new TimeSpan(9, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(8, 0, 0), start = new TimeSpan(7, 0, 0) } ,
        //},

        //    });

        //    bl.addNanny(new Nanny
        //    {
        //        Address = "צפניה 19, ירושלים",
        //        Dob = new DateTime(1990, 3, 3),
        //        Elevator = true,
        //        ExpYears = 12,
        //        SalPerHour = 23,
        //        FamilyName = "gutman5",
        //        FirstName = "sari5",
        //        Floor = 2,
        //        Id = 301,
        //        Phone = "0548455555",
        //        IsSalPerHour = true,
        //        IsTamat = false,
        //        MaxAgeMonth = 36,
        //        MaxChildren = 5,
        //        SalPerMonth = 4000,
        //        MinAgeMonth = 4,
        //        DaysOfWork = new bool[] { true, true, true, true, true, true },
        //        Week_of_work = new DayOfWork[]
        //        {
        //           new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //        },

        //    });

        //    bl.addNanny(new Nanny
        //    {
        //        Address = "צפניה 19, ירושלים",
        //        Dob = new DateTime(1990, 3, 3),
        //        Elevator = true,
        //        ExpYears = 12,
        //        SalPerHour = 23,
        //        FamilyName = "gutman1",
        //        FirstName = "sari1",
        //        Floor = 2,
        //        Id = 302,
        //        Phone = "0548455555",
        //        IsSalPerHour = true,
        //        IsTamat = false,
        //        MaxAgeMonth = 36,
        //        MaxChildren = 5,
        //        SalPerMonth = 4000,
        //        MinAgeMonth = 4,
        //        DaysOfWork = new bool[] { true, true, true, true, true, true },
        //        Week_of_work = new DayOfWork[]
        //      {
        //           new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(14, 0, 0), start = new TimeSpan(10, 30, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(19, 0, 0), start = new TimeSpan(9, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //      },

        //    });


        //    bl.addNanny(new Nanny
        //    {
        //        Address = "צפניה 19, ירושלים",
        //        Dob = new DateTime(1990, 3, 3),
        //        Elevator = true,
        //        ExpYears = 12,
        //        SalPerHour = 23,
        //        FamilyName = "gutman3",
        //        FirstName = "sari3",
        //        Floor = 2,
        //        Id = 303,
        //        Phone = "0548455555",
        //        IsSalPerHour = true,
        //        IsTamat = false,
        //        MaxAgeMonth = 36,
        //        MaxChildren = 5,
        //        SalPerMonth = 4000,
        //        MinAgeMonth = 4,
        //        DaysOfWork = new bool[] { true, true, true, true, true, true },
        //        Week_of_work = new DayOfWork[]
        //     {
        //           new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(11, 0, 0), start = new TimeSpan(9, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(20, 0, 0), start = new TimeSpan(10, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(11, 0, 0), start = new TimeSpan(7, 0, 0) } ,
        //     },

        //    });

        //    bl.addNanny(new Nanny
        //    {
        //        Address = "צפניה 19, ירושלים",
        //        Dob = new DateTime(1990, 3, 3),
        //        Elevator = true,
        //        ExpYears = 12,
        //        SalPerHour = 23,
        //        FamilyName = "gutman2",
        //        FirstName = "sari2",
        //        Floor = 2,
        //        Id = 304,
        //        Phone = "0548455555",
        //        IsSalPerHour = true,
        //        IsTamat = false,
        //        MaxAgeMonth = 36,
        //        MaxChildren = 5,
        //        SalPerMonth = 4000,
        //        MinAgeMonth = 1,
        //        DaysOfWork = new bool[] { true, true, true, true, true, true },
        //        Week_of_work = new DayOfWork[]
        //   {
        //           new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(12, 0, 0), start = new TimeSpan(9, 0, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(11, 0, 0), start = new TimeSpan(7, 0, 0) } ,
        //   },

        //    });

        //    bl.addNanny(new Nanny
        //    {
        //        Address = "צפניה 19, ירושלים",
        //        Dob = new DateTime(1990, 3, 3),
        //        Elevator = true,
        //        ExpYears = 1,
        //        SalPerHour = 23,
        //        FamilyName = "gutman4",
        //        FirstName = "sari4",
        //        Floor = 2,
        //        Id = 305,
        //        Phone = "0548455555",
        //        IsSalPerHour = true,
        //        IsTamat = false,
        //        MaxAgeMonth = 36,
        //        MaxChildren = 5,
        //        SalPerMonth = 4000,
        //        MinAgeMonth = 4,
        //        DaysOfWork = new bool[] { true, true, true, true, true, true },
        //        Week_of_work = new DayOfWork[]
        //     {
        //           new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(7, 0, 0) } ,
        //           new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 20, 0) } ,
        //           new DayOfWork { day = 2, end = new TimeSpan(15, 30, 0), start = new TimeSpan(7, 0, 0) } ,
        //           new DayOfWork { day = 3, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 4, end = new TimeSpan(17, 45, 0), start = new TimeSpan(8, 0, 0) } ,
        //           new DayOfWork { day = 5, end = new TimeSpan(10, 0, 0), start = new TimeSpan(7, 0, 0) } ,
        //     },

        //    });

        //    bl.addContract(contract: new Contract
        //    {
        //        Id_Nanny = 300,
        //        IdChild = 100,
        //        EndDate = new DateTime(2017, 12, 30),
        //        StartDate = new DateTime(2017, 11, 30),
        //        IsPerMonth = true,
        //        IsSigned = true,
        //        Sal_Per_Hour = 30,
        //        Sal_Per_Month = 4500,
        //        Theyknow = false
        //    });

        //    bl.addContract(contract: new Contract
        //    {
        //        Id_Nanny = 301,
        //        IdChild = 101,
        //        EndDate = new DateTime(2017, 12, 30),
        //        StartDate = new DateTime(2017, 11, 30),
        //        IsPerMonth = true,
        //        IsSigned = true,
        //        Sal_Per_Hour = 30,
        //        Sal_Per_Month = 4500,
        //        Theyknow = false
        //    });

        //    bl.addContract(contract: new Contract
        //    {
        //        Id_Nanny = 300,
        //        IdChild = 102,
        //        EndDate = new DateTime(2017, 12, 30),
        //        StartDate = new DateTime(2017, 11, 30),
        //        IsPerMonth = true,
        //        IsSigned = true,
        //        Sal_Per_Hour = 30,
        //        Sal_Per_Month = 4500,
        //        Theyknow = false
        //    });

            foreach (var item in bl.nannyList())
            {
                Console.WriteLine(item + "\n");
            }

            foreach (var item in bl.contractsList())
            {
                Console.WriteLine(item + "\n");
            }

            foreach (var item in bl.motherList())
            {
                Console.WriteLine(item + "\n");
            }


            foreach (var item in bl.childrenList())
            {
                Console.WriteLine(item + "\n");
            }

            foreach (var item in bl.childrenList())
            {
                Console.WriteLine(item + "\n");
            }




            Console.WriteLine(bl.salary(bl.contractsList().First()));
            // Console.WriteLine(bl.appropriate(bl.motherList().First()).First());


            // bl.delChild(bl.childrenList().First());//עובד
            //bl.updateChild(new Child
            //{
            //    Id = 333334843,
            //    DobChild = new DateTime(2016, 4, 28),
            //    FirstName = "yosi7",
            //    IsSpecialNeeds = true,
            //    MotherId = 200843567
            //});

            foreach (var item in bl.childrenList())
            {
                Console.WriteLine(item + "\n");
            }

            bl.flexAppropriate(bl.motherList().First());
            foreach (var item in bl.flexAppropriate(bl.motherList().First()))
                Console.WriteLine(item);

            foreach (var item in bl.contractsList())
                Console.WriteLine(bl.salary(item));

            Console.WriteLine(bl.salaryNanny(301));


            //foreach (var item in bl.noNanniesFound())
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(bl.payMother(201));


            //foreach (var item in bl.childSpecialNeeds())
            //    Console.WriteLine(item);

            //foreach (var item in bl.nannyWithExperience(5))
            //    Console.WriteLine(item);

            foreach (IGrouping<int, Nanny> item in bl.groupedNannies(true))
                if (item.Key == 6)
                    foreach (var n in item)
                        Console.WriteLine(n);

            foreach(var item in bl.appropriateDistance(bl.motherList().FirstOrDefault(), 15,TravelType.Driving))
            {
                Console.WriteLine(item);
            }
        }
    }
}
