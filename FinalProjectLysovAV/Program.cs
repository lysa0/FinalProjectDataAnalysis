using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using RDotNet;
using ADOX;

namespace FinalProjectLysovAV
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    class MyDataSet
    {
        private string tmpFolder = Application.StartupPath + "\\tmp\\";
        private string fileName = "";
        private string reportName = "Отчет.docx";
        private string tableName = "Анализы.xlsx";
        private int numVars=-1;
        private int numRecords=-1;
        private Word.Range wrange;
        private int iter;
        string latexText = "";
        List<string> nameVars = new List<string>();
        private Excel.Application exc;
        private REngine engine = REngine.GetInstance();
        private Word.Document worddoc;
        private Word.Application wordapp;
        private Excel.Application exapp;
        private Excel.Workbook exbook;
        OleDbConnection connection = new OleDbConnection();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        public MyDataSet(string fileName)
        {
            this.fileName = fileName;
        }
        public int GetNumVars()
        {
            return numVars;
        }
        public int GetNumRecords()
        {
            return numRecords;
        }
        public List<string> GetNameVars()
        {
            return nameVars;
        }
        public void Import()
        {
            connection.Close();
            if (!(Directory.Exists(tmpFolder))) Directory.CreateDirectory(tmpFolder);
            engine.Initialize();
            engine.Evaluate("library(readxl)");
            engine.Evaluate("dataset <- read_excel(\"" + fileName + "\")");
            numRecords = (int)(engine.Evaluate("length(dataset[,1])").AsInteger()[0]);
            numVars = engine.Evaluate("names(dataset)").AsVector().Length;
            for (int i = 0; i < numVars; i++)
                nameVars.Add(engine.Evaluate("names(dataset)").AsVector()[i].ToString());
        }
        public void WordIntro(string nameReport, string author, string dateTime)
        {
            wordapp = new Word.Application();
            wordapp.Visible = true;
            worddoc = wordapp.Documents.Add();
            worddoc.SaveAs(tmpFolder + reportName);
            engine.Initialize();
            engine.Evaluate("library(readxl)");
            engine.Evaluate("library(Hmisc)");
            DataFrame dataset = engine.Evaluate("dataset").AsDataFrame();
            for (iter = 1; iter++ <= 10; worddoc.Paragraphs.Add()) ;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 36;
            wrange.Font.Bold = 1;
            if (nameReport == "")
            {
                wrange.Text = "Тема отчета не задана!";
            }
            else
            {
                wrange.Text = nameReport;
            }
            string title = wrange.Text;
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            for (iter = 11; iter++ <= 12; worddoc.Paragraphs.Add()) ;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 24;
            wrange.Font.Bold = 0;
            if (author == "")
                wrange.Text = "Автор не задан!";
            else
                wrange.Text = author;
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 20;
            wrange.Font.Bold = 0;
            wrange.Text = dateTime;
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.InsertBreak();
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 24;
            wrange.Font.Bold = 1;
            wrange.Text = "Описание данных:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
            wrange.Text = "Для анализа были взяты данные из открытых источников. " +
                                            "Данные содержат " + numRecords.ToString() + " записей и " + numVars.ToString() + " переменных.";
        }
        private void LatexIntro(string nameReport, string author, string dateTime)
        {
            latexText = "\n\\documentclass[10pt,pdf,hyperref={unicode}, aspectratio=169]{beamer}" +
                                    "\n\\usepackage{lmodern}" +
                                    "\n\\usepackage[T2A]{fontenc}" +
                                    "\n\\usepackage[utf8]{inputenc}" +
                                    "\n\\usepackage[russian]{babel}" +
                                    "\n\\setbeamertemplate{navigation symbols}{ }" +
                                    "\n\\usepackage{lmodern}" +
                                    "\n\\usepackage{textcomp}" +
                                    "\n\\usepackage{concrete}" +
                                    "\n \\usepackage{graphicx}" +
                                    "\n\\usepackage{amssymb}" +
                                    "\n\\usepackage{amsthm}" +
                                    "\n\\usepackage{subfigure}" +
                                    "\n\\usepackage{colortbl}" +
                                    "\n\\usepackage{bullcntr}" +
                                    "\n\\useoutertheme{infolines}" +
                                    "\n\\useinnertheme{circles}" +
                                    "\n\\title[" + nameReport + "]{" + nameReport + "}" +
                                    "\n\\author[" + author + "]{ Выполнил:\\\\" + author + "} " +
                                    "\n\\date[" + dateTime + "]{Санкт-Петербург \\\\" + dateTime + "}" +
                                    "\n\\begin{document}" +
                                    "\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                                    "\n\\frame{\\titlepage}" +
                                    "\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                                    "\n\\section{Описание данных}" +
                                    "\n\\begin{frame}\\frametitle{Выбранные данные}" +
                                     "\n        \\begin{itemize}" +
                                     "\n            \\item" +
                                     "\n                Данные брались из   ." +
                                     "\n            \\item" +
                                     "\n                Данные содержат " + numRecords + " записей и " + numVars + " переменных." +
                                     "\n        \\end{itemize}" +
                                    "\n\\end{frame}" +
                                    "\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
        }
        private void DiscriptiveStatistics(List<int> activeVariables)
        {
            Header();
            wrange.Text = "Описательные статистики:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
            int count = 1;
            latexText += "\n\\begin{frame}\\frametitle{Описательные статистики}" +
                                     "\n\\begin{table}[h]" +
                                     "\n\\caption{Указанные средние значения, значения медианы и моды свидетельствуют о несмещенности данных}" +
                                     "\n\\begin{center}" +
                                    "\n\\begin{tabular}{|c|r|r|r|r|r|r|}" +
                                    "\n\\hline" +
                                    "\n Переменная & Минимум & Максимум & Медиана & Среднее & 1-й Квартиль & 3-й Квартиль\\\\\\hline";
            for (int k = 0; k < activeVariables.Count; k++)
            {
                int j = activeVariables[k];
                var summar = engine.Evaluate("summary(dataset$" + nameVars[j] + ")").AsNumeric();
                wrange.Text += count++ + ") Для переменной \"" + nameVars[j] + "\": \n        Минимум = " + string.Join(" ", summar[0])
                    + "; Максимум = " + string.Join(" ", summar[5]) + "; Медиана = " + string.Join(" ", summar[2])
                        + "; Среднее = " + string.Join(" ", summar[3]) + ";\n        1-й Квартиль = " + string.Join(" ", summar[1]) +
                        "; 3-й Квартиль = " + string.Join(" ", summar[4]) + ";";
                latexText += "\n " + nameVars[j] + " & " + summar[0] + " & " + summar[5] + " & " + summar[2] + " & " + summar[3] + " & " + summar[1] + " & " + summar[4] + "\\\\\\hline";
            }
            for (int st = iter; iter++ <= st + activeVariables.Count * 2; worddoc.Paragraphs.Add()) ;
            Conclusion();
            latexText += "\n\\end{tabular}\\label{tb:1}" +
                        "\n\\end{center}" +
                        "\n\\end{table}" +
                        "\n\\end{frame}";
        }
        private void HiSquare(List<int> activeVariables1, List<int> activeVariables2)
        {
            Header();
            wrange.Text = "Hi-square:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
            wrange.Text = "";
            latexText += "\n\\section{Hi-square}" +
                            "\n\\begin{frame}\\frametitle{Хи-квадрат}" +
                                     "\n\\begin{itemize}\n\\item";
            for (int k = 0; k < activeVariables1.Count(); k++)
            {
                wrange.Text += "\n" + (k + 1) + ". Рассматривается зависимость \"" + nameVars[activeVariables1[k]] + "\" от:";
                for (int l = 0; l < activeVariables2.Count(); l++)
                {
                    GenericVector XSZ = engine.Evaluate("Xsquared <- chisq.test(table(dataset$" + nameVars[activeVariables2[l]] + ",dataset$" + nameVars[activeVariables1[k]] + "))").AsList();
                    double xsSZ = XSZ["statistic"].AsNumeric()[0];
                    double pxSZ = engine.Evaluate("Xsquared$p.value").AsNumeric()[0];
                    wrange.Text += "\n\t" + (l + 1) + ") \"" + nameVars[activeVariables2[l]] + "\":  X-squared = " + Math.Round(xsSZ, 2).ToString()
                        + ";  p-value = " + Math.Round(pxSZ, 3).ToString() + ";";
                }
            }
            wrange.Font.Bold = 0;
            for (int st = iter; iter++ <= st + activeVariables1.Count() * activeVariables2.Count(); worddoc.Paragraphs.Add()) ;
            Conclusion();
            latexText += "\n\\end{itemize}" +
                        "\n\\end{frame}";
        }
        private void TTest(List<int> activeVariables1, List<int> activeVariables2)
        {
            Header();
            wrange.Text = "T-TEST:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
            latexText += "\n\\section{T-test}" +
                        "\n\\begin{frame}\\frametitle{Т-тест}" +
                         "\n\\begin{itemize}\n\\item";
            for (int k = 0; k < activeVariables1.Count(); k++)
            {
                wrange.Text += "\n" + (k + 1) + ". Проведем t-test для \"" + nameVars[activeVariables1[k]] + "\" и:";
                for (int l = 0; l < activeVariables2.Count(); l++)
                {
                    GenericVector testResAge = engine.Evaluate("ttest <- t.test(dataset$" + nameVars[activeVariables2[l]] + " ~ dataset$" + nameVars[activeVariables1[k]] + ")").AsList();
                    double tAge = testResAge["statistic"].AsNumeric()[0];
                    double pAge = engine.Evaluate("ttest$p.value").AsNumeric()[0];
                    wrange.Text += "\n\t" + (l + 1) + ") \"" + nameVars[activeVariables2[l]] + "\":  t-value = " + Math.Round(tAge, 2).ToString()
                        + ";  p-value = " + Math.Round(pAge, 3).ToString() + ";";
                }
            }
            wrange.Font.Bold = 0;
            for (int st = iter; iter++ <= st + activeVariables1.Count() * activeVariables2.Count(); worddoc.Paragraphs.Add()) ;
            Conclusion();
            latexText += "\n\\end{itemize}" +
            "\n\\end{frame}";
        }
        private void MannWitny(List<int> activeVariables1, List<int> activeVariables2)
        {
            Header();
            wrange.Text = "Mann-Witny:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            latexText += "\n\\section{MannWitny}" +
            "\n\\begin{frame}\\frametitle{Тест Манна-Уитни}" +
             "\n\\begin{itemize}\n\\item";
            for (int k = 0; k < activeVariables1.Count(); k++)
            {
                wrange.Text += "\n" + (k + 1) + ". Рассматривается зависимость \"" + nameVars[activeVariables1[k]] + "\" от:";
                for (int l = 0; l < activeVariables2.Count(); l++)
                {
                    GenericVector MWtAge = engine.Evaluate("mannWetney <- wilcox.test(dataset$" + nameVars[activeVariables2[l]] + " ~ dataset$" + nameVars[activeVariables1[k]] + ", paired = FALSE)").AsList();
                    double wAge = MWtAge["statistic"].AsNumeric()[0];
                    double pwAge = engine.Evaluate("mannWetney$p.value").AsNumeric()[0];
                    wrange.Text += "\n\t" + (l + 1) + ") \"" + nameVars[activeVariables2[l]] + "\":  W = " + Math.Round(wAge, 2).ToString()
                + ";  p-value = " + Math.Round(pwAge, 3).ToString() + ";";
                }
            }
            wrange.Font.Bold = 0;
            for (int st = iter; iter++ <= st + activeVariables1.Count() * activeVariables2.Count(); worddoc.Paragraphs.Add()) ;
            Conclusion();
            latexText += "\n\\end{itemize}" +
                    "\n\\end{frame}";
        }
        private void ANOVA(List<int> activeVariables1, List<int> activeVariables2)
        {
            Header();
            wrange.Text = "ANOVA:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
            latexText += "\n\\section{Anova}" +
                        "\n\\begin{frame}\\frametitle{Тест Anova}" +
                         "\n\\begin{itemize}\n\\item";
            for (int k = 0; k < activeVariables1.Count(); k++)
            {
                wrange.Text += "\n" + (k + 1) + ". Рассматривается зависимость \"" + nameVars[activeVariables1[k]] + "\" от:";
                for (int l = 0; l < activeVariables2.Count(); l++)
                {
                    engine.Evaluate("aov <- anova(lm(dataset$" + nameVars[activeVariables2[l]] + " ~ dataset$" + nameVars[activeVariables1[k]] + "))");
                    double anoAgeP = engine.Evaluate("aov[rownames(aov)[1],colnames(aov)[5]]").AsNumeric()[0];
                    double anoAgeSq = engine.Evaluate("aov[rownames(aov)[1],colnames(aov)[3]]").AsNumeric()[0];
                    wrange.Text += "\n\t" + (l + 1) + ") \"" + nameVars[activeVariables2[l]] + "\":  Mean_Sq = " + Math.Round(anoAgeSq, 2).ToString()
                + ";  p-value = " + Math.Round(anoAgeP, 3).ToString() + ";";
                }
            }
            wrange.Font.Bold = 0;
            for (int st = iter; iter++ <= st + activeVariables1.Count() * (activeVariables2.Count()+1); worddoc.Paragraphs.Add()) ;
            Conclusion();
            latexText += "\n\\end{itemize}" +
        "\n\\end{frame}";
        }
        private void Clustering(List<int> activeVariables)
        {
            latexText += "\n\\section{Clustering}";
            Header();
            wrange.Text = "Кластеризация:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
           // ClusteringMethKMean(activeVariables);
            ClusteringMethHClust();
            ClusteringMethWard();
            Conclusion();
        }
        private void ClusteringMethKMean(List<int> activeVariables)
        {

            string clust_kmean = tmpFolder + "clust_kmean.png";
            CharacterVector fileNameVector = engine.CreateCharacterVector(new[] { clust_kmean });
            engine.SetSymbol("clust_kmean", fileNameVector);
            engine.Evaluate("library(cluster)");
            engine.Evaluate("library(ggplot2)");
            string clusVar = "";
            for (int k = 0; k < activeVariables.Count; k++)
                clusVar += ((1 + activeVariables[k]).ToString()) + ",";
            clusVar = clusVar.Substring(0, clusVar.Length - 1);
            engine.Evaluate("corV <- c(" + clusVar + ")");
            engine.Evaluate("kclust <- kmeans(as.matrix(dataset[, corV]), centers = 9)");
            engine.Evaluate("png(filename=clust_kmean, width=6, height=6, units='in', res=100)");
            engine.Evaluate("clusplot(dataset[,corV], kclust$cluster, main='K-Mean', xlab = \"\", ylab =  \"Height\" , color=TRUE, shade=TRUE, labels=2, lines=0)");
            engine.Evaluate("dev.off()");
            worddoc.InlineShapes.AddPicture(clust_kmean, false, true, wrange);
            latexText += "\n\\begin{frame}\\frametitle{K-Mean}" +
                                    "\n     \\begin{figure}" +
                                    "\n         \\centering" +
                                    "\n             \\includegraphics[scale=0.48]{clust_kmean.png}" +
                                    "\n             \\caption{K-Mean}" +
                                    "\n     \\end{figure}" +
                                    "\n\\end{frame}";

        }
        private void ClusteringMethHClust()
        {
            string clust_singl = tmpFolder + "clust_singl.png";
            CharacterVector fileNameVector = engine.CreateCharacterVector(new[] { clust_singl });
            engine.SetSymbol("clust_singl", fileNameVector);
            engine.Evaluate("hcl <- hclust(dist(dataset), method = \"single\")");
            engine.Evaluate("png(filename=clust_singl, width=6, height=6, units='in', res=100)");
            engine.Evaluate("clusterCut <- cutree(hcl, h=150)");
            engine.Evaluate("plot(hcl, xlab = \"\", ylab =  \"Height\" , main='HClust')");
            engine.Evaluate("rect.hclust(hcl, k = 3, border = 2:5)");
            engine.Evaluate("dev.off()");
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            worddoc.InlineShapes.AddPicture(clust_singl, false, true, wrange);
            latexText += "\n\\begin{frame}\\frametitle{K-Mean}" +
                                    "\n     \\begin{figure}" +
                                    "\n         \\centering" +
                                    "\n             \\includegraphics[scale=0.48]{clust_singl.png}" +
                                    "\n             \\caption{HClust}" +
                                    "\n     \\end{figure}" +
                                    "\n\\end{frame}";
        }
        private void ClusteringMethWard()
        {
            string clust_ward = tmpFolder + "clust_ward.png";
            CharacterVector fileNameVector = engine.CreateCharacterVector(new[] { clust_ward });
            engine.SetSymbol("clust_ward", fileNameVector);
            engine.Evaluate("hcl <- hclust(dist(dataset), method = \"ward.D2\")");
            engine.Evaluate("png(filename=clust_ward, width=6, height=6, units='in', res=100)");
            engine.Evaluate("clusterCut <- cutree(hcl, h=3000)");
            engine.Evaluate("plot(hcl, xlab = \"\", ylab =  \"Height\", main='WARD')");
            engine.Evaluate("rect.hclust(hcl, k = 4, border = 2:5)");
            engine.Evaluate("dev.off()");
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            worddoc.InlineShapes.AddPicture(clust_ward, false, true, wrange);
            latexText += "\n\\begin{frame}\\frametitle{Ward}" +
                                    "\n     \\begin{figure}" +
                                    "\n         \\centering" +
                                    "\n             \\includegraphics[scale=0.48]{clust_ward.png}" +
                                    "\n             \\caption{Ward}" +
                                    "\n     \\end{figure}" +
                                    "\n\\end{frame}";
        }
        private void Regression(List<int> activeVariables1, List<int> activeVariables2, bool regExl)
        {
            latexText += "\n\\section{Regression}" +
            "\n\\begin{frame}\\frametitle{Регрессионный анализ}" +
             "\n\\begin{itemize}\n\\item";
            Header();
            wrange.Text = "Регрессионный анализ:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 0;
            for (int k = 0; k < activeVariables1.Count; k++)
            {
                string regVars = "", regVarsForm = "";
                for (int l = 0; l < activeVariables2.Count; l++)
                {
                    regVars += nameVars[activeVariables2[l]] + '+';
                    regVarsForm += "\"" + nameVars[activeVariables2[l]] + "\", ";
                }
                regVars = regVars.Substring(0, regVars.Length - 1);
                regVarsForm = regVarsForm.Substring(0, regVarsForm.Length - 1) + ".";
                engine.Evaluate("reg <- summary(lm(formula = " + nameVars[activeVariables1[k]] + " ~ " + regVars + ", data = dataset))");
                var call = engine.Evaluate("reg$r.squared").AsNumeric();
                engine.Evaluate("coef<-reg$coefficients").AsList();
                List<RDotNet.NumericVector> cCoef = new List<RDotNet.NumericVector>();
                List<RDotNet.NumericVector> pCoef = new List<RDotNet.NumericVector>();
                for (int l = 0; l <= activeVariables2.Count; l++)
                {
                    cCoef.Add(engine.Evaluate("coef[rownames(coef)[" + (l + 1).ToString() + "],colnames(coef)[1]]").AsNumeric());
                    pCoef.Add(engine.Evaluate("coef[rownames(coef)[" + (l + 1).ToString() + "],colnames(coef)[4]]").AsNumeric());
                }
                wrange.Text = "Рассматривается зависимость:\n \"" + nameVars[activeVariables1[k]] + "\" от " + regVarsForm + "\n"
                    + "R-squared = " + Math.Round(call[0], 3).ToString() + ";";
                wrange.Text += "\n" + 0 + ") Constant (Intercept):  Estimate = " + Math.Round(cCoef[0][0], 3).ToString()
                    + ";  p-value = " + Math.Round(pCoef[0][0], 3).ToString() + ";";
                for (int l = 1; l <= activeVariables2.Count; l++)
                {
                    wrange.Text += "\n" + l + ") \"" + nameVars[activeVariables2[l - 1]] + "\":  Estimate = " + Math.Round(cCoef[l][0], 3).ToString()
                    + ";  p-value = " + Math.Round(pCoef[l][0], 3).ToString() + ";";
                }
                for (int st = iter; iter++ <= activeVariables2.Count + st; worddoc.Paragraphs.Add()) ;
                worddoc.Paragraphs.Add();
                wrange = worddoc.Paragraphs[iter++].Range;
            }
            if (regExl)
            {
                RegExl(activeVariables2);
            }
            Conclusion();
            latexText += "\n\\end{itemize}" +
                "\n\\end{frame}";
        }
        private void Correlation(List<int> activeVariables1, bool corExc)
        {
            latexText += "\n\\section{Correlation}" +
                        "\n\\begin{frame}\\frametitle{Корреляционный анализ}" +
                        "\n\\begin{itemize}\n\\item";
            Header();
            wrange.Text = "Корреляционный анализ:";
            wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            string CorVar = "";
            for (int k = 0; k < activeVariables1.Count; k++)
                CorVar += (activeVariables1[k] + 1).ToString() + ",";
            CorVar = CorVar.Substring(0, CorVar.Length - 1);
            engine.Evaluate("corV <- c(" + CorVar + ")");
            engine.Evaluate("rc <- rcorr(as.matrix(dataset[, corV]))");
            engine.Evaluate("corP <- rc$P").AsList();
            engine.Evaluate("corR <- rc$r").AsList();
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Bold = 0;
            Word.Table wordtable = worddoc.Tables.Add(wrange, activeVariables1.Count + 1, activeVariables1.Count + 1);
            wordtable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordtable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleDashSmallGap;
            int n = wordtable.Rows.Count;
            int m = wordtable.Columns.Count;
            Word.Range wordcellrange;
            wrange.Font.Size = 12;
            string varName = "";
            for (int k = 0; k < activeVariables1.Count; k++)
            {
                varName = nameVars[activeVariables1[k]];
                wordcellrange = wordtable.Cell(1, k + 2).Range;
                wordcellrange.Text = varName;
                wordcellrange = wordtable.Cell(k + 2, 1).Range;
                wordcellrange.Text = varName;
            }
            for (int k = 2; k <= activeVariables1.Count + 1; k++)
                for (int l = 2; l <= activeVariables1.Count + 1; l++)
                {
                    wordcellrange = wordtable.Cell(k, l).Range;
                    wordcellrange.Text = "p-val. = " + Math.Round(engine.Evaluate("corP[rownames(corP)[" + (k - 1) + "],colnames(corP)[" + (l - 1) + "]]").AsNumeric()[0], 3).ToString()
                           + "\nr. = " + Math.Round(engine.Evaluate("corR[rownames(corR)[" + (k - 1) + "],colnames(corR)[" + (l - 1) + "]]").AsNumeric()[0], 3).ToString();
                }
            wrange.Font.Bold = 0;
            object unit;
            object extend;
            worddoc.Paragraphs.Add();
            unit = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            wordapp.Selection.EndKey(ref unit, ref extend);
            wrange = wordapp.Selection.Range;
            wrange.Font.Size = 14;
            wrange.Font.Bold = 1;
            wrange.Text = "Вывод:";
            worddoc.Paragraphs.Add();
            wrange.Font.Size = 14;
            wrange.Font.Bold = 1;
            unit = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            wordapp.Selection.EndKey(ref unit, ref extend);
            wrange = wordapp.Selection.Range;
            wrange.Text = "\n\n";
            wrange.Font.Size = 14;
            if (corExc)
            {
                CorExl(activeVariables1);
            }
            latexText += "\n\\end{itemize}" +
    "\n\\end{frame}";
        }
        private void Header()
        {
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Size = 24;
            wrange.Font.Bold = 1;
        }
        private void Conclusion()
        {
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Bold = 1;
            wrange.Text = "Вывод:";
            worddoc.Paragraphs.Add();
            wrange = worddoc.Paragraphs[iter++].Range;
            wrange.Font.Bold = 0;
            wrange.Text = "\n\n";
            //wrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

        }
        private void WordOutro()
        {

        }
        private void LatexOutro()
        {
            latexText += "\n\\end{document}";
            File.WriteAllText(tmpFolder + "\\Презентация.tex", latexText);
        }
        public string Export(List<Boolean> analysis, string nameReport, string author, string dateTime, List<int>[] activeVariables1, List<int>[] activeVariables2)
        {
            if (worddoc!=null)
                try
                {
                    worddoc.Close();
                }
                catch
                {
                    Console.WriteLine("Ошибочка");
                }
            if (exbook!=null)
                try
                {
                    exbook.Close();
                }
                catch { };
            DirectoryInfo dirInfo = new DirectoryInfo(tmpFolder);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch
                {

                }
            }
            WordIntro(nameReport, author, dateTime);
            LatexIntro(nameReport, author, dateTime);
            if (analysis[0])
            {
                try
                {
                    DiscriptiveStatistics(activeVariables1[0]);
                }
                catch
                {
                    return "Исправьте описательные статистики!!!";
                }
            }
            if (analysis[1])
            {
                try 
                { 
                    HiSquare(activeVariables1[1], activeVariables2[1]);
                }
                catch
                {
                    return "Исправьте Хи-квадрат!!!";
                }
            }
            if (analysis[2])
            {
                try
                {
                    TTest(activeVariables1[2], activeVariables2[2]);
                }
                catch
                {
                    return "Исправьте Т-Тест!!!";
                }
            }
            if (analysis[3])
            {
                try
                { 
                    MannWitny(activeVariables1[3], activeVariables2[3]);
                }
                catch
                {
                    return "Исправьте тест Манна-Уитни!!!";
                }
            }
            if (analysis[4])
            {
                try 
                {
                    ANOVA(activeVariables1[4], activeVariables2[4]);
                }
                catch
                {
                    return "Исправьте ANOVA!!!";
                }
            }
            if (analysis[5])
            {
                try
                { 
                    Clustering(activeVariables1[5]);
                }
                catch
                {
                    return "Исправьте кластеризацию!!!";
                }
            }
            if (analysis[7] || analysis[9])
            {
                crExl();
            }
            if (analysis[6])
            {
                Regression(activeVariables1[6], activeVariables2[6], analysis[7]);
            }
            if (analysis[8])
            {
                Correlation(activeVariables1[7], analysis[9]);
            }
            WordOutro();
            LatexOutro();
            return "Отчет создан!";
        }
        private void closeExcelDocument()
        {
            if (exapp != null) { exapp.Quit(); }
            exapp = null;
        }
        private void crExl()
        {
            closeExcelDocument();
            exapp = new Excel.Application();
            exapp.SheetsInNewWorkbook = 2;
            exbook = exapp.Workbooks.Add();
            exbook.Sheets[1].Name = "Корр. анализ";
            exbook.Sheets[2].Name = "Регр. анализ";
            exapp.Visible = true;
            exbook.SaveAs(tmpFolder + tableName);
        }
        private void RegExl(List<int> activeVariables2)
        {
            Excel.Worksheet excelws = exbook.Worksheets[2];
            Excel.Range excelcells = excelws.Cells[1, 1];
            excelcells.Value = "Коэффициент";
            excelcells = excelws.Cells[1, 2];
            excelcells.Value = "Значение";
            excelcells = excelws.Cells[1, 3];
            excelcells.Value = "P - value";
            excelcells = excelws.get_Range("A2", "C2");
            excelcells.Value = "--------";
            excelcells = excelws.Cells[3, 1];
            excelcells.Value = "(Intercept)";
            for (int l = 1; l <= activeVariables2.Count; l++)
            {
                excelcells = excelws.Cells[3 + l, 1];
                excelcells.Value = nameVars[activeVariables2[l - 1]];
            }
            for (int i = 0; i <= activeVariables2.Count; i++)
            {
                excelcells = excelws.Cells[i + 3, 2];
                excelcells.Value = excelcells.Value = engine.Evaluate("coef[rownames(coef)[" + (i + 1) + "],colnames(coef)[1]]").AsNumeric()[0];
                excelcells = excelws.Cells[i + 3, 3];
                excelcells.Value = excelcells.Value = engine.Evaluate("coef[rownames(coef)[" + (i + 1) + "],colnames(coef)[4]]").AsNumeric()[0];
            }
        }

        private void CorExl(List<int> activeVariables1)
        {

            Excel.Worksheet excelws = exbook.Worksheets[1];
            string varExName = "Имя";
            for (int j = 0; j < activeVariables1.Count; j++)
            {
                varExName = nameVars[activeVariables1[j]];
                Excel.Range excelcells = excelws.Cells[1, j + 2];
                excelcells.Value = varExName;
                excelcells = excelws.Cells[2 * (j + 2) - 2, 1];
                excelcells.Value = varExName;
            }

            for (int k = 2; k <= activeVariables1.Count + 1; k++)
                for (int l = 2; l <= activeVariables1.Count + 1; l++)
                {
                    Excel.Range excelcells = excelws.Cells[2 * k - 2, l];
                    excelcells.Value = "p. =" + Math.Round(engine.Evaluate("corP[rownames(corP)[" + (k - 1) + "],colnames(corP)[" + (l - 1) + "]]").AsNumeric()[0], 3).ToString();
                    excelcells = excelws.Cells[2 * k - 1, l];
                    excelcells.Value = "r. =" + Math.Round(engine.Evaluate("corR[rownames(corR)[" + (k - 1) + "],colnames(corR)[" + (l - 1) + "]]").AsNumeric()[0], 3).ToString();
                }
        }

        public string usingDB(string inDataSet)
        {
            connection.Close();
            engine.Initialize();
            engine.Evaluate("library(readxl)");
            engine.Evaluate("dataset <- read_excel(\"" + inDataSet + "\")");
            DataFrame dataset = engine.Evaluate("dataset").AsDataFrame();
            string conStr="";
            string pathFull = tmpFolder + "FullBD.accdb";
            conStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + pathFull + ";";
            if (File.Exists(pathFull))
            {
                File.Delete(pathFull);
            }
            connection.ConnectionString = conStr;
            ADOX.Catalog cat = new ADOX.Catalog();
            cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + pathFull + ";");
            Table fTable = new Table();
            fTable.Name = "Full";
            for (int i = 0; i < numVars; i++)
            {
                fTable.Columns.Append(nameVars[i], DataTypeEnum.adDouble);
            }
            cat.Tables.Append(fTable);
            cat = null;
            connection.Close();
            connection.Open();
            OleDbCommand commandUpd = connection.CreateCommand();
            string textQuery = "INSERT INTO [Full] (";
            for (int i = 0; i < numVars; i++)
                textQuery += nameVars[i] + ',';
            textQuery = textQuery.Substring(0, textQuery.Length - 1) + ") VALUES (";
                for (int i = 0; i < numRecords; i++)
                {
                    string subQuery ="";
                    for (int j = 0; j < numVars; j++)
                    {
                        if (!double.IsNaN((double)(dataset[i, j])))
                            subQuery += dataset[i, j].ToString() + ",";
                        else
                            subQuery += "0 ,";
                    }
                    subQuery = subQuery.Substring(0, subQuery.Length - 1) + ")";
                    commandUpd.CommandText = textQuery + subQuery;
                    commandUpd.ExecuteNonQuery();
                }
            connection.Close();

            conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathFull;
            connection.ConnectionString = conStr;
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            textQuery = "SELECT COUNT(*) FROM [Full]";
            command.CommandText = textQuery;
            string res = Convert.ToString(command.ExecuteScalar());
            connection.Close();
            return res;
        }
        public DataSet UsingQuery(string query)
        {
            string pathFull = tmpFolder + "FullBD.accdb";
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathFull;
            connection.ConnectionString = conStr;
            dataAdapter = new OleDbDataAdapter(query, connection);
            DataSet selectData = new DataSet();
            try
            {
                dataAdapter.Fill(selectData, "Full");
            }
            catch
            {

            }
            connection.Close();
            return selectData;
        }
    }
}
