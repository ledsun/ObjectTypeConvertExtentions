using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ObjectExtentions.TypeConvert
{
    /// <summary>
    /// オブジェクト型から各種型への変換用拡張メソッドクラス
    /// </summary>
    public static class ObjectTypeConvertExtentions
    {
        //sqlserver compact の制限（1/1/1753 12:00:00 AM から 12/31/9999 11:59:59 PM までの間でなければなりません。）
        public static DateTime DateTimeDefault = System.DateTime.Parse("1/1/1753 12:00:00");

        /// <summary>
        /// 値を日付に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0相当の日付値、それ以外は変換された値</returns>
        public static DateTime DateTime(this object val)
        {
            return val.IsNull() ? DateTimeDefault
                : val is SqlDateTime ? ((SqlDateTime)val).Value
                : Convert.ToDateTime(val);
        }

        /// <summary>
        /// 値を日付に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0相当の日付値、それ以外は変換された値</returns>
        public static DateTime? DateTimeNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }

            if (val is SqlDateTime)
            {
                return ((SqlDateTime)val).Value;
            }

            return Convert.ToDateTime(val);
        }

        /// <summary>
        /// 値を数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された数値</returns>
        public static Decimal Decimal(this object val)
        {
            return val.IsNull() ? 0 : Convert.ToDecimal(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を値をnull対応の数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された数値</returns>
        public static Decimal? DecimalNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToDecimal(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を浮動少数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された値</returns>
        public static double Double(this object val)
        {
            return val.IsNull() ? 0 : Convert.ToDouble(val);
        }

        /// <summary>
        /// 値をnull対応の少数に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された値</returns>
        public static double? DoubleNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToDouble(val);
        }

        /// <summary>
        /// 値を正数に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された数値</returns>
        public static uint UInt(this object val)
        {
            return val.IsNull() ? 0 : Convert.ToUInt32(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値をnull対応の整数に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された値</returns>
        public static uint? UIntNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToUInt32(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された数値</returns>
        public static int Int(this object val)
        {
            return val.IsNull() ? 0 : Convert.ToInt32(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値をnull対応の数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された数値</returns>
        public static int? IntNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToInt32(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された数値</returns>
        public static System.Int16 Int16(this object val)
        {
            return val.IsNull() ? (Int16)0 : Convert.ToInt16(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値をnull対応の数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された数値</returns>
        public static System.Int16? Int16Null(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToInt16(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された数値</returns>
        public static System.Int64 Int64(this object val)
        {
            return val.IsNull() ? (Int64)0 : Convert.ToInt64(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値をnull対応の数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された数値</returns>
        public static System.Int64? Int64Null(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToInt64(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は0、それ以外は変換された数値</returns>
        public static System.Byte Byte(this object val)
        {
            return val.IsNull() ? (Byte)0 : Convert.ToByte(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値をnull対応の数値に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合はnull、それ以外は変換された数値</returns>
        public static System.Byte? ByteNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return Convert.ToByte(val, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// 値を文字列に変換する
        /// </summary>
        /// <param name="val">変換元の値</param>
        /// <returns>nullの場合は空文字、それ以外は変換された文字</returns>
        public static string String(this object val)
        {
            return val.IsNull() ? "" : val.ToString();
        }

        /// <summary>
        /// 0はFalseそれ以外の数字はTrue
        /// 文字列の場合はTrue、False、数字は変換可能（大文字小文字を区別しない）。それ以外は例外を出す
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool Bool(this object val)
        {
            return val.IsNull() ? false : ToBoolean(val);
        }

        /// <summary>
        /// nullはnull
        /// 0はFalseそれ以外の数字はTrue
        /// 文字列の場合はTrue、False、数字は変換可能（大文字小文字を区別しない）。それ以外は例外を出す
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool? BoolNull(this object val)
        {
            if (val.IsNull())
            {
                return null;
            }
            return ToBoolean(val);
        }

        /// <summary>
        /// 数字だけの文字列は数値に変えて変換します。
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static bool ToBoolean(object val)
        {
            if (val is string && Regex.IsMatch((string)val, "^-?[0-9]+$"))
            {
                val = val.Int();
            }
            return Convert.ToBoolean(val);
        }

        /// <summary>
        /// オブジェクトがNULLを表すものかどうかを返す
        /// </summary>
        /// <param name="val">判定する値</param>
        /// <returns>true:null false:null以外</returns>
        private static bool IsNull(this object val)
        {
            return (null == val || val is DBNull);
        }
        
         /// <summary>
        /// Kishor Naik
        /// kishor.naik011.net@gmail.com
        /// Convert Object to any Specified Type 
        /// </summary>
        /// <typeparam name="T">Specified Type</typeparam>
        /// <param name="Obj">Specified Object</param>
        /// <returns>Specified Return Type</returns>
        public static T ConvertTo<T>(this Object Obj)
        {
            T TObj = default(T);
            try
            {
                TObj = (T) Convert.ChangeType(Obj, typeof (T));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return TObj;
        }
       
    }

}
