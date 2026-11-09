using System;
using System.Windows.Forms;

namespace Mathtopia
{
    public class GameForm : Form
    {
        //Game stats
        private readonly int currentLevel;
        private readonly int currentDifficulty;
        private int playerScore = 0;
        private int bombSecondsLeft;
        private int maxBombSeconds;
        private int numberRange;
        private int operandLeft;
        private int operandRight;
        private char mathOperator;
        private int correctAnswer;

        private readonly Random rng = new Random();
        private Label lblLevelIndicator;
        private Label lblMathQuestion;
        private Label lblBombSecondsLeft;
        private Label lblPlayerScore;
        private TextBox txtPlayerAnswer;
        private Button btnSubmitAnswer;
        private PictureBox pictureBox1;

        // Timer
        private System.Windows.Forms.Timer tmrBombCountdown;

        public GameForm(int level, int difficulty)
        {
            this.currentLevel = level;
            this.currentDifficulty = difficulty;
            this.maxBombSeconds = Math.Max(10, 40 - (difficulty * 6));
            this.bombSecondsLeft = maxBombSeconds;
            this.numberRange = 12;

            InitializeComponent();
            GenerateNewQuestion();
            StartBombCountdown();
            SoundManager.StartBackground();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            lblLevelIndicator = new Label();
            lblBombSecondsLeft = new Label();
            lblPlayerScore = new Label();
            lblMathQuestion = new Label();
            txtPlayerAnswer = new TextBox();
            btnSubmitAnswer = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblLevelIndicator
            // 
            lblLevelIndicator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            lblLevelIndicator.Location = new System.Drawing.Point(182, 712);
            lblLevelIndicator.Name = "lblLevelIndicator";
            lblLevelIndicator.Size = new System.Drawing.Size(133, 28);
            lblLevelIndicator.TabIndex = 1;
            lblLevelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBombSecondsLeft
            // 
            lblBombSecondsLeft.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            lblBombSecondsLeft.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            lblBombSecondsLeft.ForeColor = System.Drawing.Color.Gold;
            lblBombSecondsLeft.Location = new System.Drawing.Point(12, 719);
            lblBombSecondsLeft.Name = "lblBombSecondsLeft";
            lblBombSecondsLeft.Size = new System.Drawing.Size(61, 35);
            lblBombSecondsLeft.TabIndex = 3;
            // 
            // lblPlayerScore
            // 
            lblPlayerScore.BackColor = System.Drawing.Color.MidnightBlue;
            lblPlayerScore.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            lblPlayerScore.ForeColor = System.Drawing.Color.Gold;
            lblPlayerScore.Location = new System.Drawing.Point(273, 180);
            lblPlayerScore.Name = "lblPlayerScore";
            lblPlayerScore.Size = new System.Drawing.Size(75, 30);
            lblPlayerScore.TabIndex = 5;
            // 
            // lblMathQuestion
            // 
            lblMathQuestion.BackColor = System.Drawing.Color.Navy;
            lblMathQuestion.Font = new System.Drawing.Font("Impact", 56F, System.Drawing.FontStyle.Bold);
            lblMathQuestion.ForeColor = System.Drawing.Color.Gold;
            lblMathQuestion.Location = new System.Drawing.Point(12, 269);
            lblMathQuestion.Name = "lblMathQuestion";
            lblMathQuestion.Size = new System.Drawing.Size(418, 110);
            lblMathQuestion.TabIndex = 6;
            lblMathQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPlayerAnswer
            // 
            txtPlayerAnswer.BackColor = System.Drawing.Color.Navy;
            txtPlayerAnswer.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            txtPlayerAnswer.ForeColor = System.Drawing.Color.Gold;
            txtPlayerAnswer.Location = new System.Drawing.Point(75, 451);
            txtPlayerAnswer.Name = "txtPlayerAnswer";
            txtPlayerAnswer.Size = new System.Drawing.Size(273, 58);
            txtPlayerAnswer.TabIndex = 7;
            txtPlayerAnswer.TextAlign = HorizontalAlignment.Center;
            txtPlayerAnswer.KeyPress += TxtPlayerAnswer_KeyPress;
            // 
            // btnSubmitAnswer
            // 
            btnSubmitAnswer.BackColor = System.Drawing.Color.Navy;
            btnSubmitAnswer.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Bold);
            btnSubmitAnswer.ForeColor = System.Drawing.Color.Gold;
            btnSubmitAnswer.Location = new System.Drawing.Point(115, 565);
            btnSubmitAnswer.Name = "btnSubmitAnswer";
            btnSubmitAnswer.Size = new System.Drawing.Size(200, 55);
            btnSubmitAnswer.TabIndex = 8;
            btnSubmitAnswer.Text = "SUBMIT";
            btnSubmitAnswer.UseVisualStyleBackColor = false;
            btnSubmitAnswer.Click += BtnSubmitAnswer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(-231, -13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(893, 798);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // GameForm
            // 
            ClientSize = new System.Drawing.Size(441, 773);
            Controls.Add(lblBombSecondsLeft);
            Controls.Add(lblPlayerScore);
            Controls.Add(lblMathQuestion);
            Controls.Add(txtPlayerAnswer);
            Controls.Add(btnSubmitAnswer);
            Controls.Add(pictureBox1);
            Controls.Add(lblLevelIndicator);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += GameForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Event Handlers

        private void TxtPlayerAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CheckPlayerAnswer();
                return;
            }
            // Allows digits, backspace, minus sign (for negative answers)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-')
                e.Handled = true;
        }

