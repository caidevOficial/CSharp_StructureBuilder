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

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using FileBuilders;
using Models;
using SBExceptions;

namespace StructureBuilder_Form {
    public partial class StructureBuilder : Form {

        #region AudioPaths

        private static readonly string systemPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
        private static readonly string PathOfFiles = $"{systemPath}\\C_Files";
        private readonly string checkBox2Sound = "soundCheck2";
        private readonly string checkBox3Sound = "soundCheck3";
        private readonly string checkBox4Sound = "soundCheck4";
        private readonly string errorSound = "soundException";
        private readonly string lockOffSound = "soundUnlock";
        private readonly string lockOnSound = "soundLock";
        private readonly string loginSound = "soundLogin";
        private readonly string successSound = "soundSuccess";
        private readonly string unCheckBoxSound = "soundUnCheck";

        #endregion

        #region Attributes

        private List<TextBox> textBoxes;
        private List<TextBox> textChars;
        private readonly List<Thread> threads;
        private readonly MyPlayer myDelPlayer;
        private Parameter myParameter;
        private static Structure myStructure;
        private readonly CreatorDotH makerH = new CreatorDotH();
        private readonly CreatorDotC makerC = new CreatorDotC();
        private readonly short fullPackSize = 8; // Basic functions struct newEmpty + new + show + showall
        private readonly short packsDone = 0;
        private bool locked = false;
        private readonly string appVersion = "Version [2.6.1.5]";

        #endregion

        #region Builder

        /// <summary>
        /// Basic constructor of the form.
        /// </summary>
        public StructureBuilder() {

            InitializeComponent();
            this.textBoxes = new List<TextBox>();
            this.textChars = new List<TextBox>();
            this.threads = new List<Thread>();
            this.myDelPlayer = new MyPlayer();
            this.myDelPlayer.ESoundPlayer += this.MyPlayerMainMusic;
            myStructure = new Structure();
            this.myParameter = new Parameter();
            this.makerC = new CreatorDotC();
            this.makerH = new CreatorDotH();
        }

        #endregion

        #region LoadEvent

        /// <summary>
        /// EventHandler of Load Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StructureBuilder_Load(object sender, EventArgs e) {
            this.Hide();
            try {
                this.FormInitialState();
                this.lblNewVersion.Text = this.appVersion;
                FrmWelcome welcome = new FrmWelcome();
                if (welcome.ShowDialog() == DialogResult.OK) {
                    this.PlayMusic(this.loginSound);
                }
                
            } catch (NoSoundFoundException ns) {
                frmException fe = new frmException(ns) {
                    Location = this.Location
                };
                fe.ShowDialog();
            }
        }

        /// <summary>
        /// Sets the form in the initial state.
        /// </summary>
        private void FormInitialState() {
            this.btnCreate.Enabled = false;
            this.cmbFirstParamType.SelectedIndex = 0;
            this.cmbSecondParamType.SelectedIndex = 0;
            this.cmbThirdParamType.SelectedIndex = 0;
            this.cmbFourthParamType.SelectedIndex = 0;
            this.cmbFifthParamType.SelectedIndex = 0;
            this.cmbSixthParamType.SelectedIndex = 0;
            this.LockOrUnlockComponents(this.grpSecondParam, false);
            this.LockOrUnlockComponents(this.chkThirdParam, this.grpThirdParam, false);
            this.LockOrUnlockComponents(this.chkFourthParam, this.grpFourthParam, false);
            this.LockOrUnlockComponents(this.chkFifthParam, this.grpFifthParam, false);
            this.LockOrUnlockComponents(this.chkSixthParam, this.grpSixthParam, false);
        }

        #endregion

        #region MyPlayer

        /// <summary>
        /// Plays a sound in another thread.
        /// </summary>
        /// <param name="musicName">Name of the sound.</param>
        private void PlayMusic(object musicName) {
            Thread playerThread = new Thread(new ParameterizedThreadStart(this.MyPlayerMainMusic));
            playerThread.Start((object)musicName);
            this.threads.Add(playerThread);
        }

