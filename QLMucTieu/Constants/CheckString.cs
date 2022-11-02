
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace QLMucTieu
{
    internal static class CheckString
    {

        public static string CheckMailString(string str)
        {
            if (str.Length < 1)
            {
                return "Chưa nhập Mail";
            }
            if (str.Contains("@"))
            {
                string[] arrStr = str.Split('@');
                if (arrStr.Length == 2 && arrStr[0].Length > 0 && arrStr[1].Length > 0 && arrStr[1].Contains("."))
                {
                    byte[] asciiBytes = Encoding.ASCII.GetBytes(arrStr[0]);
                    for (int i = 0; i < asciiBytes.Length; ++i)
                    {

                        if ((asciiBytes[i] > 57 && asciiBytes[i] < 65) ||
                            (asciiBytes[i] > 90 && asciiBytes[i] < 95) || (asciiBytes[i] == 96) ||
                            (asciiBytes[i] > 122) || asciiBytes[i] == 47 || (asciiBytes[i] < 46))
                        {
                            return "Mail không đúng! Vui lòng kiểm tra lại!";
                        }
                    }
                    asciiBytes = Encoding.ASCII.GetBytes(arrStr[1]);
                    for (int i = 0; i < asciiBytes.Length; ++i)
                    {

                        if ((asciiBytes[i] > 57 && asciiBytes[i] < 65) ||
                            (asciiBytes[i] > 90 && asciiBytes[i] < 95) || (asciiBytes[i] == 96) ||
                            (asciiBytes[i] > 122) || asciiBytes[i] == 47 || (asciiBytes[i] < 46))
                        {
                            return "Mail không đúng! Vui lòng kiểm tra lại!";
                        }
                    }
                    return "OK";
                }
                else
                {
                    return "Mail không đúng! Vui lòng kiểm tra lại!";
                }
            }
            else
            {
                return "Mail không đúng! Vui lòng kiểm tra lại!";
            }
        }
        public static bool CheckSqlInjection(string str)
        {
            if (str.ToLower().Contains(" select ") || str.ToLower().Contains(" delete ") ||
                str.ToLower().Contains(" update ") || str.ToLower().Contains(" insert ") ||
                str.ToLower().Contains(" where ") || str.ToLower().Contains(" and ") ||
                str.ToLower().Contains(" or ") || str.ToLower().Contains(" create ") ||
                str.ToLower().Contains(" alter ") || str.ToLower().Contains(" exec "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckChuBay(string str)
        {
            if (str.ToLower().Replace(" ", "").Contains("địt"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("lồn"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("buồi"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("cặc"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đụ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đéo"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đít"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("chó"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("mẹ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đóng gạch"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("bướm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("dái"))
            {
                return false;
            }
            //
            if (str.ToLower().Replace(" ", "").Contains("dái"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("tinh trùng"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("tinh trung"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("tinh chùng"))
            {
                return false;
            }
            //
            if (str.ToLower().Replace(" ", "").Contains("tinh chung"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("hạt le"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("dong gach"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đóng gach"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("chim"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("chym"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("buòi"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("buôi"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("lòn"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đù"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("má"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("bím"))
            {
                return false;
            }
            //
            if (str.ToLower().Replace(" ", "").Contains("vú"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("zú"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("bố"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("lông"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("dkm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("súcsinh"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("màngtrinh"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("conđỹ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("cave"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("giaocấu"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("giaohợp"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("hạtle"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("liếm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("đónggạch"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("thổikèn"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("sócrọ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("vkl"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("dm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("tinhtrùng"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("vếu"))
            {
                return false;
            }
            return str.ToLower().Replace(" ", "").Replace(" ", "").Contains("thằngngu")
                ? false
                : !str.ToLower().Replace(" ", "").Replace(" ", "").Contains("cụ");
        }
        public static string CheckUserNameString(string userName)
        {
            if (userName.Length < 1)
            {
                return "Chưa nhập tài khoản";
            }
            if (userName.Length < 5)
            {
                return "Tài khoản > 4 ký tự";
            }
            if (!CheckChuBay(userName))
            {
                return "Hãy lịch sự";
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(userName);
            for (int i = 0; i < asciiBytes.Length; ++i)
            {
                if (asciiBytes[i] < 48 || (asciiBytes[i] > 57 && asciiBytes[i] < 65) || (asciiBytes[i] > 90 && asciiBytes[i] < 97)
                    || (asciiBytes[i] > 122))
                {

                    return "Tài khoản chỉ gồm chữ không dấu và số";
                }
            }
            return "OK";
        }
        public static string CheckPassString(string str)
        {
            if (str.Length < 1)
            {
                return "Chưa nhập mật khẩu";
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
            for (int i = 0; i < asciiBytes.Length; ++i)
            {
                if (asciiBytes[i] < 33 || asciiBytes[i] > 126)
                {

                    return "Mật khẩu chứa tiếng việt và dấu cách";
                }
            }
            return "OK";
        }
        public static int CheckStrength(string password)
        {
            int score = 1;

            if (password.Length < 1)
                return 0;
            if (password.Length < 4)
            {
                return 1;
            }

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return score;
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        public static string ToFractions(this double number, int precision = 4)
        {
            int w, n, d;
            RoundToMixedFraction(number, precision, out w, out n, out d);
            var ret = $"{w}";
            if (w > 0)
            {
                if (n > 0)
                    ret = $"{w} {n}/{d}";
            }
            else
            {
                if (n > 0)
                    ret = $"{n}/{d}";
            }
            return ret;
        }

        static void RoundToMixedFraction(double input, int accuracy, out int whole, out int numerator, out int denominator)
        {
            double dblAccuracy = (double)accuracy;
            whole = (int)(Math.Truncate(input));
            var fraction = Math.Abs(input - whole);
            if (fraction == 0)
            {
                numerator = 0;
                denominator = 1;
                return;
            }
            var n = Enumerable.Range(0, accuracy + 1).SkipWhile(e => (e / dblAccuracy) < fraction).First();
            var hi = n / dblAccuracy;
            var lo = (n - 1) / dblAccuracy;
            if ((fraction - lo) < (hi - fraction)) n--;
            if (n == accuracy)
            {
                whole++;
                numerator = 0;
                denominator = 1;
                return;
            }
            var gcd = GCD(n, accuracy);
            numerator = n / gcd;
            denominator = accuracy / gcd;
        }

        static int GCD(int a, int b)
        {
            if (b == 0) return a;
            else return GCD(b, a % b);
        }

        public static double ConvertToDouble_My(object str)
        {
            if (str == null)
                return 0;

            string str_2_ = str.ToString();

            if (str_2_ == "")
                return 0;

            double temp_ = 0;
            try
            {
                temp_ = Convert.ToDouble(str);
            }
            catch
            {
                try
                {
                    str_2_ = str_2_.Replace(",", "*");
                    str_2_ = str_2_.Replace(".", ",");
                    str_2_ = str_2_.Replace("*", ".");
                    temp_ = Convert.ToDouble(str_2_);
                }
                catch {
                    return 0;
                }
            }
            return temp_;
        }

        public static decimal ConvertToDecimal_My(object str)
        {
            if (str == null)
                return 0;
            string str_2_ = str.ToString();
            decimal temp_ = 0;
            try
            {
                temp_ = Convert.ToDecimal(str);
            }
            catch
            {
                try
                {
                    str_2_ = str_2_.Replace(",", "*");
                    str_2_ = str_2_.Replace(".", ",");
                    str_2_ = str_2_.Replace("*", ".");
                    temp_ = Convert.ToDecimal(str_2_);
                }
                catch
                {
                    return 0;
                }
            }
            return temp_;
        }


        //
        #region convert string to double:
        public static double _toDoubleInside(string str)
        {
            int deg = 0;
            int phut = 0;
            double giay = 0;
            double result = 0;

            if (str.Contains('°'))
            {
                string[] str1 = str.Split('°');
                deg = Convert.ToInt32(str1[0].Trim());
                if (str.Contains("'") || str.Contains('’'))
                {
                    if (str.Contains("'"))
                    {
                        string[] str2 = str1[1].Split('\'');
                        if (str2[0].Trim() != "") phut = Convert.ToInt32(str2[0].Trim());
                        if (str2.Length > 0)
                        {
                            string str3 = str2[1].Trim();
                            if (str3 != "")
                            {
                                if (str3.Contains("\"")) str3 = str3.Trim('"');
                                else if (str3.Contains("”")) str3 = str3.Trim('”');
                                giay = Convert.ToDouble(str3);
                            }
                        }
                        result = deg + (double)phut / 60 + (double)giay / 3600;
                    }
                    else if (str.Contains("’"))
                    {
                        string[] str2 = str1[1].Split('’');
                        if (str2[0].Trim() != "") phut = Convert.ToInt32(str2[0].Trim());
                        if (str2.Length > 0)
                        {
                            string str3 = str2[1].Trim();
                            if (str3 != "")
                            {
                                if (str3.Contains("\"")) str3 = str3.Trim('"');
                                else if (str3.Contains("”")) str3 = str3.Trim('”');
                                giay = Convert.ToDouble(str3);
                            }
                        }
                        result = deg + (double)phut / 60 + (double)giay / 3600;
                    }
                }
            }
            else if (str.Contains('⁰'))
            {
                string[] str1 = str.Split('⁰');
                deg = Convert.ToInt32(str1[0].Trim());
                if (str.Contains("'") || str.Contains('’'))
                {
                    if (str.Contains("'"))
                    {
                        string[] str2 = str1[1].Split('\'');
                        if (str2[0].Trim() != "") phut = Convert.ToInt32(str2[0].Trim());
                        if (str2.Length > 0)
                        {
                            string str3 = str2[1].Trim();
                            if (str3 != "")
                            {
                                if (str3.Contains("\"")) str3 = str3.Trim('"');
                                else if (str3.Contains("”")) str3 = str3.Trim('”');
                                giay = Convert.ToDouble(str3);
                            }
                        }
                        result = deg + (double)phut / 60 + (double)giay / 3600;
                    }
                    else if (str.Contains("’"))
                    {
                        string[] str2 = str1[1].Split('’');
                        if (str2[0].Trim() != "") phut = Convert.ToInt32(str2[0].Trim());
                        if (str2.Length > 0)
                        {
                            string str3 = str2[1].Trim();
                            if (str3 != "")
                            {
                                if (str3.Contains("\"")) str3 = str3.Trim('"');
                                else if (str3.Contains("”")) str3 = str3.Trim('”');
                                giay = Convert.ToDouble(str3);
                            }
                        }
                        result = deg + (double)phut / 60 + (double)giay / 3600;
                    }
                }
            }
            else if (str.Contains('O'))
            {
                string[] str1 = str.Split('O');
                deg = Convert.ToInt32(str1[0].Trim());
                if (str.Contains("'") || str.Contains('’'))
                {
                    if (str.Contains("'"))
                    {
                        string[] str2 = str1[1].Split('\'');
                        if (str2[0].Trim() != "") phut = Convert.ToInt32(str2[0].Trim());
                        if (str2.Length > 0)
                        {
                            string str3 = str2[1].Trim();
                            if (str3 != "")
                            {
                                if (str3.Contains("\"")) str3 = str3.Trim('"');
                                else if (str3.Contains("”")) str3 = str3.Trim('”');
                                giay = Convert.ToDouble(str3);
                            }
                        }
                        result = deg + (double)phut / 60 + (double)giay / 3600;
                    }
                    else if (str.Contains("’"))
                    {
                        string[] str2 = str1[1].Split('’');
                        if (str2[0].Trim() != "") phut = Convert.ToInt32(str2[0].Trim());
                        if (str2.Length > 0)
                        {
                            string str3 = str2[1].Trim();
                            if (str3 != "")
                            {
                                if (str3.Contains("\"")) str3 = str3.Trim('"');
                                else if (str3.Contains("”")) str3 = str3.Trim('”');
                                giay = Convert.ToDouble(str3);
                            }
                        }
                        result = deg + (double)phut / 60 + (double)giay / 3600;
                    }
                }
            }
            else
            {
                if (CheckIsNumber(str))
                {
                    result = Convert.ToDouble(str);
                }
            }
            return result;
        }

        public static double _toDouble_ToaDo(string str)
        {
            double result = 0;
            try
            {
                str = str.ToUpper().Trim();
                while (str.IndexOf("\t") >= 0)
                {
                    str = str.Replace("\t", "");
                }
                while (str.IndexOf(" ") >= 0)
                {
                    str = str.Replace(" ", "");
                }

                // 2°10'26.5"E  18⁰31’B/114⁰14’Đ” ”  ” ”  ”
                if (str.Contains('Đ'))
                {
                    str = str.Trim('Đ'); //Đông
                    result = _toDoubleInside(str);
                }
                else if (str.Contains('D'))
                {
                    str = str.Trim('D'); //Đông
                    result = _toDoubleInside(str);
                }
                else if (str.Contains('E'))
                {
                    str = str.Trim('E'); //Đông
                    result = _toDoubleInside(str);
                }
                else if (str.Contains('B'))
                {
                    str = str.Trim('B'); //Bắc
                    result = _toDoubleInside(str);
                }
                else if (str.Contains('N'))
                {
                    str = str.Trim('N');  //Nam
                    result = -_toDoubleInside(str);
                }
                else if (str.Contains('S'))
                {
                    str = str.Trim('S'); //Nam
                    result = -_toDoubleInside(str);
                }
                else if (str.Contains('T'))
                {
                    str = str.Trim('T'); //Tây
                    result = -_toDoubleInside(str);
                }
                else if (str.Contains('W'))
                {
                    str = str.Trim('W'); //Tây
                    result = -_toDoubleInside(str);
                }
                else
                {
                    result = Convert.ToDouble(str.Trim());
                }
            }
            catch
            {
            }
            return result;
        }

        //
        public static bool CheckIsNumber(string Value)
        {
            double OutVal;
            if (Double.TryParse(Value, out OutVal))
            {
                // it is a number
                return true;
            }
            else
            {
                // it is not a number
                return false;
            }
        }
        #endregion

        #region Convert string to datetime:
        //Convert datetime string from sql to datetime:
        public static DateTime _toDateTime(string str)
        {
            //DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            try
            {
                DateTime myDate = DateTime.ParseExact(str, "HH:mm:ss - dd/MM/yyyy",
                           System.Globalization.CultureInfo.InvariantCulture);
                return myDate;
            }
            catch
            {
                return DateTime.Now;
            }
        }
        #endregion
    }
}
