using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckersProject
{
    public partial class InsertDataBox : Form
    {
        public InsertDataBox()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            base.ActiveControl = textBox; //to allow changes in textbox
            textBox.SelectAll(); //to select all text in textbox
            CenterToParent(); //to centering on main form
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
