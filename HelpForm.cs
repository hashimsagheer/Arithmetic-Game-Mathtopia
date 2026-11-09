using System;
using System.Windows.Forms;

namespace Mathtopia
{
    public class HelpForm : Form
    {
        private Label lblHeading;
        private Label lblHowToPlayHeader;
        private Label lblGameDescription;
        private Label lblTipsHeader;
        private Label lblTipBombTimer;
        private Label lblTipScoring;
        private Label lblTipWrongAnswer;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnGotIt;

        public HelpForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            btnGotIt = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnGotIt
            // 
            btnGotIt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            btnGotIt.Image = (System.Drawing.Image)resources.GetObject("btnGotIt.Image");
            btnGotIt.Location = new System.Drawing.Point(148, 651);
            btnGotIt.Name = "btnGotIt";
            btnGotIt.Size = new System.Drawing.Size(107, 45);
            btnGotIt.TabIndex = 7;
            btnGotIt.Click += BtnGotIt_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(-231, -13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(979, 798);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(-231, -13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(895, 798);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // HelpForm
            // 
            ClientSize = new System.Drawing.Size(441, 773);
            Controls.Add(btnGotIt);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HelpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mathtopia – Help";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        private void BtnGotIt_Click(object sender, EventArgs e) => this.Close();

        private void lblGameDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
