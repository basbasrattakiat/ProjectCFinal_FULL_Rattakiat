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
    public partial class LOGIN : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_final;");
        MySqlCommand command;
        MySqlDataAdapter adapter;


        public string user;
        public LOGIN()
        {
            InitializeComponent();
        }

        public void openconnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Close();
            }
        }

        private void newloginBtn_Click(object sender, EventArgs e)
        {
            string login = $"SELECT * FROM login WHERE username=\"{newusernameBox.Text}\" AND password=\"{newpasswordBox.Text}\" ";
            
            try
            {
                openconnection();
                adapter = new MySqlDataAdapter(login, connect);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    user = Convert.ToString(table.Rows[0][2]);
                    MessageBox.Show("ยินดีต้อนรับ\n" + user + "\n" + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString()
                        , "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HOME screen = new HOME();
                    screen.Show();
                }
                else { MessageBox.Show("บัญชีผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch { MessageBox.Show("กรุณาเปิดฐานข้อมูล", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } 
        }

        private void newcloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("เข้าสู่ระบบสำเร็จ");
            this.Hide();
            REG_RESET m = new REG_RESET();
            m.Show();
        }

        private void Switch1_CheckedChanged(object sender, EventArgs e)
        {
            if (Switch1.Checked)
            {
                string a = newpasswordBox.Text;
                newpasswordBox.PasswordChar = '\0';
            }
            else
            {
                newpasswordBox.PasswordChar = '•';
            }
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}