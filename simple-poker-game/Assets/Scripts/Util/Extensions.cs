using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util
{
    public static class Extensions
    {
        public static int Replace<T>(List<T> list, T oldValue, T newValue)
        {
            if (list == null)
            {
                throw new ArgumentNullException("playerDeck");
            }

            var index = list.IndexOf(oldValue);
            if (index != -1)
            {
                list[index] = newValue;
            }

            return index;
        }
    }
}
