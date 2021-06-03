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
using System.IO;

namespace WinFormDB
{
    public partial class HOME : Form
    {
        public string type1Total;
        public string type2Total;
        public string type3Total;
        public string type4Total;
        public string type5Total;
        public string type6Total;
        //public string nameStatus;
        //public string logintime;

        MySqlCommand command;
        MySqlDataAdapter adapter;
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_final;");

        public void openconnection()
        {
            if (connect.State == ConnectionState.Closed) { connect.Close(); }
        }

        private void importType1()
        {
            string typeText = "1. ค่าวัสดุ";
            string select = $"SELECT * FROM activity WHERE type = \"{typeText}\"";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if (table.Rows.Count == 1) { type1Total = Convert.ToString(Convert.ToDouble(table.Rows[0][8])); }
                        else if (table.Rows.Count > 1)
                        {
                            double total = Convert.ToDouble(table.Rows[i + 1][8]) + Convert.ToDouble(table.Rows[i][8]);
                            type1Total = Convert.ToString(total);
                        }
                    }
                }
                else { type1Total = Convert.ToString(0); }
            }
            catch (Exception) { }
        }

        private void importType2()
        {
            string typeText = "2. ค่าครุภัณฑ์";
            string select = $"SELECT * FROM activity WHERE type = \"{typeText}\"";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if (table.Rows.Count == 1) { type2Total = Convert.ToString(Convert.ToDouble(table.Rows[0][8])); }
                        else if (table.Rows.Count > 1)
                        {
                            double total = Convert.ToDouble(table.Rows[i + 1][8]) + Convert.ToDouble(table.Rows[i][8]);
                            type2Total = Convert.ToString(total);
                        }
                    }
                }
                else { type2Total = Convert.ToString(0); }
            }
            catch (Exception) { }
        }

        private void importType3()
        {
            string typeText = "3. ค่าใช้สอย";
            string select = $"SELECT * FROM activity WHERE type = \"{typeText}\"";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if (table.Rows.Count == 1) { type3Total = Convert.ToString(Convert.ToDouble(table.Rows[0][8])); }
                        else if (table.Rows.Count > 1)
                        {
                            double total = Convert.ToDouble(table.Rows[i + 1][8]) + Convert.ToDouble(table.Rows[i][8]);
                            type3Total = Convert.ToString(total);
                        }
                    }
                }
                else { type3Total = Convert.ToString(0); }
            }
            catch (Exception) { }
        }

        private void importType4()
        {
            string typeText = "4. ค่าสาธารณูปโภค";
            string select = $"SELECT * FROM activity WHERE type = \"{typeText}\"";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if (table.Rows.Count == 1) { type4Total = Convert.ToString(Convert.ToDouble(table.Rows[0][8])); }
                        else if (table.Rows.Count > 1)
                        {
                            double total = Convert.ToDouble(table.Rows[i + 1][8]) + Convert.ToDouble(table.Rows[i][8]);
                            type4Total = Convert.ToString(total);
                        }
                    }
                }
                else { type4Total = Convert.ToString(0); }
            }
            catch (Exception) { }
        }

        private void importType5()
        {
            string typeText = "5. ค่าตอบแทนวิทยากร";
            string select = $"SELECT * FROM activity WHERE type = \"{typeText}\"";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if (table.Rows.Count == 1) { type5Total = Convert.ToString(Convert.ToDouble(table.Rows[0][8])); }
                        else if (table.Rows.Count > 1)
                        {
                            double total = Convert.ToDouble(table.Rows[i + 1][8]) + Convert.ToDouble(table.Rows[i][8]);
                            type5Total = Convert.ToString(total);
                        }
                    }
                }
                else { type5Total = Convert.ToString(0); }
            }
            catch (Exception) { }
        }

        private void importType6()
        {
            string typeText = "6. ค่าใช้จ่ายอื่น ๆ";
            string select = $"SELECT * FROM activity WHERE type = \"{typeText}\"";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if (table.Rows.Count == 1) { type6Total = Convert.ToString(Convert.ToDouble(table.Rows[0][8])); }
                        else if (table.Rows.Count > 1)
                        {
                            double total = Convert.ToDouble(table.Rows[i + 1][8]) + Convert.ToDouble(table.Rows[i][8]);
                            type6Total = Convert.ToString(total);
                        }
                    }
                }
                else { type6Total = Convert.ToString(0); }
            }
            catch (Exception) { }
        }

        private void showChart()
        {
            chartType.Series["chartType"].Points.AddXY("1.ค่าวัสดุ", type1Total);
            chartType.Series["chartType"].Points.AddXY("2.ค่าครุภัณฑ์", type2Total);
            chartType.Series["chartType"].Points.AddXY("3.ค่าใช้สอย", type3Total);
            chartType.Series["chartType"].Points.AddXY("4.ค่าสาธารณูปโภค", type4Total);
            chartType.Series["chartType"].Points.AddXY("5.ค่าตอบแทนวิทยากร", type5Total);
            chartType.Series["chartType"].Points.AddXY("6.ค่าใช้จ่ายอื่น ๆ", type6Total);
        }

        private void showMonny()
        {
            int monnyout = Convert.ToInt32(type1Total) + Convert.ToInt32(type2Total) + Convert.ToInt32(type3Total)
                    + Convert.ToInt32(type4Total) + Convert.ToInt32(type5Total) + Convert.ToInt32(type6Total);

            string select = "SELECT * FROM total";
            try
            {
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                newtotalText.Text = table.Rows[0][1].ToString();
                newoutText.Text = Convert.ToString(monnyout);
                if (Convert.ToInt32(Convert.ToInt32(table.Rows[0][1]) - monnyout) < 0)
                {
                    newinText.PlaceholderForeColor = Color.Red;
                }
                newinText.Text = Convert.ToString(Convert.ToInt32(table.Rows[0][1]) - monnyout);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void showAct()
        {
            try
            {
                string select = $"SELECT * FROM data";
                openconnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(select, connect);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
               

                actData.DataSource = dataset.Tables[0].DefaultView;
                if (actData.CurrentRow != null)
                {
                    actData.Columns[0].HeaderText = "ข้อที่";
                    actData.Columns[0].Width = 50;

                    actData.Columns[1].HeaderText = "รายการ";
                    actData.Columns[1].Width = 500;

                    actData.Columns[2].HeaderText = "รวม";
                    actData.Columns[2].Width = 150;
  
                    //MessageBox.Show("พบข้อมูลโครงการ");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลโครงการ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception) { }
        }

        public HOME()
        {
            InitializeComponent();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            importType1();
            importType2();
            importType3();
            importType4();
            importType5();
            importType6();
            showChart();
            showMonny();
            showAct();
        }

        private void savemonny_totalBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void saveactBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ACT m = new ACT();
            m.ShowDialog();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ออกจากระบบสำเร็จ", "LOGOUT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            LOGIN screen = new LOGIN();
            screen.Show();
        }

        private void Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchEdit.Checked)
            {
                newtotalText.Enabled = true;
                newtotalText.ReadOnly = false;
            }
            else
            {
                string select = $"UPDATE total SET totalfull = \"{newtotalText.Text}\" WHERE id = \"{0}\"";
                MySqlConnection connect = new MySqlConnection
                    ("datasource=127.0.0.1;port=3306;username=root;password=;database=project_final;");
                MySqlCommand command = new MySqlCommand(select, connect);

                connect.Open();
                int rows = command.ExecuteNonQuery();
                connect.Close();

                if (rows > 0)
                {
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                    showMonny();
                }

                newtotalText.ReadOnly = true;
                newtotalText.Enabled = false;

                showMonny();
            }
        }

        private void resaltBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RESULT screen = new RESULT();
            screen.Show();
        }
    }
}
