using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public static class StringExtentions
    {
        /// <summary>
        /// 将字符串转化为整数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this string str,int? defaultValue=null)
        {
            int result;
            if (int.TryParse(str, out result))
                return result;
            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Int数据");
        }

        /// <summary>
        /// 将字符串转化为整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToNInt(this string str)
        {
            int result;
            if (int.TryParse(str, out result))
                return result;
            return null;
        }

        public static long ToLong(this string str, long? defaultValue = null)
        {
            long result;
            if (long.TryParse(str, out result))
                return result;

            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Float数据");
        }

        public static long? ToNLong(this string str)
        {
            long result;
            if (long.TryParse(str, out result))
                return result;
            return null;
        }

        public static long ToByte(this string str, byte? defaultValue = null)
        {
            byte result;
            if (byte.TryParse(str, out result))
                return result;

            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Float数据");
        }

        public static byte? ToNByte(this string str)
        {
            byte result;
            if (byte.TryParse(str, out result))
                return result;
            return null;
        }

        public static decimal ToDecimal(this string str, decimal? defaultValue = null)
        {
            decimal result;
            if (decimal.TryParse(str, out result))
                return result;

            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Decimal数据");
        }

        public static decimal? ToNDecimal(this string str)
        {
            decimal result;
            if (decimal.TryParse(str, out result))
                return result;
            return null;
        }

        public static float ToFloat(this string str, float? defaultValue = null)
        {
            float result;
            if (float.TryParse(str, out result))
                return result;

            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Float数据");
        }

        public static float? ToNFloat(this string str)
        {
            float result;
            if (float.TryParse(str, out result))
                return result;
            return null;
        }


        public static bool ToBoolean(this string str, bool? defaultValue = null)
        {
            bool result;
            if (Boolean.TryParse(str, out result))
                return result;

            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Boolean数据");
        }

        public static bool? ToNBoolean(this string str)
        {
            bool result;
            if (bool.TryParse(str, out result))
                return result;
            return null;
        }

        public static DateTime ToDateTime(this string str, DateTime? defaultValue = null)
        {
            DateTime result;
            if (DateTime.TryParse(str,out result))
                return result;

            if (defaultValue != null)
                return defaultValue.Value;
            throw new Exception("不是有效的Boolean数据");
        }

        public static DateTime? ToNDateTime(this string str)
        {
            DateTime result;
            if (DateTime.TryParse(str, out result))
                return result;
            return null;
        }

        public static Guid ToGuid(this string str)
        {
            Guid result;
            if (Guid.TryParse(str, out result))
                return result;

            throw new Exception("不是有效的Guid数据");
        }

        public static Guid? ToNGuid(this string str)
        {
            Guid result;
            if (Guid.TryParse(str, out result))
                return result;
            return null;
        }

        public static string ToStr(this DateTime? dt, string format = null, string nullValue = "")
        {
            if(dt==null)
            {
                return nullValue;
            }

            if (String.IsNullOrWhiteSpace(format))
                return dt.Value.ToString();

            return dt.Value.ToString(format);
        }

        public static string ToStr<T>(this Nullable<T> obj, string nullOrEmptyValue = "") where T : struct
        {
            if (obj == null)
                return nullOrEmptyValue;

            string val = obj.ToString();
            if (String.IsNullOrWhiteSpace(val))
                return nullOrEmptyValue;

            return val;
        }

        public static string ToStr(this object obj, string nullOrEmptyValue = "")
        {
            if (obj == null)
                return nullOrEmptyValue;

            string val = obj.ToString();
            if (String.IsNullOrWhiteSpace(val))
                return nullOrEmptyValue;

            return val;
        }

        public static string ToStr(this object obj,Func<string,string> handler,string nullOrEmptyValue="")
        {
            if (obj == null)
                return nullOrEmptyValue;

            if (handler == null)
                throw new BusinessException("转化字符串的处理函数不能为空");

            string val = obj.ToString();
            if (String.IsNullOrWhiteSpace(val))
                return nullOrEmptyValue;

            return handler(val);
        }

        public static Guid ToGuid(this object obj)
        {
            if (obj == null)
                throw new SystemException("传入的参数不能为空");

            string strVal = obj.ToString();
            return strVal.ToGuid();
        }

        public static Guid? ToNGuid(this object obj)
        {
            if (obj == null)
                return null;

            string strVal = obj.ToString();
            return strVal.ToGuid();
        }
    }
}
