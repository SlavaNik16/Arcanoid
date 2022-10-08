using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcanoidNV
{
    public partial class MenuForm : Form
    {
        private Form1 infoForm;

        private void button1_Click(object sender, EventArgs e)
        {
            infoForm.Condit = 2;
            infoForm.Show(this);
            
        }

        public MenuForm()
        {
            InitializeComponent();
            infoForm = new Form1();
            infoForm.Condit = 0;
            
        }

       


        
    }
}
