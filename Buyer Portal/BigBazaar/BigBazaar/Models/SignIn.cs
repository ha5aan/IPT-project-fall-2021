using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;


namespace SignIn.Models
{
    public class accountSignIn
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool isLogin { get; set; }

        private string path = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/customer.xml";
        public void checkAccount()
        {
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNodeList emailList = doc.GetElementsByTagName("email");
                XmlNodeList passwordList = doc.GetElementsByTagName("password");
                for (int j = 0; j < emailList.Count; j++)
                {
                    if (emailList[j].InnerText == email && passwordList[j].InnerText == password)
                    {
                        isLogin = true;
                    }
                }
            }

        }

        
    }
}