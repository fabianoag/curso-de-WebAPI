using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SiteAspNetMVC.Models
{
    public class UserTokenDTO
    {
        public string Username { get; set; }
        public string access_token { get; set; }
    }

    public class CrieSessao
    {
        public string username
        {
            get
            {
                try
                {                    
                    return HttpContext.Current.Session["username"].ToString();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["username"] = value;
            }
        }

        public string access_token
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["token"].ToString();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["token"] = value;
            }
        }
    }
}