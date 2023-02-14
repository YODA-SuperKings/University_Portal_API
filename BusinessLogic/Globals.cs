using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public static class Globals
    {
        public static string CollectionName { get; set; }
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        static Globals()
        {
            ConnectionString = "mongodb+srv://Chiran73:QOqQESMqsVpjSzg8@chiran.brgoly6.mongodb.net/?retryWrites=true&w=majority";
            DatabaseName = "UniversityAdminDB";
        }
    }
}
