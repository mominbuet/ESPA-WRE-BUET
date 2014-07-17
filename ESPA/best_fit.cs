using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESPA
{
    class best_fit
    {
        double getSum(List<double> lst) {
            double res = 0.0;
            foreach (double val in lst)
                res += val;
            return res;
        }
        double getSquareSum(List<double> lst)
        {
            double res = 0.0;
            foreach (double val in lst)
                res += (val*val);
            return res;
        }
        double getSumXY(Dictionary<double, double> values) {
            double res = 0.0;
            foreach (double val in values.Keys.ToList()) 
                res+=(val * values[val]);
            
            return res;
        }
        public Tuple<double,double> getAB(Dictionary<double, double> values) {
            Tuple<double, double> res;
            List<double> Xkeys = values.Keys.ToList();
            List<double> Yvals = values.Values.ToList();
            double xSum =getSum(Xkeys);
            double ySum = getSum(Yvals);
            double xSquareSum =getSquareSum(Xkeys);
            double XYSum = getSumXY(values);
            double A = ((xSum * XYSum) - (xSquareSum * ySum)) / (xSum * xSum - values.Count * xSquareSum);
            double B = (1 / xSum) * (ySum - ((values.Count * xSum * XYSum - xSquareSum * ySum) / (xSum * xSum - values.Count*xSquareSum)));
            res = new Tuple<double, double>(A, B);
            return res;
        }
    }
}
