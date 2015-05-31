﻿using System;
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
    }
}