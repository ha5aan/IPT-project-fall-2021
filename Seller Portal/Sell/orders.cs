using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
/// <summary>
/// ///
/// </summary>
namespace IPTproject
{
    public partial class orders : Form
    {
        public static int ind;
        public static string ordpath = @"C:\Users\AbduRraffay\Desktop\IPTproject\order.xml";
        public static string sell_email;
        public static ComboBox c;
        public static TextBox t;
        List<int> list = new List<int>();
        public orders(string email)
        {
            sell_email = email;
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            list.Clear();
            
            XmlDocument doc = new XmlDocument();
            doc.Load(ordpath);
            XmlNodeList elemList = doc.GetElementsByTagName("sellerID");
            XmlNodeList elemList1 = doc.GetElementsByTagName("orderID");
            XmlNodeList elemList2 = doc.GetElementsByTagName("productID");
            XmlNodeList elemList3 = doc.GetElementsByTagName("customerID");
            XmlNodeList elemList4 = doc.GetElementsByTagName("totalPrice");
            XmlNodeList elemList5 = doc.GetElementsByTagName("status");
            XmlNodeList elemList6 = doc.GetElementsByTagName("shippingAddress");
            

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
            for (int k = 0; k < list.Count; k++)
            {
                GroupBox grou = new GroupBox();
                // MessageBox.Show(Convert.ToString(count));
                grou.Location = new Point(53, 73 + (((k + 1) - 1) * 300));
                grou.Visible = true;
                grou.Width = 740;
                grou.Height = 250;
                grou.Name = "g1";
                grou.BackColor = Color.White;
                grou.Text = "";
                grou.AutoSize = true;

                grou.AutoSizeMode = AutoSizeMode.GrowOnly;
                grou.Enabled = true;
                this.Controls.Add(grou);
                Label l23 = new Label();
                l23.Text = "update_status ";
                l23.Location = new Point(5, 68);
                l23.Visible = true;
                grou.Controls.Add(l23);
                ComboBox box = new ComboBox();
                box.Location = new Point(150, 68);
                box.Width = 200;
                box.Height = 26;
                box.Name = "combobox";
                box.Items.Add("processing");
                box.Items.Add("dispatched");
                box.Items.Add("shipped");
                box.Items.Add("out for delivery");
                box.Items.Add("delivered");
                box.Items.Add("cancelled");
                
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

                //grou.Controls.Add(pict);
                //this.Controls.Add(pict);
                TextBox t1 = new TextBox();
                TextBox t2 = new TextBox();
                TextBox t3 = new TextBox();
                TextBox t4 = new TextBox();
                TextBox t5 = new TextBox();
                TextBox t6 = new TextBox();
                TextBox t7 = new TextBox();
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
                t2.Width = 150;
                t2.Height = 20;
                t2.Name = "textbox2";
                t2.Visible = true;

                t4.Location = new Point(619, 133);
                t4.Width = 100;
                t4.Height = 20;
                t4.Name = "textbox4";
                t4.Visible = true;

                t5.Location = new Point(619, 175);
                t5.Width = 100;
                t5.Height = 20;
                t5.Name = "textbox5";
                t5.Visible = true;

                t6.Location = new Point(619, 219);
                t6.Width = 100;
                t6.Height = 20;
                t6.Name = "textbox6";
                t6.Visible = true;

                t7.Location = new Point(619, 265);
                t7.Width = 100;
                t7.Height = 20;
                t7.Name = "textbox7";
                t7.Visible = true;
                //this.Controls.Add(t2);
                //groupBox1.Visible = true;
                // pictureBox1.Load(prodlink);
                Label l2 = new Label();
                l2.Text = "orderID ";
                l2.Location = new Point(500, 19);
                l2.Visible = true;
                grou.Controls.Add(l2);
                Label l3 = new Label();
                l3.Text = "productID ";
                l3.Location = new Point(500, 55);
                l3.Visible = true;
                grou.Controls.Add(l3);
                Label l4 = new Label();
                l4.Text = "customerID ";
                l4.Location = new Point(500, 93);
                l4.Visible = true;
                grou.Controls.Add(l4);

                Label l5 = new Label();
                l5.Text = "sellerID ";
                l5.Location = new Point(500, 133);
                l5.Visible = true;
                grou.Controls.Add(l5);

                Label l6 = new Label();
                l6.Text = "totalPrice ";
                l6.Location = new Point(500, 175);
                l6.Visible = true;
                grou.Controls.Add(l6);

                Label l7 = new Label();
                l7.Text = "status ";
                l7.Location = new Point(500, 219);
                l7.Visible = true;
                grou.Controls.Add(l7);

                Label l8 = new Label();
                l8.Text = "shippingAddress ";
                l8.Location = new Point(500, 265);
                l8.Visible = true;
                grou.Controls.Add(l8);
                t1.Text = elemList1[list[k]].InnerText;
                t3.Text = elemList2[list[k]].InnerText;
                t2.Text = elemList3[list[k]].InnerText;
                t4.Text = elemList[list[k]].InnerText;
                t5.Text = elemList4[list[k]].InnerText;
                t6.Text = elemList5[list[k]].InnerText; //status
                t7.Text = elemList6[list[k]].InnerText;
                t1.Enabled = false;
                t2.Enabled = false;
                t3.Enabled = false;
                t4.Enabled = false;
                t5.Enabled = false;
                t6.Enabled = false;
                t7.Enabled = false;
              //  MessageBox.Show(box.Text);
                if (box.Text == "processing")
                {
                    t6.Text = "processing";
                }
                else if (box.Text == "dispatched")
                {
                    t6.Text = "dispatched";
                }
                else if (box.Text == "shipped")
                {
                    t6.Text = "shipped";
                }
                else if (box.Text == "out for delivery")
                {
                    t6.Text = "out for delivery";
                }
                else if (box.Text == "delivered")
                {
                    t6.Text = "delivered";
                }
                else if (box.Text == "cancelled")
                {
                    t6.Text = "cancelled";
                }
                
                elemList5[list[k]].InnerText = box.Text;
                c = box;
                t = t6;
                ind = k;
                box.SelectedIndexChanged += new System.EventHandler(boxes);
                
                grou.Controls.Add(box);

                grou.Controls.Add(t1);
                grou.Controls.Add(t3);
                grou.Controls.Add(t2);
                grou.Controls.Add(t4);
                grou.Controls.Add(t5);
                grou.Controls.Add(t6);
                grou.Controls.Add(t7);
                
                //item m = box.SelectedItem;
                
                Label label1 = new Label();
                label1.AutoSize = false;
                label1.Height = 2;
                label1.BorderStyle = BorderStyle.Fixed3D;
            }

        }
        private void boxes(object sender,EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ordpath);
            XmlNodeList elemList5 = doc.GetElementsByTagName("status");
            elemList5[ind].InnerText = c.Text;
            t.Text = c.Text;
            // MessageBox.Show(c.Text);
            doc.Save(ordpath);

        }
    }
}
