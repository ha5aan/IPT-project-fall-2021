using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Xml;
//using MsgBox;
namespace IPTproject
{
    public partial class products : Form
    {
        List<int> list = new List<int>();
        prodxml obj = new prodxml();
        public static int count = 0;
        public static string pname;
        product_input ip;
        public static string plink;
        int rentdays;
        public int ind;
        public static int price;
        public static string prodid;
        public static string sell_email;
        public static string path  = @"C:\Users\AbduRraffay\Desktop\IPTproject\products.xml";
        products orig_p;
        products prod1;
        public products(string email,products prod)
        {
            sell_email = email;
            prod1 = prod;
            InitializeComponent();
            //groupBox1.Visible = false;
        }
        bool wait = true;
        public products(products p3)
        {
            orig_p = p3;
        }
        public products()
        {
           // InitializeComponent();
        }
        public void result(string name, string prices, string days, string link,string pid)
        {
            //InitializeComponent();
            pname = name;
            plink = link;
            prodid = pid;
            price = Convert.ToInt32(prices);
            rentdays = Convert.ToInt32(days);
            if(!File.Exists(path))
            {
                obj.init();
                obj.addelement(sell_email, pname, plink, price, rentdays,prodid);
            }
            else
            {
                obj.addelement(sell_email,pname,plink,price,rentdays,prodid);
            }
            wait = false;
           // display();
            //string prodname,string prodlink,int prodprice,int proddays
        }
        public void display()
        {
            /*MessageBox.Show(pname);
            MessageBox.Show(plink);
            //MessageBox.Show(this);
            //MessageBox.Show(prodprice);
           // Products_Load(this,"");



            GroupBox grou = new GroupBox();
            grou.Location=new Point(179,145);
            grou.Visible = true;
            grou.Width = 761;
            grou.Height = 163;
            grou.Name = "g1";
            grou.BackColor = Color.White;
            grou.Text = "hahahah";
            grou.AutoSize = true;
            grou.AutoSizeMode=AutoSizeMode.GrowOnly;
            grou.Enabled = true;
            this.Controls.Add(grou);
            if(this is products)
            {
                MessageBox.Show("Products is this");
            }
            else
            {
                MessageBox.Show("Products is not this");
            }
            PictureBox pict = new PictureBox();
            pict.Name = "pict1";
            pict.Location = new Point(6, 19);
            pict.Width = 168;
            pict.Height = 136;
            pict.BackColor = Color.Lime;
            pict.ImageLocation = plink;
            //pict.Load(plink);
            pict.Visible = true;
            grou.Controls.Add(pict);
            //this.Controls.Add(pict);
            TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();
            TextBox t3 = new TextBox();
            t1.Location = new Point(619, 19);
            t1.Width = 100;
            t1.Height = 20;
            t1.Name = "textbox1";
            t1.Visible = true;
            t3.Location = new Point(619, 55);
            t3.Width = 100;
            t3.Height = 20;
            t3.Name = "textbox3";
            t3.Visible = true;
            //this.Controls.Add(t3);
            t2.Location = new Point(619, 93);
            t2.Width = 100;
            t2.Height = 20;
            t2.Name = "textbox2";
            t2.Visible = true;
            //this.Controls.Add(t2);
            //groupBox1.Visible = true;
            // pictureBox1.Load(prodlink);
            t1.Text = pname;
            t3.Text = Convert.ToString(price);
            t2.Text = Convert.ToString(rentdays);
            grou.Controls.Add(t1);
            grou.Controls.Add(t3);
            grou.Controls.Add(t2);
           // ip.Close();
            //this.Controls.Add(t1);
            //this.Controls.Add(t3);
            //this.Controls.Add(t2);
            */
        }
        private void Button1_Click(object sender, EventArgs e)
        {
           // groupBox1.Visible = false;
            product_input p1 = new product_input(prod1);
            ip = p1;
           // this.Hide();
            p1.Show();
            list.Clear();
            //this.Show();
            count++;




        }
        

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(plink);
            
         
        }

