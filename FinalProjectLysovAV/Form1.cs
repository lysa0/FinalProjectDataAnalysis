using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectLysovAV
{
    public partial class Form1 : Form
    {
        MyDataSet data=null;
        List<int>[] activeVariables1 = new List<int>[8] { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() }, 
                    activeVariables2 = new List<int>[8] { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() };
        int activAnalys;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            data = new MyDataSet(pathDataset.Text);
            data.Import();
            numVariables.Text = data.GetNumVars().ToString();
            numReports1.Text = data.GetNumRecords().ToString();
            variables.Items.Clear();
            variables1.Items.Clear();
            variables2.Items.Clear();
            for (int i = 0; i < data.GetNumVars(); i++) { 
                variables.Items.Add(data.GetNameVars()[i]);
                variables1.Items.Add(data.GetNameVars()[i]);
                variables2.Items.Add(data.GetNameVars()[i]);
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void checkBoxKorAn_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 7;
            checkBoxKorExl.Checked = false;
            checkBoxKorExl.Enabled = checkBoxKorAn.Checked;
            if (checkBoxKorAn.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void checkBoxRegrAn_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 6;
            checkBoxRegExl.Checked = false;
            checkBoxRegExl.Enabled = checkBoxRegrAn.Checked;
            if (checkBoxRegrAn.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.Show();
                variables2.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }

        }

        private void createReport_Click(object sender, EventArgs e)
        {
            if (data == null)
            {
                errorLabel.Text = "Необходимо импортировать данные!!!";
                return;
            }
            List<Boolean> analysis = new List<Boolean> { checkBoxDiscr.Checked, 
                checkBoxHi.Checked, checkBoxTt.Checked, checkBoxTMW.Checked, checkBoxANOVA.Checked, checkBoxClast.Checked, 
                checkBoxRegrAn.Checked, checkBoxRegExl.Checked, 
                checkBoxKorAn.Checked, checkBoxKorExl.Checked};

            errorLabel.Text = data.Export(analysis, reportName.Text, authorName.Text, dateTimePicker.Text, activeVariables1, activeVariables2);
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void selectVariables_Click(object sender, EventArgs e)
        {
            if (variables1.CheckedIndices.Count == 0)
            {
                errorLabel.Text = "Необходимо выбрать переменные!!!";
                return;
            }
            errorLabel.Text = "";
            List<int> tmpActiveVariables1 = new List<int>();
            for (int i = 0; i < variables1.CheckedIndices.Count; i++)
            {
                tmpActiveVariables1.Add(variables1.CheckedIndices[i]);
            }
            activeVariables1[activAnalys] = tmpActiveVariables1;
            List<int> tmpActiveVariables2 = new List<int>();
            for (int i = 0; i < variables2.CheckedIndices.Count; i++)
            {
                tmpActiveVariables2.Add(variables2.CheckedIndices[i]);
            }
            activeVariables2[activAnalys] = tmpActiveVariables2;
            variables1.Hide();
            variables2.Hide();
            selectVariables.Hide();
        }

        private void checkBoxDiscr_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 0;
            if (checkBoxDiscr.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                 variables1.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void checkBoxHi_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 1;
            if (checkBoxHi.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.Show();
                variables2.Show();
                selectVariables.Show();

            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void checkBoxTt_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 2;
            if (checkBoxTt.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.ClearSelected();
                variables1.Show();
                variables2.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void checkBoxTMW_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 3;
            if (checkBoxTMW.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.Show();
                variables2.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void checkBoxANOVA_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 4;
            if (checkBoxANOVA.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.Show();
                variables2.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void checkBoxClast_CheckedChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                return;
            }
            activAnalys = 5;
            if (checkBoxClast.Checked)
            {
                for (int i = 0; i < data.GetNumVars(); i++)
                {
                    variables1.SetItemChecked(i, false);
                    variables2.SetItemChecked(i, false);
                }
                for (int i = 0; i < activeVariables1[activAnalys].Count; i++)
                    variables1.SetItemChecked(activeVariables1[activAnalys][i], true);
                for (int i = 0; i < activeVariables2[activAnalys].Count; i++)
                    variables2.SetItemChecked(activeVariables2[activAnalys][i], true);
                variables1.Show();
                selectVariables.Show();
            }
            else
            {
                variables1.Hide();
                variables2.Hide();
                selectVariables.Hide();
            }
        }

        private void variables1_ItemCheck(object sender, EventArgs e)
        {
            for (int i = 0; i < variables1.CheckedIndices.Count; i++)
            {
                variables2.SetItemChecked(variables1.CheckedIndices[i], false); 
            }
        }
        private void variables2_ItemCheck(object sender, EventArgs e)
        {
            for (int i = 0; i < variables2.CheckedIndices.Count; i++)
            {
                variables1.SetItemChecked(variables2.CheckedIndices[i], false);
            }
            
        }
        private void checkBoxKorPl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (data == null)
            {
                errorLabel.Text =  "Необходимо импортировать данные!!!";
                return;
            }
            errorLabel.Text = "";
            label3.Text = data.usingDB(pathDataset.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (label3.Text == "")
            {
                errorLabel.Text = "Необходимо загрузить данные!!!";
                return;
            }
            DataSet selectData = data.UsingQuery(textBox1.Text);
            try
            {
                dataGridView1.DataSource = selectData.Tables["Full"].DefaultView;
            }
            catch
            {

            }
            label4.Text = (dataGridView1.RowCount-1).ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pathDataset_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
