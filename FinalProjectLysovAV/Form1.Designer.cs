namespace FinalProjectLysovAV
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.importData = new System.Windows.Forms.Button();
            this.pathDataset = new System.Windows.Forms.TextBox();
            this.authorName = new System.Windows.Forms.TextBox();
            this.reportName = new System.Windows.Forms.TextBox();
            this.printFIO = new System.Windows.Forms.Label();
            this.printNameReport = new System.Windows.Forms.Label();
            this.variablesLabel = new System.Windows.Forms.Label();
            this.numReports = new System.Windows.Forms.Label();
            this.numVariables = new System.Windows.Forms.Label();
            this.numReports1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.setDataset = new System.Windows.Forms.Label();
            this.methAnalysis = new System.Windows.Forms.GroupBox();
            this.selectVariables = new System.Windows.Forms.Button();
            this.variables2 = new System.Windows.Forms.CheckedListBox();
            this.variables1 = new System.Windows.Forms.CheckedListBox();
            this.checkBoxKorExl = new System.Windows.Forms.CheckBox();
            this.checkBoxRegExl = new System.Windows.Forms.CheckBox();
            this.checkBoxClast = new System.Windows.Forms.CheckBox();
            this.checkBoxRegrAn = new System.Windows.Forms.CheckBox();
            this.checkBoxANOVA = new System.Windows.Forms.CheckBox();
            this.checkBoxHi = new System.Windows.Forms.CheckBox();
            this.checkBoxTMW = new System.Windows.Forms.CheckBox();
            this.checkBoxKorAn = new System.Windows.Forms.CheckBox();
            this.checkBoxTt = new System.Windows.Forms.CheckBox();
            this.checkBoxDiscr = new System.Windows.Forms.CheckBox();
            this.variables = new System.Windows.Forms.ListBox();
            this.listVariables = new System.Windows.Forms.Label();
            this.createReport = new System.Windows.Forms.Button();
            this.printDateTime = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.methAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // importData
            // 
            this.importData.Location = new System.Drawing.Point(35, 177);
            this.importData.Name = "importData";
            this.importData.Size = new System.Drawing.Size(90, 23);
            this.importData.TabIndex = 0;
            this.importData.Text = "Импорт данных";
            this.importData.UseVisualStyleBackColor = true;
            this.importData.Click += new System.EventHandler(this.button1_Click);
            // 
            // pathDataset
            // 
            this.pathDataset.Location = new System.Drawing.Point(12, 151);
            this.pathDataset.Name = "pathDataset";
            this.pathDataset.Size = new System.Drawing.Size(139, 20);
            this.pathDataset.TabIndex = 4;
            this.pathDataset.Text = "../../data/DataSetLA.xls";
            this.pathDataset.TextChanged += new System.EventHandler(this.pathDataset_TextChanged);
            // 
            // authorName
            // 
            this.authorName.Location = new System.Drawing.Point(12, 28);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(139, 20);
            this.authorName.TabIndex = 10;
            // 
            // reportName
            // 
            this.reportName.Location = new System.Drawing.Point(12, 67);
            this.reportName.Name = "reportName";
            this.reportName.Size = new System.Drawing.Size(139, 20);
            this.reportName.TabIndex = 11;
            // 
            // printFIO
            // 
            this.printFIO.AutoSize = true;
            this.printFIO.Location = new System.Drawing.Point(9, 12);
            this.printFIO.Name = "printFIO";
            this.printFIO.Size = new System.Drawing.Size(82, 13);
            this.printFIO.TabIndex = 12;
            this.printFIO.Text = "Введите ФИО:";
            // 
            // printNameReport
            // 
            this.printNameReport.AutoSize = true;
            this.printNameReport.Location = new System.Drawing.Point(9, 51);
            this.printNameReport.Name = "printNameReport";
            this.printNameReport.Size = new System.Drawing.Size(139, 13);
            this.printNameReport.TabIndex = 13;
            this.printNameReport.Text = "Введите название отчета:";
            // 
            // variablesLabel
            // 
            this.variablesLabel.AutoSize = true;
            this.variablesLabel.Location = new System.Drawing.Point(12, 215);
            this.variablesLabel.Name = "variablesLabel";
            this.variablesLabel.Size = new System.Drawing.Size(75, 13);
            this.variablesLabel.TabIndex = 14;
            this.variablesLabel.Text = "Переменных:";
            // 
            // numReports
            // 
            this.numReports.AutoSize = true;
            this.numReports.Location = new System.Drawing.Point(12, 228);
            this.numReports.Name = "numReports";
            this.numReports.Size = new System.Drawing.Size(53, 13);
            this.numReports.TabIndex = 15;
            this.numReports.Text = "Записей:";
            // 
            // numVariables
            // 
            this.numVariables.AutoSize = true;
            this.numVariables.Location = new System.Drawing.Point(93, 215);
            this.numVariables.Name = "numVariables";
            this.numVariables.Size = new System.Drawing.Size(23, 13);
            this.numVariables.TabIndex = 16;
            this.numVariables.Text = "null";
            // 
            // numReports1
            // 
            this.numReports1.AutoSize = true;
            this.numReports1.Location = new System.Drawing.Point(93, 228);
            this.numReports1.Name = "numReports1";
            this.numReports1.Size = new System.Drawing.Size(23, 13);
            this.numReports1.TabIndex = 17;
            this.numReports1.Text = "null";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 105);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // setDataset
            // 
            this.setDataset.AutoSize = true;
            this.setDataset.Location = new System.Drawing.Point(13, 131);
            this.setDataset.Name = "setDataset";
            this.setDataset.Size = new System.Drawing.Size(103, 13);
            this.setDataset.TabIndex = 18;
            this.setDataset.Text = "Выберите датасет:";
            // 
            // methAnalysis
            // 
            this.methAnalysis.BackColor = System.Drawing.SystemColors.Window;
            this.methAnalysis.Controls.Add(this.selectVariables);
            this.methAnalysis.Controls.Add(this.variables2);
            this.methAnalysis.Controls.Add(this.variables1);
            this.methAnalysis.Controls.Add(this.checkBoxKorExl);
            this.methAnalysis.Controls.Add(this.checkBoxRegExl);
            this.methAnalysis.Controls.Add(this.checkBoxClast);
            this.methAnalysis.Controls.Add(this.checkBoxRegrAn);
            this.methAnalysis.Controls.Add(this.checkBoxANOVA);
            this.methAnalysis.Controls.Add(this.checkBoxHi);
            this.methAnalysis.Controls.Add(this.checkBoxTMW);
            this.methAnalysis.Controls.Add(this.checkBoxKorAn);
            this.methAnalysis.Controls.Add(this.checkBoxTt);
            this.methAnalysis.Controls.Add(this.checkBoxDiscr);
            this.methAnalysis.ForeColor = System.Drawing.Color.Black;
            this.methAnalysis.Location = new System.Drawing.Point(157, 12);
            this.methAnalysis.Name = "methAnalysis";
            this.methAnalysis.Size = new System.Drawing.Size(356, 258);
            this.methAnalysis.TabIndex = 6;
            this.methAnalysis.TabStop = false;
            this.methAnalysis.Text = "Виды анализа для отчета";
            // 
            // selectVariables
            // 
            this.selectVariables.Location = new System.Drawing.Point(305, 72);
            this.selectVariables.Name = "selectVariables";
            this.selectVariables.Size = new System.Drawing.Size(40, 36);
            this.selectVariables.TabIndex = 20;
            this.selectVariables.Text = "OK";
            this.selectVariables.UseVisualStyleBackColor = true;
            this.selectVariables.Click += new System.EventHandler(this.selectVariables_Click);
            this.selectVariables.Hide();

            // 
            // variables2
            // 
            this.variables2.CheckOnClick = true;
            this.variables2.FormattingEnabled = true;
            this.variables2.Location = new System.Drawing.Point(182, 161);
            this.variables2.Name = "variables2";
            this.variables2.Size = new System.Drawing.Size(117, 79);
            this.variables2.TabIndex = 19;
            this.variables2.SelectedIndexChanged += new System.EventHandler(this.variables2_ItemCheck);
            this.variables2.Hide();
            // 
            // variables1
            // 
            this.variables1.CheckOnClick = true;
            this.variables1.FormattingEnabled = true;
            this.variables1.Location = new System.Drawing.Point(182, 46);
            this.variables1.Name = "variables1";
            this.variables1.Size = new System.Drawing.Size(117, 79);
            this.variables1.TabIndex = 18;
            this.variables1.SelectedIndexChanged += new System.EventHandler(this.variables1_ItemCheck);
            this.variables1.Hide();

            // 
            // checkBoxKorExl
            // 
            this.checkBoxKorExl.AutoSize = true;
            this.checkBoxKorExl.Enabled = false;
            this.checkBoxKorExl.Location = new System.Drawing.Point(32, 235);
            this.checkBoxKorExl.Name = "checkBoxKorExl";
            this.checkBoxKorExl.Size = new System.Drawing.Size(106, 17);
            this.checkBoxKorExl.TabIndex = 17;
            this.checkBoxKorExl.Text = "Создать в Excel";
            this.checkBoxKorExl.UseVisualStyleBackColor = true;
            // 
            // checkBoxRegExl
            // 
            this.checkBoxRegExl.AutoSize = true;
            this.checkBoxRegExl.Enabled = false;
            this.checkBoxRegExl.Location = new System.Drawing.Point(32, 189);
            this.checkBoxRegExl.Name = "checkBoxRegExl";
            this.checkBoxRegExl.Size = new System.Drawing.Size(106, 17);
            this.checkBoxRegExl.TabIndex = 16;
            this.checkBoxRegExl.Text = "Создать в Excel";
            this.checkBoxRegExl.UseVisualStyleBackColor = true;
            // 
            // checkBoxClast
            // 
            this.checkBoxClast.AutoSize = true;
            this.checkBoxClast.Location = new System.Drawing.Point(15, 142);
            this.checkBoxClast.Name = "checkBoxClast";
            this.checkBoxClast.Size = new System.Drawing.Size(104, 17);
            this.checkBoxClast.TabIndex = 15;
            this.checkBoxClast.Text = "Кластеризация";
            this.checkBoxClast.UseVisualStyleBackColor = true;
            this.checkBoxClast.CheckedChanged += new System.EventHandler(this.checkBoxClast_CheckedChanged);
            // 
            // checkBoxRegrAn
            // 
            this.checkBoxRegrAn.AutoSize = true;
            this.checkBoxRegrAn.Location = new System.Drawing.Point(16, 165);
            this.checkBoxRegrAn.Name = "checkBoxRegrAn";
            this.checkBoxRegrAn.Size = new System.Drawing.Size(145, 17);
            this.checkBoxRegrAn.TabIndex = 14;
            this.checkBoxRegrAn.Text = "Регрессионный анализ";
            this.checkBoxRegrAn.UseVisualStyleBackColor = true;
            this.checkBoxRegrAn.CheckedChanged += new System.EventHandler(this.checkBoxRegrAn_CheckedChanged);
            // 
            // checkBoxANOVA
            // 
            this.checkBoxANOVA.AutoSize = true;
            this.checkBoxANOVA.Location = new System.Drawing.Point(15, 119);
            this.checkBoxANOVA.Name = "checkBoxANOVA";
            this.checkBoxANOVA.Size = new System.Drawing.Size(63, 17);
            this.checkBoxANOVA.TabIndex = 11;
            this.checkBoxANOVA.Text = "ANOVA";
            this.checkBoxANOVA.UseVisualStyleBackColor = true;
            this.checkBoxANOVA.CheckedChanged += new System.EventHandler(this.checkBoxANOVA_CheckedChanged);
            // 
            // checkBoxHi
            // 
            this.checkBoxHi.AutoSize = true;
            this.checkBoxHi.Location = new System.Drawing.Point(15, 49);
            this.checkBoxHi.Name = "checkBoxHi";
            this.checkBoxHi.Size = new System.Drawing.Size(89, 17);
            this.checkBoxHi.TabIndex = 10;
            this.checkBoxHi.Text = "Хи - квадрат";
            this.checkBoxHi.UseVisualStyleBackColor = true;
            this.checkBoxHi.CheckedChanged += new System.EventHandler(this.checkBoxHi_CheckedChanged);
            // 
            // checkBoxTMW
            // 
            this.checkBoxTMW.AutoSize = true;
            this.checkBoxTMW.Location = new System.Drawing.Point(15, 95);
            this.checkBoxTMW.Name = "checkBoxTMW";
            this.checkBoxTMW.Size = new System.Drawing.Size(126, 17);
            this.checkBoxTMW.TabIndex = 9;
            this.checkBoxTMW.Text = "Тест Манна - Уитни";
            this.checkBoxTMW.UseVisualStyleBackColor = true;
            this.checkBoxTMW.CheckedChanged += new System.EventHandler(this.checkBoxTMW_CheckedChanged);
            // 
            // checkBoxKorAn
            // 
            this.checkBoxKorAn.AutoSize = true;
            this.checkBoxKorAn.Location = new System.Drawing.Point(15, 212);
            this.checkBoxKorAn.Name = "checkBoxKorAn";
            this.checkBoxKorAn.Size = new System.Drawing.Size(152, 17);
            this.checkBoxKorAn.TabIndex = 12;
            this.checkBoxKorAn.Text = "Корреляционный анализ";
            this.checkBoxKorAn.UseVisualStyleBackColor = true;
            this.checkBoxKorAn.CheckedChanged += new System.EventHandler(this.checkBoxKorAn_CheckedChanged);
            // 
            // checkBoxTt
            // 
            this.checkBoxTt.AutoSize = true;
            this.checkBoxTt.Location = new System.Drawing.Point(15, 72);
            this.checkBoxTt.Name = "checkBoxTt";
            this.checkBoxTt.Size = new System.Drawing.Size(59, 17);
            this.checkBoxTt.TabIndex = 8;
            this.checkBoxTt.Text = "T - test";
            this.checkBoxTt.UseVisualStyleBackColor = true;
            this.checkBoxTt.CheckedChanged += new System.EventHandler(this.checkBoxTt_CheckedChanged);
            // 
            // checkBoxDiscr
            // 
            this.checkBoxDiscr.AutoSize = true;
            this.checkBoxDiscr.Location = new System.Drawing.Point(15, 26);
            this.checkBoxDiscr.Name = "checkBoxDiscr";
            this.checkBoxDiscr.Size = new System.Drawing.Size(161, 17);
            this.checkBoxDiscr.TabIndex = 7;
            this.checkBoxDiscr.Text = "Описательные статистики";
            this.checkBoxDiscr.UseVisualStyleBackColor = true;
            this.checkBoxDiscr.CheckedChanged += new System.EventHandler(this.checkBoxDiscr_CheckedChanged);
            // 
            // variables
            // 
            this.variables.FormattingEnabled = true;
            this.variables.Location = new System.Drawing.Point(12, 268);
            this.variables.Name = "variables";
            this.variables.Size = new System.Drawing.Size(139, 82);
            this.variables.TabIndex = 19;
            // 
            // listVariables
            // 
            this.listVariables.AutoSize = true;
            this.listVariables.Location = new System.Drawing.Point(12, 247);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(76, 13);
            this.listVariables.TabIndex = 20;
            this.listVariables.Text = "Переменные:";
            // 
            // createReport
            // 
            this.createReport.Location = new System.Drawing.Point(245, 276);
            this.createReport.Name = "createReport";
            this.createReport.Size = new System.Drawing.Size(158, 24);
            this.createReport.TabIndex = 21;
            this.createReport.Text = "Создать отчет";
            this.createReport.UseVisualStyleBackColor = true;
            this.createReport.Click += new System.EventHandler(this.createReport_Click);
            // 
            // printDateTime
            // 
            this.printDateTime.AutoSize = true;
            this.printDateTime.Location = new System.Drawing.Point(9, 90);
            this.printDateTime.Name = "printDateTime";
            this.printDateTime.Size = new System.Drawing.Size(80, 13);
            this.printDateTime.TabIndex = 22;
            this.printDateTime.Text = "Укажите дату:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(543, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(410, 249);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(644, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Выполнить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(792, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Всего записей: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(792, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Записей по запросу: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(913, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(913, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 29;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(543, 315);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.Text = "SELECT * FROM[Full] WHERE GLEASON = 6 AND RACE = 2";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Ошибка: ";
            // 
            // label6
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(242, 318);
            this.errorLabel.Name = "label6";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 458);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.printDateTime);
            this.Controls.Add(this.createReport);
            this.Controls.Add(this.listVariables);
            this.Controls.Add(this.variables);
            this.Controls.Add(this.methAnalysis);
            this.Controls.Add(this.setDataset);
            this.Controls.Add(this.numReports1);
            this.Controls.Add(this.numVariables);
            this.Controls.Add(this.numReports);
            this.Controls.Add(this.variablesLabel);
            this.Controls.Add(this.printNameReport);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.printFIO);
            this.Controls.Add(this.reportName);
            this.Controls.Add(this.authorName);
            this.Controls.Add(this.pathDataset);
            this.Controls.Add(this.importData);
            this.Name = "Form1";
            this.Text = "MainWindow";
            this.methAnalysis.ResumeLayout(false);
            this.methAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importData;
        private System.Windows.Forms.TextBox pathDataset;
        private System.Windows.Forms.TextBox authorName;
        private System.Windows.Forms.TextBox reportName;
        private System.Windows.Forms.Label printFIO;
        private System.Windows.Forms.Label printNameReport;
        private System.Windows.Forms.Label variablesLabel;
        private System.Windows.Forms.Label numReports;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label numVariables;
        private System.Windows.Forms.Label numReports1;
        private System.Windows.Forms.Label setDataset;
        private System.Windows.Forms.GroupBox methAnalysis;
        private System.Windows.Forms.CheckBox checkBoxClast;
        private System.Windows.Forms.CheckBox checkBoxRegrAn;
        private System.Windows.Forms.CheckBox checkBoxANOVA;
        private System.Windows.Forms.CheckBox checkBoxHi;
        private System.Windows.Forms.CheckBox checkBoxTMW;
        private System.Windows.Forms.CheckBox checkBoxTt;
        private System.Windows.Forms.CheckBox checkBoxDiscr;
        private System.Windows.Forms.CheckBox checkBoxKorAn;
        private System.Windows.Forms.CheckBox checkBoxKorExl;
        private System.Windows.Forms.CheckBox checkBoxRegExl;
        private System.Windows.Forms.ListBox variables;
        private System.Windows.Forms.Label listVariables;
        private System.Windows.Forms.Button createReport;
        private System.Windows.Forms.Label printDateTime;
        private System.Windows.Forms.CheckedListBox variables2;
        private System.Windows.Forms.CheckedListBox variables1;
        private System.Windows.Forms.Button selectVariables;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label errorLabel;
    }
}

