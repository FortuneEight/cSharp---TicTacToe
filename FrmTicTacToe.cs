using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace cSharp___TicTacToe
{
    public partial class FrmTicTacToe : Form
    {
        static Button[,] btnRC = new Button[3, 3];
        static Panel PnlTicTacToe;
        static Label LblCurrentPlayer;
        static string player = "X";
        static string myFont = "Arial Rounded MT Bold";
        public FrmTicTacToe()
        {
            InitializeComponent();
        }

        private void FrmTicTacToe_Load(object sender, EventArgs e)
        {
            CustomizeForm();
            CreateTicTacToeBoard();
        }

        private void CreateTicTacToeBoard()
        {
            int btnSize = PnlTicTacToe.Width / 4;
            int btnSpacing = (PnlTicTacToe.Width - (3 * btnSize)) / 4;
            for (int r = 0; r <= 2; r++)
            {
                for (int c = 0; c <= 2; c++)
                {
                    int x = (c * btnSize) + ((c + 1) * btnSpacing);
                    int y = (r * btnSize) + ((r + 1) * btnSpacing);

                    btnRC[r, c] = new Button()
                    {
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(myFont, 48),
                        Location = new Point(x, y),
                        Size = new Size(btnSize, btnSize),
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat,
                        Tag = "",
                    };
                    PnlTicTacToe.Controls.Add(btnRC[r, c]);
                    btnRC[r, c].Click += BtnTicTacToe_Click;
                }
            }
        }

        private void BtnTicTacToe_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text != "")
            {
                SystemSounds.Beep.Play();
                return;
            }
            (sender as Button).Text = player;

            if (HasGameBeenWon())
            {
                MessageBox.Show($"Player {player} has won!!!");
                ClearBoardForAnotherGame();
            }
            if (IsGameTied())
            {
                MessageBox.Show("TIE!");
                ClearBoardForAnotherGame();
            }
         

            TicTacToeAI();
          
        }

        private void TicTacToeAI()
        {
            player = "O";




            foreach (Button btn in btnRC)
            {
                if (btn.Text == "")
                {
                    btn.Text = "O";
                    break;
                } 
            }

             
            if (HasGameBeenWon())
            {
                MessageBox.Show($"Player {player} has won!!!");
                ClearBoardForAnotherGame();
            }
            if (IsGameTied())
            {
                MessageBox.Show("TIE!");
                ClearBoardForAnotherGame();
            }
            player = "X";

            LblCurrentPlayer.Text = $"Current Player - {player}";

        }

        private bool HasGameBeenWon()
        {
            string[] row = new string[3];
            string[] col = new string[3];
            string fDiag;
            string bDiag;

            for (int i = 0; i <= 2; i++)
            {
                row[i] = btnRC[i, 0].Text + btnRC[i, 1].Text + btnRC[i, 2].Text;
                if (row[i] == "XXX" | row[i] == "OOO") return true;

                col[i] = btnRC[0, i].Text + btnRC[1, i].Text + btnRC[2, i].Text;
                if (col[i] == "XXX" | col[i] == "OOO") return true;
            }

            bDiag = btnRC[0, 0].Text + btnRC[1, 1].Text + btnRC[2, 2].Text;
            if (bDiag == "XXX" | bDiag == "OOO") return true;

            fDiag = btnRC[0, 2].Text + btnRC[1, 1].Text + btnRC[2, 0].Text;
            if (fDiag == "XXX" | fDiag == "OOO") return true;

            return false;
        }

        private static bool IsGameTied()
        {
            foreach (Button btn in btnRC)
            {
                if (btn.Text == "")
                {
                    return false;
                }
            }

            return true;
        }


        private void ClearBoardForAnotherGame()
        {
            DialogResult yn = MessageBox.Show("Play another game?", "Tic Tac Toe Game Ended", MessageBoxButtons.YesNo);

            if (yn == DialogResult.Yes)
            {
                foreach (Button btn in btnRC)
                {
                    btn.Text = "";
                }
                return;
            }
            else
            {
                Application.Exit();
            }
        }

      
        private void CustomizeForm()
        {
            int clientWidth = 400;
            int clientHight = clientWidth + 100;
            this.ClientSize = new Size(clientWidth, clientHight);
            this.MaximizeBox = false;
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimizeBox = true;
            this.MinimumSize = new Size(this.Width, this.Height);

            int sW = Screen.PrimaryScreen.WorkingArea.Width;
            int sH = Screen.PrimaryScreen.WorkingArea.Height;
            int fW = this.Width;
            int fH = this.Height;

            this.Location = new Point((sW - fW) / 2, (sH - fH) / 2);
            this.Text = "Tic Tac Toe - C# - by Miguel";
            this.Icon = Properties.Resources.TicTacToe;

            Label LblTicTacToeTitle = new Label()
            {
                AutoSize = false,
                Text = "Tic Tac Toe",
                Size = new Size(clientWidth, 60),
                Location = new Point(0, 18),
                Font = new Font(myFont, 36),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(LblTicTacToeTitle);

            LblCurrentPlayer = new Label()
            {
                AutoSize = false,
                Text = "Current Player - X",
                Size = new Size(clientWidth, 30),
                Location = new Point(0, clientHight - 36),
                Font = new Font(myFont, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(LblCurrentPlayer);

            PnlTicTacToe = new Panel()
            {
                Size = new Size(clientWidth, clientWidth),
                Location = new Point(0, 80),
            };
            this.Controls.Add(PnlTicTacToe);
        }
    }
}

/* Easy TicTacToe AI (Rule Based)
1: Get TicTacToe
2: Block TicTacToe 
3: Center If availible
4: Go to Corner Space
5: Pick Open Space
*/
