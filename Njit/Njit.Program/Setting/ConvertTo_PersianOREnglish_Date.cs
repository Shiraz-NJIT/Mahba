using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

public class ConvertTo_PersianOREnglish_Date
{
    /// <summary>
    /// گرفتن روزهای فارسی هفته
    /// </summary>
    /// <param name="_DateTime"></param>
    public static string GetDayOfWeek(DateTime _DateTime)
    {
        if ((int)_DateTime.DayOfWeek == 0)
        {
            return "یکشنبه";
        }
        if ((int)_DateTime.DayOfWeek == 1)
        {
            return "دوشنبه";
        }
        if ((int)_DateTime.DayOfWeek == 2)
        {
            return "سه شنبه";
        }
        if ((int)_DateTime.DayOfWeek == 3)
        {
            return "چهار شنبه";
        }
        if ((int)_DateTime.DayOfWeek == 4)
        {
            return "پنج شنبه";
        }
        if ((int)_DateTime.DayOfWeek == 5)
        {
            return " جمعه";
        }

        else { return "شنبه"; }
    }
    public static string GetPersianTodayDate()
    {
        DateTime date = DateTime.Today;
        string todayp = ConvertTo_PersianOREnglish_Date.GetPersianDate(date.ToString());
        todayp = GetYears(todayp) + "/" + GetMonths(todayp) + "/" + GetDays(todayp);
        return todayp;
    }
    public static string GetPersianTodayDay()
    {
        DateTime date = DateTime.Today;
        string todayp = ConvertTo_PersianOREnglish_Date.GetPersianDate(date.ToString());
        todayp = GetDays(todayp);
        return todayp;
    }
    public static string GetPersianTodayMonth()
    {
        DateTime date = DateTime.Today;
        string todayp = ConvertTo_PersianOREnglish_Date.GetPersianDate(date.ToString());
        todayp = GetMonths(todayp);
        return todayp;
    }
    public static string GetPersianTodayYear()
    {
        DateTime date = DateTime.Today;
        string todayp = ConvertTo_PersianOREnglish_Date.GetPersianDate(date.ToString());
        todayp = GetYears(todayp);
        return todayp;
    }
    public static DateTime GetEglishDate(string _Fdate)
    {
        //    //int day=Convert.ToInt32(GetDay(_Fdate));
        //    //if (day==31)
        //    //{
        //    //    _Fdate = GetYear(_Fdate) +"/"+ GetMonth(_Fdate) + "/28";
        //    //}
        //    //if (day == 30)
        //    //{
        //    //    _Fdate = GetYear(_Fdate) +"/"+ GetMonth(_Fdate) + "/28";
        //    //}
        //    //if (day == 29)
        //    //{
        //    //    _Fdate = GetYear(_Fdate) +"/"+ GetMonth(_Fdate) + "/28";
        //    //}
        PersianCalendar p = new PersianCalendar();
        //    //DateTime fdate = Convert.ToDateTime(_Fdate);
        //    //GregorianCalendar gcalendar = new GregorianCalendar();
        //    //DateTime eDate = p.ToDateTime(
        //    //       gcalendar.GetYear(fdate),
        //    //       gcalendar.GetMonth(fdate),
        //    //       gcalendar.GetDayOfMonth(fdate),
        //    //       gcalendar.GetHour(fdate),
        //    //       gcalendar.GetMinute(fdate),
        //    //       gcalendar.GetSecond(fdate), 0);
        return p.ToDateTime(GetYear(_Fdate), GetMonth(_Fdate), GetDay(_Fdate), 0, 0, 0, 0);
    }
    public static string GetPersianDate(string _Fdate)
    {

        PersianCalendar p = new PersianCalendar();
        DateTime fdate = Convert.ToDateTime(_Fdate);
        return p.GetYear(fdate) + "/" + p.GetMonth(fdate) + "/" + p.GetDayOfMonth(fdate);
    }
    public static string GetYears(string text)
    {
        return text.Substring(0, 4);
    }
    public static string GetMonths(string text)
    {
        if (text.IndexOf("/", 5) == 7)
            return text.Substring(5, 2);
        else
        {
            return "0" + text.Substring(5, 1);
        }
    }
    public static string GetDays(string text)
    {
        if (text.IndexOf("/", 5) == 7)
        {
            if (text.Length == 10)
            {
                return text.Substring(8, 2);
            }
            else
            {
                return "0" + text.Substring(8, 1);
            }
        }
        else
        {
            if (text.Length == 9)
            {
                return text.Substring(7, 2);
            }
            else
            {
                return "0" + text.Substring(7, 1);
            }
        }
    }
    public static int GetYear(string text)
    {
        return Convert.ToInt32(text.Substring(0, 4));
    }
    public static int GetMonth(string text)
    {
        if (text.IndexOf("/", 5) == 7)
            return Convert.ToInt32(text.Substring(5, 2));
        else
        {
            return Convert.ToInt32("0" + text.Substring(5, 1));
        }
    }
    public static int GetDay(string text)
    {
        if (text.IndexOf("/", 5) == 7)
        {
            if (text.Length == 10)
            {
                return Convert.ToInt32(text.Substring(8, 2));
            }
            else
            {
                return Convert.ToInt32(text.Substring(8, 1));
            }
        }
        else
        {
            if (text.Length == 9)
            {
                return Convert.ToInt32(text.Substring(7, 2));
            }
            else
            {
                return Convert.ToInt32(text.Substring(7, 1));
            }
        }
    }

    public static string GetPersianDate(DateTime date)
    {
        string _Fdate = date.ToShortDateString();
        PersianCalendar p = new PersianCalendar();
        DateTime fdate = Convert.ToDateTime(_Fdate);
        return p.GetYear(fdate) + "/" + p.GetMonth(fdate) + "/" + p.GetDayOfMonth(fdate);
    }

    public static string GetDay(DateTime date)
    {
        string text = GetPersianDate(date);

        if (text.IndexOf("/", 5) == 7)
        {
            if (text.Length == 10)
            {
                return text.Substring(8, 2);
            }
            else
            {
                return "0" + text.Substring(8, 1);
            }
        }
        else
        {
            if (text.Length == 9)
            {
                return text.Substring(7, 2);
            }
            else
            {
                return "0" + text.Substring(7, 1);
            }
        }
    }
}
