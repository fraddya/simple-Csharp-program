using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damsara
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbl_name.Text = ulog.name;
            if (ulog.type == "U")
            {
                lbl_emp.Text = "User";
            }
            else if(ulog.type == "A")
            {
                lbl_emp.Text = "Admin";
            }
            else
            {
                MessageBox.Show(this, "Error Loadnig Home ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
