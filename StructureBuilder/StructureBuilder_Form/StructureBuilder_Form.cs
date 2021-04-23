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

using Entities.Entities;
using Entities.FileBuilders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StructureBuilder_Form
{
    public partial class StructureBuilder : Form
    {
        private Structure myStructure;
        private Parameter myParameter;
        private CreatorDotH makerH = new CreatorDotH();
        private CreatorDotC makerC = new CreatorDotC();

        #region Builder

        public StructureBuilder()
        {
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
            cmbFirstParamType.SelectedIndex = 0;
            cmbSecondParamType.SelectedIndex = 0;
            cmbThirdParamType.SelectedIndex = 0;
            cmbFourthParamType.SelectedIndex = 0;
        }

        #endregion

        #region CheckButtons

        private void chkSecondParam_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSecondParam.Checked is true)
            {
                grpSecondParam.Enabled = true;
                chkThirdParam.Enabled = true;
            }
            else
            {
                grpSecondParam.Enabled = false;
                grpThirdParam.Enabled = false;
                grpFourthParam.Enabled = false;

                chkThirdParam.Enabled = false;
                chkFourthParam.Enabled = false;
            }
        }

        private void chkThirdParam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThirdParam.Checked is true)
            {
                grpThirdParam.Enabled = true;
                chkFourthParam.Enabled = true;
            }
            else
            {
                grpThirdParam.Enabled = false;
                grpFourthParam.Enabled = false;

                chkFourthParam.Enabled = false;
            }
        }

        private void chkFourthParam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFourthParam.Checked is true)
            {
                grpFourthParam.Enabled = true;
            }
            else
            {
                grpFourthParam.Enabled = false;
            }
        }

        #endregion

        #region CreateParameters

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtStructureName.Text))
            {
                MessageBox.Show("The structure name is empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                myStructure.StructureName = txtStructureName.Text;
                myStructure.AliasName = myStructure.StructureName;
                myStructure.FinalStructureName = myStructure.AliasName;

                if (String.IsNullOrWhiteSpace(txtFirstParamName.Text) || String.IsNullOrWhiteSpace(txtFirstParamLenght.Text))
                {
                    MessageBox.Show("The Parameter name is empty, fix that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    myParameter.NameParameter = txtSecondParamName.Text;

                    if (int.TryParse(txtFirstParamLenght.Text, out int parameterLength))
                    {
                        myParameter.LengthParameter = parameterLength;
                    }
                    else
                    {
                        myParameter.LengthParameter = 1;
                    }
                    myParameter.AliasNameParameter = txtFirstParamName.Text;
                    myParameter.TypeParameter = cmbFirstParamType.Text;
                    //TODO: continue this
                    if (chkSecondParam.Enabled && !String.IsNullOrWhiteSpace(txtSecondParamName.Text) && !String.IsNullOrWhiteSpace(txtSecondParamLenght.Text))
                    {
                        myParameter.NameParameter = txtSecondParamName.Text;
                    }
                }
            }
        }

        #endregion
    }
}
