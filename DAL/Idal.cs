using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        void addNanny(Nanny nanny);
        void delNanny(Nanny nanny);
        void updateNanny(Nanny nanny);
        Nanny getNanny(int id);

        void addMother(Mother mother);
        void delMother(Mother mother);
        void updateMother(Mother mother);
        Mother getMother(int id);
        Mother getMotherFromContract(Contract contract);

        void addContract(Contract contract);
        void delContract(Contract contract);
        void updateContract(Contract contract);
        Contract getContract(int contractNumber);

        void addChild(Child child);
        void delChild(Child child);
        void updateChild(Child child);
        Child getChild(int id);

        List<Nanny> nannyList(Func<Nanny,bool> predicate=null);
        List<Mother> motherList(Func<Mother, bool> predicate = null);
        List<Child> childrenList(int idMother, Func<Child, bool> predicate = null);
        List<Child> childrenList(Func<Child, bool> predicate = null);
        List<Contract> contractsList(Func<Contract, bool> predicate = null);

    }
}
