
namespace StructureBuilder_Form {
    partial class frmException {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmException));
            this.rtbExceptionDescription = new System.Windows.Forms.RichTextBox();
            this.btnExceptionOK = new System.Windows.Forms.Button();
            this.lblExceptionTitle = new System.Windows.Forms.Label();
            this.lblExceptionSubtitle = new System.Windows.Forms.Label();
            this.lblDateException = new System.Windows.Forms.Label();
            this.lblRealDateException = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbExceptionDescription
            // 
            this.rtbExceptionDescription.BackColor = System.Drawing.Color.Black;
            this.rtbExceptionDescription.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbExceptionDescription.ForeColor = System.Drawing.Color.Red;
            this.rtbExceptionDescription.Location = new System.Drawing.Point(6, 91);
            this.rtbExceptionDescription.Name = "rtbExceptionDescription";
            this.rtbExceptionDescription.Size = new System.Drawing.Size(550, 203);
            this.rtbExceptionDescription.TabIndex = 0;
            this.rtbExceptionDescription.Text = "";
            // 
            // btnExceptionOK
            // 
            this.btnExceptionOK.BackColor = System.Drawing.Color.Black;
            this.btnExceptionOK.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExceptionOK.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnExceptionOK.Location = new System.Drawing.Point(471, 320);
            this.btnExceptionOK.Name = "btnExceptionOK";
            this.btnExceptionOK.Size = new System.Drawing.Size(85, 23);
            this.btnExceptionOK.TabIndex = 1;
            this.btnExceptionOK.Text = "OK";
            this.btnExceptionOK.UseVisualStyleBackColor = false;
            this.btnExceptionOK.Click += new System.EventHandler(this.btnExceptionOK_Click);
            // 
            // lblExceptionTitle
            // 
            this.lblExceptionTitle.AutoSize = true;
            this.lblExceptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblExceptionTitle.Font = new System.Drawing.Font("Gabriola", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblExceptionTitle.Location = new System.Drawing.Point(145, 8);
            this.lblExceptionTitle.Name = "lblExceptionTitle";
            this.lblExceptionTitle.Size = new System.Drawing.Size(272, 54);
            this.lblExceptionTitle.TabIndex = 2;
            this.lblExceptionTitle.Text = "An exception has ocurred";
            // 
            // lblExceptionSubtitle
            // 
            this.lblExceptionSubtitle.AutoSize = true;
            this.lblExceptionSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblExceptionSubtitle.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionSubtitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblExceptionSubtitle.Location = new System.Drawing.Point(89, 49);
            this.lblExceptionSubtitle.Name = "lblExceptionSubtitle";
            this.lblExceptionSubtitle.Size = new System.Drawing.Size(397, 39);
            this.lblExceptionSubtitle.TabIndex = 3;
            this.lblExceptionSubtitle.Text = "Below is the error that ocurred. Fell free to report it!";
            // 
            // lblDateException
            // 
            this.lblDateException.AutoSize = true;
            this.lblDateException.BackColor = System.Drawing.Color.Black;
            this.lblDateException.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateException.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblDateException.Location = new System.Drawing.Point(8, 313);
            this.lblDateException.Name = "lblDateException";
            this.lblDateException.Size = new System.Drawing.Size(172, 23);
            this.lblDateException.TabIndex = 4;
            this.lblDateException.Text = "Date of Exception:";
            // 
            // lblRealDateException
            // 
            this.lblRealDateException.AutoSize = true;
            this.lblRealDateException.BackColor = System.Drawing.Color.Black;
            this.lblRealDateException.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealDateException.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRealDateException.Location = new System.Drawing.Point(186, 313);
            this.lblRealDateException.Name = "lblRealDateException";
            this.lblRealDateException.Size = new System.Drawing.Size(167, 23);
            this.lblRealDateException.TabIndex = 5;
            this.lblRealDateException.Text = "Date of Exception";
            // 
            // frmException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(563, 355);
            this.Controls.Add(this.lblRealDateException);
            this.Controls.Add(this.lblDateException);
            this.Controls.Add(this.lblExceptionSubtitle);
            this.Controls.Add(this.lblExceptionTitle);
            this.Controls.Add(this.btnExceptionOK);
            this.Controls.Add(this.rtbExceptionDescription);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmException";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exception";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbExceptionDescription;
        private System.Windows.Forms.Button btnExceptionOK;
        private System.Windows.Forms.Label lblExceptionTitle;
        private System.Windows.Forms.Label lblExceptionSubtitle;
        private System.Windows.Forms.Label lblDateException;
        private System.Windows.Forms.Label lblRealDateException;
    }
}