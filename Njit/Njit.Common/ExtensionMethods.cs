using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ExtensionMethods
{
    public static bool IsNullOrEmpty(this object value)
    {
        if (value == null)
            return true;
        if (value == DBNull.Value)
            return true;
        if ((value as string) == "")
            return true;
        return false;
    }

    //public static bool IsNullOrWhiteSpace(this object value)
    //{
    //    if (value == null)
    //        return true;
    //    if (value == DBNull.Value)
    //        return true;
    //    if (string.IsNullOrWhiteSpace(value.ToString()))
    //        return true;
    //    return false;
    //}

    public static bool IsNumber(this string value)
    {
        decimal d;
        return decimal.TryParse(value, out d);
    }

    public static string GetString(this System.Net.IPAddress ip)
    {
        return ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? ip.ToString() : "[" + ip.ToString() + "]";
    }

    public static int ToInt(this string value)
    {
        return int.Parse(value);
    }

    public static int? TryToInt(this string value)
    {
        int i;
        if (int.TryParse(value, out i))
            return i;
        return null;
    }

    public static long ToLong(this string value)
    {
        return long.Parse(value);
    }

    public static long? TryToLong(this string value)
    {
        long i;
        if (long.TryParse(value, out i))
            return i;
        return null;
    }

    public static float ToFloat(this string value)
    {
        return float.Parse(value);
    }

    public static float? TryToFloat(this string value)
    {
        float i;
        if (float.TryParse(value, out i))
            return i;
        return null;
    }

    public static double ToDouble(this string value)
    {
        return double.Parse(value);
    }

    public static double? TryToDouble(this string value)
    {
        double i;
        if (double.TryParse(value, out i))
            return i;
        return null;
    }

    public static string GetText(this TimeSpan timeSpan)
    {
        string v = "";
        if (timeSpan.Days != 0)
            v += (v == "" ? "" : " و ") + Math.Abs(timeSpan.Days) + " روز";
        if (timeSpan.Hours != 0)
            v += (v == "" ? "" : " و ") + Math.Abs(timeSpan.Hours) + " ساعت";
        if (timeSpan.Minutes != 0)
            v += (v == "" ? "" : " و ") + Math.Abs(timeSpan.Minutes) + " دقیقه";
        if (timeSpan.Seconds != 0)
            v += (v == "" ? "" : " و ") + Math.Abs(timeSpan.Seconds) + " ثانیه";
        return v;
    }
}
