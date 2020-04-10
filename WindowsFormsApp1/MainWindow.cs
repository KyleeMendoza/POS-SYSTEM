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
    public partial class MainWindow : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("wine");
        static IMongoCollection<whiteWine> whitewine = db.GetCollection<whiteWine>("whiteWines");
        static IMongoCollection<redWine> redwine = db.GetCollection<redWine>("redWines");
        static IMongoCollection<alsaceWine> alsacewine = db.GetCollection<alsaceWine>("alsace");
        static IMongoCollection<franceWine> francewine = db.GetCollection<franceWine>("franceBeaujolais");
        static IMongoCollection<roseWine> rosewine = db.GetCollection<roseWine>("roseWines");

        public MainWindow()
        {
            InitializeComponent();
            ReadAllUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabPage1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabPage3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabPage4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabPage5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Log-out ?",
                      "Log out", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    this.Hide();
                    Login l = new Login();
                    l.Show();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView6.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView7.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView7.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView7.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView8.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView8.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView8.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            bool Found = false;

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) == textBox4.Text && Convert.ToString(row.Cells[1].Value) == textBox2.Text)
                    {
                        if (Convert.ToInt32(row.Cells[2].Value) >= 20)
                        {
                            MessageBox.Show("You've reached the maximum order");
                            Found = true;
                        }
                        else
                        {
                            row.Cells[2].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells[2].Value));
                            Found = true;
                        }
                    }
                }
                if (!Found)
                {
                    dataGridView1.Rows.Add(textBox4.Text, textBox2.Text, 1);
                }
            }
            else
            {
                dataGridView1.Rows.Add(textBox4.Text, textBox2.Text, 1);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[3].Value = (Convert.ToDouble(row.Cells[1].Value) * Convert.ToDouble(row.Cells[2].Value));
            }
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);

            }
            textBox5.Text = sum.ToString();
        }


        public void ReadAllUsers()
        {
            List<whiteWine> wlist = whitewine.AsQueryable().ToList<whiteWine>();
            dataGridView4.DataSource = wlist;
            List<roseWine> roselist = rosewine.AsQueryable().ToList<roseWine>();
            dataGridView5.DataSource = roselist;
            List<redWine> redlist = redwine.AsQueryable().ToList<redWine>();
            dataGridView6.DataSource = redlist;
            List<alsaceWine> alist = alsacewine.AsQueryable().ToList<alsaceWine>();
            dataGridView7.DataSource = alist;
            List<franceWine> flist = francewine.AsQueryable().ToList<franceWine>();
            dataGridView8.DataSource = flist;
        }

        [BsonIgnoreExtraElements]
        class whiteWine
        {
            //[BsonId]
            //public ObjectId Id { get; set; }
            [BsonElement("name")]
            public String Name { get; set; }
            [BsonElement("descriptions")]
            public String Description { get; set; }
            [BsonElement("quantity")]
            public String Quantity { get; set; }
            [BsonElement("price")]
            public String Price { get; set; }

            public whiteWine(string name, string description, string quantity, string price)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                Price = price;
            }
        }
        [BsonIgnoreExtraElements]
        class roseWine
        {
            //[BsonId]
            //public ObjectId Id { get; set; }
            [BsonElement("name")]
            public String Name { get; set; }
            [BsonElement("descriptions")]
            public String Description { get; set; }
            [BsonElement("quantity")]
            public String Quantity { get; set; }
            [BsonElement("price")]
            public String Price { get; set; }

            public roseWine(string name, string description, string quantity, string price)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                Price = price;
            }
        }
        [BsonIgnoreExtraElements]
        class redWine
        {
            //[BsonId]
            //public ObjectId Id { get; set; }
            [BsonElement("name")]
            public String Name { get; set; }
            [BsonElement("descriptions")]
            public String Description { get; set; }
            [BsonElement("quantity")]
            public String Quantity { get; set; }
            [BsonElement("price")]
            public String Price { get; set; }

            public redWine(string name, string description, string quantity, string price)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                Price = price;
            }
        }
        [BsonIgnoreExtraElements]
        class alsaceWine
        {
            //[BsonId]
            //public ObjectId Id { get; set; }
            [BsonElement("name")]
            public String Name { get; set; }
            [BsonElement("descriptions")]
            public String Description { get; set; }
            [BsonElement("quantity")]
            public String Quantity { get; set; }
            [BsonElement("price")]
            public String Price { get; set; }

            public alsaceWine(string name, string description, string quantity, string price)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                Price = price;
            }
        }
        [BsonIgnoreExtraElements]
        class franceWine
        {
            //[BsonId]
            //public ObjectId Id { get; set; }
            [BsonElement("name")]
            public String Name { get; set; }
            [BsonElement("descriptions")]
            public String Description { get; set; }
            [BsonElement("quantity")]
            public String Quantity { get; set; }
            [BsonElement("price")]
            public String Price { get; set; }

            public franceWine(string name, string description, string quantity, string price)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                Price = price;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    if (Convert.ToInt32(row.Cells[2].Value) == 1)
                    {
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        textBox5.Text = "";
                    }
                    else
                    {
                        row.Cells[2].Value = Convert.ToString(Convert.ToInt32(row.Cells[2].Value) - 1);
                        row.Cells[3].Value = Convert.ToString(Convert.ToInt32(row.Cells[3].Value) - Convert.ToInt32(row.Cells[1].Value));
                        textBox5.Text = Convert.ToString(row.Cells[3].Value);
                    }
                }
            }
        }
    }
}



