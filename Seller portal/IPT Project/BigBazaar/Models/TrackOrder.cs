using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;


namespace TrackOrder.Models
{
    public class orderDetails
    {
            public string sellerEmail { get; set; }
            public string sellerName { get; set; }
            public string orderID { get; set; }

            public string customerEmail { get; set; }
            public string customerName { get; set; }

            public string productID { get; set; }
            public string productName { get; set; }
            public string productLink { get; set; }
            public string productPrice { get; set; }
            public string productDays { get; set; }

            public string shipingAddress { get; set; }
            public int totalPrice { get; set; }

            private string path1 = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/products.xml";
            private string path2 = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/seller.xml";
            private string path3 = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/customer.xml";
            private string path4 = @"C:/Users/Adil Asif/Desktop/IPT Project/Files/order.xml";


            public void readProduct(string productId)
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



                    for (int j = 0; j < productnameList.Count; j++)
                    {
                        if (productIDList[j].InnerText == productId)
                        {
                            sellerEmail = emailproductList[j].InnerText;
                            productID = productIDList[j].InnerText;
                            productName = productnameList[j].InnerText;
                            productLink = productlinkList[j].InnerText;
                            productPrice = productpriceList[j].InnerText;
                            productDays = productdaysList[j].InnerText;
                            for (int i = 0; i < emailList.Count; i++)
                            {
                                if (emailList[i].InnerText == emailproductList[j].InnerText)
                                {
                                    sellerName = nameList[i].InnerText;
                                }

                            }

                        }

                    }

                }
            }

            public void readCustomerDetail(string customerID)
            {
                if (File.Exists(path3))
                {
                    XmlDocument doc1 = new XmlDocument();
                    doc1.Load(path3);


                    XmlNodeList customeremailList = doc1.GetElementsByTagName("email");
                    XmlNodeList customernameList = doc1.GetElementsByTagName("name");
                    XmlNodeList customeraddressList = doc1.GetElementsByTagName("address");



                    for (int j = 0; j < customeremailList.Count; j++)
                    {
                        if (customeremailList[j].InnerText == customerID)
                        {
                            customerEmail = customeremailList[j].InnerText;
                            customerName = customernameList[j].InnerText;


                        }


                    }

                }
            }

        }
    }
    
