using System;
using System.Windows.Forms;

namespace Mathtopia
{
    public class ResultForm : Form
    {
        private readonly bool playerWon;
        private readonly int finalScore;
        private readonly int completedLevel;
        private Label lblFinalScore;
        private Button btnNextLevelOrPlayAgain;
        private Button btnRetry;
        private PictureBox pictureBox2;
        private Label lblResultOutcome;
        private Button btnMainMenu;

        public ResultForm(bool playerWon, int finalScore, int completedLevel)
        {
            this.playerWon = playerWon;
            this.finalScore = finalScore;
            this.completedLevel = completedLevel;
            InitializeComponent();

            // Dynamic values set after InitializeComponent
            this.Text = playerWon ? "Mathtopia - You did it!" : "Mathtopia - Retry?";
            lblResultOutcome.Text = playerWon ? "YOU DID IT!" : "Retry?";
            lblResultOutcome.ForeColor = playerWon
                ? System.Drawing.Color.Gold
                : System.Drawing.Color.Gold;
            lblFinalScore.Text = finalScore.ToString();

            if (playerWon)
            {
                btnNextLevelOrPlayAgain.Text = completedLevel < 3 ? "Next Level ->" : "Play Again";
                btnNextLevelOrPlayAgain.Visible = true;
                btnRetry.Visible = false;
            }
            else
            {
                btnRetry.Visible = true;
                btnNextLevelOrPlayAgain.Visible = false;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            lblFinalScore = new Label();
            btnNextLevelOrPlayAgain = new Button();
            btnRetry = new Button();
            btnMainMenu = new Button();
            pictureBox2 = new PictureBox();
            lblResultOutcome = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblFinalScore
            // 
            lblFinalScore.BackColor = System.Drawing.Color.Navy;
            lblFinalScore.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblFinalScore.ForeColor = System.Drawing.Color.Gold;
            lblFinalScore.Location = new System.Drawing.Point(185, 593);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new System.Drawing.Size(76, 41);
            lblFinalScore.TabIndex = 2;
            lblFinalScore.Text = "0";
            lblFinalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextLevelOrPlayAgain
            // 
            btnNextLevelOrPlayAgain.BackColor = System.Drawing.Color.Navy;
            btnNextLevelOrPlayAgain.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            btnNextLevelOrPlayAgain.ForeColor = System.Drawing.Color.Gold;
            btnNextLevelOrPlayAgain.Location = new System.Drawing.Point(32, 682);
            btnNextLevelOrPlayAgain.Name = "btnNextLevelOrPlayAgain";
            btnNextLevelOrPlayAgain.Size = new System.Drawing.Size(150, 45);
            btnNextLevelOrPlayAgain.TabIndex = 3;
            btnNextLevelOrPlayAgain.Text = "Next Level ->";
            btnNextLevelOrPlayAgain.UseVisualStyleBackColor = false;
            btnNextLevelOrPlayAgain.Visible = false;
            btnNextLevelOrPlayAgain.Click += BtnNextLevelOrPlayAgain_Click;
            // 
            // btnRetry
            // 
            btnRetry.BackColor = System.Drawing.Color.Navy;
            btnRetry.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            btnRetry.ForeColor = System.Drawing.Color.Gold;
            btnRetry.Location = new System.Drawing.Point(32, 682);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(150, 45);
            btnRetry.TabIndex = 4;
            btnRetry.Text = "Retry";
            btnRetry.UseVisualStyleBackColor = false;
            btnRetry.Visible = false;
            btnRetry.Click += BtnRetry_Click;
            // 
            // btnMainMenu
            // 
            btnMainMenu.BackColor = System.Drawing.Color.Navy;
            btnMainMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            btnMainMenu.ForeColor = System.Drawing.Color.Gold;
            btnMainMenu.Location = new System.Drawing.Point(188, 682);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new System.Drawing.Size(150, 45);
            btnMainMenu.TabIndex = 5;
            btnMainMenu.Text = "Main Menu";
            btnMainMenu.UseVisualStyleBackColor = false;
            btnMainMenu.Click += BtnMainMenu_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(-103, -23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(636, 806);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // lblResultOutcome
            // 
            lblResultOutcome.BackColor = System.Drawing.Color.DarkBlue;
            lblResultOutcome.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblResultOutcome.ForeColor = System.Drawing.Color.Gold;
            lblResultOutcome.Location = new System.Drawing.Point(104, 421);
            lblResultOutcome.Name = "lblResultOutcome";
            lblResultOutcome.Size = new System.Drawing.Size(250, 53);
            lblResultOutcome.TabIndex = 0;
            lblResultOutcome.Text = "RESULT";
            lblResultOutcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultForm
            // 
            ClientSize = new System.Drawing.Size(441, 773);
            Controls.Add(lblResultOutcome);
            Controls.Add(lblFinalScore);
            Controls.Add(btnNextLevelOrPlayAgain);
            Controls.Add(btnRetry);
            Controls.Add(btnMainMenu);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mathtopia";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        private void BtnNextLevelOrPlayAgain_Click(object sender, EventArgs e)
        {
            int nextLevel = completedLevel < 3 ? completedLevel + 1 : 1;
            var gameForm = new GameForm(nextLevel, GameSettings.Difficulty);
            gameForm.Show();
            this.Close();
        }

        private void BtnRetry_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm(completedLevel, GameSettings.Difficulty);
            gameForm.Show();
            this.Close();
        }

        private void BtnMainMenu_Click(object sender, EventArgs e)
        {
            var mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Close();
        }
    }
}