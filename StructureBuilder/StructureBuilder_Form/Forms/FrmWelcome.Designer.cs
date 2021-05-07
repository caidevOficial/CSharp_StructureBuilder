
namespace StructureBuilder_Form {
    partial class FrmWelcome {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWelcome));
            this.tmFadeIn = new System.Windows.Forms.Timer(this.components);
            this.tmFadeOut = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cpbProgress = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // tmFadeIn
            // 
            this.tmFadeIn.Interval = 30;
            this.tmFadeIn.Tick += new System.EventHandler(this.tmFadeIn_Tick);
            // 
            // tmFadeOut
            // 
            this.tmFadeOut.Interval = 30;
            this.tmFadeOut.Tick += new System.EventHandler(this.tmFadeOut_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(331, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading...";
            // 
            // cpbProgress
            // 
            this.cpbProgress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpbProgress.AnimationSpeed = 500;
            this.cpbProgress.BackColor = System.Drawing.Color.Black;
            this.cpbProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpbProgress.ForeColor = System.Drawing.Color.MistyRose;
            this.cpbProgress.InnerColor = System.Drawing.Color.Black;
            this.cpbProgress.InnerMargin = 2;
            this.cpbProgress.InnerWidth = -1;
            this.cpbProgress.Location = new System.Drawing.Point(468, 402);
            this.cpbProgress.Margin = new System.Windows.Forms.Padding(0);
            this.cpbProgress.MarqueeAnimationSpeed = 2000;
            this.cpbProgress.Name = "cpbProgress";
            this.cpbProgress.OuterColor = System.Drawing.Color.Black;
            this.cpbProgress.OuterMargin = -25;
            this.cpbProgress.OuterWidth = 26;
            this.cpbProgress.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.cpbProgress.ProgressWidth = 25;
            this.cpbProgress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpbProgress.Size = new System.Drawing.Size(150, 150);
            this.cpbProgress.StartAngle = 270;
            this.cpbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cpbProgress.SubscriptColor = System.Drawing.Color.Black;
            this.cpbProgress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbProgress.SubscriptText = "";
            this.cpbProgress.SuperscriptColor = System.Drawing.Color.White;
            this.cpbProgress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbProgress.SuperscriptText = "%";
            this.cpbProgress.TabIndex = 2;
            this.cpbProgress.Text = "0";
            this.cpbProgress.TextMargin = new System.Windows.Forms.Padding(0);
            // 
            // FrmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(626, 559);
            this.Controls.Add(this.cpbProgress);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.FrmWelcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmFadeIn;
        private System.Windows.Forms.Timer tmFadeOut;
        private System.Windows.Forms.Label label1;
        private CircularProgressBar.CircularProgressBar cpbProgress;
    }
}