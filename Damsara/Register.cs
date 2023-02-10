using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damsara
{
    public partial class Register : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=damsara");
        MySqlCommand cmd;
        public Register()
        {
            InitializeComponent();
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            
            try
            {
             con.Open();


            if (string.IsNullOrEmpty(txt_name.Text))
            {
                
                MessageBox.Show("Name can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!Regex.Match(txt_name.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show(this, "Invalid name First caractor must be Uppercase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_username.Text))
            {
                MessageBox.Show("Username can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                else if (string.IsNullOrEmpty(txt_adr.Text))
            {
                MessageBox.Show(this, "Address can not be empty or can not have numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(txt_adr.Text))
              {

                 MessageBox.Show(this, "Invalid address", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); 
              }
            

            else if (txt_email.Text.Length == 0)
            {
                MessageBox.Show(this, "Please Enter Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(txt_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show(this, "Enter a valid email. Ex:name@gmail.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrEmpty(txt_psw.Text))
             {
                MessageBox.Show(this, "Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            else if (string.IsNullOrEmpty(txt_cpsw.Text))
             {
                MessageBox.Show(this, "Confirm Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            else if (txt_psw.Text!=txt_cpsw.Text)
            {
               MessageBox.Show(this, "Confirm Password and Password Not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                    if (rdo_user.Checked == true)
                    {
                        cmd = new MySqlCommand("Insert into employer (emp_name,emp_username,emp_add,emp_email,emp_psw,emp_copsw,emp_roll) Values ('" + txt_name.Text + "','" + txt_username.Text + "','" + txt_adr.Text + "', '" + txt_email.Text + "', '"
                         + txt_psw.Text + "','" + txt_cpsw.Text + "','User') ", con);

                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                            MessageBox.Show(this, "Registration Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(this, "Registration Unsuccess Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmd.Dispose();

                    }
                    else if (rdo_admin.Checked == true)
                    {
                        cmd = new MySqlCommand("Insert into employer (emp_name,emp_username,emp_add,emp_email,emp_psw,emp_copsw,emp_roll)Values ('" + txt_name.Text + "','" + txt_username.Text + "','" + txt_adr.Text + "', '" + txt_email.Text + "', '"
                         + txt_psw.Text + "',   '" + txt_cpsw.Text + "','Admin') ", con);

                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                            MessageBox.Show(this, "Registration Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(this, "Registration Unsuccess Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmd.Dispose();

                    }
                    else if (rdo_admin.Checked == false || rdo_user.Checked == false)
                    {
                        MessageBox.Show(this, "Confirm Password and Password Not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
             
             }
             con.Close();
            }

             catch (Exception)
              {
                  MessageBox.Show(this, "Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
             
        }
    }
}
