using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Mail;
using System.Text;
using PvaLibrary;

namespace PvaCore.Vfs
{
    public class DataTypes
    {
        public enum VisaEntityType
         {
             New = 0,
             Completed =1
         }
        // Data types section
        public int Priority { get; set; }
        public string PriorityStr => Const.GetListPriority()[Priority];
        public string City { get; set; }
        public string CityCode { get; set; }
        public string CityV
        {
            get
            {
                switch (CategoryCode)
                {
                    case "1":
                        return "(Nat)" + City;
                    case "2":
                        return "(She)" + City;
                    default:
                        return City;
                }
            }
        }
        public string Category { get; set; }
        public string CategoryCode { get; set; }
        public string Purpose { get; set; }
        public string PurposeCode { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public int CountAdult { get; set; }
        public int CountChild { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Receipt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ArrivalDt { get; set; }
        public string Dob { get; set; }
        public string PassportEndDate { get; set; }
        public string RedLine { get; set; }
        public DateTime RedLineDt => RedLine == null ? DateTime.MinValue : DateTime.ParseExact(RedLine, Const.DateFormat, CultureInfo.InvariantCulture);
        public string GreenLine { get; set; }
        public DateTime GreenLineDt => GreenLine == null ? DateTime.MinValue : DateTime.ParseExact(GreenLine, Const.DateFormat, CultureInfo.InvariantCulture);
        public string RegistrationInfo { get; set; }
        // Function section
        public static bool IsValidEmailAddress(string email)
        {
            try
            {
                var ma = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidPassword(string pass)
        {
            return pass.Length >= 8;
        }
        public string GetTabInfo()
        {
            var sx = new StringBuilder();
            sx.AppendLine(Name + " " + LastName);
            sx.AppendLine($"Крайняя дата подачи заявки от {GreenLine} до {RedLine}, приоритет {PriorityStr}");
            sx.AppendLine("");
            sx.AppendLine("Город: " + City);
            sx.AppendLine("Мета візиту: " + Purpose);
            sx.AppendLine($"Кількість заявників: {CountAdult}, К-сть дітей {CountChild}");
            sx.AppendLine("Візова категорія: " + Category);
            sx.AppendLine("Номер квитанції: " + Receipt);
            sx.AppendLine("Email: " + Email);
            sx.AppendLine("Пароль: " + Password);
            return sx.ToString();
        }
        // Clone section
        public DataTypes Clone()
        {
            var dt = new DataTypes
            {
                ArrivalDt = ArrivalDt,
                Category = Category,
                CategoryCode = CategoryCode,
                City = City,
                CityCode = CityCode,
                CountAdult = CountAdult,
                CountChild = CountChild,
                Dob = Dob,
                Email = Email,
                LastName = LastName,
                Name = Name,
                Nationality = Nationality,
                PassportEndDate = PassportEndDate,
                Password = Password,
                Priority = Priority,
                Purpose = Purpose,
                PurposeCode = PurposeCode,
                Receipt = Receipt,
                RedLine = RedLine,
                GreenLine = GreenLine,
                RegistrationInfo = RegistrationInfo,
                Status = Status,
                StatusCode = StatusCode
            };
            return dt;
        }
    }
    public class DataTypesComparer : IComparer<DataTypes>
    {
        public int Compare(DataTypes dataTypesX, DataTypes dataTypesY)
        {
            if (dataTypesX.RedLineDt > dataTypesY.RedLineDt)
                return 1;
            if (dataTypesX.RedLineDt < dataTypesY.RedLineDt)
                return -1;
            if (dataTypesX.Priority > dataTypesY.Priority)
                return -1;
            if (dataTypesX.Priority < dataTypesY.Priority)
                return 1;
            return 0;
        }
    }
    public class DataTypesSql
    {

        private const string ConnectionUri = "Data Source=vpa.cloudapp.net;Initial Catalog=VpaPolandDb;Persist Security Info=True;User ID=sa;Password=Casper159357*0;Pooling=False";

        public void GetData()
        {
            using (var dbSqlConnection = new SqlConnection(ConnectionUri))
            using (var sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Peopel", dbSqlConnection))
            {
                
            }
        }

        public void Update()
        {
            
        }

        public void UpdateRow()
        {
            
        }


    }
}