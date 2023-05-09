using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRa
{
    public partial class Game : Form
    {
        Form GameForm;
        internal List<Square> squareList = new List<Square>();
        Player player;
        public Game(string name, Form f)
        {

            this.GameForm = f;
            InitializeComponent();

            timer1.Enabled = true;
            player = new Player(name, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            squareList.Add(new Square(this, player));
            foreach (Square item in squareList)
            {
                item.Update(this);
            }
            HandleDeadSquares();
            UpdateHearts();
        }
        void HandleDeadSquares()
        {
            var deadSquares = squareList.FindAll(notAliveSquare => !notAliveSquare.isAlive);
            foreach (Square item in deadSquares)
            {
                squareList.Remove(item);
            }
        }
        public void UpdateHearts()
        {
            flowLayoutPanel1.Controls.Clear();
            for(int i = 0; i < player.hp; i++)
            {
                PictureBox tmpBox = new PictureBox();
                tmpBox.Load("../../Images/heart.png");
                tmpBox.Size = new Size(10, 10);
                tmpBox.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel1.Controls.Add(tmpBox);
            }
        }
        public void ClearCanvas()
        {
            foreach(Square item in squareList)
            {
                item.gamePanel.Dispose();
            }    
        }
        public void RemoveFromList(Square squareToBeRemoved)
        {
            squareList.Remove(squareToBeRemoved);
        }
        public void StopGame()
        {
            timer1.Enabled = false;
        }
    }
}