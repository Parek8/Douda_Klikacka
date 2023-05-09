﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Game game;
        Player player;
        public Square(Game game, Player player)
        {
            countdown = 5000;
            this.gamePanel = new Panel();
            this.game = game;
            this.player = player;
            CreateSquare(game);
        }
        void CreateSquare(Game game)
        {
            gamePanel.Size = GenerateSize();
            gamePanel.Location = GeneratePoint(gamePanel.Width,gamePanel.Height, game);
            gamePanel.Click += gamePanel_Click;
            gamePanel.BackColor = Color.Red;
            game.panel1.Controls.Add(gamePanel);
        }

        public void Update(Game g)
        {
            descendCountdown(g);
            changeColorOfgamePanels();
        }

        void descendCountdown(Game g)
        {
            countdown -= g.timer1.Interval;

            if (this.countdown <= 0)
            {
                gamePanel.Dispose();

            }
        }

        void changeColorOfgamePanels()
        {
            gamePanel.BackColor = changeColour();
        }

        Color changeColour()
        {
            if (countdown >= 3000)
            {
                return Color.Green;
            }
            else if (countdown >= 2000 && countdown < 3000)
            {
                return Color.Yellow;
            } 
            else
            {
                return Color.Red;
            }
        }

        private void gamePanel_Click(object sender, EventArgs e)
        {
            game.panel1.Controls.Remove(sender as Panel);
        }

        Point GeneratePoint(int width, int height, Game game)
        {
            int x = rnd.Next(0, game.panel1.Width - width);
            int y = rnd.Next(0, game.panel1.Height - height);
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
