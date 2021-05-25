using System.Drawing;
using System.Windows.Forms;

namespace Tag_Game
{
    public abstract class BaseForm
    {
        protected Panel panel;
        public virtual void Set_screen(Form window)
        {
            window.Controls.Clear();
            window.Size = new Size(450, 500);
            window.MaximizeBox = false;
            window.FormBorderStyle = FormBorderStyle.FixedSingle;
            window.StartPosition = FormStartPosition.CenterScreen;
            panel = new Panel
            {
                BackColor = Color.Gainsboro,
                Dock = DockStyle.Fill
            };
            window.Controls.Add(panel);
        }
        public abstract void ComponentForm(); 
    }
}
