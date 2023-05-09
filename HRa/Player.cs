using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRa
{
    public class Player
    {
        public string username { get; private set; }
        public int score { get; private set; } = 0;
        public int hp { get; private set; } = 5;
        private Game game_form;

        public Player(string username, Game game_form)
        {
            this.username = username;
            this.game_form = game_form;
        }

        public void AddScore()
        {
            this.score++;
        }
        public void TakeDamage()
        {
            this.hp--;
            if (this.hp <= 0)
            {
                game_form.StopGame();
                game_form.UpdateHearts();
                game_form.ClearCanvas();
                MessageBox.Show($"You died\nUsername: {username}\nScore: {score}");
            }
        }
    }
}
