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
    public partial class SelectBoardSize : Form
    {
        internal int BoardSize { get; set; }
        internal bool ifStartGame;
        public SelectBoardSize()
        {
            InitializeComponent();
            ifStartGame = false;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (ClassicBoard.Checked)
                BoardSize = 8;
            else if (SmallBoard.Checked)
                BoardSize = 4;
            else if (ExtendedBoard.Checked)
                BoardSize = 10;
            
            ifStartGame = true;
            this.Close();
        }

        private void SelectBoardSize_Load(object sender, EventArgs e)
        {
            ifStartGame = false;
        }
    }
}
