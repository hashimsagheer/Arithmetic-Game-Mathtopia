using System;
using System.Windows.Forms;

namespace Mathtopia
{
    public class MainMenuForm : Form
    {
        private Label lblTitle;
        private Button btnStart;
        private Button btnLevelSelect;
        private Button btnSettings;
        private PictureBox pictureBox1;
        private Button btnHelp;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            lblTitle = new Label();
            btnStart = new Button();
            btnLevelSelect = new Button();
            btnSettings = new Button();
            btnHelp = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Yellow;
            lblTitle.Image = (System.Drawing.Image)resources.GetObject("lblTitle.Image");
            lblTitle.Location = new System.Drawing.Point(135, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(184, 44);
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            btnStart.BackColor = System.Drawing.Color.FromArgb(34, 69, 150);
            btnStart.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Bold);
            btnStart.ForeColor = System.Drawing.Color.Yellow;
            btnStart.Image = (System.Drawing.Image)resources.GetObject("btnStart.Image");
            btnStart.Location = new System.Drawing.Point(150, 479);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(128, 56);
            btnStart.TabIndex = 1;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // btnLevelSelect
            // 
            btnLevelSelect.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Bold);
            btnLevelSelect.ForeColor = System.Drawing.Color.Yellow;
            btnLevelSelect.Image = (System.Drawing.Image)resources.GetObject("btnLevelSelect.Image");
            btnLevelSelect.Location = new System.Drawing.Point(98, 551);
            btnLevelSelect.Name = "btnLevelSelect";
            btnLevelSelect.Size = new System.Drawing.Size(235, 51);
            btnLevelSelect.TabIndex = 2;
            btnLevelSelect.Click += BtnLevelSelect_Click;
            // 
            // btnSettings
            // 
            btnSettings.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Bold);
            btnSettings.ForeColor = System.Drawing.Color.Yellow;
            btnSettings.Image = (System.Drawing.Image)resources.GetObject("btnSettings.Image");
            btnSettings.Location = new System.Drawing.Point(135, 628);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(152, 48);
            btnSettings.TabIndex = 3;
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnHelp
            // 
            btnHelp.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Bold);
            btnHelp.ForeColor = System.Drawing.Color.Yellow;
            btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
            btnHelp.Location = new System.Drawing.Point(161, 694);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new System.Drawing.Size(96, 51);
            btnHelp.TabIndex = 4;
            btnHelp.Click += BtnHelp_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(-280, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(1001, 798);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // MainMenuForm
            // 
            BackColor = System.Drawing.Color.FromArgb(34, 69, 150);
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new System.Drawing.Size(441, 773);
            Controls.Add(lblTitle);
            Controls.Add(btnStart);
            Controls.Add(btnLevelSelect);
            Controls.Add(btnSettings);
            Controls.Add(btnHelp);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mathtopia";
            Load += MainMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var levelSelectForm = new LevelSelectForm();
            levelSelectForm.Show();
            this.Hide();
            levelSelectForm.FormClosed += (s2, e2) => this.Show();
        }

        private void BtnLevelSelect_Click(object sender, EventArgs e)
        {
            var levelSelectForm = new LevelSelectForm();
            levelSelectForm.Show();
            this.Hide();
            levelSelectForm.FormClosed += (s2, e2) => this.Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            var helpForm = new HelpForm();
            helpForm.ShowDialog(this);
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
