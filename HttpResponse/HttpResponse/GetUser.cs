using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HttpResponse
{
    public class GetUser:IUser
    {
        public string cusername;
        //public string _user;
        //public string User
        //{
        //    get { return _user; }
        //    set
        //    {
        //        _user = value;
        //    }

        //}
        public string getUser(string name)
        {
            
            return name;

        }
        


    }
    public interface IUser
    { 
        string getUser(string user);
    }
}
