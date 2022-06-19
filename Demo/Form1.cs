using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        string ConnStr = @"Data Source=ngknn.ru;Initial Catalog=DemaSU;Persist Security Info=True;User ID=44П;Password=***********";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            FillGrups();

        }

        public void FillGrups()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demaSUDataSet.Tkani". При необходимости она может быть перемещена или удалена.
            this.tkaniTableAdapter.Fill(this.demaSUDataSet.Tkani);

            //string SqlText = "SELECT * FROM [Tkani]";
            //SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "[Tkani]");
            //dataGridView1.DataSource = ds.Tables["[Tkani]"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnStr);
            // Выполняем запрос к базе данных
            con.Open();//открываем соединение
            string SqlText = "INSERT INTO [Tkani] ([id],[tip])" + " VALUES(@id, @tip)";
            SqlCommand dbCommand = new SqlCommand(SqlText, con);//команда
            dbCommand.Parameters.AddWithValue("@id", textBox1.Text);
            dbCommand.Parameters.AddWithValue("@tip", textBox2.Text);

            if (dbCommand.ExecuteNonQuery() != 1)

                MessageBox.Show("Ошибка выполнения запроса! Данные не добавлены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else

                MessageBox.Show("Данные добавлены!", "Сообщение!", MessageBoxButtons.OK);
            FillGrups();

            // очистка данных из тест полей
            textBox1.Clear();
            textBox2.Clear();

        }
    }
 }