        private void Products_Load(object sender, EventArgs e)
        {

            if (!File.Exists(path))
            {
                MessageBox.Show("Sorry you don't have any items uploaded so nothing to display!!!");
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList elemList = doc.GetElementsByTagName("seller_email");
                XmlNodeList elemList1 = doc.GetElementsByTagName("productname");
                XmlNodeList elemList2 = doc.GetElementsByTagName("productprice");
                XmlNodeList elemList3 = doc.GetElementsByTagName("rentdays");
                XmlNodeList elemList4 = doc.GetElementsByTagName("productlink");
                
                for (int i=0;i<elemList.Count;i++)
                {
                    if(elemList[i].InnerText==sell_email)
                    {
                        ind = i;
                        break;
                    }
                    if(i==elemList.Count-1)
                    {
                        MessageBox.Show("Sorry the count of products is zero hence you don't have any items uploaded so nothing to display");
                    }
                }
                if (elemList.Count==0)
                {
                    MessageBox.Show("Sorry the count of products is zero hence you don't have any items uploaded so nothing to display");
                }
                else
                {
                   // MessageBox.Show(Convert.ToString(elemList.Count));
                    list.Clear();
                    for (int j = 0; j < elemList.Count; j++)
                    {
                         if (elemList[j].InnerText == sell_email)
                         {
                            list.Add(j);
                            // MessageBox.Show("You have already an accoune sorry can not create another");
                            // textBox1.Text = "";
                             //MessageBox.Show("please press the button with label already have an account");
                             
                         
                            // add list here for storing the indexes of occurences of sell_email


                         }
                         
                    }
                    for(int k=0;k<list.Count;k++)
                    {
                        GroupBox grou = new GroupBox();
                       // MessageBox.Show(Convert.ToString(count));
                        grou.Location = new Point(53, 73 + (((k+1) - 1) * 300));
                        grou.Visible = true;
                        grou.Width = 720;
                        grou.Height = 250;
                        grou.Name = "g1";
                        grou.BackColor = Color.White;
                        grou.Text = "";
                        grou.AutoSize = true;
                        
                        grou.AutoSizeMode = AutoSizeMode.GrowOnly;
                        grou.Enabled = true;
                        this.Controls.Add(grou);
                        PictureBox pict = new PictureBox();
                        pict.Name = "pict1";
                        pict.Location = new Point(41, 68);
                        pict.Width = 205;
                        pict.Height = 136;
                        
                        pict.BackColor = Color.Lime;
                        /*OpenFileDialog open = new OpenFileDialog();
                        // image filters  
                        open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            // display image in picture box  
                            pict.Image = new Bitmap(plink);
                            // image file path  
                            //textBox1.Text = open.FileName;
                        }
                        */
                        //MessageBox.Show(elemList4[list[k]].InnerText);
                        string location = elemList4[list[k]].InnerText;
                        pict.ImageLocation = location;
                        pict.SizeMode = PictureBoxSizeMode.StretchImage;
                        //MessageBox.Show(plink);
                        //pict.Load(elemList4[list[k]].InnerText);
                        pict.Visible = true;
                        grou.Controls.Add(pict);
                        //this.Controls.Add(pict);
                        TextBox t1 = new TextBox();
                        TextBox t2 = new TextBox();
                        TextBox t3 = new TextBox();
                        t1.Location = new Point(619, 19);
                        t1.Width = 100;
                        t1.Height = 20;
                        t1.Name = "textbox1";
                        t1.Visible = true;
                        t3.Location = new Point(619, 55);
                        t3.Width = 100;
                        t3.Height = 20;
                        t3.Name = "textbox3";
                        t3.Visible = true;
                        //this.Controls.Add(t3);
                        t2.Location = new Point(619, 93);
                        t2.Width = 100;
                        t2.Height = 20;
                        t2.Name = "textbox2";
                        t2.Visible = true;
                        //this.Controls.Add(t2);
                        //groupBox1.Visible = true;
                        // pictureBox1.Load(prodlink);
                        Label l2 = new Label();
                        l2.Text = "pname ";
                        l2.Location = new Point(500, 19);
                        l2.Visible = true;
                        grou.Controls.Add(l2);
                        Label l3 = new Label();
                        l3.Text = "price ";
                        l3.Location = new Point(500, 55);
                        l3.Visible = true;
                        grou.Controls.Add(l3);
                        Label l4 = new Label();
                        l4.Text = "rent days ";
                        l4.Location = new Point(500, 93);
                        l4.Visible = true;
                        grou.Controls.Add(l4);
                        t1.Text = elemList1[list[k]].InnerText;
                        t3.Text = elemList2[list[k]].InnerText;
                        t2.Text = elemList3[list[k]].InnerText;
                        t1.Enabled = false;
                        t2.Enabled = false;
                        t3.Enabled = false;
                        grou.Controls.Add(t1);
                        grou.Controls.Add(t3);
                        grou.Controls.Add(t2);
                        Label label1 = new Label();
                        label1.AutoSize = false;
                        label1.Height = 2;
                        label1.BorderStyle = BorderStyle.Fixed3D;
                    }
                    
                }
                
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Products_Load_1(object sender, EventArgs e)
        {

        }
    }
    public class prodxml
    {
        XmlElement e1;
        //signup form = new signup();
        string path1 = @"C:\Users\AbduRraffay\Desktop\IPTproject\products.xml";
         
        public void init()
        {
            //statid = stationid;
            
            XmlDocument doc = new XmlDocument();
            
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(dec, root);
                XmlElement element1 = doc.CreateElement(string.Empty, "rental_application_products", string.Empty);
                e1 = element1;
                doc.AppendChild(element1);
                doc.Save(path1);
              //  return true;
            
            
            //doc.Load(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");


            //doc.Save(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");

        }
        public void addelement(string seller_id, string prodname, string prodlink, int prodprice , int rentdays,string pid)
        {
            
                XmlDocument doc = new XmlDocument();
                doc.Load(path1);

                XmlNode root = doc.SelectSingleNode("rental_application_products");
                XmlElement element1 = doc.CreateElement(string.Empty, "product_details", string.Empty);
                root.AppendChild(element1);
                //element1.InnerText = seller_id;
                XmlElement element2 = doc.CreateElement(string.Empty, "seller_email", string.Empty);
                element1.AppendChild(element2);
                element2.InnerText = seller_id;
                XmlElement element21 = doc.CreateElement(string.Empty, "productname", string.Empty);
                element1.AppendChild(element21);
                element21.InnerText = prodname;
                XmlElement element3 = doc.CreateElement(string.Empty, "productlink", string.Empty);
                element1.AppendChild(element3);
                element3.InnerText = prodlink;

                XmlElement element4 = doc.CreateElement(string.Empty, "productprice", string.Empty);
                element1.AppendChild(element4);
                element4.InnerText = Convert.ToString(prodprice);
                XmlElement element5 = doc.CreateElement(string.Empty, "rentdays", string.Empty);
                element1.AppendChild(element5);
                element5.InnerText = Convert.ToString(rentdays);
                XmlElement element6 = doc.CreateElement(string.Empty, "productid", string.Empty);
                element1.AppendChild(element6);
                element6.InnerText = pid;
                doc.Save(path1);
            


            //doc.Load(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");

            //doc.Save(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");
        }
    }

}