        /// <summary>
        /// Creates a soundPlayer and plays the sound.
        /// </summary>
        /// <param name="soundName">Name of the sound to play.</param>
        private void MyPlayerMainMusic(object soundName) {
            if (this.InvokeRequired) {
                this.BeginInvoke(
                    (MethodInvoker)delegate {
                        MyPlayer player = new MyPlayer();
                        player.Play((string)soundName);
                    });
            } else {
                MyPlayer player = new MyPlayer();
                player.Play((string)soundName);
            }
        }

        #endregion

        #region CheckButtons

        /// <summary>
        /// Lock or unlock (bassed on the boolean variable) the GroupBox passed by parameter.
        /// </summary>
        /// <param name="box">GroupBox to lock/unlock.</param>
        /// <param name="unlocked">Boolean state that indicates if is locked or not.</param>
        private void LockOrUnlockComponents(GroupBox box, bool unlocked) {
            box.Enabled = unlocked;
            box.Visible = unlocked;
        }

        /// <summary>
        /// Lock or unlock (bassed on the boolean variable) the CheckBox passed by parameter.
        /// </summary>
        /// <param name="checkbox">Checkbox to lock/unlock.</param>
        /// <param name="unlocked">Boolean state that indicates if is locked or not.</param>
        private void LockOrUnlockComponents(CheckBox checkbox, bool unlocked) {
            checkbox.Enabled = unlocked;
            checkbox.Visible = unlocked;
            checkbox.Checked = false;
        }

        /// <summary>
        /// Lock or unlock (bassed on the boolean variable) the CheckBox and GroupBox
        /// passed by parameter.
        /// </summary>
        /// <param name="checkbox">Checkbox to lock/unlock.</param>
        /// <param name="box">GroupBox to lock/unlock.</param>
        /// <param name="unlocked">Boolean state that indicates if is locked or not.</param>
        private void LockOrUnlockComponents(CheckBox checkbox, GroupBox box, bool unlocked) {
            this.LockOrUnlockComponents(checkbox, unlocked);
            this.LockOrUnlockComponents(box, unlocked);
        }


