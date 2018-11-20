using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace BL
{

    class IBL_imp : IBL
    {
        Idal dal = FactoryDal.getDal();

        /// <summary>
        /// The function calculate the salary for a contract, considering if the payment is per month or per hour
        /// The mother get a discount of 0.02% on each child from the second child
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public double salary(Contract contract)
        {
            try
            {
                if (dal.getContract(contract.ContractNumber) == null) //checks if the contract exists
                    throw new Exception("This contract doesn't exist");

                //List of contract of the specific nanny who is on the contract
                List<Contract> nannisContract = dal.contractsList(item => item.Id_Nanny == contract.Id_Nanny); 

                //counting the number of the contracts between the same mother and nanny to get the discount
                int count = nannisContract.Count(item => (dal.getMotherFromContract(item).Id == dal.getMotherFromContract(contract).Id)) - 1;

                //calculate the num of weeks for the period of the contract
                int numOfWeek = (int)(contract.EndDate - contract.StartDate).TotalDays / 7;

                //calculate the amount if the salary is per month
                if (contract.IsPerMonth)
                    return Math.Round(((numOfWeek * (contract.Sal_Per_Month - (contract.Sal_Per_Month * count * 0.02)) / 4)), 2);

                //calculate the amount if the salary is per hour
                Nanny nanny = dal.getNanny(contract.Id_Nanny);
                Mother mother = dal.getMotherFromContract(contract);
                double sumHours = 0;
                TimeSpan start, end;
                for (int i = 0; i < 6; i++) //calculate the number of hours the mother hire the nanny
                {
                    if (mother.NeedsDay[i]&&nanny.DaysOfWork[i])
                    {
                        start = nanny.Week_of_work[i].start > mother.Day_of_keep[i].start ? nanny.Week_of_work[i].start : mother.Day_of_keep[i].start;
                        end = nanny.Week_of_work[i].end > mother.Day_of_keep[i].end ? mother.Day_of_keep[i].end : nanny.Week_of_work[i].end;
                        sumHours += (end - start).TotalHours;
                    }
                }
                return Math.Round((numOfWeek * (contract.Sal_Per_Hour - (contract.Sal_Per_Hour * count * 0.02)) * sumHours), 2);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        #region add func

        /// <summary>
        /// add a contract, checks if the child is not under 3 months and checks if the nanny didn't reach the maximum of children
        /// checks if doesn't exist a contract between the cild and the nanny
        /// </summary>
        /// <param name="contract"></param>
        public void addContract(Contract contract)
        {
            try
            {
                Child child = dal.getChild(contract.IdChild);
                if(dal.contractsList(item=>item.IdChild==contract.IdChild&&item.Id_Nanny==contract.Id_Nanny).Count!=0)
                    throw new Exception("Already exists a contract between this nanny and this child");
                if ((((DateTime.Now.Year - child.DobChild.Year) * 12) + DateTime.Now.Month - child.DobChild.Month) < 3)
                {
                    throw new Exception("The child is under 3 months");
                }

                dal.getMotherFromContract(contract);

                Nanny nanny = dal.getNanny(contract.Id_Nanny);
                if ((dal.contractsList().Count(item => item.Id_Nanny == contract.Id_Nanny)) >= nanny.MaxChildren)
                    throw new Exception("This nanny has reached the maximum of children");
                dal.addContract(contract);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void addMother(Mother mother)
        {
            try
            {
                dal.addMother(mother);
            }
            catch (InvalidCastException e)
            {

                throw e;
            }
        }


        /// <summary>
        /// add a nanny and checks if she's not under 18
        /// </summary>
        /// <param name="nanny"></param>
        public void addNanny(Nanny nanny)
        {
            if ((DateTime.Today - nanny.Dob).TotalDays < 18 * 365)
                throw new Exception("This nanny is under the minimum required age");
            try
            {
                dal.addNanny(nanny);

            }
            catch (InvalidCastException e)
            {

                throw e;
            }

        }


        /// <summary>
        /// add a child and checks if he is not under 3 months
        /// </summary>
        /// <param name="child"></param>
        public void addChild(Child child)
        {
            try
            {
                if ((((DateTime.Now.Year - child.DobChild.Year) * 12) + DateTime.Now.Month - child.DobChild.Month) < 3)
                {
                    throw new Exception("The child is under 3 months");
                }
                dal.addChild(child);
            }
            catch (InvalidCastException e)
            {

                throw e;
            }
        }

        #endregion

        #region lists func

        public List<Child> childrenList(Func<Child, bool> predicate = null)
        {
            try
            {
                return dal.childrenList(predicate);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Child> childrenList(int idMother, Func<Child, bool> predicate = null)
        {
            try
            {
                return dal.childrenList(idMother, predicate);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Contract> contractsList(Func<Contract, bool> predicate = null)
        {
            try
            {
                return dal.contractsList(predicate);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Mother> motherList(Func<Mother, bool> predicate = null)
        {
            try
            {
                return dal.motherList(predicate);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Nanny> nannyList(Func<Nanny, bool> predicate = null)
        {
            try
            {
                return dal.nannyList(predicate);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        #endregion

        #region del func
        public void delContract(Contract contract,bool anyway=false)
        {
            try
            {
                if (DateTime.Compare(contract.EndDate, DateTime.Now) > 0 && !anyway)
                {
                    throw new Exception("Contract can not be canceled before the end of the period");
                }
                dal.delContract(contract);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void delMother(Mother mother)
        {
            try
            {
                if (dal.childrenList(item => item.MotherId == mother.Id).Count != 0)
                    throw new Exception("You can't remove the mother before you remove her children");

                dal.delMother(mother);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void delNanny(Nanny nanny)
        {
            try
            {
                if (dal.contractsList(item => item.Id_Nanny == nanny.Id).Count != 0)
                {
                    throw new Exception("You can't remove this nanny before you remove her contracts");
                }
                dal.delNanny(nanny);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void delChild(Child child)
        {
            try
            {
                if (dal.contractsList(item => item.IdChild == child.Id).Count != 0)
                {
                    throw new Exception("You can't remove this child before you remove all the contracts who are related to him");
                }
                dal.delChild(child);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region update func
        public void updateContract(Contract contract)
        {
            try
            {
                dal.updateContract(contract);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void updateMother(Mother mother)
        {
            try
            {
                dal.updateMother(mother);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void updateNanny(Nanny nanny)
        {
            try
            {
                dal.updateNanny(nanny);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void updateChild(Child child)
        {
            try
            {
                dal.updateChild(child);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion


        /// <summary>
        /// return a list of nannies who fit exactly the hours the mother need
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public List<Nanny> appropriate(Mother mother)
        {
            try
            {
                List<Nanny> appropriated = new List<Nanny>();
                //check if the nanny start to work before the mother or finish to work after the mother she'll be include in the list
                foreach (var item in dal.nannyList())
                {
                    bool flag = true;
                    for (int i = 0; i < 6; i++)
                        if (item.Week_of_work[i].start > mother.Day_of_keep[i].start || item.Week_of_work[i].end < mother.Day_of_keep[i].end)
                            flag = false;
                    if (flag)
                        appropriated.Add(item);
                }
                if (appropriated.Count() == 0)
                    throw new Exception("There are no appropriated nannies, try with more flexible hours");
                return appropriated;

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        /// <summary>
        /// return a list of 5 mothers who are the most appropriate for the mother's hours
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public List<Nanny> flexAppropriate(Mother mother)
        {
            try
            {

                List<Nanny> appropriated = new List<Nanny>();
                //create a dictionnary of nanny where the key means the difference of the time between the mother and the nanny
                Dictionary<double, Nanny> differenceTime = new Dictionary<double, Nanny>();
                foreach (var item in dal.nannyList())
                {
                    double difference = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        difference += (((item.Week_of_work[i].start - mother.Day_of_keep[i].start).Duration().TotalMinutes) +
                            (item.Week_of_work[i].end - mother.Day_of_keep[i].end).Duration().TotalMinutes);
                    }
                    differenceTime.Add(difference, item);
                }

                //create a list of the keys to sort them
                var list = differenceTime.Keys.ToList();
                list.Sort();

                //add the 5 shortest time difference in a list
                int count = differenceTime.Count();
                for (int i = 0; i < count && i < 5; i++)
                {
                    appropriated.Add(differenceTime[list[i]]);
                }

                if (appropriated.Count() == 0)
                    throw new Exception("There are no nannies");
                return appropriated;



            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<Child> noNanniesFound()
        {
            try
            {
                List<Child> noNanniesFound = new List<Child>();
                foreach (var item in dal.childrenList())
                {
                    bool flag = false;
                    foreach (var i in dal.contractsList())
                    {
                        if (item.Id == i.IdChild)
                            flag = true;
                    }
                    if (!flag)
                        noNanniesFound.Add(item);
                }
                if (noNanniesFound.Count() == 0)
                    throw new Exception("All the children have a nanny");
                return noNanniesFound;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Nanny> tamatNannies()
        {
            try
            {
                var tamatNannies = dal.nannyList(item => item.IsTamat);
                if (tamatNannies.Count() == 0)
                    throw new Exception("There are no nannies who work with tamat vacations");
                return tamatNannies;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Contract> condContracts(Func<Contract, bool> predicate)
        {
            try
            {
                var condContracts = dal.contractsList(predicate);
                if (condContracts.Count() == 0)
                    throw new Exception("There are no contracts with this condition");
                return condContracts;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int numCondContracts(Func<Contract, bool> predicate)
        {
            try
            {
                var condContracts = dal.contractsList(predicate);
                if (condContracts.Count() == 0)
                    throw new Exception("There are no contracts with this condition");
                return condContracts.Count();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// calculate the current total salary for a specific nanny
        /// </summary>
        /// <param name="idNanny"></param>
        /// <returns></returns>
        public double salaryNanny(int idNanny)
        {
            try
            {
                double totalSalary = 0;
                foreach (var item in dal.contractsList(item => item.Id_Nanny == idNanny))
                {
                    totalSalary += salary(item);
                }
                return totalSalary;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// calculate the totalm payment of a mother
        /// </summary>
        /// <param name="idMother"></param>
        /// <returns></returns>
        public double payMother(int idMother)
        {
            try
            {
                double totalPay = 0;
                var motherContracts = dal.contractsList(item => dal.getMotherFromContract(item).Id == idMother);
                foreach (var item in motherContracts)
                {
                    totalPay += salary(item);
                }
                return totalPay;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Child> childSpecialNeeds()
        {
            try
            {
                List<Child> specialNeeds = dal.childrenList(item => item.IsSpecialNeeds);
                if (specialNeeds.Count() == 0)
                    throw new Exception("There is no child with special needs");
                return specialNeeds;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Nanny> nannyWithExperience(int num)
        {
            try
            {
                List<Nanny> nannyWithExperience = dal.nannyList(item => item.ExpYears >= num);
                if (nannyWithExperience.Count() == 0)
                    throw new Exception("There is no nanny with minimum " + num.ToString() + " years of experience");
                return nannyWithExperience;

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public IEnumerable<IGrouping<int, Nanny>> groupedNannies(bool min, bool order = false)
        {
            try
            {
                if (min)
                {
                    var groupedMin = from item in dal.nannyList()
                                     group item by item.MinAgeMonth;
                    if (order)
                    {
                        var grouped1 = from item in dal.nannyList()
                                       orderby item.MinAgeMonth
                                       group item by item.MinAgeMonth;
                    }
                    return groupedMin;
                }
                else
                {
                    var groupedMax = from item in dal.nannyList()
                                     group item by item.MaxAgeMonth;
                    if (order)
                    {
                        var grouped1 = from item in dal.nannyList()
                                       orderby item.MaxAgeMonth
                                       group item by item.MaxAgeMonth;
                    }
                    return groupedMax;
                }

            }

            catch (Exception e)
            {

                throw e;
            }
        }


        public IEnumerable<IGrouping<int, Contract>> GroupedContract(bool order = false)
        {
            try
            {
                if (order)
                {
                  var orderResult = from item in dal.contractsList()
                             let a = CalcDistance(dal.getMotherFromContract(item).ResearchAddress, dal.getNanny(item.Id_Nanny).Address, TravelType.Driving)
                             orderby a
                             group item by a / 100 into g
                             select g;
                    return orderResult;
                }


                var result = from item in dal.contractsList()
                             group item by CalcDistance(dal.getMotherFromContract(item).ResearchAddress, dal.getNanny(item.Id_Nanny).Address, TravelType.Driving) / 100 into g
                             select g;
                return result;
               
            }
            catch (Exception e)
            {

                throw e;
            }
        }

      
        public int CalcDistance(string source, string dest, TravelType travelType)
        {
            Leg leg = null;
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = travelType == TravelType.Walking ? TravelMode.Walking : TravelMode.Driving,
                    Origin = source,
                    Destination = dest,
                };

                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                leg = route.Legs.First();
                return leg.Distance.Value;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        /// <summary>
        /// return a list of nanny who are in a appropriate distance with the mother
        /// </summary>
        /// <param name="mother"></param>
        /// <param name="m"></param>
        /// <param name="travelType"></param>
        /// <returns></returns>
        public List<Nanny> appropriateDistance(Mother mother, double m, TravelType travelType)
        {
            try
            {
                //return the relevant address to calculate the distance
                string address = mother.ResearchAddress == null ? mother.MotherAddress : mother.ResearchAddress;
                List<Nanny> appropriateDistance = new List<Nanny>();
                foreach (var item in dal.nannyList())
                {
                    if (CalcDistance(address, item.Address, travelType) <= m * 1000)
                        appropriateDistance.Add(item);
                }

                if (appropriateDistance.Count() == 0)
                    throw new Exception("There are no appropriate Nannies");
                return appropriateDistance;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Nanny getNanny(int id)
        {
            return dal.getNanny(id);
        }

        public Child getChild(int id)
        {
            return dal.getChild(id);
        }

        public Mother getMother(int id)
        {
            return dal.getMother(id);
        }

        public Contract getContract(int contractNumber1)
        {
            return dal.getContract(contractNumber1);
        }

        /// <summary>
        /// this function return a list of nanny with the conditions of the mother
        /// </summary>
        /// <param name="selectedMother"></param>
        /// <param name="flexible" ></param>boolean to check If the mother has flexible hours
        /// <param name="distance"></param> The maximum distance the mother has accepted
        /// <param name="byCar"></param> boolean to calculate the distance by car or by walk
        /// <param name="minYears"></param> the minimum years of experience required by the mother
        /// <param name="maxFloor"></param> maximum floor required by the mother
        /// <param name="elevator"></param> boolean to know if the mother wants an elevator
        /// <param name="tamat"></param> boolean to know if the mother wants tamat vacations
        /// <returns></returns>
        public List<Nanny> findNanny(Mother selectedMother, bool flexible, int distance, bool byCar, int minYears, int maxFloor, bool elevator, bool tamat)
        {
            List<Nanny> foundNannies;
            if (flexible)
                foundNannies = flexAppropriate(selectedMother);
            else
                foundNannies = appropriate(selectedMother);

            TravelType type;
            if (byCar)
                type = TravelType.Driving;
            else
                type = TravelType.Walking;
            try
            {
                List<Nanny> appropriateDistanceList = appropriateDistance(selectedMother, distance, type);
                //using linq to filter similar nannies between 2 lists
                var result = from nanny1 in foundNannies
                             from nanny2 in appropriateDistanceList
                             where nanny1.Id == nanny2.Id
                             select nanny1;
                foundNannies = result.ToList();

            }
            catch (Exception)
            {

                throw new Exception("There is no adapted nanny");
            }
            
            
            // result = result.Distinct();
            
            //filtering the nannies by the condition of the mother
            foundNannies =foundNannies.FindAll(item => item.ExpYears >= minYears &&
            item.Floor <= maxFloor && item.IsTamat == tamat);

            //the elevator condition must to be separate because if the boolean is false doesn't mean the mother
            //doesnt want an elevator
            if (elevator)
                foundNannies.FindAll(item => item.Elevator);

            if (foundNannies.Count() == 0)
                throw new Exception("There is no adapted nanny");
            return foundNannies;
        }

    }
}
