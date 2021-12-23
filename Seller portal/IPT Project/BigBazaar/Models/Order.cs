using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;

namespace Order.Models
{
    public class orderDetails
    {
       public string sellerEmail { get; set; }
       public string sellerName { get; set; }
       public string sellerRating { get; set; }
        public string orderID{ get; set; }

        public string customerEmail { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }

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
                                sellerRating = ratingList[i].InnerText;
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
                        customerAddress = customeraddressList[j].InnerText;
                       

                    }


                }

            }
        }

        public void calculatePrice(int days,string shipAddress)
        {
            int pricePerDay = int.Parse(productPrice) / int.Parse(productDays);
            totalPrice = pricePerDay * days;
            totalPrice = totalPrice + 60;
            shipingAddress = shipAddress;
        }

        public void storeData()
        {

            createOrderID();

            if (!File.Exists(path4))
            {

                XmlDocument tempdoc = new XmlDocument();
                XmlElement temproot = tempdoc.DocumentElement;
                XmlDeclaration dec = tempdoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                tempdoc.InsertBefore(dec, temproot);
                XmlElement element1 = tempdoc.CreateElement(string.Empty, "rental_application_orders", string.Empty);
                tempdoc.AppendChild(element1);
                tempdoc.Save(path4);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path4);
            XmlNode root = doc.SelectSingleNode("rental_application_orders");
            XmlElement OrderDetail = doc.CreateElement(string.Empty, "Order_Details", string.Empty);
            root.AppendChild(OrderDetail);
            XmlElement xml_productID = doc.CreateElement(string.Empty, "productID", string.Empty);
            OrderDetail.AppendChild(xml_productID);
            xml_productID.InnerText = productID;
            XmlElement xml_sellerID = doc.CreateElement(string.Empty, "sellerID", string.Empty);
            OrderDetail.AppendChild(xml_sellerID);
            xml_sellerID.InnerText = sellerEmail;
            XmlElement xml_customerID = doc.CreateElement(string.Empty, "customerID", string.Empty);
            OrderDetail.AppendChild(xml_customerID);
            xml_customerID.InnerText = customerEmail;
            XmlElement xml_totalPrice = doc.CreateElement(string.Empty, "totalPrice", string.Empty);
            OrderDetail.AppendChild(xml_totalPrice);
            xml_totalPrice.InnerText = totalPrice.ToString();
            XmlElement xml_shippingAddress = doc.CreateElement(string.Empty, "shippingAddress", string.Empty);
            OrderDetail.AppendChild(xml_shippingAddress);
            xml_shippingAddress.InnerText = shipingAddress;
            XmlElement xml_orderstatus = doc.CreateElement(string.Empty, "status", string.Empty);
            OrderDetail.AppendChild(xml_orderstatus);
            xml_orderstatus.InnerText = "Processing";
            xml_shippingAddress.InnerText = shipingAddress;
            XmlElement xml_orderId = doc.CreateElement(string.Empty, "orderID", string.Empty);
            OrderDetail.AppendChild(xml_orderId);
            xml_orderId.InnerText = orderID ;
            doc.Save(path4);

        }

        public void createOrderID()
        {
            Random rnd = new Random();
            orderID = productID + rnd.Next().ToString()+ customerEmail[0] + customerEmail[1];
        }


    }

}


