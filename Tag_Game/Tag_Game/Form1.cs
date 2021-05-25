using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tag_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BaseForm menu = new Menu();
            menu.Set_screen(this);
            menu.ComponentForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
