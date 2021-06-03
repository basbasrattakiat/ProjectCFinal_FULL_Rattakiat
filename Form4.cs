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
    public partial class ACT : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_final;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
      
        // รีเซตค่า //
        private void resettext()
        {
            list.Text = "-";
            type.Text = "-";
            newamount.Text = "0";
            unit.Text = "-";
            newprice.Text = "0";
            sum.Text = "-";
            name.Text = "-";
        }

        // ดึงข้อมูลชื่อ + เงินรวม //
        private void showName()
        {
            try
            {
                string select = $"SELECT * FROM data WHERE id = \"{idBox.Text}\" ";
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();

                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = select;

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
                
                nameData.DataSource = ds.Tables[0].DefaultView;
                if (nameData.CurrentRow != null)
                {
                    name.Text = nameData.Rows[0].Cells["name"].FormattedValue.ToString();
                    nameData.Rows.RemoveAt(nameData.Rows[0].Index);
                }
            }
            catch (Exception){}
        }
        
        // ดึงข้อมูลรายละเอียดย่อย //
        private void showAct()
        {
            try
            {
                string select = $"SELECT * FROM activity WHERE no = \"{idBox.Text}\" AND tag = \"{noBox.Text}\"";
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();

                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = select;

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
 
                actData.DataSource = ds.Tables[0].DefaultView;
                if (actData.CurrentRow != null)
                {
                    list.Text = actData.Rows[0].Cells["list"].FormattedValue.ToString(); //รายการ
                    type.Text = actData.Rows[0].Cells["type"].FormattedValue.ToString(); //ประเภท
                    newamount.Text = actData.Rows[0].Cells["amount"].FormattedValue.ToString(); //จำนวน
                    unit.Text = actData.Rows[0].Cells["unit"].FormattedValue.ToString(); //หน่วยนับ
                    newprice.Text = actData.Rows[0].Cells["price"].FormattedValue.ToString(); //ราคาต่อหน่วย
                    int summ = Convert.ToInt16(newamount.Text) * Convert.ToInt16(newprice.Text); //รวมเงิน
                    sum.Text = Convert.ToString(summ);
                    actData.Rows.RemoveAt(actData.Rows[0].Index);
                    MessageBox.Show("พบข้อมูลโครงการ", "ACTIVITY"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    resettext();
                    MessageBox.Show("ไม่พบข้อมูลโครงการ", "ACTIVITY"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }  
            }
            catch {}
        }

        public ACT()
        {
            InitializeComponent();
        }

        private void ACT_Load(object sender, EventArgs e)
        {
            
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if ((idBox.Text != "-" ) && (noBox.Text != "-"))
            {
                showName();
                showAct();
            }
            else {MessageBox.Show("กรุุณาเลือกรหัส และลำดับที่ให้ครบ", "ACTIVITY"
                , MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            if ((idBox.Text != "-") && (noBox.Text != "-") && (name.Text != "-") && (list.Text != "-") && 
                (type.Text != "-") && (newamount.Text != "") && (unit.Text != "-") && (newprice.Text != ""))
            {
                try
                {
                    string id = idBox.Text + "." + noBox.Text;
                    int summ = Convert.ToInt16(newamount.Text) * Convert.ToInt32(newprice.Text);
                    sum.Text = Convert.ToString(summ);
                    string update = "UPDATE activity SET list ='" + list.Text +
                        "',type = '" + type.Text + "',amount = '" + newamount.Text +
                        "',unit = '" + unit.Text + "',price = '" + newprice.Text +
                        "',sum = '" + summ +
                        "' WHERE id = '" + id + "'";
                    MySqlConnection conn = databaseConnection();
                    String sql = update;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    try
                    {
                        int id1 = Convert.ToInt16(idBox.Text);
                        string update1 = "UPDATE data SET name = '" + name.Text + "' WHERE id = '" + id1 + "'";
                        MySqlConnection conn1 = databaseConnection();
                        String sql1 = update1;
                        MySqlCommand cmd1 = new MySqlCommand(sql1, conn1);

                        conn1.Open();
                        int rows1 = cmd1.ExecuteNonQuery();
                        conn1.Close();
                    }
                    catch (Exception) { }

                    if (rows > 0)
                    {
                        MessageBox.Show("บันทึกโครงการสำเร็จ", "ACTIVITY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resettext();
                        this.Hide();
                        RESULT screen = new RESULT();
                        screen.idAct = idBox.Text;
                        screen.Show();
                        noBox.Text = "-";
                        idBox.Text = "-";
                    }
                }
                catch (Exception) { MessageBox.Show("กรุณากรอกข้อมูลทุกช่องให้ครบ ส่วนช่องจำนวน เเละราคาต่อหน่วย ให้กรอกเป็นตัวเลขเท่านั้น",
                    "ACTIVITY", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง แล้วกดบันทึกโครงการใหม่อีกครั้ง", 
                "ACTIVITY" , MessageBoxButtons.OK, MessageBoxIcon.Warning); }   
        } 

        private void insertBtn_Click(object sender, EventArgs e) 
        {
            if ((idBox.Text != "-") && (noBox.Text != "-"))
            {
                try
                {
                    string select = "INSERT INTO activity (id,no,tag,list,type,amount,unit,price,sum)" +
                        "VALUES ('" + (idBox.Text + "." + noBox.Text) + "','" + idBox.Text + "','" + noBox.Text +
                        "','" + "-" + "','" + "-" + "','" + "0" + "','" + "-" + "','" + "0" + "','" + "0" + "')";
                    MySqlConnection conn = databaseConnection();
                    MySqlCommand cmd = new MySqlCommand(select, conn);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("เพิ่มรายละเอียดโครงการใหม่สำเร็จ", "ACTIVITY"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showName();
                        showAct();
                    }
                    else
                    {
                        resettext();
                    }
                }
                catch (Exception) { MessageBox.Show("มีรายละเอียดโครงการนี้ในฐานข้อมูลอยู่แล้ว", "ACTIVITY"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("กรุุณาเลือกรหัสกิจกรรม และลำดับที่ให้ครบ", "ACTIVITY"
                , MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if ((idBox.Text != "-") && (noBox.Text != "-"))
            {
                if (MessageBox.Show("ยันยันการลบโครงการ", "ACTIVITY"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    MessageBox.Show("ไม่มีการลบโครงการเกิดขึ้น", "ACTIVITY"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        string id = idBox.Text + "." + noBox.Text;
                        string delete = "DELETE FROM activity WHERE id = '" + id + "'";
                        MySqlConnection conn1 = databaseConnection();
                        String sql1 = delete;
                        MySqlCommand cmd1 = new MySqlCommand(sql1, conn1);

                        conn1.Open();
                        int rows1 = cmd1.ExecuteNonQuery();
                        conn1.Close();

                        if (rows1 > 0)
                        {
                            MessageBox.Show("ลบโครงการสำเร็จ", "ACTIVITY" 
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            noBox.Text = "-";
                            idBox.Text = "-";
                            resettext();
                        }
                        else { MessageBox.Show("ไม่พบโครงการในฐานข้อมูล"
                            , "ACTIVITY" , MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    catch (Exception) { }
                }
            }
            else { MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง แล้วกดลบโครงการใหม่อีกครั้ง"
                , "ACTIVITY" , MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void back_login_Click(object sender, EventArgs e)
        {
            MessageBox.Show("กลับหน้าแรก", "ACTIVITY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            HOME screen = new HOME();
            screen.Show();
        }

        private void resaltBtn_Click(object sender, EventArgs e)
        {
            if ((idBox.Text != "-") && (noBox.Text != "-"))
            {
                MessageBox.Show("สรุปผลข้อมูล" , "ACTIVITY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RESULT screen = new RESULT();
                screen.idAct = idBox.Text;
                screen.Show();
            }
            else { MessageBox.Show("กรุุณาเลือกรหัส และลำดับที่ให้ครบ", "ACTIVITY"
                , MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

    
    }
}
