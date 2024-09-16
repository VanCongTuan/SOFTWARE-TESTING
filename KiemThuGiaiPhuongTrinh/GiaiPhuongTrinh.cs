using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VanCongTuan_KTPM
{
   public class GiaiPhuongTrinh
    {
        private double a, b, c;
        
        public GiaiPhuongTrinh(double a, double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public GiaiPhuongTrinh(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public string PhuongTrinhBacNhat()
        {            
            if (this.a == 0)
            {
                if (this.b == 0)
                {
                    return "PTVSN";
                }
                else
                {
                    return "PTVN";
                }    
            }
            else
            {
                return Math.Round(-this.b / this.a,2).ToString();
            }             
        }
        public string PhuongTrinhBacHai()
        {            
            if (this.a == 0)
            {
                if (this.b == 0)
                {
                   if (this.c==0) return "PTVSN";
                   else return "PTVN";
                }
                else
                {
                        return Math.Round(-this.c / this.b, 2).ToString();
                }
            }
            else
            {
                double del = this.b * this.b - 4 * this.a * this.c;
                if (del == 0) return Math.Round(-this.b / 2 / this.a, 2).ToString();
                else if (del < 0) return "PTVN";
                else
                {
                    double x1 = Math.Round((-this.b - Math.Sqrt(del)) / 2 / a, 2);
                    double x2= Math.Round((-this.b + Math.Sqrt(del)) / 2 / a, 2);
                    return "X1=" +x1.ToString() + " X2="+x2.ToString();

                }
            }
        }

    }
}
