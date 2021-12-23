using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;

namespace Registration.Models
{
    public class accountRegistration
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string password { get; set; }

        private string path = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/customer.xml";
        public bool isAccountExist { get; set; }
        public void checkAccount()
        {

            //XmlDocument doc = new XmlDocument();
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList elemList = doc.GetElementsByTagName("email");
                for (int j = 0; j < elemList.Count; j++)
                {
                    if (elemList[j].InnerText == email )
                    {

                        isAccountExist = true;
                    }
                    else
                    {
                        isAccountExist = false;
                        storeData();
                    }
                }
            }
            else
            {
                isAccountExist = false;
                storeData();
            }
        }

        public void storeData()
        {
            
            
            if (!File.Exists(path))
            {

                XmlDocument tempdoc = new XmlDocument();
                XmlElement temproot = tempdoc.DocumentElement;
                XmlDeclaration dec = tempdoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                tempdoc.InsertBefore(dec, temproot);
                XmlElement element1 = tempdoc.CreateElement(string.Empty, "rental_application", string.Empty);
                tempdoc.AppendChild(element1);
                tempdoc.Save(path);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.SelectSingleNode("rental_application");
            XmlElement customerAccount = doc.CreateElement(string.Empty, "Account_Details", string.Empty);
            root.AppendChild(customerAccount);
            XmlElement xml_name = doc.CreateElement(string.Empty, "name", string.Empty);
            customerAccount.AppendChild(xml_name);
            xml_name.InnerText = name;
            XmlElement xml_email = doc.CreateElement(string.Empty, "email", string.Empty);
            customerAccount.AppendChild(xml_email);
            xml_email.InnerText = email;
            XmlElement xml_dob = doc.CreateElement(string.Empty, "dob", string.Empty);
            customerAccount.AppendChild(xml_dob);
            xml_dob.InnerText = dob.ToShortDateString();
            XmlElement xml_gender = doc.CreateElement(string.Empty, "gender", string.Empty);
            customerAccount.AppendChild(xml_gender);
            xml_gender.InnerText = gender;
            XmlElement xml_address = doc.CreateElement(string.Empty, "address", string.Empty);
            customerAccount.AppendChild(xml_address);
            xml_address.InnerText = address;
            XmlElement xml_password = doc.CreateElement(string.Empty, "password", string.Empty);
            customerAccount.AppendChild(xml_password);
            xml_password.InnerText = password;
            doc.Save(path);

        }
    }

  

}