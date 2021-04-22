
using Entities.Entities;
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

        public StructureBuilder()
        {
            InitializeComponent();
            myStructure = new Structure();
            myParameter = new Parameter();
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtStructureName.Text))
            {
                myStructure.StructureName = txtStructureName.Text;
                myStructure.AliasName = myStructure.StructureName;
                myStructure.FinalStructureName = myStructure.AliasName;
            }

            if (!String.IsNullOrWhiteSpace(txtFirstParamName.Text) && !String.IsNullOrWhiteSpace(txtFirstParamLenght.Text))
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
                //myStructure = myStructure.ListParamaters.Add(myParameter);
            }

            if (chkSecondParam.Enabled && !String.IsNullOrWhiteSpace(txtSecondParamName.Text) && !String.IsNullOrWhiteSpace(txtSecondParamLenght.Text))
            {
                myParameter.NameParameter = txtSecondParamName.Text;
            }
        }
    }
}
