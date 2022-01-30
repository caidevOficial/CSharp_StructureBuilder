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
using System.Windows.Forms;

namespace StructureBuilder_Form {
    public partial class FrmWelcome : Form {

        #region Buidler

        /// <summary>
        /// Basic constructor of the form.
        /// </summary>
        public FrmWelcome() {
            InitializeComponent();
        }

        #endregion

        #region TimerEvent

        /// <summary>
        /// Timer EventHandler of the fade-in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmFadeIn_Tick(object sender, EventArgs e) {
            try {
                if (Opacity < 1)
                    Opacity += 0.05;
                if (cpbProgress.Value < 100) {
                    cpbProgress.Value += 1;
                    cpbProgress.Text = cpbProgress.Value.ToString();
                } else {
                    tmFadeIn.Stop();
                    tmFadeOut.Start();
                }
            } catch (Exception ns) {
                frmException fe = new frmException(ns) {
                    Location = Location
                };
                fe.ShowDialog();
            }
        }

        /// <summary>
        /// Timer EventHandler of the fade-out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmFadeOut_Tick(object sender, EventArgs e) {
            if (Opacity > 0)
                Opacity -= 0.1;
            if (cpbProgress.Value < 100) {
                cpbProgress.Value += 1;
                cpbProgress.Text = cpbProgress.Value.ToString();
            }

            if (Opacity == 0) {
                Close();
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

        private void UpdateDialogResult() {
            if (InvokeRequired) {
                BeginInvoke(
                    (MethodInvoker)delegate {
                        DialogResult = DialogResult.OK;
                    });
            } else {
                DialogResult = DialogResult.OK;
            }
        }

        #region LoadEvent

        /// <summary>
        /// LoadEventHandler of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWelcome_Load(object sender, EventArgs e) {
            Opacity = 0.0;
            cpbProgress.Value = 0;
            cpbProgress.Minimum = 0;
            cpbProgress.Maximum = 100;
            //this.DialogResult = DialogResult.OK;
            tmFadeIn.Start();
        }

        #endregion
    }
}
