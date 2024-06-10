namespace WCHS_Assignment14
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartData1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listMsgs1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chartData2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listMsgs2 = new System.Windows.Forms.ListBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.chartData3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listMsgs3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartData1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData3)).BeginInit();
            this.SuspendLayout();
            // 
            // chartData1
            // 
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.Name = "ChartArea1";
            this.chartData1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartData1.Legends.Add(legend1);
            this.chartData1.Location = new System.Drawing.Point(349, 14);
            this.chartData1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chartData1.Name = "chartData1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartData1.Series.Add(series1);
            this.chartData1.Size = new System.Drawing.Size(701, 443);
            this.chartData1.TabIndex = 0;
            this.chartData1.Text = "chart1";
            this.chartData1.Visible = false;
            this.chartData1.Click += new System.EventHandler(this.chartData_Click);
            // 
            // listMsgs1
            // 
            this.listMsgs1.FormattingEnabled = true;
            this.listMsgs1.ItemHeight = 15;
            this.listMsgs1.Location = new System.Drawing.Point(17, 483);
            this.listMsgs1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listMsgs1.Name = "listMsgs1";
            this.listMsgs1.Size = new System.Drawing.Size(1032, 244);
            this.listMsgs1.TabIndex = 2;
            this.listMsgs1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Device 1",
            "Device 2",
            "Saved Data"});
            this.comboBox1.Location = new System.Drawing.Point(41, 25);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(212, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chartData2
            // 
            chartArea2.Name = "ChartArea1";
            this.chartData2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartData2.Legends.Add(legend2);
            this.chartData2.Location = new System.Drawing.Point(349, 14);
            this.chartData2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chartData2.Name = "chartData2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartData2.Series.Add(series2);
            this.chartData2.Size = new System.Drawing.Size(701, 443);
            this.chartData2.TabIndex = 4;
            this.chartData2.Text = "chartdata2";
            this.chartData2.Visible = false;
            this.chartData2.Click += new System.EventHandler(this.chart1_Click);
            // 
            // listMsgs2
            // 
            this.listMsgs2.FormattingEnabled = true;
            this.listMsgs2.ItemHeight = 15;
            this.listMsgs2.Location = new System.Drawing.Point(17, 483);
            this.listMsgs2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listMsgs2.Name = "listMsgs2";
            this.listMsgs2.Size = new System.Drawing.Size(1032, 244);
            this.listMsgs2.TabIndex = 5;
            this.listMsgs2.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(41, 430);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 27);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "save data";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // chartData3
            // 
            chartArea3.Name = "ChartArea1";
            this.chartData3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartData3.Legends.Add(legend3);
            this.chartData3.Location = new System.Drawing.Point(349, 14);
            this.chartData3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chartData3.Name = "chartData3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartData3.Series.Add(series3);
            this.chartData3.Size = new System.Drawing.Size(701, 443);
            this.chartData3.TabIndex = 7;
            this.chartData3.Text = "Saved Data Chart";
            this.chartData3.Visible = false;
            // 
            // listMsgs3
            // 
            this.listMsgs3.FormattingEnabled = true;
            this.listMsgs3.ItemHeight = 15;
            this.listMsgs3.Location = new System.Drawing.Point(16, 483);
            this.listMsgs3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listMsgs3.Name = "listMsgs3";
            this.listMsgs3.Size = new System.Drawing.Size(1033, 244);
            this.listMsgs3.TabIndex = 8;
            this.listMsgs3.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 743);
            this.Controls.Add(this.listMsgs3);
            this.Controls.Add(this.chartData3);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.listMsgs2);
            this.Controls.Add(this.chartData2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listMsgs1);
            this.Controls.Add(this.chartData1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartData1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartData1;
        private System.Windows.Forms.ListBox listMsgs1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData2;
        private System.Windows.Forms.ListBox listMsgs2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData3;
        private System.Windows.Forms.ListBox listMsgs3;
    }
}