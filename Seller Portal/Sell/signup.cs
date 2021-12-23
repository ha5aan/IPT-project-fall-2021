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
    public partial class signup : Form
    {
        Xml obj = new Xml();
        //Regex myRegularExpression1 = new Regex("*"+"@"+"*"+"."+"*");
        //Regex myRegularExpression = new Regex("\b[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,}\b");
        //Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        //if(myRegularExpression.isMatch(txtEmail.Text))
        // {
        //valid e-mail
        //}
        public signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            textBox7.Text = "0";
            textBox7.Enabled = false;
            textBox8.Text = "5";
            textBox8.Enabled = false;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string path;
            path = @"C:\Users\AbduRraffay\Desktop\IPTproject\seller.xml";
            //XmlDocument doc = new XmlDocument();
            if(File.Exists(path))
            {
                signin f1 = new signin();
                this.Hide();
                f1.Show();
            }
            else
            {
                MessageBox.Show("There is no account of yours");
            }
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // This is submit button
            if(!obj.init())
            {
                //while(true)
                
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                    {
                        obj.addelement(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                        signin f2 = new signin(textBox9.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                        this.Hide();
                        f2.Show();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        


                    }
                    else
                    {
                        MessageBox.Show("please enter all details for signup");
                    }
                
                
                    
                
            }
            else
            {
                //while (true)
                
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                    {
                        obj.addelement(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                        signin f = new signin(textBox9.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                        this.Hide();
                        f.Show();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        

                }
                    else
                    {
                        MessageBox.Show("please enter all details for signup");
                    }
                
            }
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            
            /*
            if (!textBox7.Text.All(char.IsDigit))
            {
                MessageBox.Show("enter the number of orders again without any other characters other than numbers");
                textBox7.Text = "";
            }
            */
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
        private void email_check(object sender, EventArgs e)
        {
            // MessageBox.Show("what is the length of email", "title", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if(!Regex.IsMatch(textBox4.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Please enter the email in correct format");
                textBox4.Text = "";
            }
            
            
        }
        private void gender_check(object sender, EventArgs e)
        {
            if(textBox5.Text!="Male" && textBox5.Text != "Female")
            {
                MessageBox.Show("Incorrect gender entered it should be either Male or Female");
                textBox5.Text = "";
            }
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            //string input_completed = "Have you completed the input?";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult res = MessageBox.Show(input_completed,"close window" ,buttons);
            
            


        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void check_number_length(object sender,EventArgs e)
        {
            if(textBox3.Text.Length!=11)
            {
                MessageBox.Show("please enter the number correctly the length is short than 11");
                textBox3.Text = "";
            }
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if(!textBox3.Text.All(char.IsDigit))
            {
                MessageBox.Show("enter the phone number again without any dash");
                textBox3.Text = "";
            }
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

            /*
            if (!textBox8.Text.All(char.IsDigit))
            {
                MessageBox.Show("enter the rating again without any other characters other than numbers ");
                textBox8.Text = "";
            }
            */
        }
        private void check_seller_id(object sender, EventArgs e)
        {
            string path = @"C:\Users\AbduRraffay\Desktop\IPTproject\seller.xml";
            if(File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList elemList = doc.GetElementsByTagName("email");
                for (int j = 0; j < elemList.Count; j++)
                {
                    if (elemList[j].InnerText == textBox4.Text)
                    {
                        MessageBox.Show("You have already an accoune sorry can not create another");
                        textBox4.Text = "";
                        MessageBox.Show("please press the button with label already have an account");
                        break;

                    }
                }
            }
            

        }
    }
    public class Xml
    {
        XmlElement e1;
        //signup form = new signup();
        string path="";
        public bool init()
        {
            //C:\Users\AbduRraffay\Desktop\IPTproject\
            //statid = stationid;
            path = @"C:\Users\AbduRraffay\Desktop\IPTproject\seller.xml";
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(path))
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(dec, root);
                XmlElement element1 = doc.CreateElement(string.Empty, "rental_application", string.Empty);
                e1 = element1;
                doc.AppendChild(element1);
                doc.Save(path);
                return true;
            }
            else
            {
                return false;
                
            }
            //doc.Load(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");


            //doc.Save(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");

        }
        public void addelement(string seller_id,string password, string phone_number,string email,string gender,string address,string number_of_orders, string avg_rating)
        {
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                
                XmlNode root = doc.SelectSingleNode("rental_application");
                XmlElement element1 = doc.CreateElement(string.Empty, "seller_details", string.Empty);
                root.AppendChild(element1);
                //element1.InnerText = seller_id;
                XmlElement element2 = doc.CreateElement(string.Empty, "seller_id", string.Empty);
                element1.AppendChild(element2);
                element2.InnerText = seller_id;
                XmlElement element21 = doc.CreateElement(string.Empty, "password", string.Empty);
                element1.AppendChild(element21);
                element21.InnerText = password;
                XmlElement element3 = doc.CreateElement(string.Empty, "address", string.Empty);
                element1.AppendChild(element3);
                element3.InnerText = address;
                XmlElement element4 = doc.CreateElement(string.Empty, "phone_number", string.Empty);
                element1.AppendChild(element4);
                element4.InnerText = phone_number;
                XmlElement element5 = doc.CreateElement(string.Empty, "gender", string.Empty);
                element1.AppendChild(element5);
                element5.InnerText = gender;
                XmlElement element6 = doc.CreateElement(string.Empty, "email", string.Empty);
                element1.AppendChild(element6);
                element6.InnerText = email;
                XmlElement element7 = doc.CreateElement(string.Empty, "number_of_order", string.Empty);
                element1.AppendChild(element7);
                element7.InnerText = number_of_orders;
                XmlElement element8 = doc.CreateElement(string.Empty, "avg_rating", string.Empty);
                element1.AppendChild(element8);
                element8.InnerText = avg_rating;
                doc.Save(path);
            }
            else
            {
                init();
            }


            //doc.Load(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");

            //doc.Save(@"C:\Users\AbduRraffay\Desktop\IPT_works\IPT_theory_assign1Q2\IPT_theory_assign1Q2\voterecords.xml");
        }
    }

    
}
