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
    public partial class REG_RESET : Form
    {
        public string imgLocation;

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_final;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public REG_RESET()
        {
            InitializeComponent();
        }

        private void REG_RESET_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("สรุปผลข้อมูล", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            LOGIN m = new LOGIN();
            m.Show();
        }

        private void Switch1_CheckedChanged(object sender, EventArgs e)
        {
            if (Switch1.Checked)
            {
                string a = passBox.Text;
                passBox.PasswordChar = '\0';
            }
            else
            {
                passBox.PasswordChar = '•';
            }
        }

        private void Switch2_CheckedChanged(object sender, EventArgs e)
        {
            if (Switch2.Checked)
            {
                string a = passcheckBox.Text;
                passcheckBox.PasswordChar = '\0';
            }
            else
            {
                passcheckBox.PasswordChar = '•';
            }
        }

        private void creactBtn_Click(object sender, EventArgs e)
        {
            if ((emailBox.Text != "") && (nameBox.Text != "") && (passBox.Text != "") && (passcheckBox.Text != ""))
            {
                if (passBox.Text == passcheckBox.Text)
                {
                    try
                    {
                        MySqlConnection conn = databaseConnection();

                        conn.Open();
                        string select = $"INSERT INTO login (username,password,name) VALUES " +
                            $"(\"{emailBox.Text + "@rajsima.ac.th"}\",\"{passBox.Text}\",\"{nameBox.Text}\") ";

                        MySqlCommand cmd = new MySqlCommand(select, conn);
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("สร้างบัญชีผู้ใช้ใหม่สำเร็จ", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LOGIN screen = new LOGIN();
                            screen.Show();
                        }
                    }
                    catch (Exception) { MessageBox.Show("มีบัญชีผู้ใช้นี้อยู่แล้ว", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("รหัสผ่านไม่ตรงกัน", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("กรุณากรอกข้อมูลที่จำเป็นให้ครบทุกช่อง", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if ((emailBox2.Text != "") && (passBox2.Text != "") && (passcheckBox2.Text != ""))
            {
                if (passBox2.Text == passcheckBox2.Text)
                {
                    try
                    {
                        MySqlConnection conn = databaseConnection();

                        conn.Open();
                        string select = $"UPDATE login SET password = \"{passBox2.Text}\" " +
                            $"WHERE username = \"{emailBox2.Text + "@rajsima.ac.th"}\"";

                        MySqlCommand cmd = new MySqlCommand(select, conn);
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("รีเซ็ตรหัสผ่านใหม่สำเร็จ", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LOGIN screen = new LOGIN();
                            screen.Show();
                        }
                        else
                        {
                            MessageBox.Show("ไม่มีบัญชีผู้ใช้ในฐานข้อมูล", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch {  }
                }
                else { MessageBox.Show("รหัสผ่านไม่ตรงกัน", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("กรุณากรอกข้อมูลที่จำเป็นให้ครบทุกช่อง", "REG/RESET", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void Switch3_CheckedChanged(object sender, EventArgs e)
        {
            if (Switch3.Checked)
            {
                string a = passBox2.Text;
                passBox2.PasswordChar = '\0';
            }
            else
            {
                passBox2.PasswordChar = '•';
            }
        }

        private void Switch4_CheckedChanged(object sender, EventArgs e)
        {
            if (Switch4.Checked)
            {
                string a = passcheckBox.Text;
                passcheckBox2.PasswordChar = '\0';
            }
            else
            {
                passcheckBox2.PasswordChar = '•';
            }
        }

       
    }
}
