using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public class CheckLockException : Exception
    {
        public CheckLockException(int errorCode)
            : base(GetMessage(errorCode))
        {

        }

        private static string GetMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    return ("قفل سخت افزاری پیدا نشد");
                case 2:
                    return ("قفل سخت افزاری که متصل شده است مربوط به این نرم افزار نیست");
                case 3:
                    return ("قفل سخت افزاری با قفل دیگری جابجا شده است\r\nبرا حل این مشکل سیستم سرور را ریست نمایید");
                case 4:
                    return ("خطا در ثبت اطلاعات در قفل سخت افزاری");
                case 5:
                    return ("خطا در اتصال به شبکه");
                case 6:
                    return ("خطا در اتصال به سرور قفل سخت افزاری");
                case 7:
                    return ("دسترسی شما به نرم افزار غیر مجاز است. دسترسی بیش از تعداد کاربران تعریف شده امکان پذیر نیست");
                case 9:
                    return ("خطا در خواندن اطلاعات در شبکه");
                case 10:
                    return ("داده های قفل سخت افزاری نامعتبر است");
                case 11:
                    return ("قفل به اشتراک گذاشته شده است");
                case 12:
                    return ("Query نامعتبر است");
                case -1000:
                    return ("فایل مربوط به قفل سخت افزاری پیدا نشد");
                case -1001:
                    return ("فایل مربوط به قفل سخت افزاری نامعتبر است");
                case -1002:
                    return ("تاریخ انقضای نرم افزار به پایان رسیده است");
                case -1003:
                    return ("قفل سخت افزاری پیدا شده مربوط به شرکت پیشتازان فن آوری نسل جدید ایرانیان نیست");
                default:
                    return "خطا در بررسی قفل سخت افزاری";
            }
        }
    }
}
