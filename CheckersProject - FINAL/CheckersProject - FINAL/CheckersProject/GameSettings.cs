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
    public partial class GameSettings : Form
    {
        internal ColorDialog colorDialog;
        internal Color player1color;
        internal Color player2color;
        internal string player1shape;
        internal string player2shape;
        internal bool isPlayer1shapeFilled;
        internal bool isPlayer2shapeFilled;
        internal bool isDrag;
        internal bool isFade;

        public GameSettings()
        {
            InitializeComponent();
            colorDialog = new ColorDialog();

            player1color = new Color();
            player2color = new Color();

            List<string> shapes = new List<string>();
            shapes.Add(Shape.Elipse.ToString() + " (Default)");
            shapes.Add(Shape.Rectangle.ToString());
            shapes.Add(Shape.Square.ToString());
            shapes.Add(Shape.Triangle.ToString());
            shapes.Add(Shape.Hexagon.ToString());

            Player1ShapeCombo.Items.AddRange(shapes.ToArray());
            Player2ShapeCombo.Items.AddRange(shapes.ToArray());
            Player1ShapeCombo.SelectedItem = shapes[0];
            Player2ShapeCombo.SelectedItem = shapes[0];

        }

        private void Player1ColorBtn_Click(object sender, EventArgs e)
        {
            DialogResult result =  colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ((Button)sender).BackColor = colorDialog.Color;
            }
        }


        private void DoneBtn_Click(object sender, EventArgs e)
        {
            player1color = Player1ColorBtn.BackColor;
            player2color = Player2ColorBtn.BackColor;
            player1shape = Player1ShapeCombo.SelectedItem.ToString();
            player2shape = Player2ShapeCombo.SelectedItem.ToString();
            isPlayer1shapeFilled = FilledCheckBox1.Checked;
            isPlayer2shapeFilled = FilledCheckBox2.Checked;
            isDrag = DragRadio.Checked;
            isFade = FadeRadio.Checked;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            Player1ColorBtn.BackColor = player1color;
            Player2ColorBtn.BackColor = player2color;
        }
    }
}
