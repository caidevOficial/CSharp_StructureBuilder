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
        private SoundPlayerHandler musicHandler;

        #endregion

        #region Attributes

        private readonly List<TextBox> textBoxes;
        private readonly List<TextBox> textChars;
        private readonly List<Thread> threads;
        private readonly MyPlayer myDelPlayer;
        private Parameter myParameter;
        private static Structure myStructure;
        private readonly CreatorDotH makerH = new CreatorDotH();
        private readonly CreatorDotC makerC = new CreatorDotC();
        private readonly short fullPackSize = 8; // Basic functions struct newEmpty + new + show + showall
        private readonly short packsDone = 0;
        private bool locked = false;
        private readonly string appVersion = "Version [2.7.0.0]";

        #endregion

        #region Builder

        /// <summary>
        /// Basic constructor of the form.
        /// </summary>
        public StructureBuilder() {

            InitializeComponent();
            textBoxes = new List<TextBox>();
            textChars = new List<TextBox>();
            threads = new List<Thread>();
            myDelPlayer = new MyPlayer();
            musicHandler += MyPlayerMainMusic;
            myStructure = new Structure();
            myParameter = new Parameter();
            makerC = new CreatorDotC();
            makerH = new CreatorDotH();
        }

        #endregion

        #region LoadEvent

        /// <summary>
        /// EventHandler of Load Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StructureBuilder_Load(object sender, EventArgs e) {
            Hide();
            try {
                FormInitialState();
                lblNewVersion.Text = appVersion;
                //this.PlayMusic(this.loginSound);
                FrmWelcome welcome = new FrmWelcome();
                if (welcome.ShowDialog() == DialogResult.OK) {
                    PlayMusic(loginSound);
                }

            } catch (NoSoundFoundException ns) {
                frmException fe = new frmException(ns) {
                    Location = Location
                };
                fe.ShowDialog();
            }
        }

        /// <summary>
        /// Sets the form in the initial state.
        /// </summary>
        private void FormInitialState() {
            btnCreate.Enabled = false;
            cmbFirstParamType.SelectedIndex = 0;
            cmbSecondParamType.SelectedIndex = 0;
            cmbThirdParamType.SelectedIndex = 0;
            cmbFourthParamType.SelectedIndex = 0;
            cmbFifthParamType.SelectedIndex = 0;
            cmbSixthParamType.SelectedIndex = 0;
            LockOrUnlockComponents(grpSecondParam, false);
            LockOrUnlockComponents(chkThirdParam, grpThirdParam, false);
            LockOrUnlockComponents(chkFourthParam, grpFourthParam, false);
            LockOrUnlockComponents(chkFifthParam, grpFifthParam, false);
            LockOrUnlockComponents(chkSixthParam, grpSixthParam, false);
        }

        #endregion

        #region MyPlayer

        /// <summary>
        /// Plays a sound in another thread.
        /// </summary>
        /// <param name="musicName">Name of the sound.</param>
        private void PlayMusic(object musicName) {
            Thread playerThread = new Thread(new ParameterizedThreadStart(MyPlayerMainMusic));
            playerThread.Start((object)musicName);
            threads.Add(playerThread);
        }

        /// <summary>
        /// Creates a soundPlayer and plays the sound.
        /// </summary>
        /// <param name="soundName">Name of the sound to play.</param>
        private void MyPlayerMainMusic(object soundName) {
            if (InvokeRequired) {
                BeginInvoke(
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
            LockOrUnlockComponents(checkbox, unlocked);
            LockOrUnlockComponents(box, unlocked);
        }


        /// <summary>
        /// Event manager of the second checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSecondParam_CheckedChanged(object sender, EventArgs e) {
            if (chkSecondParam.Checked is true) {
                LockOrUnlockComponents(chkThirdParam, grpSecondParam, true);
                PlayMusic(checkBox2Sound);
            } else {
                PlayMusic(unCheckBoxSound);
                LockOrUnlockComponents(chkThirdParam, grpSecondParam, false);
                LockOrUnlockComponents(chkFourthParam, grpThirdParam, false);
                LockOrUnlockComponents(grpFourthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the third checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkThirdParam_CheckedChanged(object sender, EventArgs e) {
            if (chkThirdParam.Checked is true) {
                LockOrUnlockComponents(chkFourthParam, grpThirdParam, true);
                PlayMusic(checkBox3Sound);
            } else {
                PlayMusic(unCheckBoxSound);
                LockOrUnlockComponents(chkFourthParam, grpThirdParam, false);
                LockOrUnlockComponents(chkFifthParam, grpFourthParam, false);
                LockOrUnlockComponents(grpSixthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the fourth checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFourthParam_CheckedChanged(object sender, EventArgs e) {
            if (chkFourthParam.Checked is true) {
                LockOrUnlockComponents(chkFifthParam, grpFourthParam, true);
                PlayMusic(checkBox4Sound);
            } else {
                PlayMusic(unCheckBoxSound);
                LockOrUnlockComponents(chkFifthParam, grpFourthParam, false);
                LockOrUnlockComponents(grpSixthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the Fifth checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFifthParam_CheckedChanged(object sender, EventArgs e) {
            if (chkFifthParam.Checked is true) {
                LockOrUnlockComponents(chkSixthParam, grpFifthParam, true);
                PlayMusic(checkBox2Sound);
            } else {
                PlayMusic(unCheckBoxSound);
                LockOrUnlockComponents(chkSixthParam, grpFifthParam, false);
            }
        }

        /// <summary>
        /// Event manager of the Sixth checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSixthParam_CheckedChanged(object sender, EventArgs e) {
            if (chkSixthParam.Checked is true) {
                LockOrUnlockComponents(grpSixthParam, true);
                PlayMusic(checkBox3Sound);
            } else {
                PlayMusic(unCheckBoxSound);
                LockOrUnlockComponents(grpSixthParam, false);
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
            if (String.IsNullOrWhiteSpace(txtFirstParamName.Text) || String.IsNullOrWhiteSpace(txtFirstParamLength.Text)) {
                //MessageBox.Show("There are at least one field empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new EmptyFieldException("You have at least one field Empty.");
            } else {
                //Set structure
                myStructure.StructureName = txtStructureName.Text.RemoveSpaces();
                myStructure.AliasName = myStructure.StructureName;
                myStructure.FinalStructureName = myStructure.AliasName;

                // Set parameter
                myParameter = CreateParameter(myStructure, myParameter, txtFirstParamName.Text.RemoveSpaces(), cmbFirstParamType.SelectedItem.ToString(), txtFirstParamLength.Text.RemoveSpaces());
                // add to list
                if (!(myStructure + myParameter)) {
                    MessageBox.Show($"An Error has occurred adding the 1st parameter: {myParameter.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    if (cmbFirstParamType.SelectedItem.ToString().Equals("char")) {
                        textChars.Add(txtFirstParamLength);
                    }
                    textBoxes.Add(txtFirstParamName);
                    textBoxes.Add(txtStructureName);
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
                        textBoxes.Add(txtName);
                        if (cmbType.SelectedItem.ToString().Equals("char")) {
                            textChars.Add(txtLength);
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
            if (String.IsNullOrWhiteSpace(txtStructureName.Text)) {
                MessageBox.Show("The structure name is empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    if (CreateStructure()) {
                        CreateParameterFromForm("2nd", myStructure, chkSecondParam, cmbSecondParamType, txtSecondParamName, txtSecondParamLength);
                        CreateParameterFromForm("3rd", myStructure, chkThirdParam, cmbThirdParamType, txtThirdParamName, txtThirdParamLength);
                        CreateParameterFromForm("4th", myStructure, chkFourthParam, cmbFourthParamType, txtFourthParamName, txtFourthParamLength);
                        CreateParameterFromForm("5th", myStructure, chkFifthParam, cmbFifthParamType, txtFifthParamName, txtFifthParamLength);
                        CreateParameterFromForm("6th", myStructure, chkSixthParam, cmbSixthParamType, txtSixthParamName, txtSixthParamLength);

                        if (!Directory.Exists(PathOfFiles)) {
                            Directory.CreateDirectory(PathOfFiles);
                        }

                        CreateFiles(PathOfFiles, myStructure, packsDone, fullPackSize);
                        PlayMusic(successSound);
                        FrmSuccess fs = new FrmSuccess("your desktop 'C_Files' directory") {
                            Location = Location
                        };
                        fs.ShowDialog();
                        LockForm(locked);
                        ClearTextBoxes();
                        myStructure.ListParamaters.Clear();
                    }
                } catch (Exception ex) {
                    try {
                        PlayMusic(errorSound);
                        frmException fe = new frmException(ex) {
                            Location = Location
                        };
                        fe.ShowDialog();
                    } catch (NoSoundFoundException ns) {
                        frmException fe = new frmException(ns) {
                            Location = Location
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
            SetTextBoxByComboBox(cmbFirstParamType, txtFirstParamLength);
        }

        /// <summary>
        /// Event handler of the second comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSecondParamType_SelectedIndexChanged(object sender, EventArgs e) {
            SetTextBoxByComboBox(cmbSecondParamType, txtSecondParamLength);
        }

        /// <summary>
        /// Event handler of the third comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbThirdParamType_SelectedIndexChanged(object sender, EventArgs e) {
            SetTextBoxByComboBox(cmbThirdParamType, txtThirdParamLength);
        }

        /// <summary>
        /// Event handler of the fourth comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFourthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            SetTextBoxByComboBox(cmbFourthParamType, txtFourthParamLength);
        }

        /// <summary>
        /// Event handler of the fifth comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFifthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            SetTextBoxByComboBox(cmbFifthParamType, txtFifthParamLength);
        }

        /// <summary>
        /// Event handler of the sixth comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSixthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            SetTextBoxByComboBox(cmbSixthParamType, txtSixthParamLength);
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
                PlayMusic(lockOnSound);
                locked = !locked;
                btnLock.ImageIndex = 1;
                grpAllComponents.Enabled = false;
                btnCreate.Enabled = true;
            } else {
                PlayMusic(lockOffSound);
                locked = !locked;
                btnLock.ImageIndex = 0;
                grpAllComponents.Enabled = true;
                btnCreate.Enabled = false;
            }
        }

        /// <summary>
        /// EventHandler of the lock button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, EventArgs e) {
            try {
                LockForm(locked);
            } catch (NoSoundFoundException ns) {
                frmException fe = new frmException(ns) {
                    Location = Location
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
                if (textBoxes.Count > 0) {
                    foreach (TextBox item in textBoxes) {
                        item.Text = "";
                    }
                    textBoxes.Clear();
                }
                if (textChars.Count > 0) {
                    foreach (TextBox item in textChars) {
                        item.Text = "1";
                    }
                    textChars.Clear();
                }
            } catch (Exception e) {
                frmException fe = new frmException(e) {
                    Location = Location
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
            foreach (Thread item in threads) {
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
                StopThreads();
                musicHandler -= MyPlayerMainMusic;
                Dispose();
            } else {
                e.Cancel = true;
            }
        }

        #endregion

    }
}
