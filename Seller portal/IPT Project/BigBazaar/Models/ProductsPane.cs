using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;


namespace ProductsPane.Models
{
    public class Products
    {
        public productInfo[]  product { get; set; }
        private string path1 = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/products.xml";
        private string path2 = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/seller.xml";
        public void readProduct()
        {
            if (File.Exists(path1))
            {
                XmlDocument doc1 = new XmlDocument();
                XmlDocument doc2 = new XmlDocument();
                doc1.Load(path1);
                doc2.Load(path2);


                XmlNodeList emailproductList = doc1.GetElementsByTagName("seller_email");
                XmlNodeList productIDList = doc1.GetElementsByTagName("productid");
                XmlNodeList productnameList = doc1.GetElementsByTagName("productname");
                XmlNodeList productlinkList = doc1.GetElementsByTagName("productlink");
                XmlNodeList productpriceList = doc1.GetElementsByTagName("productprice");
                XmlNodeList productdaysList = doc1.GetElementsByTagName("rentdays");
                XmlNodeList emailList = doc2.GetElementsByTagName("email");
                XmlNodeList nameList = doc2.GetElementsByTagName("seller_id");
                XmlNodeList ratingList = doc2.GetElementsByTagName("avg_rating");
                product = new  productInfo [productnameList.Count];


                for (int j = 0; j < productnameList.Count; j++)
                {

                    string sellerEmail = emailproductList[j].InnerText;
                    string sellerName="";
                    string sellerRating="";
                    string productID = productIDList[j].InnerText;
                    string productName = productnameList[j].InnerText;
                    string productLink = productlinkList[j].InnerText;
                    string productPrice = productpriceList[j].InnerText;
                    string productDays = productdaysList[j].InnerText;
                    for (int i = 0; i < emailList.Count; i++)
                    {
                        if (emailList[i].InnerText == emailproductList[j].InnerText)
                        {
                             sellerName  = nameList[i].InnerText;
                             sellerRating = ratingList[i].InnerText;
                        }

                    }
                    product[j] = new productInfo { sellerEmail = sellerEmail, sellerName = sellerName, sellerRating = sellerRating, productID = productID,productName = productName, productLink = productLink, productPrice = productPrice, productDays = productDays };


               }
                Console.WriteLine(product[0]);

            }

        }

    }

    public class productInfo
    {
        public string sellerEmail { get; set; }
        public string sellerName { get; set; }
        public string sellerRating { get; set; }

        public string productID { get; set; }
        public string productName { get; set; }
        public string productLink { get; set; }
        public string productPrice { get; set; }
        public string productDays { get; set; }
    }
}
