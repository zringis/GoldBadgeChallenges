using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Outing_Repository
{
    public class Outing_Repository
    {
        /*Event Type Golf, Bowling, Amusement Park, Concert 
         number of people that attended
         date
         total cost per person for the event
         total cost for the event*/

        private List<Outing> _outingList = new List<Outing>();

        public List<Outing> GetOutingList()
        {
            return _outingList;
        }

        public void AddToList(Outing outing)
        {
            _outingList.Add(outing);
        }
        public double ViewTotalOutingCostByType(OutingType outingType)
        {
            double total = 0; 
            foreach(Outing outing in _outingList)
            {
                if(outing.OutingEvent == outingType)
                {
                    
                    total += outing.TotalCostOfEvent;
                }
            }
            return total;
        }
        public double ViewTotalOutingCostForAll()
        {
            double total = 0;
            foreach (Outing outing in _outingList)
            {
                total += outing.TotalCostOfEvent;
            }
            return total;
        }

    }
}
