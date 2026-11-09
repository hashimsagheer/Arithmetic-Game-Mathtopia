using System;
using System.Windows.Forms;

namespace Mathtopia
{
    /// <summary>
    /// Settings screen - lets the player adjust Difficulty and Volume.
    /// Changes are written directly to the GameSettings static class.
    /// </summary>
    public class SettingsForm : Form
    {
        private Label    lblDifficultyValue;
        private TrackBar trkDifficulty;
        private Label    lblVolumeValue;
        private TrackBar trkVolume;
        private Button   btnSave;
        private PictureBox pictureBox2;
        private Button   btnCancel;

        public SettingsForm()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            lblDifficultyValue = new Label();
            trkDifficulty = new TrackBar();
            lblVolumeValue = new Label();
            trkVolume = new TrackBar();
            btnSave = new Button();
            btnCancel = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)trkDifficulty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblDifficultyValue
            // 
            lblDifficultyValue.BackColor = System.Drawing.Color.Transparent;
            lblDifficultyValue.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            lblDifficultyValue.ForeColor = System.Drawing.Color.Gold;
            lblDifficultyValue.Location = new System.Drawing.Point(128, 666);
            lblDifficultyValue.Name = "lblDifficultyValue";
            lblDifficultyValue.Size = new System.Drawing.Size(40, 30);
            lblDifficultyValue.TabIndex = 1;
            lblDifficultyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkDifficulty
            // 
            trkDifficulty.BackColor = System.Drawing.Color.MidnightBlue;
            trkDifficulty.LargeChange = 1;
            trkDifficulty.Location = new System.Drawing.Point(12, 627);
            trkDifficulty.Maximum = 5;
            trkDifficulty.Minimum = 1;
            trkDifficulty.Name = "trkDifficulty";
            trkDifficulty.Size = new System.Drawing.Size(268, 69);
            trkDifficulty.TabIndex = 2;
            trkDifficulty.Value = 1;
            trkDifficulty.Scroll += TrkDifficulty_Scroll;
            // 
            // lblVolumeValue
            // 
            lblVolumeValue.BackColor = System.Drawing.Color.Transparent;
            lblVolumeValue.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            lblVolumeValue.ForeColor = System.Drawing.Color.Gold;
            lblVolumeValue.Location = new System.Drawing.Point(268, 324);
            lblVolumeValue.Name = "lblVolumeValue";
            lblVolumeValue.Size = new System.Drawing.Size(40, 30);
            lblVolumeValue.TabIndex = 4;
            lblVolumeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkVolume
            // 
            trkVolume.BackColor = System.Drawing.Color.MidnightBlue;
            trkVolume.LargeChange = 10;
            trkVolume.Location = new System.Drawing.Point(154, 285);
            trkVolume.Maximum = 100;
            trkVolume.Name = "trkVolume";
            trkVolume.Size = new System.Drawing.Size(275, 69);
            trkVolume.TabIndex = 5;
            trkVolume.TickFrequency = 10;
            trkVolume.Scroll += TrkVolume_Scroll;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Navy;
            btnSave.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.Gold;
            btnSave.Location = new System.Drawing.Point(27, 716);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(130, 45);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.Navy;
            btnCancel.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.Gold;
            btnCancel.Location = new System.Drawing.Point(178, 716);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(130, 45);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(-176, -13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(792, 798);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // SettingsForm
            // 
            BackColor = System.Drawing.Color.MidnightBlue;
            ClientSize = new System.Drawing.Size(441, 773);
            Controls.Add(lblDifficultyValue);
            Controls.Add(trkDifficulty);
            Controls.Add(lblVolumeValue);
            Controls.Add(trkVolume);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mathtopia - Settings";
            ((System.ComponentModel.ISupportInitialize)trkDifficulty).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadCurrentSettings()
        {
            trkDifficulty.Value     = GameSettings.Difficulty;
            lblDifficultyValue.Text = GameSettings.Difficulty.ToString();
            trkVolume.Value         = GameSettings.Volume;
            lblVolumeValue.Text     = GameSettings.Volume.ToString();
        }

        private void TrkDifficulty_Scroll(object sender, EventArgs e)
            => lblDifficultyValue.Text = trkDifficulty.Value.ToString();

        private void TrkVolume_Scroll(object sender, EventArgs e)
            => lblVolumeValue.Text = trkVolume.Value.ToString();

        private void BtnSave_Click(object sender, EventArgs e)
        {
            GameSettings.Difficulty = trkDifficulty.Value;
            GameSettings.Volume     = trkVolume.Value;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
