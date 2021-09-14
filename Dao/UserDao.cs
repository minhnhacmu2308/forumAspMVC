using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using forumAspMVC.Models;

namespace forumAspMVC.Dao
{
    public class UserDao
    {
        ForumDBContext myDb = new ForumDBContext(); 

        public void register(User user)
        {
            myDb.users.Add(user);
            myDb.SaveChanges();
        }

        public bool checkLogin(string email,string password)
        {
            var objUser = myDb.users.Where(u => u.email == email && u.password == password).FirstOrDefault();
            if(objUser != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool checkEmailExist(string email)
        {
            var objUser = myDb.users.Where(u => u.email == email ).FirstOrDefault();
            if (objUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string md5(string password)
        {
            MD5 md = MD5.Create();
            byte[] inputString = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md.ComputeHash(inputString);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb.ToString();
        }
        public User getUserByEmail(string email)
        {
            var obj = myDb.users.Where(u => u.email == email).FirstOrDefault();
            return obj;
        }
    }
}