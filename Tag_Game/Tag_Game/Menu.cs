using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tag_Game
{
    public class Menu : BaseForm
    {
        public override void ComponentForm()
        {

            Button start = new Button
            {
                BackColor = Color.DarkGray,
                Location = new Point(165, 130),
                Size = new Size(110, 35),
                Text = "Start game",
                TabStop = false,
                Font = new Font("Segoe Script", 10, FontStyle.Bold)
            };
            Button help = new Button
            {
                BackColor = Color.DarkGray,
                Location = new Point(165, 230),
                Size = new Size(110, 35),
                Text = "Help",
                TabStop = false,
                Font = new Font("Segoe Script", 10, FontStyle.Bold)
            };
            panel.Controls.Add(start);
            panel.Controls.Add(help);

            start.Click += new EventHandler(Start_Click);
            help.Click += new EventHandler(Help_Click);
        }
        private void Start_Click(object sender, EventArgs e)
        {
            BaseForm game = new FormGame();
            game.Set_screen(panel.FindForm());
            game.ComponentForm();
        }
        private void Help_Click(object sender, EventArgs e)
        {
            
            Set_screen(panel.FindForm());
            Label help = new Label
            {
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe Script", 16, FontStyle.Bold)
            };
            help.Text = "Hello world!";
            panel.Controls.Add(help);

            Button back = new Button
            {
                BackColor = Color.DarkGray,
                Location = new Point(300, 400),
                Size = new Size(110, 35),
                Text = "Back",
                TabStop = false,
                Font = new Font("Segoe Script", 10, FontStyle.Bold)
            };

            panel.Controls.Add(back);
            back.Click += new EventHandler(Back_Click);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Set_screen(panel.FindForm());
            ComponentForm();
        }
    }
}
