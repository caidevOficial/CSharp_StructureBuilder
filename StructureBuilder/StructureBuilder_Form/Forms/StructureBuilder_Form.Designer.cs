/*
 * MIT License
 * 
 * Copyright (c) 2021 [FacuFalcone]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace StructureBuilder_Form
{
    partial class StructureBuilder
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureBuilder));
            this.lblStructureName = new System.Windows.Forms.Label();
            this.lblParameters = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSecondParam = new System.Windows.Forms.CheckBox();
            this.cmbSecondParamType = new System.Windows.Forms.ComboBox();
            this.txtSecondParamLenght = new System.Windows.Forms.TextBox();
            this.txtSecondParamName = new System.Windows.Forms.TextBox();
            this.grpSecondParam = new System.Windows.Forms.GroupBox();
            this.grpFirstParam = new System.Windows.Forms.GroupBox();
            this.cmbFirstParamType = new System.Windows.Forms.ComboBox();
            this.txtFirstParamLenght = new System.Windows.Forms.TextBox();
            this.txtFirstParamName = new System.Windows.Forms.TextBox();
            this.grpThirdParam = new System.Windows.Forms.GroupBox();
            this.cmbThirdParamType = new System.Windows.Forms.ComboBox();
            this.txtThirdParamLenght = new System.Windows.Forms.TextBox();
            this.txtThirdParamName = new System.Windows.Forms.TextBox();
            this.grpFourthParam = new System.Windows.Forms.GroupBox();
            this.cmbFourthParamType = new System.Windows.Forms.ComboBox();
            this.txtFourthParamLenght = new System.Windows.Forms.TextBox();
            this.txtFourthParamName = new System.Windows.Forms.TextBox();
            this.chkThirdParam = new System.Windows.Forms.CheckBox();
            this.chkFourthParam = new System.Windows.Forms.CheckBox();
            this.txtStructureName = new System.Windows.Forms.TextBox();
            this.btnLock = new System.Windows.Forms.Button();
            this.LockIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpAllComponents = new System.Windows.Forms.GroupBox();
            this.lblLockTheButton = new System.Windows.Forms.Label();
            this.lblNewVersion = new System.Windows.Forms.Label();
            this.lblCreateStructure = new System.Windows.Forms.Label();
            this.grpSecondParam.SuspendLayout();
            this.grpFirstParam.SuspendLayout();
            this.grpThirdParam.SuspendLayout();
            this.grpFourthParam.SuspendLayout();
            this.grpAllComponents.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStructureName
            // 
            resources.ApplyResources(this.lblStructureName, "lblStructureName");
            this.lblStructureName.ForeColor = System.Drawing.Color.Red;
            this.lblStructureName.Name = "lblStructureName";
            // 
            // lblParameters
            // 
            resources.ApplyResources(this.lblParameters, "lblParameters");
            this.lblParameters.BackColor = System.Drawing.Color.Transparent;
            this.lblParameters.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblParameters.Name = "lblParameters";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // chkSecondParam
            // 
            resources.ApplyResources(this.chkSecondParam, "chkSecondParam");
            this.chkSecondParam.BackColor = System.Drawing.Color.Black;
            this.chkSecondParam.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkSecondParam.Name = "chkSecondParam";
            this.chkSecondParam.UseVisualStyleBackColor = false;
            this.chkSecondParam.CheckedChanged += new System.EventHandler(this.chkSecondParam_CheckedChanged);
            // 
            // cmbSecondParamType
            // 
            this.cmbSecondParamType.BackColor = System.Drawing.Color.Black;
            this.cmbSecondParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbSecondParamType, "cmbSecondParamType");
            this.cmbSecondParamType.ForeColor = System.Drawing.Color.Red;
            this.cmbSecondParamType.FormattingEnabled = true;
            this.cmbSecondParamType.Items.AddRange(new object[] {
            resources.GetString("cmbSecondParamType.Items"),
            resources.GetString("cmbSecondParamType.Items1"),
            resources.GetString("cmbSecondParamType.Items2"),
            resources.GetString("cmbSecondParamType.Items3"),
            resources.GetString("cmbSecondParamType.Items4")});
            this.cmbSecondParamType.Name = "cmbSecondParamType";
            this.cmbSecondParamType.SelectedIndexChanged += new System.EventHandler(this.cmbSecondParamType_SelectedIndexChanged);
            // 
            // txtSecondParamLenght
            // 
            this.txtSecondParamLenght.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtSecondParamLenght, "txtSecondParamLenght");
            this.txtSecondParamLenght.ForeColor = System.Drawing.Color.Cyan;
            this.txtSecondParamLenght.Name = "txtSecondParamLenght";
            // 
            // txtSecondParamName
            // 
            this.txtSecondParamName.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtSecondParamName, "txtSecondParamName");
            this.txtSecondParamName.ForeColor = System.Drawing.Color.Cyan;
            this.txtSecondParamName.Name = "txtSecondParamName";
            // 
            // grpSecondParam
            // 
            this.grpSecondParam.BackColor = System.Drawing.Color.Transparent;
            this.grpSecondParam.Controls.Add(this.cmbSecondParamType);
            this.grpSecondParam.Controls.Add(this.txtSecondParamLenght);
            this.grpSecondParam.Controls.Add(this.txtSecondParamName);
            this.grpSecondParam.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.grpSecondParam, "grpSecondParam");
            this.grpSecondParam.Name = "grpSecondParam";
            this.grpSecondParam.TabStop = false;
            // 
            // grpFirstParam
            // 
            this.grpFirstParam.BackColor = System.Drawing.Color.Transparent;
            this.grpFirstParam.Controls.Add(this.cmbFirstParamType);
            this.grpFirstParam.Controls.Add(this.txtFirstParamLenght);
            this.grpFirstParam.Controls.Add(this.txtFirstParamName);
            this.grpFirstParam.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpFirstParam, "grpFirstParam");
            this.grpFirstParam.Name = "grpFirstParam";
            this.grpFirstParam.TabStop = false;
            // 
            // cmbFirstParamType
            // 
            this.cmbFirstParamType.BackColor = System.Drawing.Color.Black;
            this.cmbFirstParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbFirstParamType, "cmbFirstParamType");
            this.cmbFirstParamType.ForeColor = System.Drawing.Color.Red;
            this.cmbFirstParamType.FormattingEnabled = true;
            this.cmbFirstParamType.Items.AddRange(new object[] {
            resources.GetString("cmbFirstParamType.Items"),
            resources.GetString("cmbFirstParamType.Items1"),
            resources.GetString("cmbFirstParamType.Items2"),
            resources.GetString("cmbFirstParamType.Items3"),
            resources.GetString("cmbFirstParamType.Items4")});
            this.cmbFirstParamType.Name = "cmbFirstParamType";
            this.cmbFirstParamType.SelectedIndexChanged += new System.EventHandler(this.cmbFirstParamType_SelectedIndexChanged);
            // 
            // txtFirstParamLenght
            // 
            this.txtFirstParamLenght.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtFirstParamLenght, "txtFirstParamLenght");
            this.txtFirstParamLenght.ForeColor = System.Drawing.Color.Cyan;
            this.txtFirstParamLenght.Name = "txtFirstParamLenght";
            // 
            // txtFirstParamName
            // 
            this.txtFirstParamName.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtFirstParamName, "txtFirstParamName");
            this.txtFirstParamName.ForeColor = System.Drawing.Color.Cyan;
            this.txtFirstParamName.Name = "txtFirstParamName";
            // 
            // grpThirdParam
            // 
            this.grpThirdParam.BackColor = System.Drawing.Color.Transparent;
            this.grpThirdParam.Controls.Add(this.cmbThirdParamType);
            this.grpThirdParam.Controls.Add(this.txtThirdParamLenght);
            this.grpThirdParam.Controls.Add(this.txtThirdParamName);
            this.grpThirdParam.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpThirdParam, "grpThirdParam");
            this.grpThirdParam.Name = "grpThirdParam";
            this.grpThirdParam.TabStop = false;
            // 
            // cmbThirdParamType
            // 
            this.cmbThirdParamType.BackColor = System.Drawing.Color.Black;
            this.cmbThirdParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbThirdParamType, "cmbThirdParamType");
            this.cmbThirdParamType.ForeColor = System.Drawing.Color.Red;
            this.cmbThirdParamType.FormattingEnabled = true;
            this.cmbThirdParamType.Items.AddRange(new object[] {
            resources.GetString("cmbThirdParamType.Items"),
            resources.GetString("cmbThirdParamType.Items1"),
            resources.GetString("cmbThirdParamType.Items2"),
            resources.GetString("cmbThirdParamType.Items3"),
            resources.GetString("cmbThirdParamType.Items4")});
            this.cmbThirdParamType.Name = "cmbThirdParamType";
            this.cmbThirdParamType.SelectedIndexChanged += new System.EventHandler(this.cmbThirdParamType_SelectedIndexChanged);
            // 
            // txtThirdParamLenght
            // 
            this.txtThirdParamLenght.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtThirdParamLenght, "txtThirdParamLenght");
            this.txtThirdParamLenght.ForeColor = System.Drawing.Color.Cyan;
            this.txtThirdParamLenght.Name = "txtThirdParamLenght";
            // 
            // txtThirdParamName
            // 
            this.txtThirdParamName.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtThirdParamName, "txtThirdParamName");
            this.txtThirdParamName.ForeColor = System.Drawing.Color.Cyan;
            this.txtThirdParamName.Name = "txtThirdParamName";
            // 
            // grpFourthParam
            // 
            this.grpFourthParam.BackColor = System.Drawing.Color.Transparent;
            this.grpFourthParam.Controls.Add(this.cmbFourthParamType);
            this.grpFourthParam.Controls.Add(this.txtFourthParamLenght);
            this.grpFourthParam.Controls.Add(this.txtFourthParamName);
            this.grpFourthParam.ForeColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.grpFourthParam, "grpFourthParam");
            this.grpFourthParam.Name = "grpFourthParam";
            this.grpFourthParam.TabStop = false;
            // 
            // cmbFourthParamType
            // 
            this.cmbFourthParamType.BackColor = System.Drawing.Color.Black;
            this.cmbFourthParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbFourthParamType, "cmbFourthParamType");
            this.cmbFourthParamType.ForeColor = System.Drawing.Color.Red;
            this.cmbFourthParamType.FormattingEnabled = true;
            this.cmbFourthParamType.Items.AddRange(new object[] {
            resources.GetString("cmbFourthParamType.Items"),
            resources.GetString("cmbFourthParamType.Items1"),
            resources.GetString("cmbFourthParamType.Items2"),
            resources.GetString("cmbFourthParamType.Items3"),
            resources.GetString("cmbFourthParamType.Items4")});
            this.cmbFourthParamType.Name = "cmbFourthParamType";
            this.cmbFourthParamType.SelectedIndexChanged += new System.EventHandler(this.cmbFourthParamType_SelectedIndexChanged);
            // 
            // txtFourthParamLenght
            // 
            this.txtFourthParamLenght.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtFourthParamLenght, "txtFourthParamLenght");
            this.txtFourthParamLenght.ForeColor = System.Drawing.Color.Cyan;
            this.txtFourthParamLenght.Name = "txtFourthParamLenght";
            // 
            // txtFourthParamName
            // 
            this.txtFourthParamName.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtFourthParamName, "txtFourthParamName");
            this.txtFourthParamName.ForeColor = System.Drawing.Color.Cyan;
            this.txtFourthParamName.Name = "txtFourthParamName";
            // 
            // chkThirdParam
            // 
            resources.ApplyResources(this.chkThirdParam, "chkThirdParam");
            this.chkThirdParam.BackColor = System.Drawing.Color.Black;
            this.chkThirdParam.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkThirdParam.Name = "chkThirdParam";
            this.chkThirdParam.UseVisualStyleBackColor = false;
            this.chkThirdParam.CheckedChanged += new System.EventHandler(this.chkThirdParam_CheckedChanged);
            // 
            // chkFourthParam
            // 
            resources.ApplyResources(this.chkFourthParam, "chkFourthParam");
            this.chkFourthParam.BackColor = System.Drawing.Color.Transparent;
            this.chkFourthParam.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkFourthParam.Name = "chkFourthParam";
            this.chkFourthParam.UseVisualStyleBackColor = false;
            this.chkFourthParam.CheckedChanged += new System.EventHandler(this.chkFourthParam_CheckedChanged);
            // 
            // txtStructureName
            // 
            this.txtStructureName.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtStructureName, "txtStructureName");
            this.txtStructureName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtStructureName.Name = "txtStructureName";
            // 
            // btnLock
            // 
            this.btnLock.BackColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.btnLock, "btnLock");
            this.btnLock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLock.ImageList = this.LockIcons;
            this.btnLock.Name = "btnLock";
            this.btnLock.UseVisualStyleBackColor = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // LockIcons
            // 
            this.LockIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LockIcons.ImageStream")));
            this.LockIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.LockIcons.Images.SetKeyName(0, "padlock.png");
            this.LockIcons.Images.SetKeyName(1, "lock.png");
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // grpAllComponents
            // 
            this.grpAllComponents.BackColor = System.Drawing.Color.Transparent;
            this.grpAllComponents.Controls.Add(this.txtStructureName);
            this.grpAllComponents.Controls.Add(this.chkFourthParam);
            this.grpAllComponents.Controls.Add(this.chkThirdParam);
            this.grpAllComponents.Controls.Add(this.grpFourthParam);
            this.grpAllComponents.Controls.Add(this.grpThirdParam);
            this.grpAllComponents.Controls.Add(this.grpFirstParam);
            this.grpAllComponents.Controls.Add(this.grpSecondParam);
            this.grpAllComponents.Controls.Add(this.chkSecondParam);
            this.grpAllComponents.Controls.Add(this.label5);
            this.grpAllComponents.Controls.Add(this.label4);
            this.grpAllComponents.Controls.Add(this.label3);
            this.grpAllComponents.Controls.Add(this.lblParameters);
            this.grpAllComponents.Controls.Add(this.lblStructureName);
            this.grpAllComponents.ForeColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.grpAllComponents, "grpAllComponents");
            this.grpAllComponents.Name = "grpAllComponents";
            this.grpAllComponents.TabStop = false;
            // 
            // lblLockTheButton
            // 
            resources.ApplyResources(this.lblLockTheButton, "lblLockTheButton");
            this.lblLockTheButton.BackColor = System.Drawing.Color.Transparent;
            this.lblLockTheButton.ForeColor = System.Drawing.Color.Red;
            this.lblLockTheButton.Name = "lblLockTheButton";
            // 
            // lblNewVersion
            // 
            resources.ApplyResources(this.lblNewVersion, "lblNewVersion");
            this.lblNewVersion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNewVersion.Name = "lblNewVersion";
            // 
            // lblCreateStructure
            // 
            resources.ApplyResources(this.lblCreateStructure, "lblCreateStructure");
            this.lblCreateStructure.BackColor = System.Drawing.Color.Transparent;
            this.lblCreateStructure.ForeColor = System.Drawing.Color.Red;
            this.lblCreateStructure.Name = "lblCreateStructure";
            // 
            // StructureBuilder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblCreateStructure);
            this.Controls.Add(this.lblNewVersion);
            this.Controls.Add(this.lblLockTheButton);
            this.Controls.Add(this.grpAllComponents);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLock);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StructureBuilder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StructureBuilder_FormClosing);
            this.Load += new System.EventHandler(this.StructureBuilder_Load);
            this.grpSecondParam.ResumeLayout(false);
            this.grpSecondParam.PerformLayout();
            this.grpFirstParam.ResumeLayout(false);
            this.grpFirstParam.PerformLayout();
            this.grpThirdParam.ResumeLayout(false);
            this.grpThirdParam.PerformLayout();
            this.grpFourthParam.ResumeLayout(false);
            this.grpFourthParam.PerformLayout();
            this.grpAllComponents.ResumeLayout(false);
            this.grpAllComponents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStructureName;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSecondParam;
        private System.Windows.Forms.ComboBox cmbSecondParamType;
        private System.Windows.Forms.TextBox txtSecondParamLenght;
        private System.Windows.Forms.TextBox txtSecondParamName;
        private System.Windows.Forms.GroupBox grpSecondParam;
        private System.Windows.Forms.GroupBox grpFirstParam;
        private System.Windows.Forms.ComboBox cmbFirstParamType;
        private System.Windows.Forms.TextBox txtFirstParamLenght;
        private System.Windows.Forms.TextBox txtFirstParamName;
        private System.Windows.Forms.GroupBox grpThirdParam;
        private System.Windows.Forms.ComboBox cmbThirdParamType;
        private System.Windows.Forms.TextBox txtThirdParamLenght;
        private System.Windows.Forms.TextBox txtThirdParamName;
        private System.Windows.Forms.GroupBox grpFourthParam;
        private System.Windows.Forms.ComboBox cmbFourthParamType;
        private System.Windows.Forms.TextBox txtFourthParamLenght;
        private System.Windows.Forms.TextBox txtFourthParamName;
        private System.Windows.Forms.CheckBox chkThirdParam;
        private System.Windows.Forms.CheckBox chkFourthParam;
        private System.Windows.Forms.TextBox txtStructureName;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ImageList LockIcons;
        private System.Windows.Forms.GroupBox grpAllComponents;
        private System.Windows.Forms.Label lblLockTheButton;
        private System.Windows.Forms.Label lblNewVersion;
        private System.Windows.Forms.Label lblCreateStructure;
    }
}

