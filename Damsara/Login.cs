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

namespace Damsara
{
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=damsara");
        MySqlDataAdapter da;
        MySqlCommand cmd;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("SELECT * FROM Employer WHERE Emp_username='" + txt_name.Text + "' and Emp_psw='" + txt_psw.Text + "'", con);
                da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i == 1)
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    ulog.name =dr[0].ToString();
                    if (dr[6].ToString() == "Admin")
                    {
                        ulog.type = "A";
                    }
                    else if (dr[6].ToString() == "User")
                    {
                        ulog.type = "U";
                    }
                    Home fh = new Home();
                    fh.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please check your Name or Password", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Somthing Error Please Try Aggain", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linktxt_to_regF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register secondForm = new Register();
            secondForm.Show();
            this.Hide();
        }
    }
}
