using System;
using System.Windows.Forms;

namespace Mathtopia
{
    public class LevelSelectForm : Form
    {
        private Button btnLevel1;
        private Button btnLevel2;
        private Button btnLevel3;
        private PictureBox pictureBox2;
        private Button btnBack;

        public LevelSelectForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelSelectForm));
            btnLevel1 = new Button();
            btnLevel2 = new Button();
            btnLevel3 = new Button();
            btnBack = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnLevel1
            // 
            btnLevel1.BackColor = System.Drawing.Color.FromArgb(10, 42, 115);
            btnLevel1.FlatStyle = FlatStyle.Popup;
            btnLevel1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnLevel1.ForeColor = System.Drawing.Color.Gold;
            btnLevel1.Location = new System.Drawing.Point(48, 313);
            btnLevel1.Name = "btnLevel1";
            btnLevel1.Size = new System.Drawing.Size(90, 105);
            btnLevel1.TabIndex = 1;
            btnLevel1.Text = "1";
            btnLevel1.UseVisualStyleBackColor = false;
            btnLevel1.Click += BtnLevel1_Click;
            // 
            // btnLevel2
            // 
            btnLevel2.BackColor = System.Drawing.Color.FromArgb(10, 42, 115);
            btnLevel2.BackgroundImageLayout = ImageLayout.None;
            btnLevel2.FlatStyle = FlatStyle.Popup;
            btnLevel2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnLevel2.ForeColor = System.Drawing.Color.Gold;
            btnLevel2.Location = new System.Drawing.Point(249, 452);
            btnLevel2.Name = "btnLevel2";
            btnLevel2.Size = new System.Drawing.Size(102, 105);
            btnLevel2.TabIndex = 2;
            btnLevel2.Text = "2";
            btnLevel2.UseVisualStyleBackColor = false;
            btnLevel2.Click += BtnLevel2_Click;
            // 
            // btnLevel3
            // 
            btnLevel3.BackColor = System.Drawing.Color.FromArgb(10, 42, 115);
            btnLevel3.FlatStyle = FlatStyle.Popup;
            btnLevel3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnLevel3.ForeColor = System.Drawing.Color.Gold;
            btnLevel3.Location = new System.Drawing.Point(39, 618);
            btnLevel3.Name = "btnLevel3";
            btnLevel3.Size = new System.Drawing.Size(99, 101);
            btnLevel3.TabIndex = 3;
            btnLevel3.Text = "3";
            btnLevel3.UseVisualStyleBackColor = false;
            btnLevel3.Click += BtnLevel3_Click;
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBack.BackgroundImage");
            btnBack.BackgroundImageLayout = ImageLayout.None;
            btnBack.Font = new System.Drawing.Font("Arial", 11F);
            btnBack.Location = new System.Drawing.Point(186, 700);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(89, 45);
            btnBack.TabIndex = 4;
            btnBack.Click += BtnBack_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(-178, -13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(792, 798);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // LevelSelectForm
            // 
            ClientSize = new System.Drawing.Size(441, 773);
            Controls.Add(btnLevel1);
            Controls.Add(btnLevel2);
            Controls.Add(btnLevel3);
            Controls.Add(btnBack);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LevelSelectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mathtopia – Level Select";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        private void BtnLevel1_Click(object sender, EventArgs e) => StartLevel(1);
        private void BtnLevel2_Click(object sender, EventArgs e) => StartLevel(2);
        private void BtnLevel3_Click(object sender, EventArgs e) => StartLevel(3);
        private void BtnBack_Click(object sender, EventArgs e) => this.Close();

        private void StartLevel(int levelNumber)
        {
            var gameForm = new GameForm(levelNumber, GameSettings.Difficulty);
            gameForm.Show();
            this.Hide();
            gameForm.FormClosed += (s2, e2) => this.Show();
        }

        private void lblHeading_Click(object sender, EventArgs e)
        {

        }
    }
}
