using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRa
{
    internal class Player
    {
        public string username { get; private set; }
        public int score { get; private set; } = 0;
        public int hp { get; private set; } = 3;

        public Player(string username)
        {
            this.username = username;
        }

        public void AddScore()
        {
            this.score++;
        }
        public void TakeDamage()
        {
            this.hp--;
            if (this.hp <= 0)
                MessageBox.Show("You died");
        }
    }
}