        private void BtnSubmitAnswer_Click(object sender, EventArgs e) => CheckPlayerAnswer();

        private void TmrBombCountdown_Tick(object sender, EventArgs e)
        {
            bombSecondsLeft--;
            lblBombSecondsLeft.Text = bombSecondsLeft.ToString();

            if (bombSecondsLeft <= 5)
                lblBombSecondsLeft.ForeColor = System.Drawing.Color.Red;

            if (bombSecondsLeft <= 0)
            {
                tmrBombCountdown.Stop();
                NavigateToResultScreen(playerWon: false);
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrBombCountdown?.Stop();
            SoundManager.StopBackground();
        }

        // Game Logic

        private void GenerateNewQuestion()
        {
            char[] availableOperators;
            if (currentLevel == 1) availableOperators = new char[] { '+', '-' };
            else if (currentLevel == 2) availableOperators = new char[] { '+', '-', '*' };
            else availableOperators = new char[] { '+', '-', '*', '/' };

            mathOperator = availableOperators[rng.Next(availableOperators.Length)];

            switch (mathOperator)
            {
                case '/':
                    operandRight = rng.Next(2, Math.Min(numberRange, 12));
                    operandLeft = operandRight * rng.Next(1, Math.Min(numberRange / operandRight + 1, 13));
                    correctAnswer = operandLeft / operandRight;
                    break;

                case '-':
                    operandLeft = rng.Next(1, numberRange + 1);
                    operandRight = rng.Next(1, operandLeft + 1);
                    correctAnswer = operandLeft - operandRight;
                    break;

                case '*':
                    operandLeft = rng.Next(2, Math.Min(numberRange / 2, 13));
                    operandRight = rng.Next(2, Math.Min(numberRange / operandLeft + 1, 13));
                    correctAnswer = operandLeft * operandRight;
                    break;

                default: // '+'
                    operandLeft = rng.Next(1, numberRange + 1);
                    operandRight = rng.Next(1, numberRange + 1);
                    correctAnswer = operandLeft + operandRight;
                    break;
            }

            string operatorDisplay = mathOperator == '*' ? "x"
                                   : mathOperator == '/' ? "/"
                                   : mathOperator.ToString();

            lblMathQuestion.Text = $"{operandLeft}  {operatorDisplay}  {operandRight}";
            txtPlayerAnswer.Clear();
            txtPlayerAnswer.Focus();
        }

        private void StartBombCountdown()
        {
            tmrBombCountdown = new System.Windows.Forms.Timer();
            tmrBombCountdown.Interval = 1000;
            tmrBombCountdown.Tick += TmrBombCountdown_Tick;
            tmrBombCountdown.Start();
        }

        private void CheckPlayerAnswer()
        {
            if (!int.TryParse(txtPlayerAnswer.Text.Trim(), out int submittedAnswer))
            {
                MessageBox.Show("Please enter a number.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlayerAnswer.Clear();
                txtPlayerAnswer.Focus();
                return;
            }

            if (submittedAnswer == correctAnswer)
            {
                SoundManager.PlayEffect("Correct.wav");
                playerScore += 10;
                lblPlayerScore.Text = playerScore.ToString();
                lblPlayerScore.ForeColor = System.Drawing.Color.DarkGreen;

                // Bonus time for correct answer
                bombSecondsLeft = Math.Min(maxBombSeconds, bombSecondsLeft + 5);
                lblBombSecondsLeft.Text = bombSecondsLeft.ToString();
                lblBombSecondsLeft.ForeColor = System.Drawing.Color.DarkRed;

                // Win condition: 3 correct answers per level (30 pts each)
                if (playerScore >= currentLevel * 30)
                {
                    tmrBombCountdown.Stop();
                    NavigateToResultScreen(playerWon: true);
                    return;
                }
            }
            else
            {
                SoundManager.PlayEffect("Wrong.wav");
                // Wrong answer: reduce bomb time
                bombSecondsLeft = Math.Max(0, bombSecondsLeft - 5);
                lblBombSecondsLeft.Text = bombSecondsLeft.ToString();

                if (bombSecondsLeft <= 0)
                {
                    tmrBombCountdown.Stop();
                    NavigateToResultScreen(playerWon: false);
                    return;
                }
            }

            GenerateNewQuestion();
        }

        private void NavigateToResultScreen(bool playerWon)
        {
            tmrBombCountdown?.Stop();
            var resultForm = new ResultForm(playerWon, playerScore, currentLevel);
            resultForm.Show();
            this.Close();
        }
    }
}