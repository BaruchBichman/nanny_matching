using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace BL
{
    public enum TravelType
    {
        Walking,
        Driving
    }
    public interface IBL
    {
        void addNanny(Nanny nanny);
        void delNanny(Nanny nanny);
        void updateNanny(Nanny nanny);

        void addMother(Mother mother);
        void delMother(Mother mother);
        void updateMother(Mother mother);

        void addContract(Contract contract);
        void delContract(Contract contract, bool anyway);
        void updateContract(Contract contract);

        void addChild(Child child);
        void delChild(Child child);
        void updateChild(Child child);


        List<Nanny> nannyList(Func<Nanny, bool> predicate = null);
        List<Mother> motherList(Func<Mother, bool> predicate = null);
        List<Child> childrenList(int idMother, Func<Child, bool> predicate = null);
        List<Child> childrenList(Func<Child, bool> predicate = null);
        List<Contract> contractsList(Func<Contract, bool> predicate = null);

        Nanny getNanny(int id);
        Child getChild(int id);
        Mother getMother(int id);
        Contract getContract(int contractNumber);

        List<Nanny> appropriate(Mother mother); //return list of nanny who have the same hours of the mothers
        List<Nanny> flexAppropriate(Mother mother); //return list of 5 nannies who have the most appropriate hours 
        List<Nanny> tamatNannies(); //return list of nannies who work with tamay vacations
        List<Nanny> appropriateDistance(Mother mother, double km, TravelType travelType);   //list of nanny in the given distance
        List<Child> noNanniesFound();   //return list of child who dont have nannies        
        List<Child> childSpecialNeeds();    //return list of children with special needs
        List<Contract> condContracts(Func<Contract, bool> predicate);   //return list of contracts with a specific condition
        List<Nanny> nannyWithExperience(int num); //return list of nannies who have a minimum years of experience
        List<Nanny> findNanny(Mother selectedMother, bool flexible, int distance, bool byCar, int minYears, int maxFloor, bool elevator, bool tamat);//list of nanny with specific conditions

        IEnumerable<IGrouping<int, Nanny>> groupedNannies(bool min, bool order = false); //group the nannies by minimum or maximum age accepted for the children
        IEnumerable<IGrouping<int, Contract>> GroupedContract(bool order = false); //group the contract by distance

        int numCondContracts(Func<Contract, bool> predicate);//return number of contracts with specific condition
        int CalcDistance(string source, string dest, TravelType travelType); //calculate a distance between 2 addresses
        double salary(Contract contract); //calculate salary for a contract
        double payMother(int idMother); //calculate the payment for a mother
        double salaryNanny(int idNanny); //return the salary for a nanny


    }
}
