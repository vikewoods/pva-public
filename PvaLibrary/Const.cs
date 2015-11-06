using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PvaLibrary
{
    public enum RotEvents
    {
        Start = 0,
        Firsthl = 1,
        FirstCombo = 2,
        Submit = 3,
        GetData = 4,
        SecondCombo = 5,
        FillReceipt = 6,
        FillEmail = 7,
        Stop = 8,
        FillMainInfos = 9,
        SelectDayToVisit = 10,
        SelectTime = 11
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FLASHWINFO
    {
        public uint cbSize;
        public IntPtr hwnd;
        public uint dwFlags;
        public uint uCount;
        public uint dwTimeout;
    }


    public static class Const
    {
        static Const()
        {
            //prepareTranslit();
        }

        public const string UrlEkonsulat = "https://secure.e-konsulat.gov.pl/default.aspx";

        public const string Url =
            "https://polandonline.vfsglobal.com/poland-ukraine-appointment/(S(ro4garnrik5q0a55hnveytfe))/AppScheduling/AppWelcome.aspx?P=s2x6znRcBRv7WQQK7h4MTnRfnp06lzlPrFCdHEUl1mc=";

        //"https://www.vfsvisaonline.com/poland-ukraine-appointment/(S(ytzs0pjoptifju555d1inlbs))/AppScheduling/AppWelcome.aspx?P=s2x6znRcBRv7WQQK7h4MTjZiPRbOsXKqJzddYBh3qCA%3d";
        public const string DateFormat = "dd/MM/yyyy";
        public const string DateFormatForFile = "dd_MM_yyyy";

        public const string HOST = "host";
        public const string NAME = "name";
        public const string PASSW = "passw";
        public const string PORT = "port";
        public const string AUTORESOLVE = "autoResolve";
        public const string USEPROXY = "useProxy";
        public const string ASKMASTER = "askMaster";
        public const string PROXYSERVERS = "proxyServers";
        public const string REGCOUNTS = "regCounts";
        public static string DELETEDTASKS = "DeletedTasks";
        public static string ALLOWREG = "AllowReg";
        public static string REQINTERVAL = "ReqInterval";

        public const string FirstLink = "ctl00_plhMain_lnkSchApp";
        public const string CityLinkFirst = "ctl00_plhMain_cboVAC";
        public const string PurposeLinkFirst = "ctl00_plhMain_cboPurpose";
        public const string SubmitFirst = "ctl00_plhMain_btnSubmit";
        public const string ChildInput = "ctl00_plhMain_tbxNumOfApplicants";
        public const string ChildText = "ctl00_plhMain_txtChildren";
        public const string CategoryInput = "ctl00_plhMain_cboVisaCategory";
        public const string DateText = "ctl00_plhMain_lblMsg";
        public const string CapthaImage = "recaptcha_image";
        public const string ReceptionInput = "ctl00_plhMain_repAppReceiptDetails_ctl01_txtReceiptNumber";

        public static Dictionary<string, string> SettingsCities = FillConfigCities();
        private static readonly Dictionary<string, string> Transliter = new Dictionary<string, string>();

        private static void PrepareTranslit()
        {
            Transliter.Add("а", "a");
            Transliter.Add("б", "b");
            Transliter.Add("в", "v");
            Transliter.Add("г", "g");
            Transliter.Add("д", "d");
            Transliter.Add("е", "e");
            Transliter.Add("ё", "yo");
            Transliter.Add("ж", "zh");
            Transliter.Add("з", "z");
            Transliter.Add("и", "i");
            Transliter.Add("й", "j");
            Transliter.Add("к", "k");
            Transliter.Add("л", "l");
            Transliter.Add("м", "m");
            Transliter.Add("н", "n");
            Transliter.Add("о", "o");
            Transliter.Add("п", "p");
            Transliter.Add("р", "r");
            Transliter.Add("с", "s");
            Transliter.Add("т", "t");
            Transliter.Add("у", "u");
            Transliter.Add("ф", "f");
            Transliter.Add("х", "h");
            Transliter.Add("ц", "c");
            Transliter.Add("ч", "ch");
            Transliter.Add("ш", "sh");
            Transliter.Add("щ", "sch");
            Transliter.Add("ъ", "j");
            Transliter.Add("ы", "i");
            Transliter.Add("ь", "j");
            Transliter.Add("э", "e");
            Transliter.Add("ю", "yu");
            Transliter.Add("я", "ya");
            Transliter.Add("А", "A");
            Transliter.Add("Б", "B");
            Transliter.Add("В", "V");
            Transliter.Add("Г", "G");
            Transliter.Add("Д", "D");
            Transliter.Add("Е", "E");
            Transliter.Add("Ё", "Yo");
            Transliter.Add("Ж", "Zh");
            Transliter.Add("З", "Z");
            Transliter.Add("И", "I");
            Transliter.Add("Й", "J");
            Transliter.Add("К", "K");
            Transliter.Add("Л", "L");
            Transliter.Add("М", "M");
            Transliter.Add("Н", "N");
            Transliter.Add("О", "O");
            Transliter.Add("П", "P");
            Transliter.Add("Р", "R");
            Transliter.Add("С", "S");
            Transliter.Add("Т", "T");
            Transliter.Add("У", "U");
            Transliter.Add("Ф", "F");
            Transliter.Add("Х", "H");
            Transliter.Add("Ц", "C");
            Transliter.Add("Ч", "Ch");
            Transliter.Add("Ш", "Sh");
            Transliter.Add("Щ", "Sch");
            Transliter.Add("Ъ", "J");
            Transliter.Add("Ы", "I");
            Transliter.Add("Ь", "J");
            Transliter.Add("Э", "E");
            Transliter.Add("Ю", "Yu");
            Transliter.Add("Я", "Ya");
        }

        public static string GetTranslit(string sourceText)
        {
            var ans = new StringBuilder();
            for (var i = 0; i < sourceText.Length; i++)
            {
                if (Transliter.ContainsKey(sourceText[i].ToString()))
                {
                    ans.Append(Transliter[sourceText[i].ToString()]);
                }
                else
                {
                    ans.Append(sourceText[i].ToString());
                }
            }
            return ans.ToString();
        }

        public static string CityCodeByCity(string city)
        {
            return (from keyValuePair in SettingsCities where keyValuePair.Value == city select keyValuePair.Key).FirstOrDefault();
        }

        public static string GetMonthAsInt(string month)
        {
            switch (month)
            {
                case "Січ":
                case "Січень":
                case "January":
                case "Jan":
                    return "01";
                case "Лют":
                case "Лютий":
                case "February":
                case "Feb":
                    return "02";
                case "Бер":
                case "Березень":
                case "March":
                case "Mar":
                    return "03";
                case "Кві":
                case "Квітень":
                case "April":
                case "Apr":
                    return "04";
                case "Тра":
                case "Травень":
                case "May":
                    return "05";
                case "Чер":
                case "Червень":
                case "June":
                case "Jun":
                    return "06";
                case "Лип":
                case "Липень":
                case "July":
                case "Jul":
                    return "07";
                case "Сер":
                case "Серпень":
                case "August":
                case "Aug":
                    return "08";
                case "Вер":
                case "Вересень":
                case "September":
                case "Sep":
                    return "09";
                case "Жов":
                case "Жовтень":
                case "October":
                case "Oct":
                    return "10";
                case "Лис":
                case "Листопад":
                case "November":
                case "Nov":
                    return "11";
                case "Гру":
                case "Грудень":
                case "December":
                case "Dec":
                    return "12";
            }
            return month;
        }

        public static Dictionary<string, string> FillConfigCities()
        {
            var settingsCities = new Dictionary<string, string>
            {
                {"1", "Івано-Франківськ"},
                {"2", "Львів"},
                {"3", "Тернопіль"},
                {"4", "Рівне"},
                {"5", "Луцьк"},
                {"6", "Дніпропетровськ"},
                {"7", "Харків"},
                {"8", "Київ"},
                {"9", "Одеса"},
                {"10", "Хмельницький"},
                {"11", "Житомир"},
                {"12", "Вінниця"},
                {"13", "Донецьк"},
                {"14", "Ужгород"},
                {"15", "Чернівці"},
                {"16", "Луганськ"}
            };
            return settingsCities;
        }

        public static string CategoryCodeByCat(string cat)
        {
            return (from keyValuePair in GetCategoryType() where keyValuePair.Value == cat select keyValuePair.Key).FirstOrDefault();
        }

        public static Dictionary<string, string> GetCategoryType()
        {
            var dict = new Dictionary<string, string> {{"1", "Національна Віза"}, {"2", "Шенгенська Віза"}};
            return dict;
        }

        public static Dictionary<string, string> GetCategoryValueByType()
        {
            var dict = new Dictionary<string, string> {{"Національна Віза", "235"}, {"Шенгенська Віза", "229"}};
            return dict;
        }

        public static string PurposeCodeByPurpose(string purp)
        {
            return
                (from keyValuePair in FillPurpose() where keyValuePair.Value == purp select keyValuePair.Key)
                    .FirstOrDefault();
        }

        public static Dictionary<string, string> FillPurpose()
        {
            var dict = new Dictionary<string, string> {{"1", "Подача документів"}, {"2", "Консультація"}};
            return dict;
        }

        public static string StatusCodeByStatus(string stat)
        {
            return (from keyValuePair in FillStatus() where keyValuePair.Value == stat select keyValuePair.Key).FirstOrDefault();
        }

        public static Dictionary<string, string> FillStatus()
        {
            var dict = new Dictionary<string, string>
            {
                {"1", "Dr."},
                {"2", "Mr."},
                {"3", "Mrs."},
                {"4", "Ms."},
                {"5", "Mstr."}
            };
            return dict;
        }

        public static Dictionary<string, string> FillNations()
        {
            var dict = new Dictionary<string, string>
            {
                {"1", "AFGHANISTAN"},
                {"2", "ALBANIA"},
                {"3", "ALGERIA"},
                {"4", "ANDORRA"},
                {"5", "ANGOLA"},
                {"6", "ANGUILLA"},
                {"7", "ANTIGUA &amp; BARBUDA"},
                {"8", "ARGENTINA"},
                {"9", "ARMENIA"},
                {"10", "ARUBA"},
                {"11", "AUSTRALIA"},
                {"12", "AUSTRIA"},
                {"13", "AZERBAIJAN"},
                {"14", "BAHAMAS"},
                {"15", "BAHRAIN"},
                {"16", "BANGLADESH"},
                {"17", "BARBADOS"},
                {"18", "BELARUS"},
                {"19", "BELGIUM"},
                {"20", "BELIZE"},
                {"21", "BENIN"},
                {"22", "BERMUDA ISLANDS"},
                {"23", "BHUTAN"},
                {"24", "BOLIVIA"},
                {"25", "BOSNIA-HERCEGOVINA"},
                {"26", "BOTSWANA"},
                {"27", "BRAZIL"},
                {"28", "BRUNEI"},
                {"29", "BULGARIA"},
                {"30", "BURKINA FASO"},
                {"31", "BURUNDI"},
                {"32", "CAMBODIA"},
                {"33", "CAMEROON"},
                {"34", "CANADA"},
                {"35", "CAPE VERDE"},
                {"36", "CAYMAN ISLANDS"},
                {"37", "CENTRAL AFRICAN REP."},
                {"38", "CHAD"},
                {"39", "CHILE"},
                {"40", "CHINA"},
                {"41", "COLOMBIA"},
                {"42", "COMOROS"},
                {"43", "CONGO, DEM. REP."},
                {"44", "CONGO, REP."},
                {"45", "COSTA RICA"},
                {"46", "CROATIA"},
                {"47", "CUBA"},
                {"48", "CYPRUS"},
                {"49", "CZECH REPUBLIC"},
                {"50", "DENMARK"},
                {"51", "DJIBOUTI"},
                {"52", "DOMINICA"},
                {"53", "DOMINICAN REPUBLIC"},
                {"54", "EAST TIMOR"},
                {"55", "ECUADOR"},
                {"56", "EGYPT"},
                {"57", "EL SALVADOR"},
                {"58", "EQUATORIAL GUINEA"},
                {"59", "ERITREA"},
                {"60", "ESTONIA"},
                {"61", "ETHIOPIA"},
                {"62", "FEDERATED STATES OF MICRONESIA"},
                {"63", "FEDERATION OF SAINT KITTS,CHRISTOPHER AND NEVIS"},
                {"64", "FIJI"},
                {"65", "FINLAND"},
                {"66", "FRANCE"},
                {"67", "GABON"},
                {"68", "GAMBIA"},
                {"69", "GEORGIA"},
                {"70", "GERMANY"},
                {"71", "GHANA"},
                {"72", "GREECE"},
                {"73", "GRENADA"},
                {"74", "GRENADINES"},
                {"75", "GUATEMALA"},
                {"76", "GUINEA"},
                {"77", "GUINEA-BISSAU"},
                {"78", "GUYANA"},
                {"79", "HAITI"},
                {"80", "HONDURAS"},
                {"81", "HONGKONG AND MACAO"},
                {"82", "HUNGARY"},
                {"83", "ICELAND"},
                {"84", "INDIA"},
                {"85", "INDONESIA"},
                {"86", "IRAN"},
                {"87", "IRAQ"},
                {"88", "IRELAND"},
                {"89", "ISRAEL"},
                {"90", "ITALY"},
                {"91", "IVORY COAST"},
                {"92", "JAMAICA"},
                {"93", "JAPAN"},
                {"94", "JORDAN"},
                {"95", "KAZAKSTAN"},
                {"96", "KENYA"},
                {"97", "KIRIBATI"},
                {"98", "KOREA (NORTH-)"},
                {"99", "KUWAIT"},
                {"100", "KYRGYSTAN"},
                {"101", "LAOS"},
                {"102", "LATVIA"},
                {"103", "LEBANON"},
                {"104", "LESOTHO"},
                {"105", "LIBERIA"},
                {"106", "LIBYA"},
                {"107", "LIECHTENSTEIN"},
                {"108", "LITHUANIA"},
                {"109", "LUXEMBOURG"},
                {"110", "MACAU"},
                {"111", "MACEDONIA"},
                {"112", "MADAGASCAR"},
                {"113", "MALAWI"},
                {"114", "MALAYSIA"},
                {"115", "MALDIVES"},
                {"116", "MALI"},
                {"117", "MALTA"},
                {"118", "MARSHALL ISLANDS"},
                {"119", "MAURITANIA"},
                {"120", "MAURITIUS"},
                {"121", "MEXICO"},
                {"122", "MICRONESIA"},
                {"123", "MOLDAVIA"},
                {"124", "MOLDOVA"},
                {"125", "MONACO"},
                {"126", "MONGOLIA"},
                {"127", "MONTENEGRO"},
                {"128", "MONTSERRAT"},
                {"129", "MOROCCO"},
                {"130", "MOZAMBIQUE"},
                {"131", "MYANMAR (BURMA)"},
                {"132", "NA"},
                {"133", "NAMIBIA"},
                {"134", "NAURU"},
                {"135", "NEPAL"},
                {"136", "NETHERLANDS"},
                {"137", "NETHERLANDS ANTILLES"},
                {"138", "NEW ZEALAND"},
                {"139", "NICARAGUA"},
                {"140", "NIGER"},
                {"141", "NIGERIA"},
                {"142", "NON-RUSSIAN"},
                {"143", "NORWAY"},
                {"144", "NOTHERN MARIANA ISLANDS"},
                {"145", "OMAN"},
                {"146", "OTHERS"},
                {"147", "PAKISTAN"},
                {"148", "PALAU ISLANDS"},
                {"149", "PALESTINE"},
                {"150", "PANAMA"},
                {"151", "PAPUA NEW GUINEA"},
                {"152", "PARAGUAY"},
                {"153", "PERU"},
                {"154", "PHILIPPINES"},
                {"155", "POLAND"},
                {"156", "PORTUGAL"},
                {"157", "QATAR"},
                {"158", "REPUBLIC DE COTE DIVOIRE"},
                {"159", "REPUBLIC OF BURUNDI"},
                {"160", "REPUBLIC OF CONGO"},
                {"161", "REPUBLIC OF CROATIA"},
                {"162", "REPUBLIC OF KIRIBATI"},
                {"163", "REPUBLIC OF KOREA"},
                {"164", "REPUBLIC OF KOSOVO"},
                {"165", "REPUBLIC OF MACEDONIA"},
                {"166", "REPUBLIC OF PALAU"},
                {"167", "REPUBLIC OF SLOVENIA"},
                {"168", "REPUBLIC OF THE MARSHALL ISLANDS"},
                {"169", "REUNION ISLANDS"},
                {"170", "ROM"},
                {"171", "ROMANIA"},
                {"174", "RUSSIAN FEDERATION"},
                {"175", "RWANDA"},
                {"176", "SAINT LUCIA"},
                {"177", "SAMOA"},
                {"178", "SAN MARINO"},
                {"179", "SAO TOMÉ &amp; PRINCIPE"},
                {"180", "SAUDI ARABIA"},
                {"181", "SENEGAL"},
                {"182", "SERBIA"},
                {"183", "SEYCHELLES"},
                {"184", "SIERRA LEONE"},
                {"185", "SINGAPORE"},
                {"186", "SLOVAK REPUBLIC"},
                {"187", "SLOVENIA"},
                {"188", "SOLOMON ISLANDS"},
                {"189", "SOMALIA"},
                {"190", "SOUTH AFRICA"},
                {"191", "SPAIN"},
                {"192", "SRI LANKA"},
                {"193", "ST. KITTS &amp; NEVIS"},
                {"194", "ST. LUCIA"},
                {"195", "ST. VINCENT &amp; THE"},
                {"196", "STATE OF ERITREA"},
                {"197", "SUDAN"},
                {"198", "SURINAM"},
                {"199", "SWAZILAND"},
                {"200", "SWEDEN"},
                {"201", "SWITZERLAND"},
                {"202", "SYRIA"},
                {"203", "TAIWAN"},
                {"204", "TAJIKISTAN"},
                {"205", "TANZANIA"},
                {"206", "THAILAND"},
                {"207", "THE BAHAMAS"},
                {"208", "THE PHILIPPINES"},
                {"209", "TIBET"},
                {"210", "TOGO"},
                {"211", "TONGA"},
                {"212", "TRINIDAD &amp; TOBAGO"},
                {"213", "TUNISIA"},
                {"214", "TURKEY"},
                {"215", "TURKMENISTAN"},
                {"217", "TUVALU"},
                {"218", "UGANDA"},
                {"219", "UKRAINE"},
                {"216", "Ukrainians"},
                {"220", "UN NATION"},
                {"221", "UN OFFICIAL"},
                {"222", "UNITED ARAB EMIRATES"},
                {"223", "UNITED KINGDOM"},
                {"224", "UNITED NATIONS ORGANIZATION"},
                {"225", "UNITED STATES OF AMERICA"},
                {"226", "URUGUAY"},
                {"227", "UZBEKISTAN"},
                {"228", "VANUATU"},
                {"229", "VATICAN CITY (HOLY SEE)"},
                {"230", "VENEZUELA"},
                {"231", "VIETNAM"},
                {"232", "YEMEN"},
                {"233", "YUGOSLAVIA"},
                {"234", "ZAMBIA"},
                {"235", "ZIMBABWE"}
            };
            return dict;
        }

        public static List<string> GetListPriority()
        {
            var priors = new List<string> {"Низкий", "Средний", "Высокий"};
            return priors;
        }

        public static DataTable GetDataTablePriority()
        {
            var data = new DataTable();
            data.Columns.Add(new DataColumn("Value", typeof (int)));
            data.Columns.Add(new DataColumn("Description", typeof (string)));
            data.Rows.Add(0, "Низкий");
            data.Rows.Add(1, "Средний");
            data.Rows.Add(2, "Высокий");
            return data;
        }

        public static List<string> GetListFromDict(Dictionary<string, string> dict)
        {
            return dict.Select(keyValuePair => keyValuePair.Value).ToList();
        }
    }
}
