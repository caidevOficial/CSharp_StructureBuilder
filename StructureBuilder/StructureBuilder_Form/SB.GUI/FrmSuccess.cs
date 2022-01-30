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
    public partial class FrmSuccess : Form {

        private readonly string path;

        #region Builder

        public FrmSuccess() {
            InitializeComponent();
        }

        public FrmSuccess(string path) : this() {
            this.path = path;
        }

        #endregion

        #region TimerEvent

        /// <summary>
        /// EventHandler of time Fade In.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrFadeIn_Tick(object sender, EventArgs e) {
            if (Opacity < 1) {
                Opacity += 0.05;
            }
            if (pbProgress.Value < 100) {
                pbProgress.Value += 1;
                pbProgress.Text = pbProgress.Value.ToString();
            } else {
                tmrFadeIn.Stop();
                tmrFadeOut.Start();

            }
        }

        /// <summary>
        /// EventHandler of time Fade Out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrFadeOut_Tick(object sender, EventArgs e) {
            if (Opacity > 0) {
                Opacity -= 0.1;
            }
            if (pbProgress.Value < 100) {
                pbProgress.Value += 1;
                pbProgress.Text = pbProgress.Value.ToString();
            }
            if (Opacity == 0) {
                Close();
            }
        }

        #endregion

        #region LoadEvent

        /// <summary>
        /// EventHandler of Load Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSuccess_Load(object sender, EventArgs e) {
            lblSuccess.Text = $"Files Created, check in {path}";
            Opacity = 0.0;
            pbProgress.Value = 0;
            pbProgress.Minimum = 0;
            pbProgress.Maximum = 100;
            tmrFadeIn.Start();
        }

        #endregion
    }
}
