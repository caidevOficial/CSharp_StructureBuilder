
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureBuilder));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpSecondParam.SuspendLayout();
            this.grpFirstParam.SuspendLayout();
            this.grpThirdParam.SuspendLayout();
            this.grpFourthParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Structure Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(361, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "Length";
            // 
            // chkSecondParam
            // 
            this.chkSecondParam.AutoSize = true;
            this.chkSecondParam.Location = new System.Drawing.Point(19, 233);
            this.chkSecondParam.Name = "chkSecondParam";
            this.chkSecondParam.Size = new System.Drawing.Size(59, 17);
            this.chkSecondParam.TabIndex = 4;
            this.chkSecondParam.Text = "Enable";
            this.chkSecondParam.UseVisualStyleBackColor = true;
            this.chkSecondParam.CheckedChanged += new System.EventHandler(this.chkSecondParam_CheckedChanged);
            // 
            // cmbSecondParamType
            // 
            this.cmbSecondParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecondParamType.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmbSecondParamType.FormattingEnabled = true;
            this.cmbSecondParamType.Items.AddRange(new object[] {
            "int",
            "float",
            "char",
            "short",
            "long int"});
            this.cmbSecondParamType.Location = new System.Drawing.Point(20, 18);
            this.cmbSecondParamType.Name = "cmbSecondParamType";
            this.cmbSecondParamType.Size = new System.Drawing.Size(64, 43);
            this.cmbSecondParamType.TabIndex = 5;
            // 
            // txtSecondParamLenght
            // 
            this.txtSecondParamLenght.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondParamLenght.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtSecondParamLenght.Location = new System.Drawing.Point(246, 21);
            this.txtSecondParamLenght.Name = "txtSecondParamLenght";
            this.txtSecondParamLenght.Size = new System.Drawing.Size(79, 40);
            this.txtSecondParamLenght.TabIndex = 7;
            this.txtSecondParamLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSecondParamName
            // 
            this.txtSecondParamName.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondParamName.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtSecondParamName.Location = new System.Drawing.Point(105, 21);
            this.txtSecondParamName.Name = "txtSecondParamName";
            this.txtSecondParamName.Size = new System.Drawing.Size(119, 40);
            this.txtSecondParamName.TabIndex = 6;
            this.txtSecondParamName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpSecondParam
            // 
            this.grpSecondParam.Controls.Add(this.cmbSecondParamType);
            this.grpSecondParam.Controls.Add(this.txtSecondParamLenght);
            this.grpSecondParam.Controls.Add(this.txtSecondParamName);
            this.grpSecondParam.Location = new System.Drawing.Point(113, 201);
            this.grpSecondParam.Name = "grpSecondParam";
            this.grpSecondParam.Size = new System.Drawing.Size(341, 75);
            this.grpSecondParam.TabIndex = 12;
            this.grpSecondParam.TabStop = false;
            this.grpSecondParam.Text = "2° Parameter";
            // 
            // grpFirstParam
            // 
            this.grpFirstParam.Controls.Add(this.cmbFirstParamType);
            this.grpFirstParam.Controls.Add(this.txtFirstParamLenght);
            this.grpFirstParam.Controls.Add(this.txtFirstParamName);
            this.grpFirstParam.Location = new System.Drawing.Point(113, 120);
            this.grpFirstParam.Name = "grpFirstParam";
            this.grpFirstParam.Size = new System.Drawing.Size(341, 75);
            this.grpFirstParam.TabIndex = 13;
            this.grpFirstParam.TabStop = false;
            this.grpFirstParam.Text = "1° Parameter";
            // 
            // cmbFirstParamType
            // 
            this.cmbFirstParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirstParamType.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmbFirstParamType.FormattingEnabled = true;
            this.cmbFirstParamType.Items.AddRange(new object[] {
            "int",
            "float",
            "char",
            "short",
            "long int"});
            this.cmbFirstParamType.Location = new System.Drawing.Point(20, 18);
            this.cmbFirstParamType.Name = "cmbFirstParamType";
            this.cmbFirstParamType.Size = new System.Drawing.Size(64, 43);
            this.cmbFirstParamType.TabIndex = 1;
            // 
            // txtFirstParamLenght
            // 
            this.txtFirstParamLenght.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstParamLenght.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtFirstParamLenght.Location = new System.Drawing.Point(246, 21);
            this.txtFirstParamLenght.Name = "txtFirstParamLenght";
            this.txtFirstParamLenght.Size = new System.Drawing.Size(79, 40);
            this.txtFirstParamLenght.TabIndex = 3;
            this.txtFirstParamLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFirstParamName
            // 
            this.txtFirstParamName.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstParamName.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtFirstParamName.Location = new System.Drawing.Point(105, 21);
            this.txtFirstParamName.Name = "txtFirstParamName";
            this.txtFirstParamName.Size = new System.Drawing.Size(119, 40);
            this.txtFirstParamName.TabIndex = 2;
            this.txtFirstParamName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpThirdParam
            // 
            this.grpThirdParam.Controls.Add(this.cmbThirdParamType);
            this.grpThirdParam.Controls.Add(this.txtThirdParamLenght);
            this.grpThirdParam.Controls.Add(this.txtThirdParamName);
            this.grpThirdParam.Location = new System.Drawing.Point(113, 268);
            this.grpThirdParam.Name = "grpThirdParam";
            this.grpThirdParam.Size = new System.Drawing.Size(341, 75);
            this.grpThirdParam.TabIndex = 13;
            this.grpThirdParam.TabStop = false;
            this.grpThirdParam.Text = "3° Parameter";
            // 
            // cmbThirdParamType
            // 
            this.cmbThirdParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThirdParamType.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmbThirdParamType.FormattingEnabled = true;
            this.cmbThirdParamType.Items.AddRange(new object[] {
            "int",
            "float",
            "char",
            "short",
            "long int"});
            this.cmbThirdParamType.Location = new System.Drawing.Point(20, 18);
            this.cmbThirdParamType.Name = "cmbThirdParamType";
            this.cmbThirdParamType.Size = new System.Drawing.Size(64, 43);
            this.cmbThirdParamType.TabIndex = 9;
            // 
            // txtThirdParamLenght
            // 
            this.txtThirdParamLenght.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThirdParamLenght.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtThirdParamLenght.Location = new System.Drawing.Point(246, 21);
            this.txtThirdParamLenght.Name = "txtThirdParamLenght";
            this.txtThirdParamLenght.Size = new System.Drawing.Size(79, 40);
            this.txtThirdParamLenght.TabIndex = 11;
            this.txtThirdParamLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtThirdParamName
            // 
            this.txtThirdParamName.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThirdParamName.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtThirdParamName.Location = new System.Drawing.Point(105, 21);
            this.txtThirdParamName.Name = "txtThirdParamName";
            this.txtThirdParamName.Size = new System.Drawing.Size(119, 40);
            this.txtThirdParamName.TabIndex = 10;
            this.txtThirdParamName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpFourthParam
            // 
            this.grpFourthParam.Controls.Add(this.cmbFourthParamType);
            this.grpFourthParam.Controls.Add(this.txtFourthParamLenght);
            this.grpFourthParam.Controls.Add(this.txtFourthParamName);
            this.grpFourthParam.Location = new System.Drawing.Point(113, 335);
            this.grpFourthParam.Name = "grpFourthParam";
            this.grpFourthParam.Size = new System.Drawing.Size(341, 75);
            this.grpFourthParam.TabIndex = 13;
            this.grpFourthParam.TabStop = false;
            this.grpFourthParam.Text = "4° Parameter";
            // 
            // cmbFourthParamType
            // 
            this.cmbFourthParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFourthParamType.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmbFourthParamType.FormattingEnabled = true;
            this.cmbFourthParamType.Items.AddRange(new object[] {
            "int",
            "float",
            "char",
            "short",
            "long int"});
            this.cmbFourthParamType.Location = new System.Drawing.Point(20, 18);
            this.cmbFourthParamType.Name = "cmbFourthParamType";
            this.cmbFourthParamType.Size = new System.Drawing.Size(64, 43);
            this.cmbFourthParamType.TabIndex = 13;
            // 
            // txtFourthParamLenght
            // 
            this.txtFourthParamLenght.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFourthParamLenght.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtFourthParamLenght.Location = new System.Drawing.Point(246, 21);
            this.txtFourthParamLenght.Name = "txtFourthParamLenght";
            this.txtFourthParamLenght.Size = new System.Drawing.Size(79, 40);
            this.txtFourthParamLenght.TabIndex = 15;
            this.txtFourthParamLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFourthParamName
            // 
            this.txtFourthParamName.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFourthParamName.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtFourthParamName.Location = new System.Drawing.Point(105, 21);
            this.txtFourthParamName.Name = "txtFourthParamName";
            this.txtFourthParamName.Size = new System.Drawing.Size(119, 40);
            this.txtFourthParamName.TabIndex = 14;
            this.txtFourthParamName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkThirdParam
            // 
            this.chkThirdParam.AutoSize = true;
            this.chkThirdParam.Location = new System.Drawing.Point(19, 300);
            this.chkThirdParam.Name = "chkThirdParam";
            this.chkThirdParam.Size = new System.Drawing.Size(59, 17);
            this.chkThirdParam.TabIndex = 8;
            this.chkThirdParam.Text = "Enable";
            this.chkThirdParam.UseVisualStyleBackColor = true;
            this.chkThirdParam.CheckedChanged += new System.EventHandler(this.chkThirdParam_CheckedChanged);
            // 
            // chkFourthParam
            // 
            this.chkFourthParam.AutoSize = true;
            this.chkFourthParam.Location = new System.Drawing.Point(19, 367);
            this.chkFourthParam.Name = "chkFourthParam";
            this.chkFourthParam.Size = new System.Drawing.Size(59, 17);
            this.chkFourthParam.TabIndex = 12;
            this.chkFourthParam.Text = "Enable";
            this.chkFourthParam.UseVisualStyleBackColor = true;
            this.chkFourthParam.CheckedChanged += new System.EventHandler(this.chkFourthParam_CheckedChanged);
            // 
            // txtStructureName
            // 
            this.txtStructureName.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStructureName.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.txtStructureName.Location = new System.Drawing.Point(298, 12);
            this.txtStructureName.Name = "txtStructureName";
            this.txtStructureName.Size = new System.Drawing.Size(119, 40);
            this.txtStructureName.TabIndex = 0;
            this.txtStructureName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLock
            // 
            this.btnLock.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLock.Location = new System.Drawing.Point(79, 416);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(189, 64);
            this.btnLock.TabIndex = 16;
            this.btnLock.Text = "button1";
            this.btnLock.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCreate.Location = new System.Drawing.Point(298, 416);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(189, 64);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Create Structure";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // StructureBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 560);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.txtStructureName);
            this.Controls.Add(this.chkFourthParam);
            this.Controls.Add(this.chkThirdParam);
            this.Controls.Add(this.grpFourthParam);
            this.Controls.Add(this.grpThirdParam);
            this.Controls.Add(this.grpFirstParam);
            this.Controls.Add(this.grpSecondParam);
            this.Controls.Add(this.chkSecondParam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StructureBuilder";
            this.Text = "Structure Builder";
            this.grpSecondParam.ResumeLayout(false);
            this.grpSecondParam.PerformLayout();
            this.grpFirstParam.ResumeLayout(false);
            this.grpFirstParam.PerformLayout();
            this.grpThirdParam.ResumeLayout(false);
            this.grpThirdParam.PerformLayout();
            this.grpFourthParam.ResumeLayout(false);
            this.grpFourthParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
    }
}

