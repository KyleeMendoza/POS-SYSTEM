using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace WindowsFormsApp1
{
    public partial class UserRegistration : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("users");
        static IMongoCollection<admin> admin = db.GetCollection<admin>("admin");
        static IMongoCollection<employee> employee = db.GetCollection<employee>("employee");

        public UserRegistration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all information boxes");
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose type of account");
            }
            else
            {
                if (comboBox1.SelectedItem.Equals("ADMIN"))
                {
                    admin registerAdmin = new admin(textBox1.Text, textBox2.Text, textBox3.Text);
                    admin.InsertOne(registerAdmin);
                    MessageBox.Show("ACCOUNT WAS SUCCESSFULLY CREATED");
                    this.Hide();
                    Login l = new Login();
                    l.Show();
                }
                else
                {
                    employee registerEmployee = new employee(textBox1.Text, textBox2.Text, textBox3.Text);
                    employee.InsertOne(registerEmployee);
                    MessageBox.Show("ACCOUNT WAS SUCCESSFULLY CREATED");
                    this.Hide();
                    Login l = new Login();
                    l.Show();
                }
            }



        }

        
    }

    public class admin
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("username")]
        public String username { get; set; }
        [BsonElement("name")]
        public String name { get; set; }
        [BsonElement("password")]
        public string password { get; set; }

        public admin(string name, string username, string password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }
    }
    public class employee
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("username")]
        public String username { get; set; }
        [BsonElement("name")]
        public String name { get; set; }
        [BsonElement("password")]
        public string password { get; set; }

        public employee(string name, string username, string password)
        {
            this.username = name;
            this.name = username;
            this.password = password;
        }
    }

}
