using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Njit.Program
{
    public class InputBoxValidationHelper
    {
        public enum InputTypes
        {
            AllCharacters,
            Number,
            DecimalNumber,
            ShortInt,
            Int,
            LongInt,
            Float,
            Double,
            Decimal,
            PersianText,
            EnglishText,
            Mobile,
            NationalCode,
            Email
        }

        public static bool CheckValidation(IInputBox control, out string errorText)
        {
            switch (control.InputType)
            {
                case InputBoxValidationHelper.InputTypes.AllCharacters:
                    break;
                case InputBoxValidationHelper.InputTypes.LongInt:
                case InputBoxValidationHelper.InputTypes.Number:
                    if (!(control.LongValue.HasValue) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "مقدار عددی به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.Decimal:
                case InputBoxValidationHelper.InputTypes.DecimalNumber:
                    if (!(control.DecimalValue.HasValue) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "مقدار اعشاری به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.ShortInt:
                    if (!(control.ShortValue.HasValue) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "مقدار عددی به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.Int:
                    if (!(control.IntValue.HasValue) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "مقدار عددی به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.Float:
                    if (!(control.FloatValue.HasValue) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "مقدار اعشاری به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.Double:
                    if (!(control.DoubleValue.HasValue) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "مقدار اعشاری به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.PersianText:
                    foreach (char ch in control.Text)
                    {
                        if (!IsPersianChar(ch))
                        {
                            errorText = "فقط باید حروف فارسی وارد کنید";
                            return false;
                        }
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.EnglishText:
                    foreach (char ch in control.Text)
                    {
                        if (!IsEnglishChar(ch))
                        {
                            errorText = "فقط باید حروف انگلیسی وارد کنید";
                            return false;
                        }
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.Mobile:
                    if (!IsMobile(control.Text) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "شماره موبایل به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.NationalCode:
                    if (!IsNationalCode(control.Text) && (!(control.Text == "" && control.AllowEmptyText)))
                    {
                        errorText = "کد ملی به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                case InputBoxValidationHelper.InputTypes.Email:
                    if (!control.Text.Contains('@') || control.Text.EndsWith("@"))
                    {
                        errorText = "ایمیل به صورت صحیح وارد نشده است";
                        return false;
                    }
                    break;
                default:
                    throw new Exception();
            }
            if (control.Text.Length < control.MinLength && (!(control.Text == "" && control.AllowEmptyText)))
            {
                errorText = (string.Format("حداقل طول متن باید {0} حرف باشد", control.MinLength));
                return false;
            }
            if (control.Text.Length > control.MaxLength)
            {
                errorText = (string.Format("حداکثر طول متن باید {0} حرف باشد", control.MaxLength));
                return false;
            }
            if (control.MinValue.HasValue && (!(control.Text == "" && control.AllowEmptyText)))
            {
                if (control.FloatValue.Value < control.MinValue.Value)
                {
                    errorText = (string.Format("مقدار وارد شده نباید از {0} کوچکتر باشد", control.MinValue.Value));
                    return false;
                }
            }
            if (control.MaxValue.HasValue && (!(control.Text == "" && control.AllowEmptyText)))
            {
                if (control.FloatValue.Value > control.MaxValue.Value)
                {
                    errorText = (string.Format("مقدار وارد شده نباید از {0} بزرگتر باشد", control.MaxValue.Value));
                    return false;
                }
            }
            errorText = null;
            return true;
        }

        public static bool CheckKeyPressed(char keyChar, IInputBox control, out string errorText)
        {
            if (control.IllegalCharacters.Contains(keyChar))
            {
                errorText = ("حروف " + string.Join<char>(",", control.IllegalCharacters.ToArray()) + " مجاز نیستند");
                return false;
            }
            else
            {
                switch (control.InputType)
                {
                    case InputBoxValidationHelper.InputTypes.AllCharacters:
                        break;
                    case InputBoxValidationHelper.InputTypes.Number:
                        if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.DecimalNumber:
                        if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] && control.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]))
                        {
                            errorText = ("عدد اعشاری را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.PersianText:
                        if (!char.IsControl(keyChar) && !InputBoxValidationHelper.IsPersianChar(keyChar))
                        {
                            errorText = ("فقط حروف فارسی وارد کنید");
                            return false;
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.EnglishText:
                        if (!char.IsControl(keyChar) && !InputBoxValidationHelper.IsEnglishChar(keyChar))
                        {
                            errorText = ("فقط حروف انگلیسی وارد کنید");
                            return false;
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.ShortInt:
                        if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar) || keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            string text = control.GetNewText(keyChar);
                            if (text == "-")
                                text = "-0";
                            short t;
                            if (!short.TryParse(text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), ""), out t))
                            {
                                errorText = (string.Format("محدوده عدد باید بین {0} و {1} باشد", short.MinValue.ToString(), short.MaxValue.ToString()));
                                return false;
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.Int:
                        if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar) || keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            string text = control.GetNewText(keyChar);
                            if (text == "-")
                                text = "-0";
                            int t;
                            if (!int.TryParse(text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), ""), out t))
                            {
                                errorText = (string.Format("محدوده عدد باید بین {0} و {1} باشد", int.MinValue.ToString(), int.MaxValue.ToString()));
                                return false;
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.LongInt:
                        if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar) || keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            string text = control.GetNewText(keyChar);
                            if (text == "-")
                                text = "-0";
                            long t;
                            if (!long.TryParse(text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), ""), out t))
                            {
                                errorText = (string.Format("محدوده عدد باید بین {0} و {1} باشد", long.MinValue.ToString(), long.MaxValue.ToString()));
                                return false;
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.Float:
                        if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] && control.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("عدد اعشاری را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar) || keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            string text = control.GetNewText(keyChar);
                            if (text == "-")
                                text = "-0";
                            float t;
                            if (!float.TryParse(text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), ""), out t))
                            {
                                errorText = (string.Format("محدوده عدد باید بین {0} و {1} باشد", float.MinValue.ToString(), float.MaxValue.ToString()));
                                return false;
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.Double:
                        if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] && control.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("عدد اعشاری را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar) || keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            string text = control.GetNewText(keyChar);
                            if (text == "-")
                                text = "-0";
                            double t;
                            if (!double.TryParse(text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), ""), out t))
                            {
                                errorText = (string.Format("محدوده عدد باید بین {0} و {1} باشد", double.MinValue.ToString(), double.MaxValue.ToString()));
                                return false;
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.Decimal:
                        if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] && control.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            errorText = ("عدد اعشاری را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0] && control.SelectionStart != 0)
                        {
                            errorText = ("عدد را به صورت صحیح وارد کنید");
                            return false;
                        }
                        else if (!char.IsControl(keyChar) && !char.IsDigit(keyChar) && keyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar) || keyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                        {
                            string text = control.GetNewText(keyChar);
                            if (text == "-")
                                text = "-0";
                            decimal t;
                            if (!decimal.TryParse(text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), ""), out t))
                            {
                                errorText = (string.Format("محدوده عدد باید بین {0} و {1} باشد", decimal.MinValue.ToString(), decimal.MaxValue.ToString()));
                                return false;
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.Mobile:
                        if (!char.IsControl(keyChar) && !char.IsDigit(keyChar))
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar))
                        {
                            if (control.SelectionStart == 0 && keyChar != '0')
                            {
                                errorText = ("شماره موبایل باید با 09 شروع شود");
                                return false;
                            }
                            else if (control.SelectionStart == 1 && keyChar != '9')
                            {
                                errorText = ("شماره موبایل باید با 09 شروع شود");
                                return false;
                            }
                            else
                            {
                                string text = control.GetNewText(keyChar);
                                if (text.Length > 11)
                                {
                                    errorText = ("شماره موبایل باید 11 رقمی باشد");
                                    return false;
                                }
                            }
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.NationalCode:
                        if (!char.IsControl(keyChar) && !char.IsDigit(keyChar))
                        {
                            errorText = ("فقط عدد وارد کنید");
                            return false;
                        }
                        else if (char.IsDigit(keyChar))
                        {
                            //if (keyChar == '-' && (control.SelectionStart != 3 && control.SelectionStart != 10))
                            //{
                            //    errorText = ("فقط عدد وارد کنید");
                            //    return false;
                            //}
                            //else
                            //{
                            string text = control.GetNewText(keyChar);
                            if (text.Length > 12)
                            {
                                errorText = ("کد ملی نباید از 12 حرف بیشتر باشد");
                                return false;
                            }
                            //}
                        }
                        break;
                    case InputBoxValidationHelper.InputTypes.Email:
                        break;
                    default:
                        throw new Exception();
                }
            }
            errorText = null;
            return true;
        }

        public static string FormatTextValueWithInputType(IInputBox control, string value)
        {
            switch (control.InputType)
            {
                case InputBoxValidationHelper.InputTypes.AllCharacters:
                    return value;
                case InputBoxValidationHelper.InputTypes.Number:
                    long numberValue;
                    if (!long.TryParse(value, out numberValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.DecimalNumber:
                    decimal decimalNumberValue;
                    if (!decimal.TryParse(value, out decimalNumberValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.ShortInt:
                    short shortValue;
                    if (!short.TryParse(value, out shortValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.Int:
                    int intValue;
                    if (!int.TryParse(value, out intValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.LongInt:
                    long longValue;
                    if (!long.TryParse(value, out longValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.Float:
                    float floatValue;
                    if (!float.TryParse(value, out floatValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.Double:
                    double doubleValue;
                    if (!double.TryParse(value, out doubleValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.Decimal:
                    decimal decimalValue;
                    if (!decimal.TryParse(value, out decimalValue))
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.PersianText:
                    if (value.Where(t => !InputBoxValidationHelper.IsPersianChar(t)).Count() > 0)
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.EnglishText:
                    if (value.Where(t => !InputBoxValidationHelper.IsEnglishChar(t)).Count() > 0)
                        return "";
                    return value;
                case InputBoxValidationHelper.InputTypes.Mobile:
                    return GetMobile(value);
                case InputBoxValidationHelper.InputTypes.NationalCode:
                    return GetNationalCode(value);
                case InputBoxValidationHelper.InputTypes.Email:
                    if (!value.Contains('@'))
                        return "";
                    return value;
                default:
                    throw new Exception();
            }
        }

        public static bool IsEnglishChar(char keyChar)
        {
            return (((char.IsLetterOrDigit(keyChar) && EnglishChars.Contains(keyChar)) || char.IsNumber(keyChar) || keyChar == ' ' || SymbolChars.Contains(keyChar)));
        }

        public static bool IsPersianChar(char keyChar)
        {
            return (((char.IsLetterOrDigit(keyChar) && PersianChars.Contains(keyChar)) || char.IsNumber(keyChar) || keyChar == ' ' || SymbolChars.Contains(keyChar)));
        }

        public static bool IsMobile(string value)
        {
            if (value.Length != 11)
                return false;
            if (!value.StartsWith("09"))
                return false;
            foreach (char ch in value)
            {
                if (!char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        public static bool IsNationalCode(string value)
        {
            if (value.Length != 12)
                return false;
            //long l;
            //if (value.Length == 10)
            //    if (long.TryParse(value, out l))
            //        return true;
            //    else
            //        return false;
            for (int i = 0; i < value.Length; i++)
            {
                if ((i == 3 || i == 10) && (value[i] != '-'))
                    return false;
                else if (!(i == 3 || i == 10) && !char.IsDigit(value[i]))
                    return false;
            }
            return true;
        }

        public static string GetMobile(string value)
        {
            if (value.StartsWith("+98"))
                value = "0" + value.Substring(3, value.Length - 3);
            if (value.Length > 11)
                value = value.Substring(0, 11);
            if (!value.StartsWith("09"))
                return "";
            long mobile;
            if (!long.TryParse(value, out mobile))
                return "";
            return value;
        }

        public static string GetNationalCode(string value)
        {
            if (value.IsNullOrEmpty())
                return "";
            value = value.Trim();
            if (value.Length > 12)
                value = value.Substring(0, 12);
            else if (value.Length != 12 && value.Length > 10)
                value = value.Substring(0, 10);
            long numberValue;
            if (long.TryParse(value, out numberValue))
                return value.Substring(0, 3) + "-" + value.Substring(3, 6) + "-" + value.Substring(9, 1);
            else if (!InputBoxValidationHelper.IsNationalCode(value))
                return "";
            return value;
        }

        public static bool KeyIsDigit(System.Windows.Forms.Keys keys)
        {
            return (keys >= System.Windows.Forms.Keys.NumPad0 && keys <= System.Windows.Forms.Keys.NumPad9) || (keys >= System.Windows.Forms.Keys.D0 && keys <= System.Windows.Forms.Keys.D9);
        }

        const string EnglishChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        const string PersianChars = "ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیءأآ\x0640إية ";
        const string SymbolChars = "/*-+.\\~`';\"!@#$%^&*()_-=?؟<>";

        internal static void FormatTextValueAfterKeyUp(IInputBox control, System.Windows.Forms.Keys key)
        {
            switch (control.InputType)
            {
                case InputTypes.NationalCode:
                    if (KeyIsDigit(key))
                    {
                        if (control.Text.Length == 3 && control.SelectionStart == 3)
                        {
                            control.SetText(control.Text + "-");
                            control.SelectionStart = 4;
                        }
                        else if (control.Text.Length == 10 && control.Text.Where(t => t == '-').Count() == 1 && control.SelectionStart == 10)
                        {
                            control.SetText(control.Text + "-");
                            control.SelectionStart = 11;
                        }
                        else if (control.Text.Length == 9 && control.Text.Where(t => t == '-').Count() == 0 && control.SelectionStart == 9)
                        {
                            control.SetText(control.Text.Substring(0, 3) + "-" + control.Text.Substring(3, 6) + "-");
                            control.SelectionStart = 11;
                        }
                    }
                    break;
            }
        }
    }
}
