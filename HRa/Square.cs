using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRa
{
    internal class Square
    {
        Random rnd = new Random();
        Panel gamePanel;
        int countdown;
        public Square(Game game, Panel p)
        {
            countdown = 5000;
            this.gamePanel = p;
            CreateSquare(game, p);
        }
        void CreateSquare(Game game, Panel gamePanel)
        {
            Panel panel = new Panel();
            panel.Size = GenerateSize();
            panel.Location = GeneratePoint(panel.Width,panel.Height,game);
            panel.Click += Panel_Click;
            panel.BackColor = Color.Red;
            gamePanel.Controls.Add(panel);
        }

        public void Update(Game g)
        {
            descendCountdown(g);
            changeColorOfPanels(g);
        }

        void descendCountdown(Game g)
        {
            countdown -= g.timer1.Interval;
        }

        void changeColorOfPanels(Game g)
        {
            foreach (Square item in g.squareList)
            {

                item.gamePanel.Controls.panelBackColor = changeColorOfPanels(this);

            }
        }

        Color changeColour()
        {
            if (countdown > 3000)
            {
                return Color.Green;
            }
            else if (countdown > 2000 && countdown < 3000)
            {
                return Color.Yellow;
            } else
            {
                return Color.Red;
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {

            gamePanel.Controls.Remove(sender as Panel);
        }

        Point GeneratePoint(int width, int height, Game game)
        {
            int x = rnd.Next(0, gamePanel.Width - width);
            int y = rnd.Next(0, gamePanel.Height - height);
            return new Point(x, y);
        }

        Size GenerateSize()
        {
            int width = rnd.Next(20, 50);
            int height = rnd.Next(20, 50);
            return new Size(width,height);
        }
    }
}
