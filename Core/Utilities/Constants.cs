using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public static class Constants
    {
        public struct Msg
        {
            public const string InsertComplete = "Data Successfully Insert";
            public const string UpdateComplete = "Data Successfully Update";
            public const string DeleteComplete = "Data Successfully Delete";
            public const string GetList = "Data Fetch Successfully";
            public const string NoRecord = "No Record Found";
        }
        public struct StatusData
        {
            public const bool True = true;
            public const bool False = false;
        }
    }
}
