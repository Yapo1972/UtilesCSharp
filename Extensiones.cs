using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionesComunes
{
    public static class Extensiones
    {
        public static decimal ToDecimal(this object Obj)
        {
            decimal result = 0;
            if(Obj.ToString() != "") result = Convert.ToDecimal(Obj.ToString());
            return result;
        }
        public static int ToEntero( this object Obj)
        {
            int result=0;
            if (Obj.ToString() != "") result = Convert.ToInt32(Obj.ToString());
            return result;
        }
        public static string ToFecha(this object Obj)
        {
            string Result = DateTime.Today.ToShortDateString();
            if (Obj.ToString() != "") Result = Convert.ToDateTime(Obj).ToShortDateString();
            return Result;
        }
    }
}