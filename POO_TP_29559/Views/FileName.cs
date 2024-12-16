using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Views
{
    public abstract class Meal
    {
       public abstract void Calories();
    }
    public class VegetarianMeal : Meal
    {
        public override void Calories()
        {
            throw new NotImplementedException();
        }
    }
}
