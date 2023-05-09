using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            player = new Player(name);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            squareList.Add(new Square(this, player));
            foreach (Square item in squareList)
            {
                item.Update(this);
            }
        }
    }
}
