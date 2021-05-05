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

using AuxiliarClass;
using Entities;
using FileBuilders;
using SBExceptions;
using System;
using System.Media;
using System.Windows.Forms;

namespace StructureBuilder_Form {
    public partial class StructureBuilder : Form {

        #region AudioPaths

        private static string pathToMusic = $"{Environment.CurrentDirectory}/Sounds";
        private string lockOn = $"{pathToMusic}/Lock.wav";
        private string lockOff = $"{pathToMusic}/Unlock.wav";
        private string errorSound = $"{pathToMusic}/Exception.wav";
        private string success = $"{pathToMusic}/Create.wav";

        private readonly SoundPlayer myPlayer = new SoundPlayer();

        #endregion

        #region Attributes

        private static Structure myStructure;
        private Parameter myParameter;
        private CreatorDotH makerH = new CreatorDotH();
        private CreatorDotC makerC = new CreatorDotC();
        private short fullPackSize = 8; // Basic functions struct newEmpty + new + show + showall
        private short packsDone = 0;
        private bool locked = false;
        private string appVersion = "Version [2.5.1.1]";

        #endregion

        #region Builder

        public StructureBuilder() {
            InitializeComponent();
            myStructure = new Structure();
            myParameter = new Parameter();
            makerC = new CreatorDotC();
            makerH = new CreatorDotH();
            grpSecondParam.Enabled = false;
            grpThirdParam.Enabled = false;
            grpFourthParam.Enabled = false;
            chkThirdParam.Enabled = false;
            chkFourthParam.Enabled = false;
            btnCreate.Enabled = false;
            cmbFirstParamType.SelectedIndex = 0;
            cmbSecondParamType.SelectedIndex = 0;
            cmbThirdParamType.SelectedIndex = 0;
            cmbFourthParamType.SelectedIndex = 0;
            lblNewVersion.Text = appVersion;
            try {
                MyPlayer(success);
            } catch (NoSoundFoundException ns) {
                frmException fe = new frmException(ns);
                fe.Location = this.Location;
                fe.ShowDialog();
            }
        }

        #endregion

        #region MyPlayer

        /// <summary>
        /// Little soundPlayer of the app.
        /// </summary>
        /// <param name="soundPath"></param>
        private void MyPlayer(string soundPath) {
            myPlayer.SoundLocation = soundPath;
            try {
                myPlayer.Play();
            } catch (Exception e) {
                throw new NoSoundFoundException("No Sound Folder in the App's Directory.", e);
            }
        }

        #endregion

        #region CheckButtons

        private void chkSecondParam_CheckedChanged(object sender, EventArgs e) {
            if (chkSecondParam.Checked is true) {
                grpSecondParam.Enabled = true;
                chkThirdParam.Enabled = true;
            } else {
                grpSecondParam.Enabled = false;
                grpThirdParam.Enabled = false;
                grpFourthParam.Enabled = false;

                chkThirdParam.Enabled = false;
                chkFourthParam.Enabled = false;
            }
        }

        private void chkThirdParam_CheckedChanged(object sender, EventArgs e) {
            if (chkThirdParam.Checked is true) {
                grpThirdParam.Enabled = true;
                chkFourthParam.Enabled = true;
            } else {
                grpThirdParam.Enabled = false;
                grpFourthParam.Enabled = false;

                chkFourthParam.Enabled = false;
            }
        }

