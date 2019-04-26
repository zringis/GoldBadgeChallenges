using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class Cafe_Repository
    {
        private List<Product> _menuList = new List<Product>();

        public void AddToList(Product prod)
        {
            _menuList.Add(prod);
        }
        public void RemoveFromList(Product prod)
        {
            _menuList.Remove(prod);
        }
        
        public bool RemoveProductFromList(int mealNum)
        {
            bool successful = false;
            foreach (Product prod in _menuList)
            {
                if(prod.MealNumber == mealNum)
                {
                    RemoveFromList(prod);
                    successful = true;
                    break;
                }
            }
            return successful;
        }

        public bool CheckIfExists(int mealNum)
        {
            bool successful = true;
            foreach (Product prod in _menuList)
            {
                if(prod.MealNumber == mealNum)
                {
                    successful = false;
                }
            }
            return successful;
        }

        public List<Product> GetMenu()
        {
            return _menuList;
        }

    }
}
