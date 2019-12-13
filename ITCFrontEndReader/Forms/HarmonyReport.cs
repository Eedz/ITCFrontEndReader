using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace ITCFrontEndReader
{
    enum HarmonyType { RefVarList, WaveVarList }

    public partial class HarmonyReport : Form
    {

        HarmonyType ReportType;
        ITCLib.HarmonyReport HR;
       

        public HarmonyReport()
        {
            InitializeComponent();
            
            cboVarNames.DataSource = DBAction.GetAllRefVars();
            lstPrefixes.DataSource = DBAction.GetVariablePrefixes();

            ITCLib.HarmonyReport HR = new ITCLib.HarmonyReport();

            
            ReportType = HarmonyType.RefVarList;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {

        }

        private void cmdWordDocument_Click(object sender, EventArgs e)
        {
            if (ReportType == HarmonyType.RefVarList)
                ClassicHarmony();
                
        }

        private void ClassicHarmony()
        {
            List<VariableName> vars = new List<VariableName>();

            // for each refVarName, get all the varnames with that refVarName
            foreach (string s in lstSelVar.Items)
            {
                List<VariableName> vlist = new List<VariableName>();

                //vlist.AddRange(DBAction.GetVarNamesByRef(s))
            }
        }


        private void cmdOnscreen_Click(object sender, EventArgs e)
        {

        }

        private void cmdAddVar_Click(object sender, EventArgs e)
        {
            if (cboVarNames.SelectedItem == null) return;

            lstSelVar.Items.Add(cboVarNames.SelectedItem);
            cboVarNames.SelectedIndex++;
        }

        private void cmdRemoveVar_Click(object sender, EventArgs e)
        {
            if (lstSelVar.SelectedItem == null) return;

            int sel = lstSelVar.SelectedIndex; // retain last selected index

            lstSelVar.Items.Remove(lstSelVar.SelectedItem); // remove selected item
           
            // reselect the last selected index, or the last item if we removed the last item
            if (lstSelVar.Items.Count >0)
                if (sel >= lstSelVar.Items.Count)
                    lstSelVar.SelectedIndex = lstSelVar.Items.Count-1;
                else
                    lstSelVar.SelectedIndex = sel;

        }
    }
}
