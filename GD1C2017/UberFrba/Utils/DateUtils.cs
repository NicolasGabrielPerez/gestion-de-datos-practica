using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Utils
{
    class DateUtils
    {

        static String format = "yyyy-MM-dd hh:mm:ss"; 

        public static String stringFromDate(DateTime time) {
            return time.ToString(format);
        }

    }
}
