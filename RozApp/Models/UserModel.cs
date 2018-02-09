using System;
using Realms;
using SQLite;

namespace RozApp.Models
{
    public class UserModel : RealmObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Segment { get; set; }
        public string Year { get; set; }
    }
}
