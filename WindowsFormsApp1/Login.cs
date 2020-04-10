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
    public partial class Login : Form

    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("users");
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userAdmin = db.GetCollection<BsonDocument>("admin");

            var adminUsername = Builders<BsonDocument>.Filter.Eq("username",textBox1.Text);
            var adminPassword = Builders<BsonDocument>.Filter.Eq("password",textBox2.Text);
            var doc = userAdmin.Find(adminUsername & adminPassword).FirstOrDefault();
            

            var userEmployee = db.GetCollection<BsonDocument>("employee");

            var employeeUsername = Builders<BsonDocument>.Filter.Eq("username", textBox1.Text);
            var employeePassword = Builders<BsonDocument>.Filter.Eq("password", textBox2.Text);
            var emp = userEmployee.Find(employeeUsername & employeePassword).FirstOrDefault();
           
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter Username and Password");
            }

            else if (doc == null)
            {
                if (emp == null)
                {
                    MessageBox.Show("Incorrect Username or Password");
                }
                else
                {
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
            }
            else
            {
                this.Hide();
                MainWindow mw = new MainWindow();
                mw.Show();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserRegistration ur = new UserRegistration();
            ur.Show();

        }

        
    }

    

}
