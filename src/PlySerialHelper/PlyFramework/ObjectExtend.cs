using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlyFramework
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectExtend
    {
        /// <summary>
        /// 返回32位数值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt32(this string input)
        {
            int result = 0;
            int.TryParse(input, out result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long ToInt64(this string input)
        {
            long result = 0;
            long.TryParse(input, out result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double ToDouble(this string input)
        {
            double result = 0;
            double.TryParse(input, out result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string input)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(input, out result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ToBool(this string input)
        {
            bool result;
            bool.TryParse(input, out result);
            return result;
        }
    }
}
