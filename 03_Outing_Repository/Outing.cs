using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Outing_Repository
{
    /*Event Type Golf, Bowling, Amusement Park, Concert 
         number of people that attended
         date
         total cost per person for the event
         total cost for the event*/
    public enum OutingType { Golf = 1, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public OutingType OutingEvent { get; set; }
        public int NumberAttended { get; set; }
        public DateTime DateOfOuting { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCostOfEvent { get; set; }

        public Outing()
            {
            }
        public Outing(OutingType outingType, int numberAttended, DateTime dateOfOuting, double costPerPerson, double totalCostOfEvent)
        {
            OutingEvent = outingType;
            NumberAttended = numberAttended;
            DateOfOuting = dateOfOuting;
            CostPerPerson = costPerPerson;
            TotalCostOfEvent = totalCostOfEvent;
        }
    }
}
