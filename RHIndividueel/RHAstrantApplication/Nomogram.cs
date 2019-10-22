using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHAstrantApplication
{
    class Nomogram
    {
        /*
         * 
         * scoring (formula): Here is also the formula (Buono et al. 1989) that the nomogram is based on, where predicted VO2max is in L/min, HRss is the steady heart rate after 6 min of exercise, and the workload in kg.m/min. To convert a load in watts to kg.m/min, multiply the watts by 6.12.
females: VO2max = (0.00193 x workload + 0.326) / (0.769 x HRss - 56.1) x 100
males: VO2max = (0.00212 x workload + 0.299) / (0.769 x HRss - 48.5) x 100
         *
         * 
         * 
         * HRss         ==  Steady heartrate BMP
         * workload     ==  kg.m/min
         * VO2max       ==  L/min
         */


        public static double getVO2Male(double workload, double HRss)
        {
            return (0.00212 * workload + 0.299)
            / (0.769 * HRss - 48.5)
            * 100;
        }

        public static double getVO2Female(double workload, double HRss)
        {
            return (0.00193 * workload + 0.326) 
            / (0.769 * HRss - 56.1) 
            * 100;
        }

    }
}
