using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Tag_Game
{
    class FormGame : BaseForm
    {
        int size = 12, start_time = 1;
        Label step, labletime;
        LogicGame game;
        Button restart_game;
        Timer timer = null;
        public override void Set_screen(Form window)
        {
            window.Controls.Clear();
            window.Size = new Size((80 + size * 50),(180 + size * 50));
            window.MaximizeBox = false;
            window.FormBorderStyle = FormBorderStyle.FixedSingle;
            window.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - window.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - window.Height) / 2);
            panel = new Panel
            {
                BackColor = Color.Gainsboro,
                Dock = DockStyle.Fill
            };
            window.Controls.Add(panel);
        }
        public override void ComponentForm()
        {
            game = new LogicGame(size);
            game.Start(10);
            Timer();
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    Button btn = new Button
                    {
                        BackColor = Color.DarkGray,
                        Name = x.ToString() + " " + y.ToString(),
                        Location = new Point(30 + x * 50, 30 + y * 50),
                        Size = new Size(50, 50),
                        TabStop = false,
                        Font = new Font("Segoe Script", 10, FontStyle.Bold)
                    };
                    btn.Click += Button_Click;
                    panel.Controls.Add(btn);                   
                }

            Button back = new Button
            {
                BackColor = Color.DarkGray,
                Location = new Point(((80 + size * 50) / 2) + 120, 80 + size * 50),
                Size = new Size(110, 35),
                Text = "Back",
                TabStop = false,
                Font = new Font("Segoe Script", 10, FontStyle.Bold)
            };
            back.Click += Back_Click;
            restart_game = new Button
            {
                BackColor = Color.DarkGray,
                Location = new Point(((80 + size * 50) / 2) - 220, 80 + size * 50),
                Size = new Size(110, 35),
                Text = "Restart",
                TabStop = false,
                Font = new Font("Segoe Script", 10, FontStyle.Bold)
            };
            restart_game.Click += RestartGame_Click;
            step = new Label
            {
                Location = new Point(30 , 40 + size * 50),
                AutoSize = true,
                Font = new Font("Segoe Script", 16, FontStyle.Bold)
            };
            panel.Controls.Add(restart_game);
            restart_game.Hide();
            panel.Controls.Add(back);
            panel.Controls.Add(step);
            ShoweButtons();
        }
        void Timer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000;
            timer.Start();
            labletime = new Label
            {
                Location = new Point((80 + size * 50) - 170, 40 + size * 50),
                AutoSize = true,
                Font = new Font("Segoe Script", 16, FontStyle.Bold),
                Text = "00:00:00"
            };
            panel.Controls.Add(labletime);
        }
        string StringTime(int time)
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
        void Timer_Tick(object sender, EventArgs e)
        {
                labletime.Text = StringTime(start_time);
                start_time++;
        }
        void ShoweButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(game.GetDigetAt(x, y), x, y);
            step.Text = "Step:" + game.moves;
        }
        void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)panel.Controls[x + " " + y];
            button.Text = digit.ToString();
            button.Visible = digit > 0;
        }
        void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Split(' ')[0]);
            int y = int.Parse(button.Name.Split(' ')[1]);
            game.PressAt(x, y);
            ShoweButtons();
            if (game.CheckWin())
            {
                timer.Stop();
                step.Text = "Step:" + game.moves + "                   " + "You Win!!!";
                restart_game.Show();
            }
        }
        private void RestartGame_Click(object sender, EventArgs e)
        {
            start_time = 0;
            timer.Start();
            game.Start(10);
            ShoweButtons();
            restart_game.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            BaseForm menu = new Menu();
            menu.Set_screen(panel.FindForm());
            menu.ComponentForm();
        }
    }
}
