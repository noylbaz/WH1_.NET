//Noy Elbaz 315073122
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH1_NoyElbaz
{
    public static class Extension //extension Course  Class 
    {
        public static string ShowGrade(this Course c, int index)
        {
            return c[index];
        }
    }
}
