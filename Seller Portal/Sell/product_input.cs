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
    public partial class product_input : Form
    {
        public static string path = @"C:\Users\AbduRraffay\Desktop\IPTproject\products.xml";
        public string pname;
        public int price;
        public string link;
        public int rent_days;
        products p1;
        public product_input(products prod)
        {
            p1 = prod;
            
            InitializeComponent();
            textBox5.Enabled = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void ret()
        {
            //products p2 = new products();

            //p2.result(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

        }
        public string getitems()
        {
            return "hello";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="")
            {
                if (!textBox3.Text.All(char.IsDigit))
                {
                    MessageBox.Show("enter the product price again without any other characters other than numbers");
                    textBox3.Text = "";
                }
                else if(!textBox2.Text.All(char.IsDigit))
                {
                    MessageBox.Show("enter the number of rent days again without any other characters other than numbers");
                    textBox2.Text = "";
                }
                else if(textBox2.Text=="0")
                {
                    MessageBox.Show("The rent can not of zero days plzz enter valid days!!");
                    textBox2.Text = "";
                }
                else
                {
                    p1.result(textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text,textBox5.Text);
                    this.Close();
                   // ret();
                    //this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("please enter all details of the product");

            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Product_input_Load(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void prodid(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            if(File.Exists(path))
            {
                XmlNodeList elemList = doc.GetElementsByTagName("seller_email");
                textBox5.Enabled = true;
                textBox5.Text = "p" + Convert.ToString(elemList.Count);
                textBox5.Enabled = false;
            }
            else
            {
                textBox5.Enabled = true;
                textBox5.Text = "p0";
                textBox5.Enabled = false;
            }
            
        }
    }
}
