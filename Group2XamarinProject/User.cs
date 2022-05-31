using System;
using System.Collections.Generic;
using System.Text;

namespace Group2XamarinProject
{
    public class User
    {
        private int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User(string un, string pass)
        {
            username = un;
            password = pass;
        }
    }
}
