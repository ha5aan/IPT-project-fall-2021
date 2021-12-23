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
using System.Text.RegularExpressions;

namespace IPTproject
{
    public partial class signin : Form
    {
        bool already_have_an_acc;
        int count;
        string name;
        string password;
        string phone;
        string semail;
        string address;
        string num_orders;
        string avg_rating;
        public signin()
        {
            already_have_an_acc = true;
            InitializeComponent();
        }
        public signin(string seller_name, string pass, string number, string emails, string address1, string num_of_orders, string rating)
        {
            name = seller_name;
            password = pass;
            phone = number;
            semail = emails;
            address = address1;
            avg_rating = rating;
            num_orders = num_of_orders;
            already_have_an_acc = false;
            InitializeComponent();
        }
        private void email_check(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Please enter the email in correct format");
                textBox1.Text = "";
            }
            else
            {
                //MessageBox.Show(semail);
                //if(!already_have_an_acc)
                
                    verify_email();
                
                
                //MessageBox.Show("hello");
            }
            
        }
        private void verify_email()
        {
            bool valid_emails = false;
            string email;
            XmlDocument d = new XmlDocument();
            string path = @"C:\Users\AbduRraffay\Desktop\IPTproject\seller.xml";
            d.Load(path);
            
            XmlNodeList elemList = d.GetElementsByTagName("email");
            if(semail!=null)
            {
               // MessageBox.Show(semail);

                for (int j = 0; j < elemList.Count; j++)
                {
                    if (elemList[j].InnerText == textBox1.Text && textBox1.Text==semail)
                    {
                        //MessageBox.Show("HIIIIII");
                        count = j;
                        email = textBox1.Text;
                        valid_emails = true;
                        break;


                    }
                    else
                    {
                        valid_emails = false;
                    }
                }
                if(!valid_emails)
                {
                    MessageBox.Show("Invalid email");
                    textBox1.Text = "";
                }
            }
            else
            {
                
                for (int j = 0; j < elemList.Count; j++)
                {
                    
                    if (elemList[j].InnerText == textBox1.Text)
                    {
                       // MessageBox.Show("HIIIIII");
                        count = j;
                       // email = textBox1.Text;
                        valid_emails = true;
                        break;


                    }
                    else
                    {
                        valid_emails = false;
                    }
                }
                if (!valid_emails)
                {
                    MessageBox.Show("Invalid email");
                    textBox1.Text = "";
                }
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void check_password(object sender, EventArgs e)
        {
            XmlDocument d = new XmlDocument();
            string path = @"C:\Users\AbduRraffay\Desktop\IPTproject\seller.xml";
            d.Load(path);
            XmlNodeList elemList = d.GetElementsByTagName("password");
            if (elemList[count].InnerText != textBox2.Text)
            {
                
                MessageBox.Show("Incorrect password entered");
                textBox2.Text = "";
                


            }
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!=""&& !already_have_an_acc)
            {
                Form1 f = new Form1(name,password,phone,semail,address,num_orders,avg_rating);
                this.Hide();
                f.Show();
            }
            else if(textBox1.Text != "" && textBox2.Text != "" && already_have_an_acc)
            {
                Form1 f1 = new Form1(textBox1.Text,textBox2.Text,count);
                this.Hide();
                f1.Show();
            }
            else 
            {
                MessageBox.Show("Please enter the missing credentials correctly");
            }
        }

        private void Signin_Load(object sender, EventArgs e)
        {

        }
    }
}
