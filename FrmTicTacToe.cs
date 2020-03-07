using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharp___TicTacToe
{
    public partial class FrmTicTacToe : Form
    {
        static Button[,] btnRC = new Button[3, 3];
        static Panel PnlTicTacToe;
        static string player = "X";
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
                Font = new Font("Broadway", 36),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(LblTicTacToeTitle);
        }
    }
}
