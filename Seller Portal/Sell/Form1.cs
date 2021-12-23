using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace IPTproject
{
    public partial class Form1 : Form
    {
        string name;
        string password;
        string phone;
        string email;
        string address;
        string num_orders;
        string avg_rating;
        int index;
        public Form1(string sell_email,string sell_passwd, int ind)
        {
            InitializeComponent();
            email = sell_email;
            password = sell_passwd;
            index = ind;
            XmlDocument d = new XmlDocument();
            string path = @"C:\Users\AbduRraffay\Desktop\IPTproject\seller.xml";
            d.Load(path);
            XmlNodeList elemList = d.GetElementsByTagName("phone_number");
            XmlNodeList elemList1 = d.GetElementsByTagName("address");
            XmlNodeList elemList2 = d.GetElementsByTagName("number_of_order");
            XmlNodeList elemList3 = d.GetElementsByTagName("avg_rating");
            XmlNodeList elemList4 = d.GetElementsByTagName("seller_id");
            phone = elemList[index].InnerText;
            address = elemList1[index].InnerText;
            num_orders = elemList2[index].InnerText;
            avg_rating = elemList3[index].InnerText;
            name = elemList4[index].InnerText;
            name = email.Split('@')[0];
            

        }
        public Form1(string seller_name,string pass,string number,string emails,string address1,string num_of_orders,string rating)
        {
            InitializeComponent();
            name = seller_name;
            password = pass;
            phone = number;
            email = emails;
            address = address1;
            avg_rating = rating;
            num_orders = num_of_orders;
            
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private void label2_name(object sender, EventArgs e)
        {
            //MessageBox.Show(name);
            label2.Text = "Welcome  " + name;
           // MessageBox.Show(label2.Text);
            label5.Text = name;

            label12.Text = password;
            
            label7.Text = phone;
            label10.Text = email;
            label14.Text = address;
            label16.Text = num_orders;
            label18.Text = avg_rating;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool check_order()
        {
            string ordpath = @"C:\Users\AbduRraffay\Desktop\IPTproject\order.xml";
            if(File.Exists(ordpath))
            {
                XmlDocument d = new XmlDocument();
                
                d.Load(ordpath);
                XmlNodeList elemList = d.GetElementsByTagName("sellerID");
                int i;
                for(i=0;i<elemList.Count;i++)
                {
                    if(email==elemList[i].InnerText)
                    {
                        return true;
                    }
                    if(i==elemList.Count-1)
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
            return false;
        }
        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool resp;
            resp = check_order();
            if(resp)
            {
                
                orders o1 = new orders(email);
                o1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry you don't have any orders to display!!!");
            }
            
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            products prod=new products();
            products p = new products(email,prod);
            products q = new products(p);
            this.Hide();
            p.Show();
        }
    }
}