        /// <summary>
        /// Event manager of the second checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSecondParam_CheckedChanged(object sender, EventArgs e) {
            if (this.chkSecondParam.Checked is true) {
                this.LockOrUnlockComponents(this.chkThirdParam, this.grpSecondParam, true);
                this.PlayMusic(this.checkBox2Sound);
            } else {
                this.PlayMusic(this.unCheckBoxSound);
                this.LockOrUnlockComponents(this.chkThirdParam, this.grpSecondParam, false);
                this.LockOrUnlockComponents(this.chkFourthParam, this.grpThirdParam, false);
                this.LockOrUnlockComponents(this.grpFourthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the third checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkThirdParam_CheckedChanged(object sender, EventArgs e) {
            if (this.chkThirdParam.Checked is true) {
                this.LockOrUnlockComponents(this.chkFourthParam, this.grpThirdParam, true);
                this.PlayMusic(this.checkBox3Sound);
            } else {
                this.PlayMusic(this.unCheckBoxSound);
                this.LockOrUnlockComponents(this.chkFourthParam, this.grpThirdParam, false);
                this.LockOrUnlockComponents(this.chkFifthParam, this.grpFourthParam, false);
                this.LockOrUnlockComponents(this.grpSixthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the fourth checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFourthParam_CheckedChanged(object sender, EventArgs e) {
            if (this.chkFourthParam.Checked is true) {
                this.LockOrUnlockComponents(this.chkFifthParam, this.grpFourthParam, true);
                this.PlayMusic(this.checkBox4Sound);
            } else {
                this.PlayMusic(this.unCheckBoxSound);
                this.LockOrUnlockComponents(this.chkFifthParam, this.grpFourthParam, false);
                this.LockOrUnlockComponents(this.grpSixthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the Fifth checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFifthParam_CheckedChanged(object sender, EventArgs e) {
            if (this.chkFifthParam.Checked is true) {
                this.LockOrUnlockComponents(this.chkSixthParam, this.grpFifthParam, true);
                this.PlayMusic(this.checkBox2Sound);
            } else {
                this.PlayMusic(this.unCheckBoxSound);
                this.LockOrUnlockComponents(this.chkSixthParam, this.grpFifthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the Sixth checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSixthParam_CheckedChanged(object sender, EventArgs e) {
            if (this.chkSixthParam.Checked is true) {
                this.LockOrUnlockComponents(this.grpSixthParam, true);
                this.PlayMusic(this.checkBox3Sound);
            } else {
                this.PlayMusic(this.unCheckBoxSound);
                this.LockOrUnlockComponents(this.grpSixthParam, false);
            }
        }

        #endregion

        #region CreateParameters

        /// <summary>
        /// Takes the info of the form to create a parameter.
        /// </summary>
        /// <param name="myParameter">Entity to assemble the data.</param>
        /// <param name="nameParameter">Name of the parameter.</param>
        /// <param name="typeParameter">type of the parameter.</param>
        /// <param name="lengthParameter">length of the parameter.</param>
        /// <returns>Returns the parameter.</returns>
        private Parameter CreateParameter(Structure myStructure, Parameter myParameter, string nameParameter, string typeParameter, string lengthParameter) {
            if (myStructure.ListParamaters.Count == 0) {
                myParameter.IdParameter = 1;
            } else {
                myParameter.IdParameter = (short)(myStructure.ListParamaters.Count + 1);
            }
            myParameter.NameParameter = nameParameter.Trim().Replace(" ", "");
            myParameter.AliasNameParameter = myParameter.NameParameter;
            myParameter.TypeParameter = typeParameter;
            if (int.TryParse(lengthParameter, out int paramLength)) {
                myParameter.LengthParameter = paramLength;
            } else {
                myParameter.LengthParameter = 1;
            }

            return myParameter;
        }

        #endregion

        #region CreateStructureWithParam

        /// <summary>
        /// Creates the structure with one parameter inside its list.
        /// </summary>
        /// <returns>True if can create the entity, otherwise returns false.</returns>
        private bool CreateStructure() {
            if (String.IsNullOrWhiteSpace(this.txtFirstParamName.Text) || String.IsNullOrWhiteSpace(this.txtFirstParamLength.Text)) {
                //MessageBox.Show("There are at least one field empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new EmptyFieldException("You have at least one field Empty.");
            } else {
                //Set structure
                myStructure.StructureName = this.txtStructureName.Text.RemoveSpaces();
                myStructure.AliasName = myStructure.StructureName;
                myStructure.FinalStructureName = myStructure.AliasName;

                // Set parameter
                this.myParameter = CreateParameter(myStructure, this.myParameter, this.txtFirstParamName.Text.RemoveSpaces(), this.cmbFirstParamType.SelectedItem.ToString(), this.txtFirstParamLength.Text.RemoveSpaces());
                // add to list
                if (!(myStructure + this.myParameter)) {
                    MessageBox.Show($"An Error has occurred adding the 1st parameter: {this.myParameter.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    if (this.cmbFirstParamType.SelectedItem.ToString().Equals("char")) {
                        this.textChars.Add(this.txtFirstParamLength);
                    }
                    this.textBoxes.Add(this.txtFirstParamName);
                    this.textBoxes.Add(this.txtStructureName);
                }


                return true;
            }
        }

        #endregion

        #region CreateFile

        /// <summary>
        /// Creator fo both text files of the app.
        /// </summary>
        /// <param name="myStructure">Structure instance</param>
        /// <param name="packsDone">Amount of completed steps.</param>
        /// <param name="fullPackSize">Total amount of steps.</param>
        private void CreateFiles(string path, Structure myStructure, short packsDone, short fullPackSize) {
            packsDone = makerH.FileMaker(path, myStructure, packsDone, fullPackSize);
            packsDone = makerC.FileMaker(path, myStructure, packsDone, fullPackSize);
            //ConsolePrinter.ShowProgress(fullPackSize, packsDone);
        }

        #endregion

        #region ButtonCreate

        /// <summary>
        /// Creates a parameter and tries to add it into the Structure.
        /// </summary>
        /// <param name="paramNumber">Ordinal number of the parameter 'like 1st, 2nd, etc.'</param>
        /// <param name="aStructure">Structure to add the parameter.</param>
        /// <param name="chBox">Check box of the parameter.</param>
        /// <param name="cmbType">Combo Box of the parameter.</param>
        /// <param name="txtName">TextBox of the parameter's name.</param>
        /// <param name="txtLength">TextBox of the parameter's Length.</param>
        private void CreateParameterFromForm(string paramNumber, Structure aStructure, CheckBox chBox, ComboBox cmbType, TextBox txtName, TextBox txtLength) {
            if (chBox.Checked) {
                Parameter aParameter = new Parameter();
                if (!String.IsNullOrWhiteSpace(txtName.Text) && !String.IsNullOrWhiteSpace(txtLength.Text)) {
                    aParameter = CreateParameter(aStructure, aParameter, txtName.Text, cmbType.SelectedItem.ToString(), txtLength.Text);
                    if (!(aStructure + aParameter)) {
                        MessageBox.Show($"An Error has occurred adding the {paramNumber} parameter: {aParameter.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        this.textBoxes.Add(txtName);
                        if (cmbType.SelectedItem.ToString().Equals("char")) {
                            this.textChars.Add(txtLength);
                        }
                    }
                } else {
                    throw new EmptyFieldException("You have at least one field Empty.");
                }
            }
        }

        /// <summary>
        /// Event manager of the create button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(this.txtStructureName.Text)) {
                MessageBox.Show("The structure name is empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    if (this.CreateStructure()) {
                        this.CreateParameterFromForm("2nd", myStructure, this.chkSecondParam, this.cmbSecondParamType, this.txtSecondParamName, this.txtSecondParamLength);
                        this.CreateParameterFromForm("3rd", myStructure, this.chkThirdParam, this.cmbThirdParamType, this.txtThirdParamName, this.txtThirdParamLength);
                        this.CreateParameterFromForm("4th", myStructure, this.chkFourthParam, this.cmbFourthParamType, this.txtFourthParamName, this.txtFourthParamLength);
                        this.CreateParameterFromForm("5th", myStructure, this.chkFifthParam, this.cmbFifthParamType, this.txtFifthParamName, this.txtFifthParamLength);
                        this.CreateParameterFromForm("6th", myStructure, this.chkSixthParam, this.cmbSixthParamType, this.txtSixthParamName, this.txtSixthParamLength);

                        if (!Directory.Exists(PathOfFiles)) {
                            Directory.CreateDirectory(PathOfFiles);
                        }

                        this.CreateFiles(PathOfFiles, myStructure, this.packsDone, this.fullPackSize);
                        this.PlayMusic(this.successSound);
                        FrmSuccess fs = new FrmSuccess("your desktop 'C_Files' directory") {
                            Location = this.Location
                        };
                        fs.ShowDialog();
                        this.LockForm(this.locked);
                        this.ClearTextBoxes();
                        myStructure.ListParamaters.Clear();
                    }
                } catch (Exception ex) {
                    try {
                        this.PlayMusic(this.errorSound);
                        frmException fe = new frmException(ex) {
                            Location = this.Location
                        };
                        fe.ShowDialog();
                    } catch (NoSoundFoundException ns) {
                        frmException fe = new frmException(ns) {
                            Location = this.Location
                        };
                        fe.ShowDialog();
                    }
                }
            }
        }

        #endregion

        #region ComboBoxEvents

        /// <summary>
        /// Event handler of the first comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFirstParamType_SelectedIndexChanged(object sender, EventArgs e) {
            this.SetTextBoxByComboBox(this.cmbFirstParamType, this.txtFirstParamLength);
        }

        /// <summary>
        /// Event handler of the second comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSecondParamType_SelectedIndexChanged(object sender, EventArgs e) {
            this.SetTextBoxByComboBox(this.cmbSecondParamType, this.txtSecondParamLength);
        }

        /// <summary>
        /// Event handler of the third comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbThirdParamType_SelectedIndexChanged(object sender, EventArgs e) {
            this.SetTextBoxByComboBox(this.cmbThirdParamType, this.txtThirdParamLength);
        }

        /// <summary>
        /// Event handler of the fourth comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFourthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            this.SetTextBoxByComboBox(this.cmbFourthParamType, this.txtFourthParamLength);
        }

        /// <summary>
        /// Event handler of the fifth comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFifthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            this.SetTextBoxByComboBox(this.cmbFifthParamType, this.txtFifthParamLength);
        }

        /// <summary>
        /// Event handler of the sixth comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSixthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            this.SetTextBoxByComboBox(this.cmbSixthParamType, this.txtSixthParamLength);
        }

        /// <summary>
        /// Sets The text box regarding the selected index of the combo box.
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="txt"></param>
        private void SetTextBoxByComboBox(ComboBox cmb, TextBox txt) {
            if (cmb.SelectedItem.Equals("char")) {
                txt.Enabled = true;
            } else {
                txt.Text = "1";
                txt.Enabled = false;
            }
        }

        #endregion

        #region LockEvent

        /// <summary>
        /// Locks or unlock the entire form.
        /// </summary>
        /// <param name="lockedForm"></param>
        private void LockForm(bool lockedForm) {
            if (!lockedForm) {
                this.PlayMusic(lockOnSound);
                this.locked = !this.locked;
                this.btnLock.ImageIndex = 1;
                this.grpAllComponents.Enabled = false;
                this.btnCreate.Enabled = true;
            } else {
                this.PlayMusic(lockOffSound);
                this.locked = !this.locked;
                this.btnLock.ImageIndex = 0;
                this.grpAllComponents.Enabled = true;
                this.btnCreate.Enabled = false;
            }
        }

        /// <summary>
        /// EventHandler of the lock button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, EventArgs e) {
            try {
                this.LockForm(this.locked);
            } catch (NoSoundFoundException ns) {
                frmException fe = new frmException(ns) {
                    Location = this.Location
                };
                fe.ShowDialog();
            }
        }

        #endregion

        #region Clear

        /// <summary>
        /// Clear all the unlocked textBox and set its length to 1.
        /// </summary>
        private void ClearTextBoxes() {
            try {
                if (this.textBoxes.Count > 0) {
                    foreach (TextBox item in this.textBoxes) {
                        item.Text = "";
                    }
                    this.textBoxes.Clear();
                }
                if (this.textChars.Count > 0) {
                    foreach (TextBox item in this.textChars) {
                        item.Text = "1";
                    }
                    this.textChars.Clear();
                }
            } catch (Exception e) {
                frmException fe = new frmException(e) {
                    Location = this.Location
                };
                fe.ShowDialog();
            }
        }

        #endregion

        #region CloseEvent

        /// <summary>
        /// Stops All the possible alive threads.
        /// </summary>
        private void StopThreads() {
            foreach (Thread item in this.threads) {
                if (!(item is null) && item.IsAlive) {
                    item.Abort();
                }
            }
        }

        /// <summary>
        /// Send a messageBox to the screen asking if the user want to quit the app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StructureBuilder_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show("Do you want to quit?", "Choose Wisely", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                this.StopThreads();
                this.myDelPlayer.ESoundPlayer -= this.MyPlayerMainMusic;
                this.Dispose();
            } else {
                e.Cancel = true;
            }
        }

        #endregion

    }
}
