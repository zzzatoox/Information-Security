using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Classes
{
    internal class UserData
    {
        //public static int UserId { get; set; }
        public static string LastName { get; set;}
        public static string FirstName { get; set; }
        public static string Patronymic { get; set; }
        public static string PhotoPath { get; set; }
        
        //do constructor

        public UserData(SqlDataReader reader) 
        {
            LastName = reader.GetString(0);
            FirstName = reader.GetString(1);
            Patronymic = reader.IsDBNull(2) ? "" : reader.GetString(2);
            PhotoPath = reader.GetString(3);
        }
    }
}
