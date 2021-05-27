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
            if (this.Opacity < 1)
                this.Opacity += 0.05;
            if (this.cpbProgress.Value < 100) {
                this.cpbProgress.Value += 1;
                this.cpbProgress.Text = this.cpbProgress.Value.ToString();
            } else {
                tmFadeIn.Stop();
                tmFadeOut.Start();
            }
        }

        /// <summary>
        /// Timer EventHandler of the fade-out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmFadeOut_Tick(object sender, EventArgs e) {
            if (this.Opacity > 0)
                this.Opacity -= 0.1;
            if (this.cpbProgress.Value < 100) {
                this.cpbProgress.Value += 1;
                this.cpbProgress.Text = this.cpbProgress.Value.ToString();
            }

            if (this.Opacity == 0) {
                this.Close();
            }
        }

        #endregion

        #region LoadEvent

        /// <summary>
        /// LoadEventHandler of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWelcome_Load(object sender, EventArgs e) {
            this.Opacity = 0.0;
            this.cpbProgress.Value = 0;
            this.cpbProgress.Minimum = 0;
            this.cpbProgress.Maximum = 100;
            tmFadeIn.Start();
        }

        #endregion
    }
}