        private void chkFourthParam_CheckedChanged(object sender, EventArgs e) {
            if (chkFourthParam.Checked is true) {
                grpFourthParam.Enabled = true;
            } else {
                grpFourthParam.Enabled = false;
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
            if (String.IsNullOrWhiteSpace(txtFirstParamName.Text) || String.IsNullOrWhiteSpace(txtFirstParamLenght.Text)) {
                //MessageBox.Show("There are at least one field empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new EmptyFieldException("You have at least one field Empty.");
            } else {
                //Set structure
                myStructure.StructureName = txtStructureName.Text.Trim().Replace(" ", "");
                myStructure.AliasName = myStructure.StructureName;
                myStructure.FinalStructureName = myStructure.AliasName;

                // Set parameter
                myParameter = CreateParameter(myStructure, myParameter, txtFirstParamName.Text.Trim().Replace(" ", ""), cmbFirstParamType.SelectedItem.ToString(), txtFirstParamLenght.Text.Trim().Replace(" ", ""));
                // add to list
                if (!(myStructure + myParameter))
                    MessageBox.Show($"An Error has occurred adding the 1st parameter: {myParameter.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }
        }

        #endregion

        #region CreateFile

        private void CreateFiles(Structure myStructure, short packsDone, short fullPackSize) {
            packsDone = makerH.FileMaker(myStructure, packsDone, fullPackSize);
            packsDone = makerC.FileMaker(myStructure, packsDone, fullPackSize);
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);
        }

        #endregion

        #region ButtonCreate

        private void btnCreate_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(txtStructureName.Text)) {
                MessageBox.Show("The structure name is empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    if (CreateStructure()) {
                        if (chkSecondParam.Checked) {
                            Parameter secondPa = new Parameter();
                            if (!String.IsNullOrWhiteSpace(txtSecondParamName.Text) && !String.IsNullOrWhiteSpace(txtSecondParamLenght.Text)) {
                                secondPa = CreateParameter(myStructure, secondPa, txtSecondParamName.Text, cmbSecondParamType.SelectedItem.ToString(), txtSecondParamLenght.Text);
                                if (!(myStructure + secondPa)) {
                                    MessageBox.Show($"An Error has occurred adding the 2nd parameter: {secondPa.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            } else {
                                throw new EmptyFieldException("You have at least one field Empty.");
                            }
                        }

                        if (chkThirdParam.Checked) {
                            Parameter ThirdPa = new Parameter();
                            if (!String.IsNullOrWhiteSpace(txtThirdParamName.Text) && !String.IsNullOrWhiteSpace(txtThirdParamLenght.Text)) {
                                ThirdPa = CreateParameter(myStructure, ThirdPa, txtThirdParamName.Text, cmbThirdParamType.SelectedItem.ToString(), txtThirdParamLenght.Text);
                                if (!(myStructure + ThirdPa)) {
                                    MessageBox.Show($"An Error has occurred adding the 3rd parameter: {ThirdPa.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            } else {
                                throw new EmptyFieldException("You have at least one field Empty.");
                            }
                        }

                        if (chkFourthParam.Checked) {
                            Parameter fourthPa = new Parameter();
                            if (!String.IsNullOrWhiteSpace(txtFourthParamName.Text) && !String.IsNullOrWhiteSpace(txtFourthParamLenght.Text)) {
                                fourthPa = CreateParameter(myStructure, fourthPa, txtFourthParamName.Text, cmbFourthParamType.SelectedItem.ToString(), txtFourthParamLenght.Text);
                                if (!(myStructure + fourthPa)) {
                                    MessageBox.Show($"An Error has occurred adding the 4th parameter: {fourthPa.NameParameter}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            } else {
                                throw new EmptyFieldException("You have at least one field Empty.");
                            }
                        }

                        CreateFiles(myStructure, packsDone, fullPackSize);
                        MyPlayer(success);
                        MessageBox.Show($"Structure {myStructure.FinalStructureName} Created Successfully, Congratulations!\n" +
                            $"Check the files created in the directory of this App.\n\n" +
                            $"Now you have to come with me, where? Back to the future!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        myStructure.ListParamaters.Clear();
                    }
                } catch (Exception ex) {
                    try {
                        MyPlayer(errorSound);
                        frmException fe = new frmException(ex);
                        fe.Location = this.Location;
                        fe.ShowDialog();
                    } catch (NoSoundFoundException ns) {
                        frmException fe = new frmException(ns);
                        fe.Location = this.Location;
                        fe.ShowDialog();
                    }
                }
            }
        }

        #endregion

        #region ComboBoxEvents

        private void cmbFirstParamType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbFirstParamType.SelectedItem.Equals("char")) {
                txtFirstParamLenght.Enabled = true;
            } else {
                txtFirstParamLenght.Text = "1";
                txtFirstParamLenght.Enabled = false;
            }
        }

        private void cmbSecondParamType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbSecondParamType.SelectedItem.Equals("char")) {
                txtSecondParamLenght.Enabled = true;
            } else {
                txtSecondParamLenght.Text = "1";
                txtSecondParamLenght.Enabled = false;
            }
        }

        private void cmbThirdParamType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbThirdParamType.SelectedItem.Equals("char")) {
                txtThirdParamLenght.Enabled = true;
            } else {
                txtThirdParamLenght.Text = "1";
                txtThirdParamLenght.Enabled = false;
            }
        }

        private void cmbFourthParamType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbFourthParamType.SelectedItem.Equals("char")) {
                txtFourthParamLenght.Enabled = true;
            } else {
                txtFourthParamLenght.Text = "1";
                txtFourthParamLenght.Enabled = false;
            }
        }

        #endregion

        #region LockEvent

        /// <summary>
        /// EventHandler of lock button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, EventArgs e) {
            try {
                if (!locked) {
                    MyPlayer(lockOn);
                    locked = !locked;
                    btnLock.ImageIndex = 1;
                    grpAllComponents.Enabled = false;
                    btnCreate.Enabled = true;
                } else {
                    MyPlayer(lockOff);
                    locked = !locked;
                    btnLock.ImageIndex = 0;
                    grpAllComponents.Enabled = true;
                    btnCreate.Enabled = false;
                }
            } catch (NoSoundFoundException ns) {
                frmException fe = new frmException(ns);
                fe.Location = this.Location;
                fe.ShowDialog();
            }
        }

        #endregion

        #region CloseEvent

        /// <summary>
        /// Send a messageBox to the screen asking if the user want to quit the app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StructureBuilder_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show("Do you want to quit?", "Choose Wisely", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                Dispose();
            } else {
                e.Cancel = true;
            }
        }

        #endregion
    }
}
