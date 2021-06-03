using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormDB
{
    public partial class RESULT : Form
    {
        public RESULT()
        {
            InitializeComponent();
        }

        public string idAct; //รับค่ามาจาก From4

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_final;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void showName()
        {
            try
            {
                string select = $"SELECT * FROM data WHERE id = \"{idBox.Text}\"";
                MySqlConnection conn = databaseConnection();
                DataSet dataset = new DataSet();

                conn.Open();
                MySqlCommand command;
                command = conn.CreateCommand();
                command.CommandText = select;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataset);
                conn.Close();

                nameData.DataSource = dataset.Tables[0].DefaultView;
                if (nameData.CurrentRow != null)
                {
                    name.Text = nameData.Rows[0].Cells["name"].FormattedValue.ToString();
                    nameData.Rows.RemoveAt(nameData.Rows[0].Index);
                }
            }
            catch (Exception) { }
        }

        private void showAct()
        {
            try
            {
                string select = $"SELECT * FROM activity WHERE no = \"{idBox.Text}\"";
                MySqlConnection conn = databaseConnection();
                DataSet dataset = new DataSet();

                conn.Open();
                MySqlCommand command;
                command = conn.CreateCommand();
                command.CommandText = select;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataset);
                conn.Close();


                totalBox.Text = "";
                actData.DataSource = dataset.Tables[0].DefaultView;

                if (actData.CurrentRow != null)
                {
                    actData.Columns[0].HeaderText = "ข้อที่";
                    actData.Columns[0].Width = 50;
                    actData.Columns[1].Visible = false;
                    actData.Columns[2].Visible = false;
                    actData.Columns[3].HeaderText = "รายการ";
                    actData.Columns[3].Width = 500;
                    actData.Columns[4].HeaderText = "ประเภทตามรายจ่าย";
                    actData.Columns[4].Width = 200;
                    actData.Columns[5].HeaderText = "จำนวน";
                    actData.Columns[5].Width = 80;
                    actData.Columns[6].HeaderText = "หน่วยนับ";
                    actData.Columns[6].Width = 80;
                    actData.Columns[7].HeaderText = "ราคาต่อหน่วย";
                    actData.Columns[7].Width = 100;
                    actData.Columns[8].HeaderText = "รวม";
                    actData.Columns[8].Width = 150;

                    int total = 0;
                    for (int i = 0; i < actData.Rows.Count; ++i)
                    {
                        total += Convert.ToInt32(actData.Rows[i].Cells[8].Value);
                    }
                    totalBox.Text = Convert.ToString(total);
                    MessageBox.Show("พบข้อมูลโครงการ " + Convert.ToDouble(actData.Rows.Count) + " รายการ\nรวมทั้งสิ้น " + Convert.ToString(total) + " บาท"
                        , "COUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string update1 = $"UPDATE data SET total = \"{totalBox.Text}\" WHERE id = \"{idBox.Text}\"";
                    MySqlConnection conn1 = databaseConnection();
                    String sql1 = update1;
                    MySqlCommand command1 = new MySqlCommand(sql1, conn1);

                    conn1.Open();
                    int rows1 = command1.ExecuteNonQuery();
                    conn1.Close();
                }
            }
            catch { }
        }
        
        private void RESULT_Load(object sender, EventArgs e)
        {
            if (idAct == null)
            {
                idAct = "-";
            }
            
            idBox.Text = idAct;
            if (idBox.Text == "-")
            {
                totalBox.Text = "";
                name.Text = "";
                actData.DataSource = null;
                MessageBox.Show("กรุณาเลือกรหัสกิจกรรม", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void idBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idBox.Text == "-")
            {
                totalBox.Text = "";
                name.Text = "";
                actData.DataSource = null;
                MessageBox.Show("กรุณาเลือกรหัสกิจกรรม", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                showName();
                showAct();
            }
        }

        private void saveactBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ACT screen = new ACT();
            screen.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME screen = new HOME();
            screen.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
