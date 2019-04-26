using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet_Repository
{
    public class Greet_Repository
    {
        private List<Greet> _greet = new List<Greet>();

        

        #region Create
        public void AddToList(Greet greeting)
        {
            _greet.Add(greeting);
        }
        #endregion

        #region Read
        public List<Greet> ViewList()
        {
            List<Greet> orderedList = _greet.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            return orderedList;
        }

        public int GetListCount()
        {
            int listcount = _greet.Count();
            return listcount;
        }
        #endregion

        #region Updates
        public void UpdateFirstName(string firstNameToLower, string lastNameToLower, string newFirstName)
        {
            foreach (Greet greeting in _greet)
            {
                if(firstNameToLower == greeting.FirstName.ToLower() && lastNameToLower == greeting.LastName.ToLower())
                {
                    greeting.FirstName = newFirstName;
                }
            }
        }
        public void UpdateLastName(string firstNameToLower, string lastNameToLower, string newLastName)
        {
            foreach (Greet greeting in _greet)
            {
                if (firstNameToLower == greeting.FirstName.ToLower() && lastNameToLower == greeting.LastName.ToLower())
                {
                    greeting.LastName = newLastName;
                }
            }
        }
        public void UpdateCustomerType(string firstNameToLower, string lastNameToLower, CustomerType customerType)
        {
            foreach (Greet greeting in _greet)
            {
                if (firstNameToLower == greeting.FirstName.ToLower() && lastNameToLower == greeting.LastName.ToLower())
                {
                    greeting.Type = customerType;
                }
            }
        }
        public void UpdateEmail(string firstNameToLower, string lastNameToLower, string emailMessage)
        {
            foreach (Greet greeting in _greet)
            {
                if (firstNameToLower == greeting.FirstName.ToLower() && lastNameToLower == greeting.LastName.ToLower())
                {
                    greeting.Email = emailMessage;
                }
            }
        }
        #endregion

        #region Delete
        public void DeleteFromList(string firstNameToLower, string lastNameToLower)
        {
            foreach(Greet greeting in _greet)
            {
                if (firstNameToLower == greeting.FirstName.ToLower() && lastNameToLower == greeting.LastName.ToLower())
                {
                    DeleteCustomer(greeting);
                    break;
                }
            }
        }

        public void DeleteCustomer(Greet greeting)
        {
            _greet.Remove(greeting);
        }
        #endregion
    }
}
